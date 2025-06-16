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
    public partial class FormEstudiante : Form
    {
        private estudianteM _estudiante;

        public FormEstudiante(string usuario)
        {
            InitializeComponent();
            this.Text = "Panel del Estudiante";

            var controlador = new estudianteN();
            _estudiante = controlador.ObtenerInformacionEstudiante(usuario);


        }
    }
}
