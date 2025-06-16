using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1asistenciaEC.modelo;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC.negocio
{
    public class AniosLectivosN
    {
        private AniosLectivosC controlador = new AniosLectivosC();

        public List<aniosLectivosM> ObtenerTodos()
        {
            return controlador.ObtenerTodos();
        }

        public void Insertar(aniosLectivosM anio)
        {
            controlador.Insertar(anio);
        }

        public void Modificar(aniosLectivosM anio)
        {
            controlador.Modificar(anio);
        }

        public void Eliminar(int id)
        {
            controlador.Eliminar(id);
        }
    }
}
