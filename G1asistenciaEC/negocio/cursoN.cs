using System.Collections.Generic;
using G1asistenciaEC.modelo;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC.negocio
{
    public class CursoN
    {
        private CursosC controlador = new CursosC();

        public List<CursoM> ObtenerTodos()
        {
            return controlador.ObtenerTodos();
        }

        public void Insertar(CursoM curso)
        {
            controlador.Insertar(curso);
        }

        public void Modificar(CursoM curso)
        {
            controlador.Modificar(curso);
        }

        public void Eliminar(string id)
        {
            controlador.Eliminar(id);
        }
    }
}