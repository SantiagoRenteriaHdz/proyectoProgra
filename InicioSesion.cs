using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinal
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
            //para que la contrasena no se vea
            textBoxContraseña.UseSystemPasswordChar = true;
            buttonMostrar.BackgroundImage = Properties.Resources.mostrar;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            string cuenta = textBoxCuenta.Text;
            string cont = textBoxContraseña.Text;

            ConexionBD ingresar = new ConexionBD();
            //comprueba la cuenta que se ingreso
            if (ingresar.comprobarCuenta(cuenta, cont))
            {
                if(ingresar.verificarAdmin(cuenta))
                {
                    FormAdmin admin = new FormAdmin();
                    this.Hide();
                    admin.ShowDialog();
                    textBoxCuenta.Text = "";
                    textBoxContraseña.Text = "";
                    ingresar.desconectar();
                    this.Show();
                }
                else
                {

                    FormTienda usuario = new FormTienda(ingresar.datosCuenta(cuenta));
                    this.Hide();
                    usuario.ShowDialog();
                    textBoxCuenta.Text = "";
                    textBoxContraseña.Text = "";
                    ingresar.desconectar();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Cuenta o contraseña inválida.","Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ingresar.desconectar();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

    
        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            
            textBoxContraseña.UseSystemPasswordChar = !textBoxContraseña.UseSystemPasswordChar;
            buttonMostrar.BackgroundImage = textBoxContraseña.UseSystemPasswordChar ? Properties.Resources.mostrar : Properties.Resources.ocultar;

        }
    }
}
