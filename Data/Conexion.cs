using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Adm_ProyectoI
{
    public class ConexionSQL
    {
        public string connString = "Data Source=LAPTOP-I48A0MCL;Initial Catalog=TatuajesDB;User=sa;Password=123";
        public SqlConnection connection;

        public ConexionSQL()
        {
            connection = new SqlConnection(connString);

        }

        public void AbrirConexion()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa :)");
                }
                else
                {
                    Console.WriteLine("La conexión ya está abierta.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la base de datos: " + ex.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada :)");
                }
                else
                {
                    Console.WriteLine("La conexión ya está cerrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la base de datos: " + ex.Message);
            }
        }

    }
}