namespace ProyectoFinal
{
    public partial class FormTienda : Form
    {
        List<Panel> paneles;
        Usuarios infoUsuario;
        static int cont = 0;

        public FormTienda(Usuarios datos)
        {
            infoUsuario = datos;
            InitializeComponent();
            // Configuración del formulario
            this.Text = "Paneles con Controles";
            this.Size = new Size(480, 360);

            // Crear y configurar la lista de paneles
            paneles = new List<Panel>();
            int numPaneles = 10;

            for (int i = 0; i < numPaneles; i++)
            {
                crearPaneles(i);
            }
        }

        private void FormTienda_Load(object sender, EventArgs e)
        {

        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void crearPaneles(int i)
        {
            int vec = 90; // Variable para manejar la posición vertical
            if (i >= 5)
            {
                vec = 400;
                i = cont;
                cont++;
            }

            // Crear un nuevo panel
            Panel panel = new Panel
            {
                Size = new Size(200, 230),
                Location = new Point(30 + (i * 237), vec), // Espaciado horizontal
                BackColor = Color.FromArgb(212, 197, 182)
            };

            // Método para asignar el evento Click al panel y sus controles hijos
            void AsignarEventoClick(Control control)
            {
                control.Click += (sender, e) => MessageBox.Show($"¡Hiciste clic en el panel {i + 1}!");
                foreach (Control child in control.Controls)
                {
                    AsignarEventoClick(child); // Recursivamente asignar evento a hijos
                }
            }

            // Crear y agregar el primer Label en la parte superior del panel
            Label topLabel = new Label
            {
                Text = "Encabezado",
                Size = new Size(177, 20),
                Location = new Point(10, 10), // En la parte superior del panel
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(topLabel);

            // Crear y agregar una PictureBox dentro del panel
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(177, 92),
                Location = new Point(10, 40), // Debajo del topLabel
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Image = Properties.Resources.has2, // Aquí va la imagen que viene de la base de datos
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            panel.Controls.Add(pictureBox);

            // Crear y agregar un Label justo debajo de la imagen
            Label middleLabel = new Label
            {
                Text = "Hola",
                Size = new Size(177, 20), // Tamaño del Label
                Location = new Point(10, pictureBox.Bottom + 5), // Justo debajo del PictureBox con 5px de margen
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(middleLabel);

            // Crear y agregar un nuevo Label que muestra un número, alineado a la derecha
            Label numberLabel = new Label
            {
                Text = $"{i + 1}", // Número dinámico basado en `i`
                Size = new Size(50, 20), // Tamaño del Label
                Location = new Point(panel.Width - 60, panel.Height - 25), // Esquina inferior derecha del panel
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(numberLabel);

            // Crear y agregar el Label en la parte inferior, alineado a la izquierda
            Label bottomLabel = new Label
            {
                Text = "Pie de página",
                Size = new Size(100, 20),
                Location = new Point(10, panel.Height - 25), // Alineado a la izquierda y en la parte inferior
                TextAlign = ContentAlignment.MiddleLeft, // Alineación a la izquierda
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(bottomLabel);

            // Agregar el evento Click al panel y todos sus hijos
            AsignarEventoClick(panel);

            // Agregar el panel a la lista y al formulario
            paneles.Add(panel);
            this.Controls.Add(panel);
        }





    }
}

