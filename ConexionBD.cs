using System;
using System.Drawing.Text;
using MySql.Data.MySqlClient;
using ProyectoFinal;
public class ConexionBD
{
    private MySqlConnection conexion;
    bool admin = false;
    

    public ConexionBD()
	{
		this.conectar();
	}

	public void conectar()
	{
		string connection = "Server=localhost;Database=tienda;User=root; Password=; SslMode=none;";
		try
		{
			conexion = new MySqlConnection(connection);
			conexion.Open();
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Error con la base de datos : {ex.Message}", "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

	}

	public void desconectar()
	{
		if(conexion != null && conexion.State == System.Data.ConnectionState.Open)
		{
			conexion.Close();
		}
	}

    //ingreso a una cuenta
    public bool comprobarCuenta(string cuenta, string contrasena)
    {
        bool existe = false;
        string query = "SELECT COUNT(*) FROM usuarios WHERE cuenta = '" + cuenta + "' AND contraseña = '" + contrasena + "'";

        try
        {
            MySqlCommand command = new MySqlCommand(query, conexion);
            int existente = Convert.ToInt32(command.ExecuteScalar());

            if (existente > 0)
            {
                existe = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al comprobar la cuenta o contraseña." + ex.Message);
        }
        return existe;

    }

    //verificar si la cuenta es el admin o no
    public bool verificarAdmin(string cuenta)
    {
        if(cuenta == "admin")
        {
            admin = true;
        }
        else
        {
            admin = false;
        }
        return admin;
    }

    //guardar los datos de la cuenta
    public Usuarios datosCuenta(string cuenta)
    {
        Usuarios datos = null;
        int id;
        string nombre;
        string account = cuenta;
        string contrasena;
        int monto;

        try
        {
            string query = "SELECT * FROM usuarios where cuenta='" + account + "';";
            MySqlCommand command = new MySqlCommand(query, conexion);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
                nombre = Convert.ToString(reader["nombre completo"]) ?? "";
                contrasena = Convert.ToString(reader["contraseña"]) ?? "";
                monto = Convert.ToInt32(reader["monto"]);

                datos = new Usuarios(id, nombre, account, contrasena, monto);
            }
            reader.Close();

        }
        catch(Exception ex)
        {
            MessageBox.Show("Error al leer datos de cuenta: " + ex.Message);
            this.desconectar();
        }
        return datos;
    }

    //metodos para el admin
    //Consulta de datos
    public List<Gorras> consulta()
    {
        List<Gorras> info = new List<Gorras>();
        Gorras registro;
        int id;
        string nombre;
        int existencias;
        string descripcion;
        int precio;
        string imagen;
        try
        {
            string query = "SELECT * FROM gorras ORDER BY existencias ASC";
            MySqlCommand command = new MySqlCommand(query, this.conexion);


            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                id = Convert.ToInt32(reader["id"]);
                nombre = Convert.ToString(reader["nombre"]) ?? "";
                existencias = Convert.ToInt32(reader["existencias"]);
                descripcion = Convert.ToString(reader["descripcion"]) ?? "";
                precio = Convert.ToInt32(reader["precio"]);
                imagen = Convert.ToString(reader["imagen"]) ?? "";

                registro = new Gorras(id, nombre, existencias, descripcion, precio, imagen);
                info.Add(registro);

            }
            reader.Close();


        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al leer la tabla de la base de datos: " + ex.Message);
            this.desconectar();
        }
        return info;
    }

    //agregar un regisro
    public void agregar(int id, string nombre, int existencias, string descripcion, int precio, string imagen)
    {
        string query = "";
        try
        {
            query = "INSERT INTO gorras (id, nombre, existencias, descripcion, precio, imagen) VALUES ("
                + "'" + id + "',"
                + "'" + nombre + "',"
                + "'" + existencias + "',"
                + "'" + descripcion + "',"
                + "'" + precio + "',"
                + "'" + imagen + "')";

            MySqlCommand command = new MySqlCommand(query, conexion);
            command.ExecuteNonQuery();
            MessageBox.Show(query + "\nSe agrego exitosamente.");

        }
        catch (Exception ex)
        {
            MessageBox.Show(query + "Este id ya existe" + ex.Message);
            this.desconectar();
        }

    }

