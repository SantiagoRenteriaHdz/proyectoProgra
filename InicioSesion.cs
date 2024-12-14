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
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            FormTienda abrir = new FormTienda();
            this.Close();
            abrir.ShowDialog();
            this.Show();

        }
    }
}
