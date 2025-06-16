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
    public class apoderadoN
    {
        private negocio.apoderadoC _negocio = new negocio.apoderadoC();

        public apoderadoM ObtenerInformacionApoderado(string usuario)
        {
            return _negocio.ObtenerApoderadoPorUsuario(usuario);
        }
    }
}
