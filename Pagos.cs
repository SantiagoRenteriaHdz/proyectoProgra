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

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gorras;

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

        }

        //funcion para capturar la nota

        Bitmap CapturarFormulario(Form formulario)
        {
            // Crear un bitmap con el tamaño del formulario
            Bitmap captura = new Bitmap(formulario.Width, formulario.Height);

            // Dibujar el formulario en el bitmap
            formulario.DrawToBitmap(captura, new Rectangle(0, 0, formulario.Width, formulario.Height));

            return captura;
        }

        //se manda la captura de la nota a un pdf
        void ExportarFormularioAPDF(Form formulario, string rutaArchivo)
        {
            // Capturar el formulario como imagen
            Bitmap captura = CapturarFormulario(formulario);

            // Crear un nuevo documento PDF
            PdfDocument documento = new PdfDocument();
            PdfPage pagina = documento.AddPage();

            // Configurar las dimensiones de la página PDF en base a la imagen capturada
            pagina.Width = XUnit.FromPoint(captura.Width * 0.75); // 0.75 para ajustar la relación DPI (96 DPI a 72 DPI)
            pagina.Height = XUnit.FromPoint(captura.Height * 0.75);

            // Convertir la imagen Bitmap a un MemoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                captura.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); // Guarda la imagen en formato PNG en el MemoryStream
                memoryStream.Position = 0; // Asegúrate de posicionarte al principio del stream

                // Crear un objeto XImage desde el flujo de memoria
                using (XGraphics gfx = XGraphics.FromPdfPage(pagina))
                {
                    XImage imagen = XImage.FromStream(memoryStream); // Usar FromStream en lugar de FromGdiPlusImage
                    gfx.DrawImage(imagen, 0, 0, pagina.Width, pagina.Height); // Dibujar la imagen en la página PDF
                }
            }

            // Guardar el archivo PDF
            documento.Save(rutaArchivo);

            // Confirmación
            MessageBox.Show("Archivo PDF generado exitosamente.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                //cambiar los datos en bd gorras


                this.Close();
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
                MessageBox.Show("Introduce un cvv válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
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

            }
        }
    }
}
