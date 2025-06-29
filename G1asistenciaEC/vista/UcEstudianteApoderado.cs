using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace G1asistenciaEC.vista
{
    public partial class UcEstudianteApoderado : UserControl
    {
        private readonly EstudianteApoderadoN _negocio = new EstudianteApoderadoN();
        private List<EstudianteApoderadoM> _listaOriginal = new List<EstudianteApoderadoM>();

        public UcEstudianteApoderado()
        {
            InitializeComponent();
            CargarCombos();
            CargarEstudianteApoderados();
            ConfigurarEventos();
            PoblarColumnasBusqueda();
        }

        private void ConfigurarEventos()
        {
            button1.Click += btnInsertar_Click;
            button2.Click += btnModificar_Click;
            button3.Click += btnEliminar_Click;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void CargarCombos()
        {
            cbIdEstudiante.Items.Clear();
            foreach (var est in _negocio.ObtenerEstudiantes())
                cbIdEstudiante.Items.Add(new ComboBoxItem($"{est.Key} - {est.Value}", est.Key));

            cbIdApoderado.Items.Clear();
            foreach (var apo in _negocio.ObtenerApoderados())
                cbIdApoderado.Items.Add(new ComboBoxItem($"{apo.Key} - {apo.Value}", apo.Key));

            cbPrioridad.Items.Clear();
            cbPrioridad.Items.Add(new ComboBoxItem("1 - Muy baja", 1));
            cbPrioridad.Items.Add(new ComboBoxItem("2 - Baja", 2));
            cbPrioridad.Items.Add(new ComboBoxItem("3 - Media", 3));
            cbPrioridad.Items.Add(new ComboBoxItem("4 - Alta", 4));
            cbPrioridad.Items.Add(new ComboBoxItem("5 - Muy alta", 5));
            cbPrioridad.SelectedIndex = 2;

            cbEstado.Items.Clear();
            cbEstado.Items.Add("activo");
            cbEstado.Items.Add("inactivo");
            cbEstado.SelectedIndex = 0;
        }

        private void CargarEstudianteApoderados()
        {
            try
            {
                _listaOriginal = _negocio.ObtenerTodos();
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = _listaOriginal;
                ConfigurarColumnas();
                PoblarColumnasBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiante-apoderados: " + ex.Message);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvUsuarios.Columns.Contains("Id"))
                dgvUsuarios.Columns["Id"].HeaderText = "ID";
            if (dgvUsuarios.Columns.Contains("IdEstudiante"))
                dgvUsuarios.Columns["IdEstudiante"].Visible = false;
            if (dgvUsuarios.Columns.Contains("IdApoderado"))
                dgvUsuarios.Columns["IdApoderado"].Visible = false;
            if (dgvUsuarios.Columns.Contains("NombreEstudiante"))
                dgvUsuarios.Columns["NombreEstudiante"].HeaderText = "Estudiante";
            if (dgvUsuarios.Columns.Contains("NombreApoderado"))
                dgvUsuarios.Columns["NombreApoderado"].HeaderText = "Apoderado";
            if (dgvUsuarios.Columns.Contains("Parentesco"))
                dgvUsuarios.Columns["Parentesco"].HeaderText = "Parentesco";
            if (dgvUsuarios.Columns.Contains("Prioridad"))
                dgvUsuarios.Columns["Prioridad"].HeaderText = "Prioridad";
            if (dgvUsuarios.Columns.Contains("Estado"))
                dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
        }

        private void PoblarColumnasBusqueda()
        {
            cbBuscarColumna.Items.Clear();
            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
            {
                if (col.Visible)
                    cbBuscarColumna.Items.Add(col.HeaderText);
            }
            if (cbBuscarColumna.Items.Count > 0)
                cbBuscarColumna.SelectedIndex = 0;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                {
                    MessageBox.Show("Debe completar todos los campos requeridos.");
                    return;
                }

                var estudianteApoderado = new EstudianteApoderadoM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbIdEstudiante.SelectedItem).Value.ToString(),
                    IdApoderado = ((ComboBoxItem)cbIdApoderado.SelectedItem).Value.ToString(),
                    Parentesco = txtParentesco.Text,
                    Prioridad = (int)((ComboBoxItem)cbPrioridad.SelectedItem).Value,
                    Estado = cbEstado.SelectedItem.ToString()
                };

                _negocio.Insertar(estudianteApoderado);
                CargarEstudianteApoderados();
                LimpiarCampos();
                MessageBox.Show("Registro insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar un registro para modificar.");
                    return;
                }
                if (!ValidarCampos())
                {
                    MessageBox.Show("Debe completar todos los campos requeridos.");
                    return;
                }

                var estudianteApoderado = new EstudianteApoderadoM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbIdEstudiante.SelectedItem).Value.ToString(),
                    IdApoderado = ((ComboBoxItem)cbIdApoderado.SelectedItem).Value.ToString(),
                    Parentesco = txtParentesco.Text,
                    Prioridad = (int)((ComboBoxItem)cbPrioridad.SelectedItem).Value,
                    Estado = cbEstado.SelectedItem.ToString()
                };

                _negocio.Modificar(estudianteApoderado);
                CargarEstudianteApoderados();
                LimpiarCampos();
                MessageBox.Show("Registro modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar un registro para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _negocio.Eliminar(txtId.Text);
                    CargarEstudianteApoderados();
                    LimpiarCampos();
                    MessageBox.Show("Registro eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.DataBoundItem is EstudianteApoderadoM ea)
            {
                txtId.Text = ea.Id;
                SeleccionarComboBoxPorValor(cbIdEstudiante, ea.IdEstudiante);
                SeleccionarComboBoxPorValor(cbIdApoderado, ea.IdApoderado);
                txtParentesco.Text = ea.Parentesco;
                SeleccionarComboBoxPorValor(cbPrioridad, ea.Prioridad);
                cbEstado.SelectedItem = ea.Estado;
            }
        }

        private void SeleccionarComboBoxPorValor(ComboBox combo, object valor)
        {
            foreach (ComboBoxItem item in combo.Items)
            {
                if (item.Value.ToString() == valor?.ToString())
                {
                    combo.SelectedItem = item;
                    break;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            cbIdEstudiante.SelectedIndex = -1;
            cbIdApoderado.SelectedIndex = -1;
            txtParentesco.Text = "";
            cbPrioridad.SelectedIndex = 2;
            cbEstado.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) return false;
            if (cbIdEstudiante.SelectedItem == null) return false;
            if (cbIdApoderado.SelectedItem == null) return false;
            if (string.IsNullOrWhiteSpace(txtParentesco.Text)) return false;
            if (cbPrioridad.SelectedItem == null) return false;
            if (cbEstado.SelectedItem == null) return false;
            return true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void FiltrarDatos()
        {
            if (_listaOriginal == null) return;

            string columna = cbBuscarColumna.SelectedItem?.ToString();
            string filtro = txtBuscar.Text.Trim().ToLower();

            var filtrada = _listaOriginal;

            if (!string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(columna))
            {
                switch (columna)
                {
                    case "ID":
                        filtrada = _listaOriginal.FindAll(x => (x.Id ?? "").ToLower().Contains(filtro));
                        break;
                    case "Estudiante":
                        filtrada = _listaOriginal.FindAll(x => (x.NombreEstudiante ?? "").ToLower().Contains(filtro));
                        break;
                    case "Apoderado":
                        filtrada = _listaOriginal.FindAll(x => (x.NombreApoderado ?? "").ToLower().Contains(filtro));
                        break;
                    case "Parentesco":
                        filtrada = _listaOriginal.FindAll(x => (x.Parentesco ?? "").ToLower().Contains(filtro));
                        break;
                    case "Prioridad":
                        filtrada = _listaOriginal.FindAll(x => x.Prioridad.ToString().Contains(filtro));
                        break;
                    case "Estado":
                        filtrada = _listaOriginal.FindAll(x => (x.Estado ?? "").ToLower().Contains(filtro));
                        break;
                    default:
                        filtrada = _listaOriginal;
                        break;
                }
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = filtrada;
            ConfigurarColumnas();
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
