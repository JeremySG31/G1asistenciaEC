using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using G1asistenciaEC.modelo;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.controlador
{
    public class CursosMatriculadosC
    {
        public List<CursosMatriculadosM> ObtenerTodos()
        {
            var lista = new List<CursosMatriculadosM>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id, id_matricula, id_cursos, id_estudiante FROM cursos_matriculados";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CursosMatriculadosM
                        {
                            Id = reader["id"].ToString(),
                            IdMatricula = reader["id_matricula"].ToString(),
                            IdCursos = reader["id_cursos"].ToString(),
                            IdEstudiante = reader["id_estudiante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(CursosMatriculadosM cursoMat)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "INSERT INTO cursos_matriculados (id, id_matricula, id_cursos, id_estudiante) VALUES (@id, @id_matricula, @id_cursos, @id_estudiante)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", cursoMat.Id);
                    cmd.Parameters.AddWithValue("@id_matricula", cursoMat.IdMatricula);
                    cmd.Parameters.AddWithValue("@id_cursos", cursoMat.IdCursos);
                    cmd.Parameters.AddWithValue("@id_estudiante", cursoMat.IdEstudiante);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(CursosMatriculadosM cursoMat)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE cursos_matriculados SET id_matricula=@id_matricula, id_cursos=@id_cursos, id_estudiante=@id_estudiante WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_matricula", cursoMat.IdMatricula);
                    cmd.Parameters.AddWithValue("@id_cursos", cursoMat.IdCursos);
                    cmd.Parameters.AddWithValue("@id_estudiante", cursoMat.IdEstudiante);
                    cmd.Parameters.AddWithValue("@id", cursoMat.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(string id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM cursos_matriculados WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<KeyValuePair<string, object>> ObtenerMatriculas()
        {
            var lista = new List<KeyValuePair<string, object>>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT m.id, u.nombres, u.ape_paterno, u.ape_materno
                      FROM matriculas m
                      INNER JOIN estudiantes e ON m.id_estudiante = e.id
                      INNER JOIN usuarios u ON e.id_usuario = u.id", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string display = $"{dr["id"]} - {dr["nombres"]} {dr["ape_paterno"]} {dr["ape_materno"]}";
                    lista.Add(new KeyValuePair<string, object>(display, dr["id"]));
                }
                dr.Close();
            }
            return lista;
        }

        public List<KeyValuePair<string, object>> ObtenerCursos()
        {
            var lista = new List<KeyValuePair<string, object>>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre FROM cursos", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string display = $"{dr["id"]} - {dr["nombre"]}";
                    lista.Add(new KeyValuePair<string, object>(display, dr["id"]));
                }
                dr.Close();
            }
            return lista;
        }

        public List<KeyValuePair<string, object>> ObtenerEstudiantes()
        {
            var lista = new List<KeyValuePair<string, object>>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT e.id, u.nombres, u.ape_paterno, u.ape_materno 
                      FROM estudiantes e 
                      INNER JOIN usuarios u ON e.id_usuario = u.id", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string display = $"{dr["id"]} - {dr["nombres"]} {dr["ape_paterno"]} {dr["ape_materno"]}";
                    lista.Add(new KeyValuePair<string, object>(display, dr["id"]));
                }
                dr.Close();
            }
            return lista;
        }

        public string ObtenerSiguienteIdCM()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(id, 3, LEN(id)-2) AS INT)) FROM cursos_matriculados WHERE id LIKE 'CM%'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    int ultimo = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    return $"CM{(ultimo + 1).ToString("D2")}";
                }
            }
        }

        public bool ExisteIdCM(string id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM cursos_matriculados WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
