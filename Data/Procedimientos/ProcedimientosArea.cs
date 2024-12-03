using Adm_ProyectoI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Data.Propiedades;

namespace Data.Procedimientos
{
    public class ProcedimientosArea
    {
        private ConexionSQL conexion;


        public ProcedimientosArea()
        {
            conexion = new ConexionSQL();

        }

        public List<PropiedadesArea> ObtenerPropiedades()
        {

            List<PropiedadesArea> areas = new List<PropiedadesArea>();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Spconsultar", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@Action", "READ");
                while (reader.Read())
                {

                    int idArea = Convert.ToInt32(reader["idArea"]);
                    string nombreArea = reader["nombreArea"].ToString();
                    PropiedadesArea Area = new PropiedadesArea(idArea, nombreArea);
                    areas.Add(Area);


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la lista de artistas: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return areas;

        }

        public PropiedadesArea ConsultarAreaPorId(int id)
        {
            PropiedadesArea area = null;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idArea", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idArea = Convert.ToInt32(reader["idArea"]);
                    string nombreArea = reader["nombreArea"].ToString();
                    area = new PropiedadesArea(idArea, nombreArea);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar el área por ID: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return area;
        }
        public bool CrearAre(int id, string nombre)
        {
            bool resultado = false;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "CREATE");
                cmd.Parameters.AddWithValue("@idArea", id);
                cmd.Parameters.AddWithValue("@nombreArea", nombre);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el área: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return resultado;
        }
        public bool ActualizarArea(int id, string nombre)
        {
            bool resultado = false;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@idArea", id);
                cmd.Parameters.AddWithValue("@nombreArea", nombre);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el área: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return resultado;
        }
        public bool EliminarArea(int id)
        {
            bool resultado = false;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@idArea", id);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el área: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return resultado;
        }
    }

}

