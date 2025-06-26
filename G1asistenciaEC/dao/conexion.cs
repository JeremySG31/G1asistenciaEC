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
            "Data Source=Jeremy;Initial Catalog=G1asistenciaEC;Integrated Security=True;Encrypt=False";
            //"Data Source=176.50.40.239;Initial Catalog=G1asistenciaEC;User ID=sa;Password=12345;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
