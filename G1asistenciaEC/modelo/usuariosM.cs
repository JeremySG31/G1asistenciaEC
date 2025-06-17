using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1asistenciaEC.modelo
{
    public class UsuariosM
    {
        public string Id { get; set; }
        public string IdEstudiante { get; set; }
        public string IdProfesor { get; set; }
        public string IdApoderado { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public string Telefono { get; set; }
    }

    public class RolComboM
    {
        public string Id { get; set; }
        public string NombreRol { get; set; }
    }
}
