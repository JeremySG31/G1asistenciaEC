using G1asistenciaEC.controlador;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace G1asistenciaEC
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.Icon = new Icon("resources/ACADEMIX.ico");
            this.Size = new Size(685, 290);
            this.MaximumSize = new Size(685, 275);
            this.MinimumSize = new Size(685, 275);
            this.MaximizeBox = false;
            campo_contrasenia.UseSystemPasswordChar = true;
            checkBoxMostrar.CheckedChanged += checkBoxMostrar_CheckedChanged;
            campo_contrasenia.KeyPress += campo_contrasenia_KeyPress;
            this.AcceptButton = login; 
            campo_contrasenia.KeyDown += CampoContrasenia_KeyDown; 
            campo_usuario.KeyDown += CampoContrasenia_KeyDown; 
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            campo_usuario.Text = string.Empty;
            campo_contrasenia.Text = string.Empty;
            campo_usuario.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = campo_usuario.Text.Trim();
            string contrasenia = campo_contrasenia.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasenia))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            try
            {
                var loginControlador = new LoginN();
                loginM usuarioAutenticado = loginControlador.Login(usuario, contrasenia);

                if (usuarioAutenticado == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return;
                }

                if (!string.Equals(usuarioAutenticado.Estado, "activo", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El usuario está inactivo.");
                    return;
                }

                this.Hide();
                Form formDestino = null;
                switch (usuarioAutenticado.Rol.ToLower())
                {
                    case "profesor":
                        formDestino = new FormProfesor(usuario);
                        break;
                    case "estudiante":
                        formDestino = new FormEstudiante(usuario);
                        break;
                    case "apoderado":
                        formDestino = new FormApoderado(usuario);
                        break;
                    case "administrador":
                        formDestino = new FormAdministrador(usuario, this);
                        break;
                    default:
                        MessageBox.Show("Rol no reconocido.");
                        this.Show();
                        return;
                }
                formDestino.ShowDialog();
                this.Show();
          
                campo_usuario.Text = string.Empty;
                campo_contrasenia.Text = string.Empty;
                campo_usuario.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        private void campo_contrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void CampoContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                button1_Click(login, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void checkBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            campo_contrasenia.UseSystemPasswordChar = !checkBoxMostrar.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
