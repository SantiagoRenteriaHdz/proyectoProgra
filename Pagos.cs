using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using QRCoder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProyectoFinal
{
    public partial class Pagos : Form
    {
        int totProductos = 0;   //variable para guardar los productos que se van a pagar
        List<Gorras> gorras;    //se usa para guardar los datos de los productos que se van a comprar
        Usuarios comprador;     //se guardan los datos del comprador, para agregar el monto y para cuando se regrese a la otra pantalla
        int pago;               //variable para el pago sin impuestos
        double pagoTot;         //variable para el pago con impuestos
        double impuesto;        //variable para calcular el impuesto
        int tipoPago;           //variable para saber el metodo pago


        public Pagos(List<Gorras> productos, Usuarios usuario, int pago, int tipo)
        {
            //se calcula el total de productos con la lista que se recibe
            totProductos = productos.Count;
            this.pago = pago;
            //se pasa la lista de gorras que va a pagar
            gorras = productos;
            //se pasan los datos del comprador
            comprador = usuario;
            //se calcula el impuesto
            impuesto = pago * .06;
            //se calcula el total a pagar
            pagoTot = pago + impuesto;
            InitializeComponent();
            tipoPago = tipo;
            //se muestra lo necesario segun el tipo de pago
            tipodePago(tipoPago);

            if (tipoPago == 2)
            {
                GenerarCodigoQR("Cantidad a pagar: " + pagoTot.ToString("F2") + "\nPase a pagar a su Oxxo mas cercano");
            }

        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            //se muestra la fecha y la hora normal
            labelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Limpiar las columnas y filas del DataGridView
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Agregar solo las columnas que necesitas
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Precio", "Precio");


            // Llenar las filas solo con los datos que quieres mostrar
            foreach (var producto in gorras)
            {
                dataGridView1.Rows.Add(producto.Id, producto.Nombre, producto.Precio);
            }

            //se muestran los datos que se piden
            labelPago.Text = "Pago: " + pago;
            labelTotproductos.Text = "Cantidad de productos: " + totProductos;
            labelImpuesto.Text = "6% de impuesto: " + impuesto;
            labelTotPago.Text = "Total a pagar: " + pagoTot;
            tipodePago(tipoPago);
        }

        private void tipodePago(int tipoPago)
        {
            //se muestra solo lo necesario segun el tipo de pago
            switch (tipoPago)
            {
                case 0: //efectivo
                    groupBoxEfectivo.Visible = true;
                    groupBoxTarjeta.Visible = false;
                    groupBoxOxxo.Visible = false;
                    break;

                case 1: //tarjeta
                    groupBoxEfectivo.Visible = false;
                    groupBoxTarjeta.Visible = true;
                    groupBoxOxxo.Visible = false;
                    break;

                case 2: //oxxo
                    groupBoxEfectivo.Visible = false;
                    groupBoxTarjeta.Visible = false;
                    groupBoxOxxo.Visible = true;
                    break;




            }
        }


        //se crea el evento click para el qr
        private void pictureBoxQR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pago realizado.", "Gracias por su compra.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //cambios en bd
            ConexionBD modificar = new ConexionBD();

            //se hace cast a la variable del pago total
            int agregado = (int)pagoTot;

            // Actualizar el monto del comprador
            modificar.actualizarMontoUsuario(comprador.Id, comprador.Monto + agregado);

            // Actualizar existencias de los productos comprados
            foreach (var gorra in gorras)
            {
                int nuevaExistencia = gorra.Existencias - 1; // Restamos 1 por cada gorra comprada
                modificar.actualizarProducto(gorra.Id, gorra.Nombre, nuevaExistencia, gorra.Descripcion, gorra.Precio, gorra.Imagen); // Actualizamos la base de datos con la nueva existencia
            }


            //se la instancia de la interfaz para guardar el archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Guardar archivo PDF"
            };

            //si se abre la interfaz,  se manda llamar la funcion para crear la imagen de la nota
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportarFormularioAPDF(this, saveFileDialog.FileName); //se manda el formulario actual y la ruta que el usuario haya elegido para guardar
            }

            this.Close();

            // Cerrar el formulario Pagos y reabrir el formulario FormTienda con los datos actualizados
            FormTienda abrirTienda = new FormTienda(comprador); // Pasamos los datos del usuario
            FormTienda.DineroPagar = 0;
            abrirTienda.cargarTienda();
            abrirTienda.Show(); // Mostramos la tienda

        }

       

        //se manda la captura de la nota a un pdf
        void ExportarFormularioAPDF(Form formulario, string rutaArchivo)
        {

            // se pone el form al frente, para que en la captura solo se vea el form
            formulario.BringToFront();

            //se actualiza el form para que se vea la informacion actualizada
            formulario.Invalidate();
            formulario.Update();


            // Definir el rectángulo que representa el área del GroupBox
            Rectangle areaDeCaptura = new Rectangle(
                groupBox1.Location.X - formulario.AutoScrollPosition.X,  // Restar el desplazamiento horizontal
                groupBox1.Location.Y - formulario.AutoScrollPosition.Y,  // Restar el desplazamiento vertical
                groupBox1.Width,  // Ancho del GroupBox
                groupBox1.Height  // Alto del GroupBox
            );

            // Crear un Bitmap con el tamaño del área de captura
            Bitmap captura = new Bitmap(areaDeCaptura.Width, areaDeCaptura.Height);

            // Capturar la parte del formulario correspondiente al GroupBox
            using (Graphics g = Graphics.FromImage(captura))
            {
                g.CopyFromScreen(
                    formulario.PointToScreen(areaDeCaptura.Location), // Ubicación del GroupBox en la pantalla
                    new Point(0, 0),  // Dónde se dibujará la captura en el Bitmap
                    areaDeCaptura.Size // Tamaño del área a capturar
                );
            }

            // se crea una instancia para el documento pdf
            PdfDocument documento = new PdfDocument();
            PdfPage pagina = documento.AddPage();

            // Configurar el tamaño de la página del PDF según la imagen capturada
            pagina.Width = XUnit.FromPoint(captura.Width * 0.75f);
            pagina.Height = XUnit.FromPoint(captura.Height * 0.75f);

            // Convertir la imagen Bitmap a un MemoryStream para poder maniobrar con la imagen de la nota
            using (MemoryStream memoryStream = new MemoryStream())
            {
                captura.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); // Guardar como PNG
                memoryStream.Position = 0; 

                // Crear un objeto XImage desde el flujo de memoria
                using (XGraphics gfx = XGraphics.FromPdfPage(pagina))
                {
                    XImage imagen = XImage.FromStream(memoryStream); // Usar el stream para obtener la imagen
                    gfx.DrawImage(imagen, 0, 0, pagina.Width, pagina.Height); // Dibujar la imagen en la página del PDF
                }
            }

            // Guardar el archivo PDF
            documento.Save(rutaArchivo);
        }


        //boton para pagar en efectivo
        private void buttonPagar_Click_1(object sender, EventArgs e)
        {
            //se crea la variable del dinero que se recibe
            double recibido;

            //se pasa a double el dinero recibido
            double.TryParse(textBoxRecibido.Text, out recibido);

            //si el dinero recibido es menor a lo que debe pagar, manda un error
            if (recibido < pagoTot)
            {
                MessageBox.Show("Monto inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //variable para mostrar el cambio
                double cambio;
                //se calcula el cambio
                cambio = recibido - pagoTot;
                //se redondea el cambio
                cambio = Math.Round(cambio);
                MessageBox.Show("Tu cambio es: $" + cambio, "Gracias por su compra", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cambios en bd
                ConexionBD modificar = new ConexionBD();

                int agregado = (int)pagoTot;

                // Actualizar el monto del comprador
                modificar.actualizarMontoUsuario(comprador.Id, comprador.Monto + agregado);

                // Actualizar existencias de los productos comprados
                foreach (var gorra in gorras)
                {
                    int nuevaExistencia = gorra.Existencias - 1; // Restamos 1 por cada gorra comprada
                    modificar.actualizarProducto(gorra.Id, gorra.Nombre, nuevaExistencia, gorra.Descripcion, gorra.Precio, gorra.Imagen); // Actualizamos la base de datos con la nueva existencia
                }

                //implementar nota
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    Title = "Guardar archivo PDF"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarFormularioAPDF(this, saveFileDialog.FileName); // Exportar el formulario actual
                }




                this.Close();

                // Cerrar el formulario Pagos y reabrir el formulario FormTienda con los datos actualizados
                FormTienda abrirTienda = new FormTienda(comprador); // Pasamos los datos del usuario
                FormTienda.DineroPagar = 0;
                abrirTienda.cargarTienda();
                abrirTienda.Show(); // Mostramos la tienda
            }
        }

        private void buttonPagoTarjeta_Click_1(object sender, EventArgs e)
        {
            string tarjeta;
            //se usa para calcular los digitos de la tarjeta
            int i;
            tarjeta = textBoxTarjeta.Text;
            i = tarjeta.Length;
            string fecha = textBoxFecha.Text;
            //se usa para ver si puso una fecha valida
            int fechaValida = fecha.Length;
            string cvv = textBoxCvv.Text;
            //se usa para saber si puso un cvv valido
            int cvvValido = cvv.Length;

            //se verifica que la tarjeta tenga 16 digitos
            if (i != 16)
            {
                MessageBox.Show("Introduce una tarjeta válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //se verifica la fecha
            else if (fechaValida != 5)
            {
                MessageBox.Show("Introduce una fecha válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //se verifica el cvv
            else if (cvvValido != 3)
            {
                MessageBox.Show("Introduce un CVV válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Pago realizado.", "Gracias por su compra.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cambios en BD 
                ConexionBD modificar = new ConexionBD();
                int agregado = (int)pagoTot;

                // Actualizar el monto del comprador
                modificar.actualizarMontoUsuario(comprador.Id, comprador.Monto + agregado);

                // Actualizar existencias de los productos comprados
                foreach (var gorra in gorras)
                {
                    int nuevaExistencia = gorra.Existencias - 1; // Restamos 1 por cada gorra comprada
                    modificar.actualizarProducto(gorra.Id, gorra.Nombre, nuevaExistencia, gorra.Descripcion, gorra.Precio, gorra.Imagen);
                }

                // Se genera el PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    Title = "Guardar archivo PDF"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarFormularioAPDF(this, saveFileDialog.FileName); // Exportar el formulario actual como PDF
                }

                // Se cierra el form y se muestra el de la tienda
                this.Close();

                FormTienda abrirTienda = new FormTienda(comprador); // Pasamos los datos del usuario
                FormTienda.DineroPagar = 0;
                abrirTienda.cargarTienda();
                abrirTienda.Show(); // Mostramos la tienda
            }
        }

        private void GenerarCodigoQR(string textoQR)
        {
            // Crear el generador de código QR
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // Crear el objeto QRCode con los datos generados
            QRCode qrCode = new QRCode(qrGenerator.CreateQrCode(textoQR, QRCodeGenerator.ECCLevel.Q));

            // Convertir el código QR a una imagen Bitmap
            Bitmap qrCodeImage = qrCode.GetGraphic(10); 

            // Asignar la imagen generada al PictureBox
         
            pictureBoxQR.Image = qrCodeImage;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {


        }

        //boton para cancelar el pago
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FormTienda abrirTienda = new FormTienda(comprador); // Pasamos los datos del usuario
            abrirTienda.Show(); // Mostramos la tienda
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
