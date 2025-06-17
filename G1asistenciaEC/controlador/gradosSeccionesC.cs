using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class GradosSeccionesC
    {
        public List<EstudianteComboM> ObtenerEstudiantes()
        {
            var lista = new List<EstudianteComboM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT e.id, u.nombres, u.ape_paterno, u.ape_materno 
                      FROM estudiantes e 
                      INNER JOIN usuarios u ON e.id_usuario = u.id", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new EstudianteComboM
                        {
                            Id = dr["id"].ToString(),
                            NombreCompleto = $"{dr["nombres"]} {dr["ape_paterno"]} {dr["ape_materno"]}"
                        });
                    }
                }
            }
            return lista;
        }

        public List<GradoM> ObtenerGrados()
        {
            var lista = new List<GradoM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT g.id, g.nombres, g.id_estudiante, g.nivel,
                             CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre_estudiante
                      FROM grados g
                      LEFT JOIN estudiantes e ON g.id_estudiante = e.id
                      LEFT JOIN usuarios u ON e.id_usuario = u.id", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new GradoM
                        {
                            Id = dr["id"].ToString(),
                            Nombres = dr["nombres"].ToString(),
                            IdEstudiante = dr["id_estudiante"].ToString(),
                            Nivel = dr["nivel"].ToString(),
                            NombreEstudiante = dr["nombre_estudiante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<SeccionM> ObtenerSecciones()
        {
            var lista = new List<SeccionM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT s.id, s.nombre, s.id_estudiante,
                             CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre_estudiante
                      FROM secciones s
                      LEFT JOIN estudiantes e ON s.id_estudiante = e.id
                      LEFT JOIN usuarios u ON e.id_usuario = u.id", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new SeccionM
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

        public void InsertarGrado(GradoM grado)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO grados (id, nombres, id_estudiante, nivel) VALUES (@id, @nombres, @id_estudiante, @nivel)",
                    conn);
                cmd.Parameters.AddWithValue("@id", grado.Id);
                cmd.Parameters.AddWithValue("@nombres", grado.Nombres);
                cmd.Parameters.AddWithValue("@id_estudiante", grado.IdEstudiante);
                cmd.Parameters.AddWithValue("@nivel", grado.Nivel);
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarGrado(GradoM grado)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE grados SET nombres=@nombres, id_estudiante=@id_estudiante, nivel=@nivel WHERE id=@id",
                    conn);
                cmd.Parameters.AddWithValue("@id", grado.Id);
                cmd.Parameters.AddWithValue("@nombres", grado.Nombres);
                cmd.Parameters.AddWithValue("@id_estudiante", grado.IdEstudiante);
                cmd.Parameters.AddWithValue("@nivel", grado.Nivel);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarGrado(string id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM grados WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertarSeccion(SeccionM seccion)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO secciones (id, nombre, id_estudiante) VALUES (@id, @nombre, @id_estudiante)",
                    conn);
                cmd.Parameters.AddWithValue("@id", seccion.Id);
                cmd.Parameters.AddWithValue("@nombre", seccion.Nombre);
                cmd.Parameters.AddWithValue("@id_estudiante", seccion.IdEstudiante);
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarSeccion(SeccionM seccion)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE secciones SET nombre=@nombre, id_estudiante=@id_estudiante WHERE id=@id",
                    conn);
                cmd.Parameters.AddWithValue("@id", seccion.Id);
                cmd.Parameters.AddWithValue("@nombre", seccion.Nombre);
                cmd.Parameters.AddWithValue("@id_estudiante", seccion.IdEstudiante);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarSeccion(string id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM secciones WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
