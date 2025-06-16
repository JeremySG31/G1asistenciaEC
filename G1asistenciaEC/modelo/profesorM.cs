using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace G1asistenciaEC.modelo
{
    public class profesorM : Persona
    {
        public string NombreCompleto => $"{Nombres} {ApellidoPaterno} {ApellidoMaterno}";
        
    }
}