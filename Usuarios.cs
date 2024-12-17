using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    //Clase para guardar los datos de los usuarios
    public class Usuarios
    {
        private int id;
        private string name;
        private string cuenta;
        private string contrasena;
        private int monto;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Cuenta { get => cuenta; set => cuenta = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public int Monto { get => monto; set => monto = value; }

        public Usuarios(int id, string name, string cuenta, string contrasena, int monto)
        {
            this.id = id;
            this.name = name;
            this.cuenta = cuenta;
            this.contrasena = contrasena;
            this.monto = monto;
        }
    }
}
