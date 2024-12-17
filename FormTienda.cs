namespace ProyectoFinal
{
    public partial class FormTienda : Form
    {
        List<Panel> paneles;
        Usuarios infoUsuario;
        static int cont = 0;
        ConexionBD mostrar = new ConexionBD();
        List<Gorras> registros;
        DateTime fecha = DateTime.Now;
        List<Gorras> compras;
        int dineroPagar;


        public FormTienda(Usuarios datos)
        {
            //se guardan los datos del usuario
            infoUsuario = datos;
            //se inicializa la lista de compras
            compras = new List<Gorras>();
            InitializeComponent();


            // Configuraci�n del Timer para la fecha yhora
            timer1.Interval = 1000;  // Intervalo de 1 segundo (1000 ms)
            timer1.Start();          // Iniciar el Timer


        }

        private void FormTienda_Load(object sender, EventArgs e)
        {
            // Poner la fecha inicial al cargar el formulario (esto no es necesario si el Timer lo actualiza)
            labelFecha.Text = fecha.ToString("dd/MM/yyyy HH:mm:ss");
            labelUsuario.Text = infoUsuario.Name;

            registros = mostrar.consulta();



            // Crear y configurar la lista de paneles
            paneles = new List<Panel>();

            int numPaneles = registros.Count;
            for (int i = 0; i < numPaneles; i++)
            {
                crearPaneles(i);
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento Tick del Timer para actualizar la fecha cada segundo
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Actualiza el labelFecha con la fecha actual cada vez que se dispare el evento Tick
            labelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            labelDinero.Text = dineroPagar.ToString();

        }

        private void crearPaneles(int i)
        {
            int vec = 90; // Variable para manejar la posici�n vertical
            if (i >= 5)
            {
                vec = 400;
                i = cont;
                cont++;
            }

            Gorras gorra = registros[i];

            // Crear un nuevo panel
            Panel panel = new Panel
            {
                Size = new Size(200, 230),
                AutoSize = true,
                Location = new Point(30 + (i * 237), vec), // Espaciado horizontal
                BackColor = Color.FromArgb(212, 197, 182),

                // se crea un tag para poder pasar el dato justo al evento click, osea al agregar al carrito
                Tag = registros[i]
            };

            // M�todo para asignar el evento Click al panel y sus controles hijos
            void AsignarEventoClick(Control control, Gorras producto)
            {
                if (producto.Existencias > 0)
                {

                    control.Click += (sender, e) =>
                    {

                        //se agrega el producto a la lista de compras
                        compras.Add(producto);
                        dineroPagar += producto.Precio;

                        MessageBox.Show($"Se agreg� {producto.Nombre} al carrito.", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
                    foreach (Control child in control.Controls)
                    {
                        AsignarEventoClick(child, producto); // Recursivamente asignar evento a hijos
                    }
                }

            }

            // Crear y agregar el primer Label en la parte superior del panel
            Label LabelNombre = new Label
            {
                Text = registros[i].Nombre,
                Size = new Size(177, 20),
                Location = new Point(10, 10), // En la parte superior del panel
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(LabelNombre);

            // Crear y agregar una PictureBox dentro del panel
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(177, 92),
                Location = new Point(10, 40), // Debajo del topLabel
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Intentamos obtener la imagen del recurso con el nombre almacenado en la base de datos
            string nombreImagen = registros[i].Imagen; // Aqu� supongo que Imagen es el nombre del recurso sin la extensi�n

            try
            {
                // Usar Reflection para obtener el recurso de imagen desde los recursos del proyecto
                var imageResource = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(nombreImagen);


                if (registros[i].Existencias == 0) // Si el producto no tiene existencias
                {
                    pictureBox.Image = Properties.Resources.agotado;               // Muestra que esta agotado
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.BorderStyle = BorderStyle.None;
                }
                else
                {
                    if (imageResource != null)             // Si la imagen se encuentra
                    {
                        pictureBox.Image = imageResource;
                    }
                    else
                    {
                        pictureBox.Image = Properties.Resources.has2; // Imagen predeterminada
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre alg�n error, asignar la imagen predeterminada
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                pictureBox.Image = Properties.Resources.has2;
            }

            panel.Controls.Add(pictureBox);

            // Crear y agregar un Label justo debajo de la imagen
            Label labelDescripcion = new Label
            {
                Text = registros[i].Descripcion,
                Size = new Size(177, 20),
                Location = new Point(10, pictureBox.Bottom + 5),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(labelDescripcion);

            // Crear y agregar un nuevo Label que muestra un n�mero, alineado a la derecha
            Label labelExistencias = new Label
            {
                Text = "Existencias: " + registros[i].Existencias.ToString(), // N�mero din�mico basado en i
                Size = new Size(100, 20), // Tama�o del Label
                Location = new Point(panel.Width - 100, panel.Height - 25), // Esquina inferior derecha del panel
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(labelExistencias);

            // Crear y agregar el Label en la parte inferior, alineado a la izquierda
            Label labelPrecio = new Label
            {
                Text = "$" + registros[i].Precio.ToString(),
                Size = new Size(100, 20),
                Location = new Point(10, panel.Height - 25), // Alineado a la izquierda y en la parte inferior
                TextAlign = ContentAlignment.MiddleLeft, // Alineaci�n a la izquierda
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(labelPrecio);

            // Agregar el evento Click al panel y todos sus hijos
            AsignarEventoClick(panel, registros[i]);

            // Agregar el panel a la lista y al formulario
            paneles.Add(panel);
            this.Controls.Add(panel);


        }



        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se elimin� el carrito de compras.", "Borrando...", MessageBoxButtons.OK);
            dineroPagar = 0;
            compras.Clear();
        }

        private void buttonEfectivo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pagos efectivo = new Pagos(compras, infoUsuario, dineroPagar, 0);
            efectivo.ShowDialog();

            this.Show();
        }

        private void buttonTarjeta_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pagos efectivo = new Pagos(compras, infoUsuario, dineroPagar, 1);
            efectivo.ShowDialog();

            this.Show();
        }

        private void buttonOxxo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pagos efectivo = new Pagos(compras, infoUsuario, dineroPagar, 2);
            efectivo.ShowDialog();


            this.Show();
        }


    }
}