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
            CargarRoles();
        }

        private void ConfigurarEventos()
        {
            dgvRoles.SelectionChanged += dgvRoles_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
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

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe ingresar el ID del rol.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del rol.");
                return false;
            }
            return true;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var rol = new RolM
                {
                    Id = txtId.Text,
                    NombreRol = txtNombreRol.Text
                };

                _negocio.Insertar(rol);
                CargarRoles();
                LimpiarCampos();
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
                if (!ValidarCampos())
                    return;

                var rol = new RolM
                {
                    Id = txtId.Text,
                    NombreRol = txtNombreRol.Text
                };

                _negocio.Modificar(rol);
                CargarRoles();
                LimpiarCampos();
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
