using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.negocio
{
    public class GradosSeccionesN
    {
        private readonly GradosSeccionesC _controlador = new GradosSeccionesC();

        public List<EstudianteComboM> ObtenerEstudiantes()
        {
            return _controlador.ObtenerEstudiantes();
        }

        public List<GradoM> ObtenerGrados()
        {
            return _controlador.ObtenerGrados();
        }

        public List<SeccionM> ObtenerSecciones()
        {
            return _controlador.ObtenerSecciones();
        }

        public void InsertarGrado(GradoM grado)
        {
            _controlador.InsertarGrado(grado);
        }

        public void ModificarGrado(GradoM grado)
        {
            _controlador.ModificarGrado(grado);
        }

        public void EliminarGrado(string id)
        {
            _controlador.EliminarGrado(id);
        }

        public void InsertarSeccion(SeccionM seccion)
        {
            _controlador.InsertarSeccion(seccion);
        }

        public void ModificarSeccion(SeccionM seccion)
        {
            _controlador.ModificarSeccion(seccion);
        }

        public void EliminarSeccion(string id)
        {
            _controlador.EliminarSeccion(id);
        }
    }
}
