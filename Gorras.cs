using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Gorras
    {
        private int id;
        private string nombre;
        private int existencias;
        private string descripcion;
        private int precio;
        private string imagen;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Existencias { get => existencias; set => existencias = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Imagen { get => imagen; set => imagen = value; }

        public Gorras(int id, string nombre, int existencias, string descripcion, int precio, string imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.existencias = existencias;
            this.descripcion = descripcion;
            this.precio = precio;
            this.imagen = imagen;
        }
    }
}
