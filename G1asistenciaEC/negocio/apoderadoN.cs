using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC.negocio
{
    public class apoderadoN
    {
        private apoderadoC _negocio = new apoderadoC();

        public apoderadoM ObtenerInformacionApoderado(string usuario)
        {
            return _negocio.ObtenerApoderadoPorUsuario(usuario);
        }

        public DataTable ObtenerAsistencias(string idApoderado)
        {
            return _negocio.ObtenerAsistenciasPorApoderado(idApoderado);
        }
    }
}

