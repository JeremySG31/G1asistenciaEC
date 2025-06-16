using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC
{
    public partial class FormApoderado : Form
    {
        private apoderadoM _apoderado;

        public FormApoderado(string usuario)
        {
            InitializeComponent();
            this.Text = "Panel del Apoderado";

            var controlador = new apoderadoN();
            _apoderado = controlador.ObtenerInformacionApoderado(usuario);

        }
    }
}
