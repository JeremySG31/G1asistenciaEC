using System;
using System.Data.SqlClient;
using G1asistenciaEC.modelo;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.negocio
{
    public class profesorC
    {
        public profesorM ObtenerProfesorPorUsuario(string usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT id, nombres, ape_paterno, ape_materno, 
                           dni, correo, estado, telefono
                    FROM usuarios
                    WHERE nombre_usuario = @Usuario";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new profesorM
                            {
                                Id = reader["id"].ToString(),
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

        public void ActualizarProfesor(profesorM profesor)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    UPDATE usuarios 
                    SET nombres = @nombres,
                        ape_paterno = @apePaterno,
                        ape_materno = @apeMaterno,
                        dni = @dni,
                        correo = @correo,
                        telefono = @telefono
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", profesor.Id);
                    cmd.Parameters.AddWithValue("@nombres", profesor.Nombres);
                    cmd.Parameters.AddWithValue("@apePaterno", profesor.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@apeMaterno", profesor.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@dni", profesor.Dni);
                    cmd.Parameters.AddWithValue("@correo", profesor.Correo);
                    cmd.Parameters.AddWithValue("@telefono", profesor.Telefono);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}