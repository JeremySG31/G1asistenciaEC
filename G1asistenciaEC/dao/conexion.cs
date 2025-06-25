using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias adicionales
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace G1asistenciaEC.dao
{
    public class Conexion
    {
        private static readonly string cadenaConexion =
            "Data Source=DESKTOP-PRFS54I;Initial Catalog=G1asistenciaEC;Integrated Security=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
