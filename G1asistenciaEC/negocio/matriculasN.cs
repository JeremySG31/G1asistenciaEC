using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.negocio
{
    public class MatriculasN
    {
        private readonly MatriculasC _controlador = new MatriculasC();

        public List<MatriculaM> ObtenerTodos()
        {
            return _controlador.ObtenerTodos();
        }

        public List<ComboItemM> ObtenerEstudiantes()
        {
            return _controlador.ObtenerEstudiantes();
        }

        public List<ComboItemM> ObtenerGrados()
        {
            return _controlador.ObtenerGrados();
        }

        public List<ComboItemM> ObtenerSecciones()
        {
            return _controlador.ObtenerSecciones();
        }

        public List<ComboItemM> ObtenerTurnos()
        {
            return _controlador.ObtenerTurnos();
        }

        public List<ComboItemM> ObtenerAniosLectivos()
        {
            return _controlador.ObtenerAniosLectivos();
        }

        public List<ComboItemM> ObtenerApoderados()
        {
            return _controlador.ObtenerApoderados();
        }

        public void Insertar(MatriculaM matricula)
        {
            _controlador.Insertar(matricula);
        }

        public void Modificar(MatriculaM matricula)
        {
            _controlador.Modificar(matricula);
        }

        public void Eliminar(string id)
        {
            _controlador.Eliminar(id);
        }
    }
}
