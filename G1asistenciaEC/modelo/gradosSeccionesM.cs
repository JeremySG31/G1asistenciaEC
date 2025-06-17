using System;

namespace G1asistenciaEC.modelo
{
    public class GradoM
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string IdEstudiante { get; set; }
        public string Nivel { get; set; }
        public string NombreEstudiante { get; set; }  // Para mostrar en la UI
    }

    public class SeccionM
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }  // Para mostrar en la UI
    }

    public class EstudianteComboM
    {
        public string Id { get; set; }
        public string NombreCompleto { get; set; }
    }
}
