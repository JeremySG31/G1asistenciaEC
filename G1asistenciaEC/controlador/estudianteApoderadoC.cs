using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class EstudianteApoderadoC
    {
        public List<EstudianteApoderadoM> ObtenerTodos()
        {
            var lista = new List<EstudianteApoderadoM>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT ea.id, ea.id_estudiante, ea.id_apoderado, ea.parentesco, 
                           ea.prioridad, ea.estado,
                           ISNULL(CONCAT(ue.nombres, ' ', ue.ape_paterno, ' ', ue.ape_materno), '') as nombre_estudiante,
                           CONCAT(ua.nombres, ' ', ua.ape_paterno, ' ', ua.ape_materno) as nombre_apoderado
                    FROM estudiante_apoderados ea
                    LEFT JOIN estudiantes e ON ea.id_estudiante = e.id
                    LEFT JOIN usuarios ue ON e.id_usuario = ue.id
                    INNER JOIN apoderados a ON ea.id_apoderado = a.id
                    INNER JOIN usuarios ua ON a.id_usuario = ua.id";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombreEstudiante = reader["nombre_estudiante"].ToString();
                        if (string.IsNullOrWhiteSpace(nombreEstudiante))
                            nombreEstudiante = "sin asignar";

                        lista.Add(new EstudianteApoderadoM
                        {
                            Id = reader["id"].ToString(),
                            IdEstudiante = reader["id_estudiante"] == DBNull.Value ? null : reader["id_estudiante"].ToString(),
                            IdApoderado = reader["id_apoderado"].ToString(),
                            Parentesco = reader["parentesco"].ToString(),
                            Prioridad = Convert.ToInt32(reader["prioridad"]),
                            Estado = reader["estado"].ToString(),
                            NombreEstudiante = nombreEstudiante,
                            NombreApoderado = reader["nombre_apoderado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(EstudianteApoderadoM modelo)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO estudiante_apoderados 
                               (id, id_estudiante, id_apoderado, parentesco, prioridad, estado)
                               VALUES (@id, @id_estudiante, @id_apoderado, @parentesco, @prioridad, @estado)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", modelo.Id);
                    cmd.Parameters.AddWithValue("@id_estudiante", string.IsNullOrEmpty(modelo.IdEstudiante) ? (object)DBNull.Value : modelo.IdEstudiante);
                    cmd.Parameters.AddWithValue("@id_apoderado", modelo.IdApoderado);
                    cmd.Parameters.AddWithValue("@parentesco", modelo.Parentesco);
                    cmd.Parameters.AddWithValue("@prioridad", modelo.Prioridad);
                    cmd.Parameters.AddWithValue("@estado", modelo.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(EstudianteApoderadoM modelo)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE estudiante_apoderados 
                               SET id_estudiante = @id_estudiante,
                                   id_apoderado = @id_apoderado,
                                   parentesco = @parentesco,
                                   prioridad = @prioridad,
                                   estado = @estado
                               WHERE id = @id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", modelo.Id);
                    cmd.Parameters.AddWithValue("@id_estudiante", string.IsNullOrEmpty(modelo.IdEstudiante) ? (object)DBNull.Value : modelo.IdEstudiante);
                    cmd.Parameters.AddWithValue("@id_apoderado", modelo.IdApoderado);
                    cmd.Parameters.AddWithValue("@parentesco", modelo.Parentesco);
                    cmd.Parameters.AddWithValue("@prioridad", modelo.Prioridad);
                    cmd.Parameters.AddWithValue("@estado", modelo.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(string id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM estudiante_apoderados WHERE id = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<KeyValuePair<string, string>> ObtenerEstudiantes()
        {
            var lista = new List<KeyValuePair<string, string>>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT e.id, CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre
                               FROM estudiantes e
                               INNER JOIN usuarios u ON e.id_usuario = u.id";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new KeyValuePair<string, string>(
                            reader["id"].ToString(),
                            reader["nombre"].ToString()
                        ));
                    }
                }
            }
            return lista;
        }

        public List<KeyValuePair<string, string>> ObtenerApoderados()
        {
            var lista = new List<KeyValuePair<string, string>>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT a.id, CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre
                               FROM apoderados a
                               INNER JOIN usuarios u ON a.id_usuario = u.id";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new KeyValuePair<string, string>(
                            reader["id"].ToString(),
                            reader["nombre"].ToString()
                        ));
                    }
                }
            }
            return lista;
        }
    }
}
