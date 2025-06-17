using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class UsuariosC
    {
        public DataTable ObtenerTodos()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        u.id, 
                        e.id AS id_estudiante,
                        p.id AS id_profesor,
                        a.id AS id_apoderado,
                        u.nombre_usuario, 
                        u.nombres, 
                        u.ape_paterno, 
                        u.ape_materno, 
                        u.dni, 
                        u.correo, 
                        u.contrasena, 
                        u.rol, 
                        u.estado, 
                        u.telefono
                    FROM usuarios u
                    LEFT JOIN estudiantes e ON e.id_usuario = u.id
                    LEFT JOIN profesores p ON p.id_usuario = u.id
                    LEFT JOIN apoderados a ON a.id_usuario = u.id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public List<RolComboM> ObtenerRoles()
        {
            var roles = new List<RolComboM>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id, nombre_rol FROM roles";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new RolComboM
                        {
                            Id = reader["id"].ToString(),
                            NombreRol = reader["nombre_rol"].ToString()
                        });
                    }
                }
            }
            return roles;
        }

        public void Insertar(UsuariosM usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insertar usuario principal
                        string query = @"
                            INSERT INTO usuarios (
                                id, nombre_usuario, nombres, ape_paterno, ape_materno,
                                dni, correo, contrasena, rol, estado, telefono
                            ) VALUES (
                                @id, @nombre_usuario, @nombres, @ape_paterno, @ape_materno,
                                @dni, @correo, @contrasena, @rol, @estado, @telefono
                            )";

                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", usuario.Id);
                            cmd.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                            cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                            cmd.Parameters.AddWithValue("@ape_paterno", usuario.ApePaterno);
                            cmd.Parameters.AddWithValue("@ape_materno", (object)usuario.ApeMaterno ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                            cmd.Parameters.AddWithValue("@correo", (object)usuario.Correo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                            cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                            cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                            cmd.Parameters.AddWithValue("@telefono", (object)usuario.Telefono ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        InsertarSecundarios(conn, transaction, usuario);
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

        public void Modificar(UsuariosM usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            UPDATE usuarios SET 
                                nombre_usuario = @nombre_usuario,
                                nombres = @nombres,
                                ape_paterno = @ape_paterno,
                                ape_materno = @ape_materno,
                                dni = @dni,
                                correo = @correo,
                                contrasena = @contrasena,
                                rol = @rol,
                                estado = @estado,
                                telefono = @telefono
                            WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", usuario.Id);
                            cmd.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                            cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                            cmd.Parameters.AddWithValue("@ape_paterno", usuario.ApePaterno);
                            cmd.Parameters.AddWithValue("@ape_materno", (object)usuario.ApeMaterno ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                            cmd.Parameters.AddWithValue("@correo", (object)usuario.Correo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                            cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                            cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                            cmd.Parameters.AddWithValue("@telefono", (object)usuario.Telefono ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        ModificarSecundarios(conn, transaction, usuario);
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

        public void Eliminar(string id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        EliminarSecundarios(conn, transaction, id);

                        string query = "DELETE FROM usuarios WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

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

        private void InsertarSecundarios(SqlConnection conn, SqlTransaction transaction, UsuariosM usuario)
        {
            if (!string.IsNullOrWhiteSpace(usuario.IdEstudiante))
            {
                var cmd = new SqlCommand(
                    "INSERT INTO estudiantes (id, id_usuario) VALUES (@id, @id_usuario)", 
                    conn, transaction);
                cmd.Parameters.AddWithValue("@id", usuario.IdEstudiante);
                cmd.Parameters.AddWithValue("@id_usuario", usuario.Id);
                cmd.ExecuteNonQuery();
            }

            if (!string.IsNullOrWhiteSpace(usuario.IdProfesor))
            {
                var cmd = new SqlCommand(
                    "INSERT INTO profesores (id, id_usuario) VALUES (@id, @id_usuario)", 
                    conn, transaction);
                cmd.Parameters.AddWithValue("@id", usuario.IdProfesor);
                cmd.Parameters.AddWithValue("@id_usuario", usuario.Id);
                cmd.ExecuteNonQuery();
            }

            if (!string.IsNullOrWhiteSpace(usuario.IdApoderado))
            {
                var cmd = new SqlCommand(
                    "INSERT INTO apoderados (id, id_usuario) VALUES (@id, @id_usuario)", 
                    conn, transaction);
                cmd.Parameters.AddWithValue("@id", usuario.IdApoderado);
                cmd.Parameters.AddWithValue("@id_usuario", usuario.Id);
                cmd.ExecuteNonQuery();
            }
        }

        private void ModificarSecundarios(SqlConnection conn, SqlTransaction transaction, UsuariosM usuario)
        {
            if (!string.IsNullOrWhiteSpace(usuario.IdEstudiante))
            {
                var cmd = new SqlCommand(@"
                    IF EXISTS (SELECT 1 FROM estudiantes WHERE id = @id)
                        UPDATE estudiantes SET id_usuario = @id_usuario WHERE id = @id
                    ELSE
                        INSERT INTO estudiantes (id, id_usuario) VALUES (@id, @id_usuario)", 
                    conn, transaction);
                cmd.Parameters.AddWithValue("@id", usuario.IdEstudiante);
                cmd.Parameters.AddWithValue("@id_usuario", usuario.Id);
                cmd.ExecuteNonQuery();
            }

            if (!string.IsNullOrWhiteSpace(usuario.IdProfesor))
            {
                var cmd = new SqlCommand(@"
                    IF EXISTS (SELECT 1 FROM profesores WHERE id = @id)
                        UPDATE profesores SET id_usuario = @id_usuario WHERE id = @id
                    ELSE
                        INSERT INTO profesores (id, id_usuario) VALUES (@id, @id_usuario)", 
                    conn, transaction);
                cmd.Parameters.AddWithValue("@id", usuario.IdProfesor);
                cmd.Parameters.AddWithValue("@id_usuario", usuario.Id);
                cmd.ExecuteNonQuery();
            }

            if (!string.IsNullOrWhiteSpace(usuario.IdApoderado))
            {
                var cmd = new SqlCommand(@"
                    IF EXISTS (SELECT 1 FROM apoderados WHERE id = @id)
                        UPDATE apoderados SET id_usuario = @id_usuario WHERE id = @id
                    ELSE
                        INSERT INTO apoderados (id, id_usuario) VALUES (@id, @id_usuario)", 
                    conn, transaction);
                cmd.Parameters.AddWithValue("@id", usuario.IdApoderado);
                cmd.Parameters.AddWithValue("@id_usuario", usuario.Id);
                cmd.ExecuteNonQuery();
            }
        }

        private void EliminarSecundarios(SqlConnection conn, SqlTransaction transaction, string idUsuario)
        {
            var cmd1 = new SqlCommand("DELETE FROM estudiantes WHERE id_usuario = @id_usuario", conn, transaction);
            cmd1.Parameters.AddWithValue("@id_usuario", idUsuario);
            cmd1.ExecuteNonQuery();

            var cmd2 = new SqlCommand("DELETE FROM profesores WHERE id_usuario = @id_usuario", conn, transaction);
            cmd2.Parameters.AddWithValue("@id_usuario", idUsuario);
            cmd2.ExecuteNonQuery();

            var cmd3 = new SqlCommand("DELETE FROM apoderados WHERE id_usuario = @id_usuario", conn, transaction);
            cmd3.Parameters.AddWithValue("@id_usuario", idUsuario);
            cmd3.ExecuteNonQuery();
        }
    }
}
