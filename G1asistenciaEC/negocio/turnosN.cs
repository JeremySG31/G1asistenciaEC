using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.negocio
{
    public class TurnoN
    {
        private readonly TurnoC _controlador = new TurnoC();

        public List<TurnoM> ObtenerTodos()
        {
            return _controlador.ObtenerTodos();
        }

        public List<EstudianteTurnoM> ObtenerEstudiantes()
        {
            return _controlador.ObtenerEstudiantes();
        }

        public void Insertar(TurnoM turno)
        {
            _controlador.Insertar(turno);
        }

        public void Modificar(TurnoM turno)
        {
            _controlador.Modificar(turno);
        }

        public void Eliminar(string id)
        {
            _controlador.Eliminar(id);
        }
    }
}
