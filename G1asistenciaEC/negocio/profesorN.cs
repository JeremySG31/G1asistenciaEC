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
    public class profesorN
    {
        private negocio.profesorC _negocio = new negocio.profesorC();

        public profesorM ObtenerInformacionProfesor(string usuario)
        {
            return _negocio.ObtenerProfesorPorUsuario(usuario);
        }
    }
}