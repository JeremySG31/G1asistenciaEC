using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1asistenciaEC.modelo
{
    public class profesorM : Persona
    {
        public string Id { get; set; }
        
        public string NombreCompleto
        {
            get { return $"{Nombres} {ApellidoPaterno} {ApellidoMaterno}"; }
        }
    }
}