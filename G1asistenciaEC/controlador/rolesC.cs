using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.controlador
{
    public class RolesC
    {
        public List<RolM> ObtenerTodos()
        {
            var lista = new List<RolM>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre_rol FROM roles", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new RolM
                        {
                            Id = dr["id"].ToString(),
                            NombreRol = dr["nombre_rol"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Insertar(RolM rol)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO roles (id, nombre_rol) VALUES (@id, @nombre_rol)", 
                    conn);

                cmd.Parameters.AddWithValue("@id", rol.Id);
                cmd.Parameters.AddWithValue("@nombre_rol", rol.NombreRol);
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(RolM rol)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE roles SET nombre_rol = @nombre_rol WHERE id = @id", 
                    conn);

                cmd.Parameters.AddWithValue("@id", rol.Id);
                cmd.Parameters.AddWithValue("@nombre_rol", rol.NombreRol);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(string id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM roles WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
