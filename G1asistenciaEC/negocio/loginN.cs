using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
namespace G1asistenciaEC.controlador
{
    public class loginN
    {
        private usuarioC usuarioNegocio = new usuarioC();

        public usuarioM Login(string usuario, string contrasenia)
        {
            return usuarioNegocio.Autenticar(usuario, contrasenia);
        }
    }
}