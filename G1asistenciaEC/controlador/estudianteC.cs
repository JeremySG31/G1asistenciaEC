using G1asistenciaEC.modelo;
using System.Data.SqlClient;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.negocio
{
    public class estudianteC
    {
        public estudianteM ObtenerEstudiantePorUsuario(string usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT nombres, ape_paterno, ape_materno, dni, correo, estado, telefono
                                 FROM usuarios WHERE nombre_usuario = @Usuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new estudianteM
                            {
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

        public estudianteM ObtenerPorDni(string dni)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT e.id, u.nombres, u.ape_paterno, u.ape_materno, u.dni, u.correo, u.estado, u.telefono
                    FROM estudiantes e
                    INNER JOIN usuarios u ON e.id_usuario = u.id
                    WHERE u.dni = @dni", conn);

                cmd.Parameters.AddWithValue("@dni", dni);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new estudianteM
                        {
                            Id = dr["id"].ToString(),
                            Nombres = dr["nombres"].ToString(),
                            ApellidoPaterno = dr["ape_paterno"].ToString(),
                            ApellidoMaterno = dr["ape_materno"].ToString(),
                            Dni = dr["dni"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Estado = dr["estado"].ToString(),
                            Telefono = dr["telefono"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}