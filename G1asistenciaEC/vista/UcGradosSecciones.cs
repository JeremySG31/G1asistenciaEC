using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using G1asistenciaEC.dao;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;

namespace G1asistenciaEC.vista
{
    public partial class UcGradosSecciones : UserControl
    {
        private readonly GradosSeccionesN _negocio = new GradosSeccionesN();

        public UcGradosSecciones()
        {
            InitializeComponent();
            CargarEstudiantes();
            CargarGrados();
            CargarSecciones();
            ConfigurarEventos();
            ConfigurarNiveles();
            ConfigurarCombosGradoSeccion();
            ConfigurarRestricciones();
        }

        private void ConfigurarEventos()
        {
            dgvGrados.SelectionChanged += dgvGrados_SelectionChanged;
            dgvSecciones.SelectionChanged += dgvSecciones_SelectionChanged;
            btnInsertarGrado.Click += btnInsertarGrado_Click;
            btnModificarGrado.Click += btnModificarGrado_Click;
            btnEliminarGrado.Click += btnEliminarGrado_Click;
            btnInsertarSeccion.Click += btnInsertarSeccion_Click;
            btnModificarSeccion.Click += btnModificarSeccion_Click;
            btnEliminarSeccion.Click += btnEliminarSeccion_Click;
        }

        private void ConfigurarNiveles()
        {
            cbNivelGrado.Items.Clear();
            cbNivelGrado.Items.Add("Primaria");
            cbNivelGrado.Items.Add("Secundaria");
            cbNivelGrado.SelectedIndex = 0;
        }

        private void ConfigurarCombosGradoSeccion()
        {
            cbNombreGrado.Items.Clear();
            cbNombreSeccion.Items.Clear();
            ActualizarComboGrados();
            for (char c = 'A'; c <= 'Z'; c++)
                cbNombreSeccion.Items.Add(c.ToString());
            if (cbNombreSeccion.Items.Count > 0)
                cbNombreSeccion.SelectedIndex = 0;
            cbNivelGrado.SelectedIndexChanged += (s, e) => ActualizarComboGrados();
        }

        private void ActualizarComboGrados()
        {
            cbNombreGrado.Items.Clear();
            string[] primaria = { "Primero", "Segundo", "Tercero", "Cuarto", "Quinto", "Sexto" };
            string[] secundaria = { "Primero", "Segundo", "Tercero", "Cuarto", "Quinto" };
            var nivel = cbNivelGrado.SelectedItem?.ToString();
            if (nivel == "Secundaria")
            {
                cbNombreGrado.Items.AddRange(secundaria);
            }
            else
            {
                cbNombreGrado.Items.AddRange(primaria);
            }
            if (cbNombreGrado.Items.Count > 0)
                cbNombreGrado.SelectedIndex = 0;
        }

        private void ConfigurarRestricciones()
        {
            txtIdGrado.MaxLength = 10;
            txtIdGrado.KeyPress += TxtIdGrado_KeyPress;
            txtIdSeccion.MaxLength = 10;
            txtIdSeccion.KeyPress += TxtIdSeccion_KeyPress;
        }

        private void TxtIdGrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtIdSeccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CargarEstudiantes()
        {
            cbEstudianteGrado.Items.Clear();
            cbEstudianteSeccion.Items.Clear();
            var estudiantes = _negocio.ObtenerEstudiantes();
            foreach (var est in estudiantes)
            {
                var item = new ComboBoxItem($"{est.Id}-{est.NombreCompleto}", est.Id);
                cbEstudianteGrado.Items.Add(item);
                cbEstudianteSeccion.Items.Add(item);
            }
            if (cbEstudianteGrado.Items.Count > 0)
                cbEstudianteGrado.SelectedIndex = 0;
            if (cbEstudianteSeccion.Items.Count > 0)
                cbEstudianteSeccion.SelectedIndex = 0;
        }

        private void CargarGrados()
        {
            try
            {
                var grados = _negocio.ObtenerGrados();
                dgvGrados.DataSource = grados;
                ConfigurarColumnasGrados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar grados: " + ex.Message);
            }
        }

        private void CargarSecciones()
        {
            try
            {
                var secciones = _negocio.ObtenerSecciones();
                dgvSecciones.DataSource = secciones;
                ConfigurarColumnasSecciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar secciones: " + ex.Message);
            }
        }

        private void ConfigurarColumnasGrados()
        {
            if (dgvGrados.Columns.Contains("Id"))
                dgvGrados.Columns["Id"].HeaderText = "ID";
            if (dgvGrados.Columns.Contains("IdEstudiante"))
                dgvGrados.Columns["IdEstudiante"].HeaderText = "ID Estudiante";
            if (dgvGrados.Columns.Contains("Nombres"))
            {
                dgvGrados.Columns["Nombres"].HeaderText = "Grados";
                dgvGrados.Columns["Nombres"].HeaderCell.Style.Font = new System.Drawing.Font(
                    dgvGrados.Font, System.Drawing.FontStyle.Bold);
            }
            if (dgvGrados.Columns.Contains("Nivel"))
                dgvGrados.Columns["Nivel"].HeaderText = "Nivel";
            if (dgvGrados.Columns.Contains("NombreEstudiante"))
                dgvGrados.Columns["NombreEstudiante"].HeaderText = "Estudiante";
        }

