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
        }

        private void ConfigurarEventos()
        {
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
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
                IdEstudiante = txtIdEstudiante.Text,
                IdProfesor = txtIdProfesor.Text,
                IdApoderado = txtIdApoderado.Text,
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
            txtIdEstudiante.Text = row.Cells["id_estudiante"].Value?.ToString();
            txtIdProfesor.Text = row.Cells["id_profesor"].Value?.ToString();
            txtIdApoderado.Text = row.Cells["id_apoderado"].Value?.ToString();
            txtNombreUsuario.Text = row.Cells["nombre_usuario"].Value?.ToString();
            txtNombres.Text = row.Cells["nombres"].Value?.ToString();
            txtApePaterno.Text = row.Cells["ape_paterno"].Value?.ToString();
            txtApeMaterno.Text = row.Cells["ape_materno"].Value?.ToString();
            txtDni.Text = row.Cells["dni"].Value?.ToString();
            txtCorreo.Text = row.Cells["correo"].Value?.ToString();
            txtContrasena.Text = row.Cells["contrasena"].Value?.ToString();
            cbRol.Text = row.Cells["rol"].Value?.ToString();
            cbEstado.Text = row.Cells["estado"].Value?.ToString();
            txtTelefono.Text = row.Cells["telefono"].Value?.ToString();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtIdEstudiante.Text = "";
            txtIdProfesor.Text = "";
            txtIdApoderado.Text = "";
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
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }
    }
}