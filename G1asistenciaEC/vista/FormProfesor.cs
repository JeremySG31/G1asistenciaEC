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
using G1asistenciaEC.vista;

namespace G1asistenciaEC
{
    public partial class FormProfesor : Form
    {
        private G1asistenciaEC.modelo.profesorM _profesor; 

        public FormProfesor(string usuario)
        {
            InitializeComponent();
            this.Text = "Panel del Profesor";

            var controlador = new profesorN();
            _profesor = controlador.ObtenerInformacionProfesor(usuario);

            lblNombreProfesor.Text = _profesor.NombreCompleto;
        }



        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
