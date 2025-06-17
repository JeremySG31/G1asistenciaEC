using System;
using System.Drawing;
using System.Windows.Forms;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;

namespace G1asistenciaEC.vista
{
    public partial class UcTurnos : UserControl
    {
        private readonly TurnoN _negocio = new TurnoN();
        private BindingSource bindingSource = new BindingSource();

        public UcTurnos()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarEventos();
            CargarEstudiantes();
            CargarTurnos();
        }

        private void ConfigurarDataGridView()
        {
            dgvTurnos.AutoGenerateColumns = true;
            dgvTurnos.AllowUserToAddRows = true;
            dgvTurnos.MultiSelect = false;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.BackgroundColor = Color.White;
            dgvTurnos.BorderStyle = BorderStyle.Fixed3D;
            dgvTurnos.RowHeadersVisible = true;
            dgvTurnos.AllowUserToAddRows = true;
        }

        private void ConfigurarEventos()
        {
            dgvTurnos.SelectionChanged += dgvTurnos_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void CargarEstudiantes()
        {
            cbEstudiante.Items.Clear();
            var estudiantes = _negocio.ObtenerEstudiantes();
            foreach (var est in estudiantes)
            {
                cbEstudiante.Items.Add(new ComboBoxItem($"{est.Id}-{est.NombreCompleto}", est.Id));
            }
            if (cbEstudiante.Items.Count > 0)
                cbEstudiante.SelectedIndex = 0;
        }

        private void CargarTurnos()
        {
            try
            {
                var turnos = _negocio.ObtenerTodos();
                bindingSource.DataSource = turnos;
                dgvTurnos.DataSource = bindingSource;

                ConfigurarColumnasTurnos();

                dgvTurnos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void ConfigurarColumnasTurnos()
        {
            try
            {
                if (dgvTurnos.Columns.Count == 0)
                {
                    MessageBox.Show("No se han generado columnas en el DataGridView");
                    return;
                }

                if (dgvTurnos.Columns.Contains("Id"))
                {
                    dgvTurnos.Columns["Id"].HeaderText = "ID";
                    dgvTurnos.Columns["Id"].Width = 100;
                }

                if (dgvTurnos.Columns.Contains("Nombre"))
                {
                    dgvTurnos.Columns["Nombre"].HeaderText = "Nombre";
                    dgvTurnos.Columns["Nombre"].Width = 200;
                }

                if (dgvTurnos.Columns.Contains("IdEstudiante"))
                {
                    dgvTurnos.Columns["IdEstudiante"].Visible = false;
                }

                if (dgvTurnos.Columns.Contains("NombreEstudiante"))
                {
                    dgvTurnos.Columns["NombreEstudiante"].HeaderText = "Estudiante";
                    dgvTurnos.Columns["NombreEstudiante"].Width = 250;
                }

      
                if (dgvTurnos.Columns.Contains("Id") &&
                    dgvTurnos.Columns.Contains("Nombre") &&
                    dgvTurnos.Columns.Contains("NombreEstudiante"))
                {
                    dgvTurnos.Columns["Id"].DisplayIndex = 0;
                    dgvTurnos.Columns["Nombre"].DisplayIndex = 1;
                    dgvTurnos.Columns["NombreEstudiante"].DisplayIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe ingresar el ID del turno.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del turno.");
                return false;
            }
            if (cbEstudiante.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estudiante.");
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

                var turno = new TurnoM
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString()
                };

                _negocio.Insertar(turno);
                CargarTurnos();
                LimpiarCampos();
                MessageBox.Show("Turno insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar turno: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var turno = new TurnoM
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString()
                };

                _negocio.Modificar(turno);
                CargarTurnos();
                LimpiarCampos();
                MessageBox.Show("Turno modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar turno: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar un turno para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar este turno?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _negocio.Eliminar(txtId.Text);
                    CargarTurnos();
                    LimpiarCampos();
                    MessageBox.Show("Turno eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar turno: " + ex.Message);
            }
        }

        private void dgvTurnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow != null && dgvTurnos.CurrentRow.Index >= 0 && !dgvTurnos.CurrentRow.IsNewRow)
            {
                var turno = dgvTurnos.CurrentRow.DataBoundItem as TurnoM;
                if (turno != null)
                {
                    txtId.Text = turno.Id;
                    txtNombre.Text = turno.Nombre;
                    SeleccionarComboBoxPorValor(cbEstudiante, turno.IdEstudiante);
                }
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void SeleccionarComboBoxPorValor(ComboBox combo, object valor)
        {
            foreach (ComboBoxItem item in combo.Items)
            {
                if ((item.Value == null && valor == null) ||
                    (item.Value != null && item.Value.ToString() == valor?.ToString()))
                {
                    combo.SelectedItem = item;
                    break;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cbEstudiante.SelectedIndex = 0;
        }



        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public ComboBoxItem(string text, object value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }
    }
}
