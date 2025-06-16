using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;

namespace G1asistenciaEC.controlador
{
    public class administradorN
    {
        private negocio.administradorC _negocio = new negocio.administradorC();

        public administradorM ObtenerInformacionAdministrador(string usuario)
        {
            return _negocio.ObtenerAdministradorPorUsuario(usuario);
        }
    }
}