    //eliminar un registro
    public void eliminar(int eliminar)
    {
        string query = "";
        try
        {
            // Consulta para obtener los datos del registro antes de eliminarlo
            query = "SELECT * FROM gorras WHERE id = " + eliminar + ";";

            MySqlCommand cmdSelect = new MySqlCommand(query, conexion);
            MySqlDataReader reader = cmdSelect.ExecuteReader();

            if (reader.Read()) // Si encuentra un registro
            {
                // Obtener los datos del registro
                string nombre = reader["nombre"].ToString();
                string existencias = reader["existencias"].ToString();
                string descripcion = reader["descripcion"].ToString();
                string precio = reader["precio"].ToString();
                string imagen = reader["imagen"].ToString();

                // Mostrar todos los datos al usuario antes de eliminar
                MessageBox.Show("Datos del registro a eliminar:\n" +
                                "Nombre: " + nombre + "\n" +
                                "Existencias: " + existencias + "\n" +
                                "Descripción: " + descripcion + "\n" +
                                "Precio: " + precio + "\n" +
                                "Imagen: " + imagen);
            }
            else
            {
                MessageBox.Show("No se encontró el registro con id: " + eliminar);
                return; // Si no se encuentra el registro, no procedemos a eliminar
            }

            reader.Close(); // Cerrar el reader después de usarlo

            // Ahora, proceder a eliminar el registro
            query = "DELETE FROM gorras WHERE id=" + eliminar + ";";
            MySqlCommand cmdDelete = new MySqlCommand(query, conexion);
            cmdDelete.ExecuteNonQuery();

            // Confirmar que el registro ha sido eliminado
            MessageBox.Show("Registro con ID " + eliminar + " eliminado correctamente.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            this.desconectar();
        }
    }

    public int ventasTotales()
    {
        
        int montoTotal=0;
        int monto;
        
        try
        {
            string query = "SELECT * FROM usuarios;";
            MySqlCommand command = new MySqlCommand(query, this.conexion);


            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                monto = Convert.ToInt32(reader["monto"]);
                montoTotal += monto;
                

            }
            reader.Close();


        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al calcular las ventas totales: " + ex.Message);
            this.desconectar();
        }
        return montoTotal;
    }

    public void actualizarProducto(int id, string nombre, int nuevaExistencia, string descripcion,int precio, string imagen)
    {
        try
        {
            //  Obtener las existencias actuales
            string querySelect = "SELECT existencias FROM gorras WHERE id = '" + id + "';";
            MySqlCommand cmdSelect = new MySqlCommand(querySelect, conexion);

            int existenciasActuales = 0;
            using (MySqlDataReader reader = cmdSelect.ExecuteReader())
            {
                if (reader.Read())
                {
                    existenciasActuales = reader.GetInt32("existencias");
                }
            }

            // Restar una unidad de las existencias actuales
            int nuevasExistencias = existenciasActuales - 1;

            // Verificar si las existencias son mayores a cero antes de actualizar
            if (nuevasExistencias >= 0)
            {
                //  Actualizar el producto con las nuevas existencias
                string queryUpdate = "UPDATE gorras SET nombre = '" + nombre + "', descripcion = '" + descripcion + "', precio = '" + precio + "', imagen = '" + imagen + "', existencias = '" + nuevasExistencias + "' WHERE id = '" + id + "';";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conexion);

                // Ejecutar la actualización
                cmdUpdate.ExecuteNonQuery();
                
            }
            else
            {
                MessageBox.Show("No hay suficientes existencias para actualizar el producto.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error en la actualización: " + ex.Message);
        }
    }

    public void actualizarMontoUsuario(int id, int nuevoMonto)
    {
        try
        {
            // Crear la consulta SQL para actualizar el monto del usuario
            string query = "UPDATE usuarios SET monto = '" + nuevoMonto + "' WHERE id = '" + id + "';";

            // Crear el comando SQL
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            // Ejecutar el comando
            cmd.ExecuteNonQuery();

            
        }
        catch (Exception ex)
        {
            // En caso de error, mostrar el mensaje correspondiente
            MessageBox.Show("Error al actualizar el monto: " + ex.Message);
        }
    }



}
