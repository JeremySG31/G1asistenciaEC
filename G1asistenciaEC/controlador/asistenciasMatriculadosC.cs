using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class asistenciasMatriculadosM
    {
        public string Id { get; set; }
        public string IdMatricula { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class asistenciasMatriculadosC
    {
        public asistenciasMatriculadosM ObtenerPorMatriculaYFecha(string idMatricula, DateTime fecha)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM asistencias_matriculados WHERE id_matricula=@idMatricula AND fecha=@fecha", conn);
                cmd.Parameters.AddWithValue("@idMatricula", idMatricula);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new asistenciasMatriculadosM
                        {
                            Id = dr["id"].ToString(),
                            IdMatricula = dr["id_matricula"].ToString(),
                            Fecha = Convert.ToDateTime(dr["fecha"]),
                            Estado = dr["estado"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Insertar(asistenciasMatriculadosM asistencia)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO asistencias_matriculados (id, id_matricula, fecha, estado) VALUES (@id, @idMatricula, @fecha, @estado)", conn);
                cmd.Parameters.AddWithValue("@id", asistencia.Id ?? Guid.NewGuid().ToString());
                cmd.Parameters.AddWithValue("@idMatricula", asistencia.IdMatricula);
                cmd.Parameters.AddWithValue("@fecha", asistencia.Fecha.Date);
                cmd.Parameters.AddWithValue("@estado", asistencia.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(asistenciasMatriculadosM asistencia)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE asistencias_matriculados SET estado=@estado WHERE id_matricula=@idMatricula AND fecha=@fecha", conn);
                cmd.Parameters.AddWithValue("@estado", asistencia.Estado);
                cmd.Parameters.AddWithValue("@idMatricula", asistencia.IdMatricula);
                cmd.Parameters.AddWithValue("@fecha", asistencia.Fecha.Date);
                cmd.ExecuteNonQuery();
            }
        }

        public List<asistenciasMatriculadosM> ObtenerPorGradoYSeccionYFecha(string grado, string seccion, DateTime fecha)
        {
            var lista = new List<asistenciasMatriculadosM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT a.id, a.id_matricula, a.fecha, a.estado
                    FROM asistencias_matriculados a
                    INNER JOIN matriculas m ON a.id_matricula = m.id
                    INNER JOIN grados g ON m.id_grado = g.id
                    INNER JOIN secciones s ON m.id_seccion = s.id
                    WHERE LOWER(g.nombres) = LOWER(@grado)
                    AND LOWER(s.nombre) = LOWER(@seccion)
                    AND a.fecha = @fecha
                    AND m.estado = 'activo'", conn);

                cmd.Parameters.AddWithValue("@grado", grado);
                cmd.Parameters.AddWithValue("@seccion", seccion);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new asistenciasMatriculadosM
                        {
                            Id = dr["id"].ToString(),
                            IdMatricula = dr["id_matricula"].ToString(),
                            Fecha = DateTime.Parse(dr["fecha"].ToString()),
                            Estado = dr["estado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}