using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class TurnoC
    {
        public List<TurnoM> ObtenerTodos()
        {
            var lista = new List<TurnoM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT t.id, t.nombre, t.id_estudiante,
                           CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre_estudiante
                    FROM turnos t
                    LEFT JOIN estudiantes e ON t.id_estudiante = e.id
                    LEFT JOIN usuarios u ON e.id_usuario = u.id", conn);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TurnoM
                        {
                            Id = dr["id"].ToString(),
                            Nombre = dr["nombre"].ToString(),
                            IdEstudiante = dr["id_estudiante"].ToString(),
                            NombreEstudiante = dr["nombre_estudiante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<EstudianteTurnoM> ObtenerEstudiantes()
        {
            var lista = new List<EstudianteTurnoM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT e.id, CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre_completo
                      FROM estudiantes e 
                      INNER JOIN usuarios u ON e.id_usuario = u.id", conn);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new EstudianteTurnoM
                        {
                            Id = dr["id"].ToString(),
                            NombreCompleto = dr["nombre_completo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(TurnoM turno)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO turnos (id, nombre, id_estudiante) VALUES (@id, @nombre, @id_estudiante)", 
                    conn);

                cmd.Parameters.AddWithValue("@id", turno.Id);
                cmd.Parameters.AddWithValue("@nombre", turno.Nombre);
                cmd.Parameters.AddWithValue("@id_estudiante", turno.IdEstudiante);
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(TurnoM turno)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE turnos SET nombre = @nombre, id_estudiante = @id_estudiante WHERE id = @id", 
                    conn);

                cmd.Parameters.AddWithValue("@id", turno.Id);
                cmd.Parameters.AddWithValue("@nombre", turno.Nombre);
                cmd.Parameters.AddWithValue("@id_estudiante", turno.IdEstudiante);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(string id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM turnos WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}