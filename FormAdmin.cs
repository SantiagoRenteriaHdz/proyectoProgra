﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace ProyectoFinal
{
    public partial class FormAdmin : Form
    {
        List<Gorras> registros; //se usa para guardar los datos de los productos de la base de datos
        private bool mostrarGrafica = false;
        int montoTotal = 0;     //se usa para calcular el total de ventas

        public FormAdmin()
        {
            ConexionBD ventas = new ConexionBD();
            montoTotal = ventas.ventasTotales();
            InitializeComponent();
            labelVentas.Text = "Las ventas totales son: $" + montoTotal.ToString();


        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAltas_Click(object sender, EventArgs e)
        {
            int id;
            string nombre;
            int existencias;
            string descripcion;
            int precio;
            string imagen;

            //comprueba que haya menos de 10 registros
            if (registros.Count >= 10)
            {
                MessageBox.Show("No puedes agregar mas productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                id = Convert.ToInt32(this.textBoxId.Text);
                nombre = this.textBoxNombre.Text;
                existencias = Convert.ToInt32(this.textBoxExistencias.Text);
                descripcion = this.textBoxDescripcion.Text;
                precio = Convert.ToInt32(this.textBoxPrecio.Text);
                imagen = this.textBoxImagen.Text;

                ConexionBD altas = new ConexionBD();
                altas.agregar(id, nombre, existencias, descripcion, precio, imagen);
                altas.desconectar();

                textBoxId.Text = "";
                textBoxNombre.Text = "";
                textBoxExistencias.Text = "";
                textBoxDescripcion.Text = "";
                textBoxPrecio.Text = "";
                textBoxImagen.Text = "";
                actualizarInfo();
            }

        }

        private void buttonBajas_Click(object sender, EventArgs e)
        {
            int eliminar;

            //comprueba que haya minimo 6 productos
            if (registros.Count <= 6)
            {
                MessageBox.Show("No puedes eliminar mas productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                eliminar = Convert.ToInt32(this.textBoxId.Text);
                ConexionBD bajas = new ConexionBD();
                bajas.eliminar(eliminar);
                bajas.desconectar();

                textBoxId.Text = "";
                textBoxNombre.Text = "";
                textBoxExistencias.Text = "";
                textBoxDescripcion.Text = "";
                textBoxPrecio.Text = "";
                textBoxImagen.Text = "";
                actualizarInfo();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //se usa para que el data grid se actualice siempre
            actualizarInfo();

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //se actualiza la informacion al abrir el form
            actualizarInfo();
            //muestra todo menos la grafica pero si la crea
            dataGridView1.Visible = true;
            labelLista.Visible = true;
            formsPlot1.Visible = false;
            crearGrafica(registros);


            


        }

        //metodo para actualizar los datos de los productos en el data grid
        private void actualizarInfo()
        {

            ConexionBD mostrar = new ConexionBD();

            registros = mostrar.consulta();

            mostrar.desconectar();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = registros;

            crearGrafica(registros);
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        //boton para activar la grafica
        private void buttonGrafica_Click(object sender, EventArgs e)
        {
            if (mostrarGrafica)
            {
                dataGridView1.Visible = false;
                labelLista.Visible = false;

                //mostrar grafica
                formsPlot1.Visible = true;
            }
            else
            {
                dataGridView1.Visible = true;
                labelLista.Visible = true;

                //ocultar grafica
                formsPlot1.Visible = false;
            }

            mostrarGrafica = !mostrarGrafica;
        }

        //metodo para crear la grafica
        private void crearGrafica(List<Gorras> registros)
        {
            
            formsPlot1.Plot.Clear();

            
            for (int i = 0; i < registros.Count; i++)
            {
                // Se agrega una barra por cada gorra
                formsPlot1.Plot.Add.Bar(position: i + 1, value: registros[i].Existencias, error: 0); 
            }

            // Crear los ticks con los nombres de las gorras
            ScottPlot.Tick[] ticks = registros
                .Select((gorra, index) => new ScottPlot.Tick(index + 1, gorra.Id.ToString()))  // Asociar cada id de gorra con su posición
                .ToArray();

            // Establecer los ticks en el eje X
            formsPlot1.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // Establecer el estilo de los ticks del eje X (por ejemplo, sin marcas en los ticks)
            formsPlot1.Plot.Axes.Bottom.MajorTickStyle.Length = 0;

            // Ocultar la cuadrícula (si lo deseas)
            formsPlot1.Plot.HideGrid();

            // Establecer márgenes en el eje Y
            formsPlot1.Plot.Axes.Margins(bottom: 0);

            //se configura el texto de la grafica
            formsPlot1.Plot.Title("Existencias por producto.");
            formsPlot1.Plot.XLabel("Productos.");
            formsPlot1.Plot.YLabel("Existencias.");

            // Refrescar para mostrar la gráfica
            formsPlot1.Refresh();
        }


    }
}
