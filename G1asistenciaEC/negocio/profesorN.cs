using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;

namespace G1asistenciaEC.negocio // Cambiado a G1asistenciaEC.negocio
{
    public class profesorN
    {
        private readonly negocio.profesorC _controlador;

        public profesorN()
        {
            _controlador = new negocio.profesorC();
        }

        public profesorM ObtenerInformacionProfesor(string usuario)
        {
            var profesor = _controlador.ObtenerProfesorPorUsuario(usuario);
            if (profesor == null)
                throw new Exception("No se encontró información del profesor");
            return profesor;
        }

        public void ActualizarInformacionProfesor(profesorM profesor)
        {
            if (profesor == null)
                throw new ArgumentNullException(nameof(profesor));
            
            _controlador.ActualizarProfesor(profesor);
        }
    }
}