using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using System;
using System.Windows.Forms;

namespace G1asistenciaEC.vista
{
    public partial class UcEstudianteApoderado : UserControl
    {
        private readonly EstudianteApoderadoN _negocio = new EstudianteApoderadoN();

        public UcEstudianteApoderado()
        {
            InitializeComponent();
            CargarEstudianteApoderados();
            CargarCombos();
            dgvEstudianteApoderados.SelectionChanged += dgvEstudianteApoderados_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void CargarCombos()
        {
            cbPrioridad.Items.Clear();
            cbPrioridad.Items.Add(new ComboBoxItem("1 - Muy baja", 1));
            cbPrioridad.Items.Add(new ComboBoxItem("2 - Baja", 2));
            cbPrioridad.Items.Add(new ComboBoxItem("3 - Media", 3));
            cbPrioridad.Items.Add(new ComboBoxItem("4 - Alta", 4));
            cbPrioridad.Items.Add(new ComboBoxItem("5 - Muy alta", 5));
            cbPrioridad.SelectedIndex = 2; // Media por defecto

            cbIdEstudiante.Items.Clear();
            var estudiantes = _negocio.ObtenerEstudiantes();
            foreach (var est in estudiantes)
            {
                cbIdEstudiante.Items.Add(new ComboBoxItem($"{est.Key} - {est.Value}", est.Key));
            }

            cbIdApoderado.Items.Clear();
            var apoderados = _negocio.ObtenerApoderados();
            foreach (var apo in apoderados)
            {
                cbIdApoderado.Items.Add(new ComboBoxItem($"{apo.Key} - {apo.Value}", apo.Key));
            }
        }

        private void CargarEstudianteApoderados()
        {
            try
            {
                var lista = _negocio.ObtenerTodos();
                dgvEstudianteApoderados.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiante-apoderados: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposRequeridos())
                {
                    MessageBox.Show("Debe completar los campos requeridos.");
                    return;
                }

                var estudianteApoderado = new EstudianteApoderadoM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbIdEstudiante.SelectedItem)?.Value.ToString(),
                    IdApoderado = ((ComboBoxItem)cbIdApoderado.SelectedItem)?.Value.ToString(),
                    Parentesco = txtParentesco.Text,
                    Prioridad = (int)((ComboBoxItem)cbPrioridad.SelectedItem)?.Value,
                    Estado = cbEstado.Text
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

                var estudianteApoderado = new EstudianteApoderadoM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbIdEstudiante.SelectedItem)?.Value.ToString(),
                    IdApoderado = ((ComboBoxItem)cbIdApoderado.SelectedItem)?.Value.ToString(),
                    Parentesco = txtParentesco.Text,
                    Prioridad = (int)((ComboBoxItem)cbPrioridad.SelectedItem)?.Value,
                    Estado = cbEstado.Text
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

        private void dgvEstudianteApoderados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstudianteApoderados.CurrentRow != null)
            {
                var estudianteApoderado = dgvEstudianteApoderados.CurrentRow.DataBoundItem as EstudianteApoderadoM;
                if (estudianteApoderado != null)
                {
                    txtId.Text = estudianteApoderado.Id;

                    foreach (ComboBoxItem item in cbIdEstudiante.Items)
                    {
                        if (item.Value.ToString() == estudianteApoderado.IdEstudiante)
                        {
                            cbIdEstudiante.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (ComboBoxItem item in cbIdApoderado.Items)
                    {
                        if (item.Value.ToString() == estudianteApoderado.IdApoderado)
                        {
                            cbIdApoderado.SelectedItem = item;
                            break;
                        }
                    }

                    txtParentesco.Text = estudianteApoderado.Parentesco;

                    foreach (ComboBoxItem item in cbPrioridad.Items)
                    {
                        if ((int)item.Value == estudianteApoderado.Prioridad)
                        {
                            cbPrioridad.SelectedItem = item;
                            break;
                        }
                    }

                    cbEstado.Text = estudianteApoderado.Estado;
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
            cbEstado.Text = "";
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

        private void UcEstudianteApoderado_Load(object sender, EventArgs e)
        {

        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool ValidarCamposRequeridos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
                return false;
            if (cbIdEstudiante.SelectedItem == null)
                return false;
            if (cbIdApoderado.SelectedItem == null)
                return false;
            if (string.IsNullOrWhiteSpace(txtParentesco.Text))
                return false;
            if (cbPrioridad.SelectedItem == null)
                return false;
            if (string.IsNullOrWhiteSpace(cbEstado.Text))
                return false;
            return true;
        }
    }
}
