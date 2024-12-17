namespace ProyectoFinal
{
    public partial class FormTienda : Form
    {

        List<Panel> paneles;    //Lista para crear los paneles de los productos
        Usuarios infoUsuario;   //para guardar los datos del usuario que ingreso
        static int cont = 0;    //se usa para mostrar los paneles
        ConexionBD mostrar = new ConexionBD();  //se crea una instancia para poder usar la base de datos
        List<Gorras> registros; //Lista para poder imprimir los datos de los productos en cada panel
        DateTime fecha = DateTime.Now;  //para ver la fecha y hora
        List<Gorras> compras;   //para registrar lo que se agregue al carrito
        static int dineroPagar; //para mostrar en pantalla la cantidad de dinero que pagara

        public static int DineroPagar { get => dineroPagar; set => dineroPagar = value; } // propiedad para guardar el valor si el usuario no paga

        public FormTienda(Usuarios datos)
        {
            //se guardan los datos del usuario
            infoUsuario = datos;
            //se inicializa la lista de compras
            compras = new List<Gorras>();
            InitializeComponent();
           

            // Configuración del Timer para la fecha yhora
            timer1.Interval = 1000;  // Intervalo de 1 segundo (1000 ms)
            timer1.Start();          // Iniciar el Timer

        }

        private void FormTienda_Load(object sender, EventArgs e)
        {
            // se muestra la fecha y el nombre del usuario
            labelFecha.Text = fecha.ToString("dd/MM/yyyy HH:mm:ss");
            labelUsuario.Text = infoUsuario.Name;
            // se crea la instancia para crear los paneles
            this.paneles = new List<Panel>();
            //actualiza los paneles cada que abre el form
            this.cargarTienda();

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            //cierra este form y abre el de inicio sesion
            this.Close();
            InicioSesion abrir = new InicioSesion();
            abrir.Show();
        }

        public void cargarTienda()
        {
            //se reinicia para que al abrir de nuevo este form, se muestren los paneles como deben de ser
            cont = 0;
            
            //se guardan los datos de la base de datos en la lista de las gorras
            this.registros = mostrar.consulta();

            // Se vuelven a crear los paneles al volver a abrir el form
            this.paneles = new List<Panel>();

            //calcular el numero de productos
            int numPaneles = this.registros.Count;
            for (int i = 0; i < numPaneles; i++)
            {
                crearPaneles(i);
                cont++;
            }
        }

        // timer para actualizar la fehca y el carrito
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            labelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            labelDinero.Text = DineroPagar.ToString();

        }

        private void crearPaneles(int i)
        {
            int vec = 90; // Variable para manejar la posición vertical
            int j = cont;
            if (i >= 5) //esto es para que despues de 5 productos, se muestren abajo los restantes
            {
                vec = 400;
                j -= 5;

            }

            //se cicla la lista de los productos usando una variable
            Gorras gorra = registros[i];

            // Crear un nuevo panel
            Panel panel = new Panel
            {
                Size = new Size(200, 250),
                AutoSize = true,
                Location = new Point(30 + (j * 237), vec), // Espaciado horizontal
                BackColor = Color.FromArgb(212, 197, 182),

                // se crea un tag para poder pasar el dato justo al evento click, osea al agregar al carrito
                Tag = registros[i]
            };

            // metodo para crear el evento click en los paneles y sus elementos
            void AsignarEventoClick(Control control, Gorras producto)
            {
                //se configura el evento click, solo cuando si hay existencias
                if (producto.Existencias > 0)
                {

                    control.Click += (sender, e) =>
                    {

                        //se agrega el producto a la lista de compras
                        compras.Add(producto);
                        //se suma el costo del producto al total a pagar
                        DineroPagar += producto.Precio;

                        MessageBox.Show($"Se agregó {producto.Nombre} al carrito.", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    //se asigna el evento click a todo lo que este dentro del panel
                    foreach (Control child in control.Controls)
                    {
                        AsignarEventoClick(child, producto); 
                    }
                }

            }

            // se crea y agrega el label para el nombre
            Label LabelNombre = new Label
            {
                Text = registros[i].Nombre,
                Size = new Size(177, 20),
                Location = new Point(10, 170), 
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            panel.Controls.Add(LabelNombre);

            // se crea el pictureBox para la imagen del producto
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(165, 150),
                Location = new Point(20, 10), 
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Intentamos obtener la imagen del recurso con el nombre almacenado en la base de datos
            string nombreImagen = registros[i].Imagen; //el nombre de la imagen tiene que ser sin extension

            try
            {
                //se usa esta linea para obtener la imagen de la carpeta de recursos con el nombre de la base de datos
                var imageResource = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(nombreImagen);


                if (registros[i].Existencias == 0) // Si el producto no tiene existencias
                {
                    pictureBox.Image = Properties.Resources.agotado;               // Muestra imagen de agotado
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.BorderStyle = BorderStyle.None;
                }
                else
                {
                    if (imageResource != null)             // Si la imagen se encuentra, se muestra
                    {
                        pictureBox.Image = imageResource;
                    }
                    else
                    {
                        pictureBox.Image = Properties.Resources.has2; // si no se encuentra se pone una predeterminada
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre algún error, asignar la imagen predeterminada
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                pictureBox.Image = Properties.Resources.has2;
            }

            panel.Controls.Add(pictureBox);

            // se hace el label para mostrar la descripcion del producto
            Label labelDescripcion = new Label
            {
                Text = registros[i].Descripcion,
                Size = new Size(177, 40),  
                Location = new Point(10, 185),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                AutoSize = false,  
                Font = new Font("Arial", 8, FontStyle.Regular),  
                MaximumSize = new Size(177, 40) 
            };

            panel.Controls.Add(labelDescripcion);

            // se crea label para mostrar las existencias
            Label labelExistencias = new Label
            {
                Text = "Existencias: " + registros[i].Existencias.ToString(), 
                Size = new Size(100, 20), // Tamaño del Label
                Location = new Point(panel.Width - 100, panel.Height - 25), 
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(labelExistencias);

            // se hace label para mostrar el precio
            Label labelPrecio = new Label
            {
                Text = "$" + registros[i].Precio.ToString(),
                Size = new Size(100, 20),
                Location = new Point(10, panel.Height - 25), 
                TextAlign = ContentAlignment.MiddleLeft, 
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Font = new Font("Arial", 12)
            };
            panel.Controls.Add(labelPrecio);

            // Agregar el evento Click al panel y todos sus hijos
            AsignarEventoClick(panel, registros[i]);

            // Agregar el panel a la lista y al formulario
            paneles.Add(panel);
            this.Controls.Add(panel);


        }


        //boton para borrar el carrito
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se eliminó el carrito de compras.", "Borrando...", MessageBoxButtons.OK);
            DineroPagar = 0;
            compras.Clear();
        }

        //boton para pagar en efectivo
        private void buttonEfectivo_Click(object sender, EventArgs e)
        {
            this.Close();
            Pagos efectivo = new Pagos(compras, infoUsuario, DineroPagar, 0);
            efectivo.Show();

        }

        //boton para pagar con tarjeta
        private void buttonTarjeta_Click(object sender, EventArgs e)
        {
            this.Close();
            Pagos efectivo = new Pagos(compras, infoUsuario, DineroPagar, 1);
            efectivo.Show();
            
        }

        //boton para pagar con oxxo
        private void buttonOxxo_Click(object sender, EventArgs e)
        {
            this.Close();
            Pagos efectivo = new Pagos(compras, infoUsuario, DineroPagar, 2);
            efectivo.Show();


           
        }

        private void labelDinero_Click(object sender, EventArgs e)
        {

        }
    }
}