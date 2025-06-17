using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;
using System.Data.SqlClient;
using System;

namespace G1asistenciaEC.controlador
{
    public class LoginC
    {
        public loginM ObtenerUsuarioPorCredenciales(string usuario, string contrasenia)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT u.nombre_usuario, u.contrasena, u.estado, r.nombre_rol
                        FROM usuarios u
                        INNER JOIN roles r ON u.rol = r.id
                        WHERE u.nombre_usuario = @nombreUsuario 
                        AND u.contrasena = @contrasenia";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasenia", contrasenia);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new loginM
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
                catch (Exception ex)
                {
                    throw new Exception("Error al conectar con la base de datos: " + ex.Message);
                }
            }
            return null;
        }

        public loginM ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT u.nombre_usuario, u.contrasena, u.estado, r.nombre_rol
                        FROM usuarios u
                        INNER JOIN roles r ON u.rol = r.id
                        WHERE u.nombre_usuario = @nombreUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new loginM
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
                catch (Exception ex)
                {
                    throw new Exception("Error al conectar con la base de datos: " + ex.Message);
                }
            }
            return null;
        }
    }
}