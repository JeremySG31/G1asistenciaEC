using System;
using System.Data;
using System.Windows.Forms;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;

namespace G1asistenciaEC.vista
{
    public partial class UcUsuarios : UserControl
    {
        private readonly UsuariosN _usuariosNegocio;

        public UcUsuarios()
        {
            InitializeComponent();
            _usuariosNegocio = new UsuariosN();
            ConfigurarEventos();
            CargarDatosIniciales();
            // Llama a esta función para establecer el estado inicial de los campos ID
            ActualizarEstadoCamposIDs();
        }

        private void ConfigurarEventos()
        {
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            cbRol.SelectedIndexChanged += cbRol_SelectedIndexChanged;
            chkIdEstudiante.CheckedChanged += chkIdEstudiante_CheckedChanged;
            chkIdProfesor.CheckedChanged += chkIdProfesor_CheckedChanged;
            chkIdApoderado.CheckedChanged += chkIdApoderado_CheckedChanged;
        }

        private void CargarDatosIniciales()
        {
            CargarUsuarios();
            CargarCombos();
        }

        private void CargarUsuarios()
        {
            try
            {
                var dt = _usuariosNegocio.ObtenerTodos();
                dgvUsuarios.DataSource = dt;
                ConfigurarColumnasFiltrado(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void ConfigurarColumnasFiltrado(DataTable dt)
        {
            cbBuscarColumna.Items.Clear();
            foreach (DataColumn col in dt.Columns)
                cbBuscarColumna.Items.Add(col.ColumnName);
            if (cbBuscarColumna.Items.Count > 0)
                cbBuscarColumna.SelectedIndex = 0;
        }

        private void CargarCombos()
        {
            try
            {
                cbRol.Items.Clear();
                var roles = _usuariosNegocio.ObtenerRoles();
                foreach (var rol in roles)
                {
                    cbRol.Items.Add(new ComboBoxItem
                    {
                        Text = rol.NombreRol,
                        Value = rol.Id
                    });
                }
                cbRol.DisplayMember = "Text";
                cbRol.ValueMember = "Value";

                cbEstado.Items.Clear();
                cbEstado.Items.Add("activo");
                cbEstado.Items.Add("inactivo");
                if (cbEstado.Items.Count > 0)
                {
                    cbEstado.SelectedIndex = 0; // Seleccionar el primero por defecto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de combos: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = ObtenerDatosFormulario();
                _usuariosNegocio.Insertar(usuario);
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar un usuario para modificar.");
                    return;
                }

                var usuario = ObtenerDatosFormulario();
                _usuariosNegocio.Modificar(usuario);
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar un usuario para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _usuariosNegocio.Eliminar(txtId.Text);
                    CargarUsuarios();
                    LimpiarCampos();
                    MessageBox.Show("Usuario eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.Index >= 0)
            {
                CargarDatosEnFormulario(dgvUsuarios.CurrentRow);
                // Cuando se carga un usuario, también actualiza el estado de los campos ID
                ActualizarEstadoCamposIDs();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.DataSource is DataTable dt && cbBuscarColumna.SelectedItem != null)
            {
                AplicarFiltro(dt, cbBuscarColumna.SelectedItem.ToString(), txtBuscar.Text);
            }
        }

        private void AplicarFiltro(DataTable dt, string columna, string filtro)
        {
            filtro = filtro.Replace("'", "''");
            dt.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                ? ""
                : $"CONVERT([{columna}], System.String) LIKE '%{filtro}%'";
        }

        private UsuariosM ObtenerDatosFormulario()
        {
            return new UsuariosM
            {
                Id = txtId.Text,
                IdEstudiante = chkIdEstudiante.Checked ? txtIdEstudiante.Text : null,
                IdProfesor = chkIdProfesor.Checked ? txtIdProfesor.Text : null,
                IdApoderado = chkIdApoderado.Checked ? txtIdApoderado.Text : null,
                NombreUsuario = txtNombreUsuario.Text,
                Nombres = txtNombres.Text,
                ApePaterno = txtApePaterno.Text,
                ApeMaterno = txtApeMaterno.Text,
                Dni = txtDni.Text,
                Correo = txtCorreo.Text,
                Contrasena = txtContrasena.Text,
                Rol = (cbRol.SelectedItem as ComboBoxItem)?.Value?.ToString(),
                Estado = cbEstado.Text,
                Telefono = txtTelefono.Text
            };
        }

        private void CargarDatosEnFormulario(DataGridViewRow row)
        {
            txtId.Text = row.Cells["id"].Value?.ToString();
            txtNombreUsuario.Text = row.Cells["nombre_usuario"].Value?.ToString();
            txtNombres.Text = row.Cells["nombres"].Value?.ToString();
            txtApePaterno.Text = row.Cells["ape_paterno"].Value?.ToString();
            txtApeMaterno.Text = row.Cells["ape_materno"].Value?.ToString();
            txtDni.Text = row.Cells["dni"].Value?.ToString();
            txtCorreo.Text = row.Cells["correo"].Value?.ToString();
            txtContrasena.Text = row.Cells["contrasena"].Value?.ToString();
            cbRol.Text = row.Cells["rol"].Value?.ToString(); // Esto debería funcionar si el DisplayMember es "Text"
            cbEstado.Text = row.Cells["estado"].Value?.ToString();
            txtTelefono.Text = row.Cells["telefono"].Value?.ToString();

            string idEstudiante = row.Cells["id_estudiante"].Value?.ToString();
            chkIdEstudiante.Checked = !string.IsNullOrEmpty(idEstudiante);
            txtIdEstudiante.Text = idEstudiante;

            string idProfesor = row.Cells["id_profesor"].Value?.ToString();
            chkIdProfesor.Checked = !string.IsNullOrEmpty(idProfesor);
            txtIdProfesor.Text = idProfesor;

            string idApoderado = row.Cells["id_apoderado"].Value?.ToString();
            chkIdApoderado.Checked = !string.IsNullOrEmpty(idApoderado);
            txtIdApoderado.Text = idApoderado;

            ActualizarEstadoCamposIDs(); // Asegura que los campos estén habilitados/deshabilitados correctamente
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombreUsuario.Text = "";
            txtNombres.Text = "";
            txtApePaterno.Text = "";
            txtApeMaterno.Text = "";
            txtDni.Text = "";
            txtCorreo.Text = "";
            txtContrasena.Text = "";
            cbRol.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtTelefono.Text = "";

            chkIdEstudiante.Checked = false;
            chkIdProfesor.Checked = false;
            chkIdApoderado.Checked = false;
        }

        private void ActualizarEstadoCamposIDs()
        {
            txtIdEstudiante.Enabled = txtIdEstudiante.Visible;
            txtIdProfesor.Enabled = txtIdProfesor.Visible;
            txtIdApoderado.Enabled = txtIdApoderado.Visible;
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No hacer nada aquí respecto a los checkboxes, el usuario los marca manualmente
        }

        private void chkIdEstudiante_CheckedChanged(object sender, EventArgs e)
        {
            lblIdEstudiante.Visible = chkIdEstudiante.Checked;
            txtIdEstudiante.Visible = chkIdEstudiante.Checked;
            txtIdEstudiante.Enabled = chkIdEstudiante.Checked;
            if (!chkIdEstudiante.Checked) txtIdEstudiante.Text = "";
        }

        private void chkIdProfesor_CheckedChanged(object sender, EventArgs e)
        {
            lblIdProfesor.Visible = chkIdProfesor.Checked;
            txtIdProfesor.Visible = chkIdProfesor.Checked;
            txtIdProfesor.Enabled = chkIdProfesor.Checked;
            if (!chkIdProfesor.Checked) txtIdProfesor.Text = "";
        }

        private void chkIdApoderado_CheckedChanged(object sender, EventArgs e)
        {
            lblIdApoderado.Visible = chkIdApoderado.Checked;
            txtIdApoderado.Visible = chkIdApoderado.Checked;
            txtIdApoderado.Enabled = chkIdApoderado.Checked;
            if (!chkIdApoderado.Checked) txtIdApoderado.Text = "";
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }
    }
}