using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;
using G1asistenciaEC.vista;
using System;
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
            this.Text = "Panel del Administrador";
            _formLogin = formLogin;

            var controlador = new administradorN();
            _administrador = controlador.ObtenerInformacionAdministrador(usuario);
            this.Load += FormAdministrador_Load;
        }

        // Método para mostrar un UserControl en el panel central
        private void MostrarEnPanel(UserControl control)
        {
            panelContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            MostrarUcUsuarios();
        }

        private void MostrarUcUsuarios()
        {
            // Limpia el contenedor antes de agregar el UserControl
            panelContenido.Controls.Clear();

            // Crea una instancia de UcUsuarios y la agrega al panel
            UcUsuarios ucUsuarios = new UcUsuarios();
            ucUsuarios.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(ucUsuarios);
        }

        private void mANTENIMIENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aSISTENCIAMATRICULADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new UcAsistenciaMatriculados());
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
