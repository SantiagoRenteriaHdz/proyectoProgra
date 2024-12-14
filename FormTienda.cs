namespace ProyectoFinal
{
    public partial class FormTienda : Form
    {
        private List<Panel> paneles;
        public FormTienda()
        {
            InitializeComponent();
            // Configuración del formulario
            this.Text = "Paneles con Controles";
            this.Size = new Size(800, 600);

            // Crear y configurar la lista de paneles
            paneles = new List<Panel>();
            int numPaneles = 4;

            for (int i = 0; i < numPaneles; i++)
            {
                // Crear un nuevo panel
                Panel panel = new Panel
                {
                    Size = new Size(300, 300),
                    Location = new Point(50 + (i * 320), 50), // Espaciado horizontal
                    BackColor = Color.FromArgb(50 * i, 100, 150) // Colores distintos
                };

                // Crear y agregar una PictureBox dentro del panel
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(200, 140),
                    Location = new Point(50, 20),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = Properties.Resources.has2,// aqui va la imagen que viene de la base de datos // Usa una imagen del proyecto o pon null
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                panel.Controls.Add(pictureBox);

                // Crear y agregar un botón dentro del panel
                Button button = new Button
                {
                    Text = $"Botón {i + 1}",
                    Size = new Size(200, 60),
                    Location = new Point(50, 180)
                };
                button.Click += (sender, e) => MessageBox.Show($"¡Hiciste clic en el botón {i + 1}!");
                panel.Controls.Add(button);

                // Agregar el panel a la lista y al formulario
                paneles.Add(panel);
                this.Controls.Add(panel);
            }
        }

        private void FormTienda_Load(object sender, EventArgs e)
        {

        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}

