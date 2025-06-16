using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;
using System.Data.SqlClient;

namespace G1asistenciaEC.negocio
{
    public class usuarioC
    {
        public usuarioM Autenticar(string usuario, string contrasenia)
        {
            return ObtenerUsuario(usuario, contrasenia);
        }

        public usuarioM ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            return ObtenerUsuario(nombreUsuario, null);
        }

        // Método privado unificado
        private usuarioM ObtenerUsuario(string nombreUsuario, string contrasenia)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT u.nombre_usuario, u.contrasena, u.estado, r.nombre_rol
                    FROM usuarios u
                    INNER JOIN roles r ON u.rol = r.id
                    WHERE u.nombre_usuario = @nombreUsuario";

                if (contrasenia != null)
                {
                    query += " AND u.contrasena = @contrasenia";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    if (contrasenia != null)
                        cmd.Parameters.AddWithValue("@contrasenia", contrasenia);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new usuarioM
                            {
                                NombreUsuario = reader["nombre_usuario"].ToString(),
                                Contrasena = reader["contrasena"].ToString(),
                                Estado = reader["estado"].ToString(),
                                Rol = reader["nombre_rol"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}