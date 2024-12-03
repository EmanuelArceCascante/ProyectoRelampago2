using Adm_ProyectoI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data.Propiedades;
namespace Data.Procedimientos
{
    public class ProcedimientosMacroProceso
    {
        private ConexionSQL conexion;
        public ProcedimientosMacroProceso()
        {
            conexion = new ConexionSQL();

        }
        public List<PropiedadesMacroProceso> ObtenerPropiedades()
        {

            List<PropiedadesMacroProceso> Macro = new List<PropiedadesMacroProceso>();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@Action", "READ");
                while (reader.Read())
                {

                    int IdMacroproceso = Convert.ToInt32(reader["idMacroproceso"]);
                    string NombreMacroproceso = reader["nombreMacroproceso"].ToString();
                    PropiedadesMacroProceso MacroProcesos = new PropiedadesMacroProceso(IdMacroproceso, NombreMacroproceso);
                    Macro.Add(MacroProcesos);


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

            return Macro;

        }

        public bool CrearMacroProceso(int id, string nombre)
        {
            bool resultado = false;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_MacroProceso", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "CREATE");
                cmd.Parameters.AddWithValue("@idMacroproceso", id);
                cmd.Parameters.AddWithValue("@nombreMacroproceso", nombre);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el Macroproceso: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return resultado;
        }

        public bool ActualizarMacroProceso(int id, string nombre)
        {
            bool resultado = false;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_MacroProceso", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@idMacroproceso", id);
                cmd.Parameters.AddWithValue("@nombreMacroproceso", nombre);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el Macroproceso: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return resultado;
        }

        public bool EliminarMacroProceso(int id)
        {
            bool resultado = false;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_MacroProceso", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@idMacroproceso", id);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el Macroproceso: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return resultado;
        }

        public PropiedadesMacroProceso ConsultarMacroProcesoPorId(int id)
        {
            PropiedadesMacroProceso macroProceso = null;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_MacroProceso", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "READ");
                cmd.Parameters.AddWithValue("@idMacroproceso", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int IdMacroproceso = Convert.ToInt32(reader["idMacroproceso"]);
                    string NombreMacroproceso = reader["nombreMacroproceso"].ToString();
                    macroProceso = new PropiedadesMacroProceso(IdMacroproceso, NombreMacroproceso);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar el Macroproceso por ID: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return macroProceso;
        }
    }
}

