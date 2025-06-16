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
    public class usuarioN
    {
        private negocio.usuarioC _negocio = new negocio.usuarioC();

        public usuarioM ObtenerInformacionUsuario(string nombreUsuario)
        {
            return _negocio.ObtenerUsuarioPorNombre(nombreUsuario);
        }
    }
}