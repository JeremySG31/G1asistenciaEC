using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.modelo;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.controlador
{
    public class AniosLectivosC
    {
        public List<aniosLectivosM> ObtenerTodos()
        {
            var lista = new List<aniosLectivosM>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id, nombre, descripcion, estado FROM aniosLectivos";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new aniosLectivosM
                        {
                            Id = (string)reader["id"],
                            Nombre = reader["nombre"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Estado = reader["estado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(aniosLectivosM anio)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "INSERT INTO aniosLectivos (id, nombre, descripcion, estado) VALUES (@id, @nombre, @descripcion, @estado)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", anio.Id);
                    cmd.Parameters.AddWithValue("@nombre", anio.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", anio.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", anio.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(aniosLectivosM anio)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE aniosLectivos SET nombre=@nombre, descripcion=@descripcion, estado=@estado WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", anio.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", anio.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", anio.Estado);
                    cmd.Parameters.AddWithValue("@id", anio.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM aniosLectivos WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