        private void ConfigurarColumnasSecciones()
        {
            if (dgvSecciones.Columns.Contains("Id"))
                dgvSecciones.Columns["Id"].HeaderText = "ID";
            if (dgvSecciones.Columns.Contains("IdEstudiante"))
                dgvSecciones.Columns["IdEstudiante"].HeaderText = "ID Estudiante";
            if (dgvSecciones.Columns.Contains("Nombre"))
            {
                dgvSecciones.Columns["Nombre"].HeaderText = "Sección";
                dgvSecciones.Columns["Nombre"].HeaderCell.Style.Font = new System.Drawing.Font(
                    dgvSecciones.Font, System.Drawing.FontStyle.Bold);
            }
            if (dgvSecciones.Columns.Contains("NombreEstudiante"))
                dgvSecciones.Columns["NombreEstudiante"].HeaderText = "Estudiante";
        }

        private bool ValidarCamposGrado()
        {
            if (string.IsNullOrWhiteSpace(txtIdGrado.Text))
            {
                MessageBox.Show("Debe ingresar el ID del grado.");
                return false;
            }
            if (cbNombreGrado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el nombre del grado.");
                return false;
            }
            if (cbEstudianteGrado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estudiante.");
                return false;
            }
            if (cbNivelGrado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un nivel.");
                return false;
            }
            return true;
        }

        private bool ValidarCamposSeccion()
        {
            if (string.IsNullOrWhiteSpace(txtIdSeccion.Text))
            {
                MessageBox.Show("Debe ingresar el ID de la sección.");
                return false;
            }
            if (cbNombreSeccion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el nombre de la sección.");
                return false;
            }
            if (cbEstudianteSeccion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estudiante.");
                return false;
            }
            return true;
        }

        private void btnInsertarGrado_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposGrado())
                    return;

                var grado = new GradoM
                {
                    Id = txtIdGrado.Text,
                    Nombres = cbNombreGrado.SelectedItem.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudianteGrado.SelectedItem).Value.ToString(),
                    Nivel = cbNivelGrado.SelectedItem.ToString()
                };
                _negocio.InsertarGrado(grado);
                CargarGrados();
                LimpiarCamposGrado();
                MessageBox.Show("Grado insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar grado: " + ex.Message);
            }
        }

        private void btnModificarGrado_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposGrado())
                    return;

                var grado = new GradoM
                {
                    Id = txtIdGrado.Text,
                    Nombres = cbNombreGrado.SelectedItem.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudianteGrado.SelectedItem).Value.ToString(),
                    Nivel = cbNivelGrado.SelectedItem.ToString()
                };
                _negocio.ModificarGrado(grado);
                CargarGrados();
                LimpiarCamposGrado();
                MessageBox.Show("Grado modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar grado: " + ex.Message);
            }
        }

        private void btnEliminarGrado_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdGrado.Text))
                {
                    MessageBox.Show("Debe seleccionar un grado para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar este grado?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _negocio.EliminarGrado(txtIdGrado.Text);
                    CargarGrados();
                    LimpiarCamposGrado();
                    MessageBox.Show("Grado eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar grado: " + ex.Message);
            }
        }

        private void btnInsertarSeccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposSeccion())
                    return;

                var seccion = new SeccionM
                {
                    Id = txtIdSeccion.Text,
                    Nombre = cbNombreSeccion.SelectedItem.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudianteSeccion.SelectedItem).Value.ToString()
                };
                _negocio.InsertarSeccion(seccion);
                CargarSecciones();
                LimpiarCamposSeccion();
                MessageBox.Show("Sección insertada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar sección: " + ex.Message);
            }
        }

        private void btnModificarSeccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposSeccion())
                    return;

                var seccion = new SeccionM
                {
                    Id = txtIdSeccion.Text,
                    Nombre = cbNombreSeccion.SelectedItem.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudianteSeccion.SelectedItem).Value.ToString()
                };
                _negocio.ModificarSeccion(seccion);
                CargarSecciones();
                LimpiarCamposSeccion();
                MessageBox.Show("Sección modificada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar sección: " + ex.Message);
            }
        }

        private void btnEliminarSeccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdSeccion.Text))
                {
                    MessageBox.Show("Debe seleccionar una sección para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar esta sección?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _negocio.EliminarSeccion(txtIdSeccion.Text);
                    CargarSecciones();
                    LimpiarCamposSeccion();
                    MessageBox.Show("Sección eliminada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar sección: " + ex.Message);
            }
        }

        private void dgvGrados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGrados.CurrentRow != null && dgvGrados.CurrentRow.Index >= 0)
            {
                var grado = dgvGrados.CurrentRow.DataBoundItem as GradoM;
                if (grado != null)
                {
                    txtIdGrado.Text = grado.Id;
                    cbNombreGrado.SelectedItem = grado.Nombres;
                    SeleccionarComboBoxPorValor(cbEstudianteGrado, grado.IdEstudiante);
                    cbNivelGrado.SelectedItem = grado.Nivel;
                }
            }
        }

        private void dgvSecciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSecciones.CurrentRow != null && dgvSecciones.CurrentRow.Index >= 0)
            {
                var seccion = dgvSecciones.CurrentRow.DataBoundItem as SeccionM;
                if (seccion != null)
                {
                    txtIdSeccion.Text = seccion.Id;
                    cbNombreSeccion.SelectedItem = seccion.Nombre;
                    SeleccionarComboBoxPorValor(cbEstudianteSeccion, seccion.IdEstudiante);
                }
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

        private void LimpiarCamposGrado()
        {
            txtIdGrado.Text = "";
            if (cbNombreGrado.Items.Count > 0) cbNombreGrado.SelectedIndex = 0;
            cbEstudianteGrado.SelectedIndex = 0;
            cbNivelGrado.SelectedIndex = 0;
        }

        private void LimpiarCamposSeccion()
        {
            txtIdSeccion.Text = "";
            if (cbNombreSeccion.Items.Count > 0) cbNombreSeccion.SelectedIndex = 0;
            cbEstudianteSeccion.SelectedIndex = 0;
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

        private void cbNivelGrado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void dgvGrados_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}