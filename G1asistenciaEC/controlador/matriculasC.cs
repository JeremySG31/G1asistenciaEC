using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class MatriculasC
    {
        public List<MatriculaM> ObtenerTodos()
        {
            var lista = new List<MatriculaM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT m.*, 
                           CONCAT(ue.nombres, ' ', ue.ape_paterno, ' ', ue.ape_materno) as nombre_estudiante,
                           g.nombres as nombre_grado,
                           s.nombre as nombre_seccion,
                           t.nombre as nombre_turno,
                           al.nombre as nombre_anio_lectivo,
                           CONCAT(ua.nombres, ' ', ua.ape_paterno, ' ', ua.ape_materno) as nombre_apoderado
                    FROM matriculas m
                    LEFT JOIN estudiantes e ON m.id_estudiante = e.id
                    LEFT JOIN usuarios ue ON e.id_usuario = ue.id
                    LEFT JOIN grados g ON m.id_grado = g.id
                    LEFT JOIN secciones s ON m.id_seccion = s.id
                    LEFT JOIN turnos t ON m.id_turno = t.id
                    LEFT JOIN aniosLectivos al ON m.id_aniolectivo = al.id
                    LEFT JOIN apoderados a ON m.id_apoderado = a.id
                    LEFT JOIN usuarios ua ON a.id_usuario = ua.id", conn);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MatriculaM
                        {
                            Id = dr["id"].ToString(),
                            IdEstudiante = dr["id_estudiante"].ToString(),
                            IdGrado = dr["id_grado"].ToString(),
                            FechaMatricula = Convert.ToDateTime(dr["fecha_matricula"]),
                            IdApoderado = dr["id_apoderado"].ToString(),
                            IdSeccion = dr["id_seccion"].ToString(),
                            IdTurno = dr["id_turno"].ToString(),
                            IdAnioLectivo = dr["id_aniolectivo"].ToString(),
                            Estado = dr["estado"].ToString(),
                            NombreEstudiante = dr["nombre_estudiante"].ToString(),
                            NombreGrado = dr["nombre_grado"].ToString(),
                            NombreSeccion = dr["nombre_seccion"].ToString(),
                            NombreTurno = dr["nombre_turno"].ToString(),
                            NombreAnioLectivo = dr["nombre_anio_lectivo"].ToString(),
                            NombreApoderado = dr["nombre_apoderado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<ComboItemM> ObtenerEstudiantes()
        {
            var lista = new List<ComboItemM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT e.id, CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre
                      FROM estudiantes e 
                      INNER JOIN usuarios u ON e.id_usuario = u.id", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ComboItemM
                        {
                            Id = dr["id"].ToString(),
                            Nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<ComboItemM> ObtenerGrados()
        {
            var lista = new List<ComboItemM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombres, nivel FROM grados", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string nivel = dr["nivel"].ToString();
                        string nivelTexto = nivel == "1" ? "Primaria" : nivel == "2" ? "Secundaria" : nivel;
                        lista.Add(new ComboItemM
                        {
                            Id = dr["id"].ToString(),
                            Nombre = dr["nombres"].ToString(),
                            Descripcion = nivelTexto
                        });
                    }
                }
            }
            return lista;
        }

        public List<ComboItemM> ObtenerSecciones()
        {
            var lista = new List<ComboItemM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre FROM secciones", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ComboItemM
                        {
                            Id = dr["id"].ToString(),
                            Nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<ComboItemM> ObtenerTurnos()
        {
            var lista = new List<ComboItemM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre FROM turnos", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ComboItemM
                        {
                            Id = dr["id"].ToString(),
                            Nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<ComboItemM> ObtenerAniosLectivos()
        {
            var lista = new List<ComboItemM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre FROM aniosLectivos", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ComboItemM
                        {
                            Id = dr["id"].ToString(),
                            Nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<ComboItemM> ObtenerApoderados()
        {
            var lista = new List<ComboItemM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT a.id, CONCAT(u.nombres, ' ', u.ape_paterno, ' ', u.ape_materno) as nombre
                      FROM apoderados a 
                      INNER JOIN usuarios u ON a.id_usuario = u.id", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ComboItemM
                        {
                            Id = dr["id"].ToString(),
                            Nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(MatriculaM matricula)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO matriculas 
                    (id, id_estudiante, id_grado, fecha_matricula, id_apoderado, 
                     id_seccion, id_turno, id_aniolectivo, estado)
                    VALUES 
                    (@id, @id_estudiante, @id_grado, @fecha_matricula, @id_apoderado, 
                     @id_seccion, @id_turno, @id_aniolectivo, @estado)", conn);

                cmd.Parameters.AddWithValue("@id", matricula.Id);
                cmd.Parameters.AddWithValue("@id_estudiante", matricula.IdEstudiante);
                cmd.Parameters.AddWithValue("@id_grado", matricula.IdGrado);
                cmd.Parameters.AddWithValue("@fecha_matricula", matricula.FechaMatricula);
                cmd.Parameters.AddWithValue("@id_apoderado", matricula.IdApoderado);
                cmd.Parameters.AddWithValue("@id_seccion", matricula.IdSeccion);
                cmd.Parameters.AddWithValue("@id_turno", matricula.IdTurno);
                cmd.Parameters.AddWithValue("@id_aniolectivo", matricula.IdAnioLectivo);
                cmd.Parameters.AddWithValue("@estado", matricula.Estado);

                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(MatriculaM matricula)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE matriculas SET 
                        id_estudiante=@id_estudiante, 
                        id_grado=@id_grado, 
                        fecha_matricula=@fecha_matricula, 
                        id_apoderado=@id_apoderado, 
                        id_seccion=@id_seccion, 
                        id_turno=@id_turno, 
                        id_aniolectivo=@id_aniolectivo, 
                        estado=@estado 
                    WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@id", matricula.Id);
                cmd.Parameters.AddWithValue("@id_estudiante", matricula.IdEstudiante);
                cmd.Parameters.AddWithValue("@id_grado", matricula.IdGrado);
                cmd.Parameters.AddWithValue("@fecha_matricula", matricula.FechaMatricula);
                cmd.Parameters.AddWithValue("@id_apoderado", matricula.IdApoderado);
                cmd.Parameters.AddWithValue("@id_seccion", matricula.IdSeccion);
                cmd.Parameters.AddWithValue("@id_turno", matricula.IdTurno);
                cmd.Parameters.AddWithValue("@id_aniolectivo", matricula.IdAnioLectivo);
                cmd.Parameters.AddWithValue("@estado", matricula.Estado);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(string id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM matriculas WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
