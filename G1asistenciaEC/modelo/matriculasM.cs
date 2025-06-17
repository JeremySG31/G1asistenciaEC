using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1asistenciaEC.modelo
{
    public class MatriculaM
    {
        public string Id { get; set; }
        public string IdEstudiante { get; set; }
        public string IdGrado { get; set; }
        public System.DateTime FechaMatricula { get; set; }
        public string IdApoderado { get; set; }
        public string IdSeccion { get; set; }
        public string IdTurno { get; set; }
        public string IdAnioLectivo { get; set; }
        public string Estado { get; set; }
        public string NombreEstudiante { get; set; }
        public string NombreGrado { get; set; }
        public string NombreSeccion { get; set; }
        public string NombreTurno { get; set; }
        public string NombreAnioLectivo { get; set; }
        public string NombreApoderado { get; set; }
    }

    public class ComboItemM
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
