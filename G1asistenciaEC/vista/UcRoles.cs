using System;
using System.Drawing;
using System.Windows.Forms;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;

namespace G1asistenciaEC.vista
{
    public partial class UcRoles : UserControl
    {
        private readonly RolesN _negocio = new RolesN();
        private BindingSource bindingSource = new BindingSource();

        public UcRoles()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarRestricciones();
            CargarRoles();
            LimpiarCampos();
            SugerirSiguienteId();
        }

        private void ConfigurarEventos()
        {
            dgvRoles.SelectionChanged += dgvRoles_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ConfigurarRestricciones()
        {
            txtId.MaxLength = 5;
            txtNombreRol.MaxLength = 20;
            txtNombreRol.KeyPress += TxtNombreRol_KeyPress;
        }

        private void TxtNombreRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void CargarRoles()
        {
            try
            {
                var roles = _negocio.ObtenerTodos();
                dgvRoles.DataSource = roles;
                ConfigurarColumnasRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }

        private void ConfigurarColumnasRoles()
        {
            if (dgvRoles.Columns.Contains("Id"))
                dgvRoles.Columns["Id"].HeaderText = "ID";
            if (dgvRoles.Columns.Contains("NombreRol"))
                dgvRoles.Columns["NombreRol"].HeaderText = "Nombre del Rol";
        }

        private void SugerirSiguienteId()
        {
            var roles = _negocio.ObtenerTodos();
            int max = 0;
            foreach (var rol in roles)
            {
                if (!string.IsNullOrEmpty(rol.Id) && rol.Id.StartsWith("R") && int.TryParse(rol.Id.Substring(1), out int num))
                {
                    if (num > max) max = num;
                }
            }
            txtId.Text = $"R{(max + 1)}";
        }

        private bool ValidarCampos(bool esInsertar = true)
        {
            string errores = "";
            if (string.IsNullOrWhiteSpace(txtId.Text))
                errores += "- Debe ingresar el ID del rol.\n";
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtId.Text, @"^R\d{1,4}$"))
                errores += "- El ID debe tener el formato R seguido de hasta 4 números (ejemplo: R1, R01, R1234).\n";
            if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
                errores += "- Debe ingresar el nombre del rol.\n";
            else if (txtNombreRol.Text.Length > 20)
                errores += "- El nombre del rol no puede exceder 20 caracteres.\n";
            else if (!EsSoloLetras(txtNombreRol.Text))
                errores += "- El nombre del rol solo puede contener letras y espacios.\n";
            if (esInsertar && IdRolExiste(txtId.Text))
                errores += "- El ID ya existe.\n";
            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show("Por favor corrija los siguientes errores:\n\n" + errores, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool EsSoloLetras(string texto)
        {
            foreach (char c in texto)
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            return true;
        }

        private bool IdRolExiste(string id)
        {
            var roles = _negocio.ObtenerTodos();
            foreach (var rol in roles)
            {
                if (rol.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(true))
                    return;

                var rol = new RolM
                {
                    Id = txtId.Text,
                    NombreRol = txtNombreRol.Text
                };

                _negocio.Insertar(rol);
                CargarRoles();
                LimpiarCampos();
                SugerirSiguienteId();
                MessageBox.Show("Rol insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar rol: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(false))
                    return;

                var rol = new RolM
                {
                    Id = txtId.Text,
                    NombreRol = txtNombreRol.Text
                };

                _negocio.Modificar(rol);
                CargarRoles();
                LimpiarCampos();
                SugerirSiguienteId();
                MessageBox.Show("Rol modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar rol: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar un rol para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar este rol?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _negocio.Eliminar(txtId.Text);
                    CargarRoles();
                    LimpiarCampos();
                    SugerirSiguienteId();
                    MessageBox.Show("Rol eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar rol: " + ex.Message);
            }
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow != null && dgvRoles.CurrentRow.Index >= 0)
            {
                var rol = dgvRoles.CurrentRow.DataBoundItem as RolM;
                if (rol != null)
                {
                    txtId.Text = rol.Id;
                    txtNombreRol.Text = rol.NombreRol;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombreRol.Text = "";
        }
    }
}
