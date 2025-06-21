using G1asistenciaEC.modelo;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using System;
using System.Collections.Generic;
using System.Data;

namespace G1asistenciaEC.controlador
{
    public class apoderadoC
    {
        public apoderadoM ObtenerApoderadoPorUsuario(string usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT a.id AS id_apoderado, u.nombres, u.ape_paterno, u.ape_materno, u.dni, u.correo, u.estado, u.telefono
                    FROM usuarios u
                    INNER JOIN apoderados a ON a.id_usuario = u.id
                    WHERE u.nombre_usuario = @Usuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new apoderadoM
                            {
                                Id = reader["id_apoderado"].ToString(),
                                Nombres = reader["nombres"].ToString(),
                                ApellidoPaterno = reader["ape_paterno"].ToString(),
                                ApellidoMaterno = reader["ape_materno"].ToString(),
                                Dni = reader["dni"].ToString(),
                                Correo = reader["correo"].ToString(),
                                Estado = reader["estado"].ToString(),
                                Telefono = reader["telefono"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public DataTable ObtenerAsistenciasPorApoderado(string idApoderado)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT am.fecha, am.estado, 
                           CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) AS nombre_estudiante,
                           g.nombres AS grado, s.nombre AS seccion
                    FROM asistencias_matriculados am
                    INNER JOIN matriculas m ON am.id_matricula = m.id
                    INNER JOIN estudiantes e ON m.id_estudiante = e.id
                    INNER JOIN usuarios u ON e.id_usuario = u.id
                    INNER JOIN grados g ON m.id_grado = g.id
                    INNER JOIN secciones s ON m.id_seccion = s.id
                    INNER JOIN estudiante_apoderados ea ON ea.id_estudiante = e.id
                    WHERE ea.id_apoderado = @idApoderado
                      AND m.estado = 'activo'
                    ORDER BY am.fecha DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idApoderado", idApoderado);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable asistencias = new DataTable();
                        adapter.Fill(asistencias);
                        return asistencias;
                    }
                }
            }
        }
    }
}