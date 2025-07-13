using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;
using G1asistenciaEC.vista;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace G1asistenciaEC
{
    public partial class FormAdministrador : Form
    {
        private administradorM _administrador;
        private FormLogin _formLogin;

        public FormAdministrador(string usuario, FormLogin formLogin)
        {
            InitializeComponent();
            this.Size = new Size(900, 500); 
            this.MaximumSize = new Size(900, 500);
            this.MinimumSize = new Size(900, 500);
            this.MaximizeBox = false; 
            this.Text = "Panel del Administrador";
            _formLogin = formLogin;

            var controlador = new administradorN();
            _administrador = controlador.ObtenerInformacionAdministrador(usuario);
        }

        private void MostrarEnPanel(UserControl control)
        {
            panelContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }


        private void mANTENIMIENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eSTUDIANTEAPODERADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcEstudianteApoderado());
        }

        private void mATRICULASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcMatriculas());
        }

        private void rOLESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcRoles());
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcUsuarios());
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            _formLogin.Show();
            this.Close();
        }

        private void aDMINISTRARMATRICULASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcMatriculas());
        }

        private void gRADOSYSECCIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcGradosSecciones());
        }

        private void aÑOSLECTIVOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcAniosLectivos());
        }

        private void cURSOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcCursos());
        }

        private void tURNOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcTurnos());
        }

        private void cURSOSPORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcCursosMatriculados());
        }
    }
}
