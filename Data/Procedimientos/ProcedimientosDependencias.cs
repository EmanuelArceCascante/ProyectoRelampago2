using Adm_ProyectoI;
using Data.Propiedades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Procedimientos
{
    public class ProcedimientosDependencias
    {
        private ConexionSQL conexion;

        public ProcedimientosDependencias()
        {
            conexion = new ConexionSQL();
        }

        // Método para obtener todas las dependencias
        public List<PropiedadesDependencia> ObtenerDependencias()
        {
            List<PropiedadesDependencia> dependencias = new List<PropiedadesDependencia>();
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@Action", "READ");
                while (reader.Read())
                {

                    int idDependencia = Convert.ToInt32(reader["idDependencia"]);
                    string nombreDependencia = reader["nombreDependencia"].ToString();

                    PropiedadesDependencia dependencia = new PropiedadesDependencia(idDependencia, nombreDependencia);
                    dependencias.Add(dependencia);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las dependencias: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return dependencias;
        }
        public PropiedadesDependencia ConsultarAreaPorId(int id)
        {
            PropiedadesDependencia dependencia = null;

            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idDependencia", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idDependencia = Convert.ToInt32(reader["idArea"]);
                    string nombreDependencia = reader["nombreArea"].ToString();
                    dependencia = new PropiedadesDependencia(idDependencia, nombreDependencia);
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

            return dependencia;
        }
        // Método para crear una nueva dependencia
        public bool CrearDependencia(int id, string nombre)
        {
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_CrearDependencia", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@idDependencia", id);
                cmd.Parameters.AddWithValue("@nombreDependencia", nombre);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la dependencia: " + ex.Message);
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Método para actualizar una dependencia
        public bool ActualizarDependencia(int id, string nombre)
        {
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_ActualizarDependencia", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@idDependencia", id);
                cmd.Parameters.AddWithValue("@nombreDependencia", nombre);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la dependencia: " + ex.Message);
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Método para eliminar una dependencia
        public bool EliminarDependencia(int id)
        {
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SP_EliminarDependencia", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@idDependencia", id);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la dependencia: " + ex.Message);
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
