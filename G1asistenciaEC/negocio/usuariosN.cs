using System;
using System.Data;
using System.Collections.Generic;
using G1asistenciaEC.modelo;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC.negocio
{
    public class UsuariosN
    {
        private readonly UsuariosC _usuariosController;

        public UsuariosN()
        {
            _usuariosController = new UsuariosC();
        }

        public DataTable ObtenerTodos()
        {
            return _usuariosController.ObtenerTodos();
        }

        public List<RolComboM> ObtenerRoles()
        {
            return _usuariosController.ObtenerRoles();
        }

        public void Insertar(UsuariosM usuario)
        {
            ValidarUsuario(usuario, true);
            _usuariosController.Insertar(usuario);
        }

        public void Modificar(UsuariosM usuario)
        {
            ValidarUsuario(usuario, false);
            _usuariosController.Modificar(usuario);
        }

        public void Eliminar(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El ID del usuario es requerido");

            _usuariosController.Eliminar(id);
        }

        private void ValidarUsuario(UsuariosM usuario, bool esNuevo)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (string.IsNullOrWhiteSpace(usuario.Id))
                throw new ArgumentException("El ID del usuario es requerido");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException("El nombre de usuario es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Nombres))
                throw new ArgumentException("Los nombres son requeridos");

            if (string.IsNullOrWhiteSpace(usuario.ApePaterno))
                throw new ArgumentException("El apellido paterno es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Dni))
                throw new ArgumentException("El DNI es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Rol))
                throw new ArgumentException("El rol es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Estado))
                throw new ArgumentException("El estado es requerido");

            if (esNuevo && string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new ArgumentException("La contraseña es requerida para nuevos usuarios");
        }
    }
}