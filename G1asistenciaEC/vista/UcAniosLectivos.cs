using System;
using System.Collections.Generic;
using System.Windows.Forms;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.vista
{
    public partial class UcAniosLectivos : UserControl
    {
        private AniosLectivosC controlador = new AniosLectivosC();

        public UcAniosLectivos()
        {
            InitializeComponent();
            CargarAniosLectivos();
            CargarEstados();
            ConfigurarRestricciones();
            dgvAniosLectivos.SelectionChanged += dgvAniosLectivos_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ConfigurarRestricciones()
        {
            txtId.MaxLength = 6;
            txtId.KeyPress += TxtId_KeyPress;
            txtNombre.MaxLength = 4;
            txtNombre.KeyPress += TxtNombre_KeyPress;
            txtDescripcion.MaxLength = 100;
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras y dígitos, pero no espacios ni símbolos
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números para el año
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CargarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add("activo");
            cbEstado.Items.Add("inactivo");
            cbEstado.SelectedIndex = 0;
        }

        private void CargarAniosLectivos()
        {
            try
            {
                var lista = controlador.ObtenerTodos();
                dgvAniosLectivos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar años lectivos: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                var anio = new aniosLectivosM
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Estado = cbEstado.SelectedItem.ToString()
                };
                controlador.Insertar(anio);
                CargarAniosLectivos();
                LimpiarCampos();
                MessageBox.Show("Año lectivo insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar año lectivo: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del año lectivo a modificar.");
                    return;
                }
                var anio = new aniosLectivosM
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Estado = cbEstado.SelectedItem.ToString()
                };
                controlador.Modificar(anio);
                CargarAniosLectivos();
                LimpiarCampos();
                MessageBox.Show("Año lectivo modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar año lectivo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del año lectivo a eliminar.");
                    return;
                }
                controlador.Eliminar(int.Parse(txtId.Text));
                CargarAniosLectivos();
                LimpiarCampos();
                MessageBox.Show("Año lectivo eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar año lectivo: " + ex.Message);
            }
        }

        private void dgvAniosLectivos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAniosLectivos.CurrentRow != null && dgvAniosLectivos.CurrentRow.Index >= 0)
            {
                var row = dgvAniosLectivos.CurrentRow.DataBoundItem as aniosLectivosM;
                if (row != null)
                {
                    txtId.Text = row.Id.ToString();
                    txtNombre.Text = row.Nombre;
                    txtDescripcion.Text = row.Descripcion;
                    cbEstado.SelectedItem = row.Estado;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cbEstado.SelectedIndex = 0;
        }
    }
}
