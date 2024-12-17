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
                //revisa si la cuenta es del administrador o de un usuario normal
                if(ingresar.verificarAdmin(cuenta))
                {
                    //abre el form del admin y reinicia los valores de este form para cuando se vuelva a abrir
                    FormAdmin admin = new FormAdmin();
                    MessageBox.Show("Bienvenido administrador!!", "Ingresando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    admin.ShowDialog();
                    textBoxCuenta.Text = "";
                    textBoxContraseña.Text = "";
                    ingresar.desconectar();
                    this.Show();
                }
                else
                {
                    //abre la tienda y reinicia los valores de este form
                    FormTienda usuario = new FormTienda(ingresar.datosCuenta(cuenta));
                    MessageBox.Show("Bienvenido a Urban Rodeo!!", "Ingresando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    usuario.Show();
                    textBoxCuenta.Text = "";
                    textBoxContraseña.Text = "";
                    ingresar.desconectar();
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
            //cambia la imagen del boton y la propiedad para ver el texto de la contrasena
            textBoxContraseña.UseSystemPasswordChar = !textBoxContraseña.UseSystemPasswordChar;
            buttonMostrar.BackgroundImage = textBoxContraseña.UseSystemPasswordChar ? Properties.Resources.mostrar : Properties.Resources.ocultar;

        }
    }
}
