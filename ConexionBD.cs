﻿using System;
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
            string query = "SELECT * FROM usuarios where cuenta=" + account + ";";
            MySqlCommand command = new MySqlCommand(query, conexion);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
                nombre = Convert.ToString(reader["nombre"]) ?? "";
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

            query = "DELETE FROM gorras WHERE id=" + eliminar + ";";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.ExecuteNonQuery();
            MessageBox.Show(query + "\nRegistro Eliminado");
        }
        catch (Exception ex)
        {
            MessageBox.Show(query + "\nError " + ex.Message);
            this.desconectar();
        }
    }


    //actualizar datos de un registro
    public void actualizar(int act, string nombre, int existencias,string descripcion, int precio, string imagen)
    {

        try
        {
            string query = "UPDATE gorras SET id=" + "'" + act + "'" + ",nombre=" + "'" + nombre + "'" + ",existencias=" + "'" + existencias + "'" + ",descripcion=" + "'" + descripcion + ",precio=" + "'" + precio + "'" + ",imagen=" + "'" + imagen + "'" + "where id=" + act + ";";
            MessageBox.Show(query);
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.ExecuteNonQuery();
            MessageBox.Show(query + "\nRegistro Actualizado");


        }
        catch (Exception ex)
        {
            MessageBox.Show("Error en la actualizacion: " + ex.Message);
            this.desconectar();
        }
    }




}
