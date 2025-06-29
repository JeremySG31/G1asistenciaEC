using System;
using System.Collections.Generic;
using System.Windows.Forms;
using G1asistenciaEC.negocio;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.vista
{
    public partial class UcCursos : UserControl
    {
        private CursoN negocio = new CursoN();

        public UcCursos()
        {
            InitializeComponent();
            CargarCursos();
            ConfigurarRestricciones();
            dgvCursos.SelectionChanged += dgvCursos_SelectionChanged;
            btnInsertarCurso.Click += btnInsertarCurso_Click;
            btnModificarCurso.Click += btnModificarCurso_Click;
            btnEliminarCurso.Click += btnEliminarCurso_Click;
        }

        private void ConfigurarRestricciones()
        {
            txtIdCurso.MaxLength = 10;
            txtIdCurso.KeyPress += TxtIdCurso_KeyPress;
            txtNombreCurso.MaxLength = 30;
            txtNombreCurso.KeyPress += TxtNombreCurso_KeyPress;
        }

        private void TxtIdCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras y dígitos, pero no espacios ni símbolos
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtNombreCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo letras y espacios
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void CargarCursos()
        {
            try
            {
                var lista = negocio.ObtenerTodos();
                dgvCursos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cursos: " + ex.Message);
            }
        }

        private void btnInsertarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                var curso = new CursoM
                {
                    Id = txtIdCurso.Text,
                    Nombre = txtNombreCurso.Text,
                    Descripcion = txtDescripcionCurso.Text
                };
                negocio.Insertar(curso);
                CargarCursos();
                LimpiarCampos();
                MessageBox.Show("Curso insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar curso: " + ex.Message);
            }
        }

        private void btnModificarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdCurso.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del curso a modificar.");
                    return;
                }
                var curso = new CursoM
                {
                    Id = txtIdCurso.Text,
                    Nombre = txtNombreCurso.Text,
                    Descripcion = txtDescripcionCurso.Text
                };
                negocio.Modificar(curso);
                CargarCursos();
                LimpiarCampos();
                MessageBox.Show("Curso modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar curso: " + ex.Message);
            }
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdCurso.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del curso a eliminar.");
                    return;
                }
                negocio.Eliminar(txtIdCurso.Text);
                CargarCursos();
                LimpiarCampos();
                MessageBox.Show("Curso eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar curso: " + ex.Message);
            }
        }

        private void dgvCursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow != null && dgvCursos.CurrentRow.Index >= 0)
            {
                var row = dgvCursos.CurrentRow.DataBoundItem as CursoM;
                if (row != null)
                {
                    txtIdCurso.Text = row.Id.ToString();
                    txtNombreCurso.Text = row.Nombre;
                    txtDescripcionCurso.Text = row.Descripcion;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtIdCurso.Text = "";
            txtNombreCurso.Text = "";
            txtDescripcionCurso.Text = "";
        }
    }
}
