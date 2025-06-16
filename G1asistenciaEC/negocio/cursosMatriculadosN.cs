using System.Collections.Generic;
using G1asistenciaEC.modelo;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC.negocio
{
    public class CursosMatriculadosN
    {
        private CursosMatriculadosC controlador = new CursosMatriculadosC();

        public List<CursosMatriculadosM> ObtenerTodos()
        {
            return controlador.ObtenerTodos();
        }

        public void Insertar(CursosMatriculadosM cursoMat)
        {
            controlador.Insertar(cursoMat);
        }

        public void Modificar(CursosMatriculadosM cursoMat)
        {
            controlador.Modificar(cursoMat);
        }

        public void Eliminar(string id)
        {
            controlador.Eliminar(id);
        }

        public List<KeyValuePair<string, object>> ObtenerMatriculas()
        {
            return controlador.ObtenerMatriculas();
        }

        public List<KeyValuePair<string, object>> ObtenerCursos()
        {
            return controlador.ObtenerCursos();
        }

        public List<KeyValuePair<string, object>> ObtenerEstudiantes()
        {
            return controlador.ObtenerEstudiantes();
        }
    }
}