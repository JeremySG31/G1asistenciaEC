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
    public class estudianteN
    {
        private negocio.estudianteC _negocio = new negocio.estudianteC();

        public estudianteM ObtenerInformacionEstudiante(string usuario)
        {
            return _negocio.ObtenerEstudiantePorUsuario(usuario);
        }

        public estudianteM ObtenerPorDni(string dni)
        {
            return _negocio.ObtenerPorDni(dni);
        }
    }
}
