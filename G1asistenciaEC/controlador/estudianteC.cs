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
    }
}