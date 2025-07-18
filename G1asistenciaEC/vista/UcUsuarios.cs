﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
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
            ConfigurarRestricciones();
            ConfigurarEventos();
            CargarDatosIniciales();
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
            txtDni.KeyPress += ValidarSoloNumeros;
            txtTelefono.KeyPress += ValidarSoloNumeros;
            txtNombres.KeyPress += ValidarSoloLetras;
            txtApePaterno.KeyPress += ValidarSoloLetras;
            txtApeMaterno.KeyPress += ValidarSoloLetras;
            txtId.KeyPress += txtId_KeyPress;
        }

        private void ConfigurarRestricciones()
        {
            txtId.MaxLength = 5;
            txtNombreUsuario.MaxLength = 20;
            txtDni.MaxLength = 8;
            txtContrasena.MaxLength = 12;
            txtTelefono.MaxLength = 9;
            txtNombres.MaxLength = 30;
            txtApePaterno.MaxLength = 20;
            txtApeMaterno.MaxLength = 20;
            txtCorreo.MaxLength = 100;
        }

        private bool ValidarCampos()
        {
            string errores = "";

            // ID Usuario
            if (string.IsNullOrWhiteSpace(txtId.Text))
                errores += "- El campo ID Usuario es obligatorio.\n";
            else if (!Regex.IsMatch(txtId.Text, @"^U\d{2,}$"))
                errores += "- El ID Usuario debe tener el formato U## (ejemplo: U03).\n";

            // DNI
            if (string.IsNullOrWhiteSpace(txtDni.Text))
                errores += "- El campo DNI es obligatorio.\n";
            else if (txtDni.Text.Length != 8 || !EsNumerico(txtDni.Text))
                errores += "- El DNI debe tener 8 dígitos.\n";

            // Nombres
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
                errores += "- El campo Nombres es obligatorio.\n";
            else if (txtNombres.Text.Length > 30)
                errores += "- El campo Nombres no puede exceder 30 caracteres.\n";
            else if (!EsSoloLetras(txtNombres.Text))
                errores += "- El campo Nombres solo puede contener letras y espacios.\n";

            // Apellido Paterno
            if (string.IsNullOrWhiteSpace(txtApePaterno.Text))
                errores += "- El campo Apellido Paterno es obligatorio.\n";
            else if (txtApePaterno.Text.Length > 20)
                errores += "- El campo Apellido Paterno no puede exceder 20 caracteres.\n";
            else if (!EsSoloLetras(txtApePaterno.Text))
                errores += "- El campo Apellido Paterno solo puede contener letras y espacios.\n";

            // Apellido Materno
            if (string.IsNullOrWhiteSpace(txtApeMaterno.Text))
                errores += "- El campo Apellido Materno es obligatorio.\n";
            else if (txtApeMaterno.Text.Length > 20)
                errores += "- El campo Apellido Materno no puede exceder 20 caracteres.\n";
            else if (!EsSoloLetras(txtApeMaterno.Text))
                errores += "- El campo Apellido Materno solo puede contener letras y espacios.\n";

            // Correo
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                errores += "- El campo Correo es obligatorio.\n";
            else if (txtCorreo.Text.Length > 100)
                errores += "- El correo no puede exceder 100 caracteres.\n";
            else if (!txtCorreo.Text.EndsWith("@cole.edu", StringComparison.OrdinalIgnoreCase))
                errores += "- El correo debe terminar con @cole.edu.\n";

            // Teléfono
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && (txtTelefono.Text.Length != 9 || !EsNumerico(txtTelefono.Text)))
                errores += "- El teléfono debe tener 9 dígitos.\n";

            // Usuario
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                errores += "- El campo Usuario es obligatorio.\n";
            else if (txtNombreUsuario.Text.Length > 20)
                errores += "- El campo Usuario no puede exceder 20 caracteres.\n";

            // Contraseña
            if (txtContrasena.Text.Length > 12)
                errores += "- La contraseña no debe exceder 12 caracteres.\n";

            // Rol
            if (cbRol.SelectedItem == null)
                errores += "- Debe seleccionar un Rol.\n";

            // Estado
            if (cbEstado.SelectedItem == null)
                errores += "- Debe seleccionar un Estado.\n";

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show("Por favor corrija los siguientes errores:\n\n" + errores, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool EsNumerico(string texto)
        {
            foreach (char c in texto)
                if (!char.IsDigit(c)) return false;
            return true;
        }

        private bool EsSoloLetras(string texto)
        {
            foreach (char c in texto)
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) return false;
            return true;
        }

        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void ValidarSoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private bool ValidarIdUsuario(string id)
        {
            return Regex.IsMatch(id, @"^U\d{1,4}$");
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
                    cbEstado.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de combos: " + ex.Message);
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            string texto = txtId.Text;

            if (char.IsControl(e.KeyChar))
                return;

            if (texto.Length == 0)
            {
                if (e.KeyChar != 'U')
                    e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (!ValidarIdUsuario(txtId.Text))
            {
                MessageBox.Show("El ID debe empezar con 'U' seguido de hasta 4 números. Ejemplo: U01, U1234");
                return;
            }

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
            if (!ValidarCampos())
                return;

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
            cbRol.Text = row.Cells["rol"].Value?.ToString();
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

            ActualizarEstadoCamposIDs();
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

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}