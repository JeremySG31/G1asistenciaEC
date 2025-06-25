using System;
using G1asistenciaEC.modelo;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC.negocio
{
    public class LoginN
    {
        private readonly LoginC _loginControlador;

        public LoginN()
        {
            _loginControlador = new LoginC();
        }

        public loginM Login(string usuario, string contrasenia)
        {
            if (!ValidarDatosLogin(usuario, contrasenia))
            {
                return null;
            }

            var usuarioAutenticado = _loginControlador.ObtenerUsuarioPorCredenciales(usuario, contrasenia);

            if (usuarioAutenticado == null)
            {
                return null;
            }

            return usuarioAutenticado;
        }

        public bool VerificarPermisos(string nombreUsuario, string[] rolesPermitidos)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || rolesPermitidos == null || rolesPermitidos.Length == 0)
            {
                return false;
            }

            try
            {
                var usuario = _loginControlador.ObtenerUsuarioPorNombre(nombreUsuario);
                return usuario != null && Array.Exists(rolesPermitidos, rol =>
                    string.Equals(rol, usuario.Rol, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }

        public bool ValidarSesionActiva(loginM sesion)
        {
            if (sesion == null)
            {
                return false;
            }

            var usuarioActual = _loginControlador.ObtenerUsuarioPorNombre(sesion.NombreUsuario);
            return usuarioActual != null &&
                   string.Equals(usuarioActual.Estado, "activo", StringComparison.OrdinalIgnoreCase);
        }

        private bool ValidarDatosLogin(string usuario, string contrasena)
        {
            return !string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(contrasena);
        }
    }
}