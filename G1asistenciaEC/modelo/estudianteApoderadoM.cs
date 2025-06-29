using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1asistenciaEC.modelo
{
    public class EstudianteApoderadoM
    {
        public string Id { get; set; }
        public string IdEstudiante { get; set; } = null; // o "";
        public string IdApoderado { get; set; }
        public string Parentesco { get; set; }
        public int Prioridad { get; set; }
        public string Estado { get; set; }
        public string NombreEstudiante { get; set; }
        public string NombreApoderado { get; set; }
    }
}