using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class asistenciasMatriculadosC
    {
        public List<asistenciasMatriculadosM> ObtenerAsistenciasPorFecha(DateTime fecha)
        {
            var lista = new List<asistenciasMatriculadosM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT 
                        a.id,
                        a.id_matricula,
                        a.fecha,
                        a.estado,
                        u.nombres,
                        u.ape_paterno,
                        u.ape_materno,
                        g.nombres as nombre_grado,
                        s.nombre as nombre_seccion,
                        u.correo,
                        CONCAT(u.nombres, ' ', u.ape_paterno, ' ', ISNULL(u.ape_materno, '')) as nombre_estudiante
                    FROM asistencias_matriculados a
                    INNER JOIN matriculas m ON a.id_matricula = m.id
                    INNER JOIN estudiantes e ON m.id_estudiante = e.id
                    INNER JOIN usuarios u ON e.id_usuario = u.id
                    INNER JOIN grados g ON m.id_grado = g.id
                    INNER JOIN secciones s ON m.id_seccion = s.id
                    WHERE CONVERT(DATE, a.fecha) = @fecha
                    AND m.estado = 'activo'
                    ORDER BY g.nombres, s.nombre, u.ape_paterno, u.ape_materno, u.nombres", conn);

                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var asistencia = new asistenciasMatriculadosM
                        {
                            Id = dr["id"]?.ToString(),
                            IdMatricula = dr["id_matricula"]?.ToString(),
                            Fecha = Convert.ToDateTime(dr["fecha"]),
                            Estado = dr["estado"]?.ToString(),
                            NombreEstudiante = dr["nombre_estudiante"]?.ToString(),
                            NombreGrado = dr["nombre_grado"]?.ToString(),
                            NombreSeccion = dr["nombre_seccion"]?.ToString(),
                            CorreoUsuario = dr["correo"]?.ToString()
                        };
                        lista.Add(asistencia);
                    }
                }
            }
            return lista;
        }

        public asistenciasMatriculadosM ObtenerPorMatriculaYFecha(string idMatricula, DateTime fecha)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT 
                        a.id,
                        a.id_matricula,
                        a.fecha,
                        a.estado,
                        CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre_estudiante,
                        g.nombres as nombre_grado,
                        s.nombre as nombre_seccion,
                        u.correo
                    FROM asistencias_matriculados a
                    INNER JOIN matriculas m ON a.id_matricula = m.id
                    INNER JOIN estudiantes e ON m.id_estudiante = e.id
                    INNER JOIN usuarios u ON e.id_usuario = u.id
                    INNER JOIN grados g ON m.id_grado = g.id
                    INNER JOIN secciones s ON m.id_seccion = s.id
                    WHERE a.id_matricula = @idMatricula 
                    AND a.fecha = @fecha", conn);

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
                            Estado = dr["estado"].ToString(),
                            Fecha = Convert.ToDateTime(dr["fecha"]),
                            NombreEstudiante = dr["nombre_estudiante"].ToString(),
                            NombreGrado = dr["nombre_grado"].ToString(),
                            NombreSeccion = dr["nombre_seccion"].ToString(),
                            CorreoUsuario = dr["correo"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public List<asistenciasMatriculadosM> ObtenerPorGradoYSeccionYFecha(string grado, string seccion, DateTime fecha)
        {
            var lista = new List<asistenciasMatriculadosM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT 
                        a.id,
                        a.id_matricula,
                        a.fecha,
                        a.estado,
                        CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre_estudiante,
                        g.nombres as nombre_grado,
                        s.nombre as nombre_seccion,
                        u.correo
                    FROM asistencias_matriculados a
                    INNER JOIN matriculas m ON a.id_matricula = m.id
                    INNER JOIN estudiantes e ON m.id_estudiante = e.id
                    INNER JOIN usuarios u ON e.id_usuario = u.id
                    INNER JOIN grados g ON m.id_grado = g.id
                    INNER JOIN secciones s ON m.id_seccion = s.id
                    WHERE LOWER(g.nombres) = LOWER(@grado)
                    AND LOWER(s.nombre) = LOWER(@seccion)
                    AND a.fecha = @fecha
                    AND m.estado = 'activo'
                    ORDER BY u.ape_paterno, u.ape_materno, u.nombres", conn);

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
                            Estado = dr["estado"].ToString(),
                            Fecha = Convert.ToDateTime(dr["fecha"]),
                            NombreEstudiante = dr["nombre_estudiante"].ToString(),
                            NombreGrado = dr["nombre_grado"].ToString(),
                            NombreSeccion = dr["nombre_seccion"].ToString(),
                            CorreoUsuario = dr["correo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(asistenciasMatriculadosM asistencia)
        {
            if (string.IsNullOrEmpty(asistencia.IdMatricula))
                throw new ArgumentException("El ID de matrícula es requerido");

            if (string.IsNullOrEmpty(asistencia.Estado))
                throw new ArgumentException("El estado es requerido");

            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var cmd = new SqlCommand(@"
                            INSERT INTO asistencias_matriculados (id, id_matricula, fecha, estado)
                            VALUES (@id, @idMatricula, @fecha, @estado)", conn, transaction);

                        cmd.Parameters.AddWithValue("@id", asistencia.Id ?? Guid.NewGuid().ToString());
                        cmd.Parameters.AddWithValue("@idMatricula", asistencia.IdMatricula);
                        cmd.Parameters.AddWithValue("@fecha", asistencia.Fecha.Date);
                        cmd.Parameters.AddWithValue("@estado", asistencia.Estado);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Modificar(asistenciasMatriculadosM asistencia)
        {
            if (string.IsNullOrEmpty(asistencia.IdMatricula))
                throw new ArgumentException("El ID de matrícula es requerido");

            if (string.IsNullOrEmpty(asistencia.Estado))
                throw new ArgumentException("El estado es requerido");

            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var cmd = new SqlCommand(@"
                            UPDATE asistencias_matriculados 
                            SET estado = @estado 
                            WHERE id_matricula = @idMatricula AND fecha = @fecha", conn, transaction);

                        cmd.Parameters.AddWithValue("@estado", asistencia.Estado);
                        cmd.Parameters.AddWithValue("@idMatricula", asistencia.IdMatricula);
                        cmd.Parameters.AddWithValue("@fecha", asistencia.Fecha.Date);

                        if (cmd.ExecuteNonQuery() == 0)
                            throw new Exception("No se encontró el registro para actualizar");

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
