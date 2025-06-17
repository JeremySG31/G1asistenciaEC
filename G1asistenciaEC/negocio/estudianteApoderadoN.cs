using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.negocio
{
    public class EstudianteApoderadoN
    {
        private readonly EstudianteApoderadoC _controlador = new EstudianteApoderadoC();

        public List<EstudianteApoderadoM> ObtenerTodos()
        {
            return _controlador.ObtenerTodos();
        }

        public void Insertar(EstudianteApoderadoM estudianteApoderado)
        {
            _controlador.Insertar(estudianteApoderado);
        }

        public void Modificar(EstudianteApoderadoM estudianteApoderado)
        {
            _controlador.Modificar(estudianteApoderado);
        }

        public void Eliminar(string id)
        {
            _controlador.Eliminar(id);
        }

        public List<KeyValuePair<string, string>> ObtenerEstudiantes()
        {
            return _controlador.ObtenerEstudiantes();
        }

        public List<KeyValuePair<string, string>> ObtenerApoderados()
        {
            return _controlador.ObtenerApoderados();
        }
    }
}
