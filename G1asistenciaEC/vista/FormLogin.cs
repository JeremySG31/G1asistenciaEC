using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using G1asistenciaEC.dao;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            campo_contrasenia.UseSystemPasswordChar = true;
            checkBoxMostrar.CheckedChanged += checkBoxMostrar_CheckedChanged;
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
                var loginControlador = new loginN();
                usuarioM usuarioAutenticado = loginControlador.Login(usuario, contrasenia);

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
