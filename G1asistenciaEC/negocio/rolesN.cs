using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.negocio
{
    public class RolesN
    {
        private readonly RolesC _controlador = new RolesC();

        public List<RolM> ObtenerTodos()
        {
            return _controlador.ObtenerTodos();
        }

        public void Insertar(RolM rol)
        {
            _controlador.Insertar(rol);
        }

        public void Modificar(RolM rol)
        {
            _controlador.Modificar(rol);
        }

        public void Eliminar(string id)
        {
            _controlador.Eliminar(id);
        }
    }
}
