using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.modelo;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.controlador
{
    public class CursosC
    {
        public List<CursoM> ObtenerTodos()
        {
            var lista = new List<CursoM>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id, nombre, descripcion FROM cursos";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CursoM
                        {
                            Id = (string)reader["id"],
                            Nombre = reader["nombre"].ToString(),
                            Descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(CursoM curso)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "INSERT INTO cursos (id, nombre, descripcion) VALUES (@id, @nombre, @descripcion)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", curso.Id);
                    cmd.Parameters.AddWithValue("@nombre", curso.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", curso.Descripcion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(CursoM curso)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE cursos SET nombre=@nombre, descripcion=@descripcion WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", curso.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", curso.Descripcion);
                    cmd.Parameters.AddWithValue("@id", curso.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(string id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM cursos WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
