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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProyectoFinal
{
    public partial class Pagos : Form
    {
        int totProductos = 0;
        List<Gorras> gorras;
        Usuarios comprador;
        int pago;
        double pagoTot;
        double impuesto;
        int tipoPago;


        public Pagos(List<Gorras> productos, Usuarios usuario, int pago, int tipo)
        {
            totProductos = productos.Count;
            this.pago = pago;
            gorras = productos;
            comprador = usuario;
            impuesto = pago * .06;
            pagoTot = pago + impuesto;
            InitializeComponent();
            tipoPago = tipo;
            tipodePago(tipoPago);


        }

        private void Pagos_Load(object sender, EventArgs e)
        {
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

            labelPago.Text = "Pago: " + pago;
            labelTotproductos.Text = "Cantidad de productos: " + totProductos;
            labelImpuesto.Text = "6% de impuesto: " + impuesto;
            labelTotPago.Text = "Total a pagar: " + pagoTot;
            tipodePago(tipoPago);
        }

        private void tipodePago(int tipoPago)
        {
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


        private void pictureBoxQR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pago realizado.", "Gracias por su compra.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //cambios en bd
            ConexionBD modificar = new ConexionBD();

            int agregado = (int)pagoTot;
            // Actualizar el monto del comprador
            modificar.actualizarMontoUsuario(comprador.Id, comprador.Monto + agregado); // Asumiendo que "comprador.Monto" es el saldo actual del usuario

            // Actualizar existencias de los productos comprados
            foreach (var gorra in gorras)
            {
                int nuevaExistencia = gorra.Existencias - 1; // Restamos 1 por cada gorra comprada
                modificar.actualizarProducto(gorra.Id, gorra.Nombre, nuevaExistencia, gorra.Descripcion, gorra.Precio, gorra.Imagen); // Actualizamos la base de datos con la nueva existencia
            }

            //se hace la nota
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

        //funcion para capturar la nota

        Bitmap CapturarFormulario(Form formulario, Rectangle region)
        {
            // Crear un bitmap con el tamaño del formulario
            Bitmap captura = new Bitmap(region.Width, region.Height);

            // Dibujar el formulario en el bitmap
            formulario.DrawToBitmap(captura, region);

            return captura;
        }

        //se manda la captura de la nota a un pdf
        void ExportarFormularioAPDF(Form formulario, string rutaArchivo)
        {

            // Asegurarse de que el formulario esté en primer plano
            formulario.BringToFront();

            // Actualizar el formulario para asegurarse de que se dibuje correctamente
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

            // Crear un nuevo documento PDF
            PdfDocument documento = new PdfDocument();
            PdfPage pagina = documento.AddPage();

            // Configurar el tamaño de la página del PDF según la imagen capturada
            pagina.Width = XUnit.FromPoint(captura.Width * 0.75f);  // Escalar según el DPI
            pagina.Height = XUnit.FromPoint(captura.Height * 0.75f);

            // Convertir la imagen Bitmap a un MemoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                captura.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); // Guardar como PNG
                memoryStream.Position = 0; // Asegúrate de posicionarte al principio del stream

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

        private void buttonPagar_Click_1(object sender, EventArgs e)
        {
            double recibido;
            double.TryParse(textBoxRecibido.Text, out recibido);

            if (recibido < pagoTot)
            {
                MessageBox.Show("Monto inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double cambio;
                cambio = recibido - pagoTot;
                cambio = Math.Round(cambio);
                MessageBox.Show("Tu cambio es: $" + cambio, "Gracias por su compra", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cambios en bd
                ConexionBD modificar = new ConexionBD();

                int agregado = (int)pagoTot;
                // Actualizar el monto del comprador
                modificar.actualizarMontoUsuario(comprador.Id, comprador.Monto + agregado); // Asumiendo que "comprador.Monto" es el saldo actual del usuario

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
            int i;
            tarjeta = textBoxTarjeta.Text;
            i = tarjeta.Length;
            string fecha = textBoxFecha.Text;
            int fechaValida = fecha.Length;
            string cvv = textBoxCvv.Text;
            int cvvValido = cvv.Length;

            if (i != 16)
            {
                MessageBox.Show("Introduce una tarjeta válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (fechaValida != 5)
            {
                MessageBox.Show("Introduce una fecha válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cvvValido != 3)
            {
                MessageBox.Show("Introduce un CVV válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Pago realizado.", "Gracias por su compra.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cambios en BD (actualización de monto del usuario y existencias de productos)
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

                // Después de todo esto, cerramos el formulario actual y mostramos de nuevo la tienda
                this.Close();

                // Cerrar el formulario Pagos y reabrir el formulario FormTienda con los datos actualizados
                FormTienda abrirTienda = new FormTienda(comprador); // Pasamos los datos del usuario
                FormTienda.DineroPagar = 0;
                abrirTienda.cargarTienda();
                abrirTienda.Show(); // Mostramos la tienda
            }
        }


        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FormTienda abrirTienda = new FormTienda(comprador); // Pasamos los datos del usuario
            abrirTienda.Show(); // Mostramos la tienda
        }
    }
}
