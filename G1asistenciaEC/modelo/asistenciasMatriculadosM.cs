using System;

namespace G1asistenciaEC.modelo
{
    public class asistenciasMatriculadosM
    {
        public string Id { get; set; }
        public string IdMatricula { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreEstudiante { get; set; }
        public string NombreGrado { get; set; }
        public string NombreSeccion { get; set; }
        public string CorreoUsuario { get; set; }
    }
}