using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class FormPortada : Form
    {
        public FormPortada()
        {
            InitializeComponent();
            labelFecha.Text = DateTime.Now.ToString("d");
        }

        private void FormPortada_Load(object sender, EventArgs e)
        {

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            InicioSesion abrir = new InicioSesion();
            this.Hide();
            abrir.ShowDialog();
            
        }
    }
}
