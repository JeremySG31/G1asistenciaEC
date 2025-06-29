using System;
using System.Windows.Forms;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;

namespace G1asistenciaEC.vista
{
    public partial class UcMatriculas : UserControl
    {
        private readonly MatriculasN _negocio = new MatriculasN();

        public UcMatriculas()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarRestricciones();
            CargarCombos();
            CargarMatriculas();
        }

        private void ConfigurarEventos()
        {
            dgvMatriculas.SelectionChanged += dgvMatriculas_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ConfigurarRestricciones()
        {
            txtId.MaxLength = 5;
            txtId.KeyPress += TxtId_KeyPress;
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CargarCombos()
        {
            cbEstudiante.Items.Clear();
            foreach (var est in _negocio.ObtenerEstudiantes())
            {
                cbEstudiante.Items.Add(new ComboBoxItem($"{est.Id}-{est.Nombre}", est.Id));
            }

            cbGrado.Items.Clear();
            cbNivel.Items.Clear();
            var niveles = new System.Collections.Generic.HashSet<string>();
            foreach (var grado in _negocio.ObtenerGrados())
            {
                cbGrado.Items.Add(new ComboBoxItem($"{grado.Id}-{grado.Nombre} [{grado.Descripcion}]", grado.Id));
                if (!string.IsNullOrWhiteSpace(grado.Descripcion))
                    niveles.Add(grado.Descripcion);
            }
            foreach (var nivel in niveles)
                cbNivel.Items.Add(nivel);
            if (cbNivel.Items.Count > 0)
                cbNivel.SelectedIndex = 0;

            cbSeccion.Items.Clear();
            foreach (var seccion in _negocio.ObtenerSecciones())
            {
                cbSeccion.Items.Add(new ComboBoxItem($"{seccion.Id}-{seccion.Nombre}", seccion.Id));
            }

            cbTurno.Items.Clear();
            foreach (var turno in _negocio.ObtenerTurnos())
            {
                cbTurno.Items.Add(new ComboBoxItem($"{turno.Id}-{turno.Nombre}", turno.Id));
            }

            cbAnioLectivo.Items.Clear();
            foreach (var anio in _negocio.ObtenerAniosLectivos())
            {
                cbAnioLectivo.Items.Add(new ComboBoxItem($"{anio.Id}-{anio.Nombre}", anio.Id));
            }

            cbApoderado.Items.Clear();
            foreach (var apo in _negocio.ObtenerApoderados())
            {
                cbApoderado.Items.Add(new ComboBoxItem($"{apo.Id}-{apo.Nombre}", apo.Id));
            }

            cbEstado.Items.Clear();
            cbEstado.Items.Add("activo");
            cbEstado.Items.Add("inactivo");
            cbEstado.SelectedIndex = 0;
        }

        private void CargarMatriculas()
        {
            try
            {
                var matriculas = _negocio.ObtenerTodos();
                dgvMatriculas.DataSource = matriculas;
                ConfigurarColumnasMatriculas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar matrículas: " + ex.Message);
            }
        }

        private void ConfigurarColumnasMatriculas()
        {
            if (dgvMatriculas.Columns.Contains("Id"))
                dgvMatriculas.Columns["Id"].HeaderText = "ID";
            if (dgvMatriculas.Columns.Contains("IdEstudiante"))
                dgvMatriculas.Columns["IdEstudiante"].Visible = false;
            if (dgvMatriculas.Columns.Contains("IdGrado"))
                dgvMatriculas.Columns["IdGrado"].Visible = false;
            if (dgvMatriculas.Columns.Contains("IdApoderado"))
                dgvMatriculas.Columns["IdApoderado"].Visible = false;
            if (dgvMatriculas.Columns.Contains("IdSeccion"))
                dgvMatriculas.Columns["IdSeccion"].Visible = false;
            if (dgvMatriculas.Columns.Contains("IdTurno"))
                dgvMatriculas.Columns["IdTurno"].Visible = false;
            if (dgvMatriculas.Columns.Contains("IdAnioLectivo"))
                dgvMatriculas.Columns["IdAnioLectivo"].Visible = false;

            if (dgvMatriculas.Columns.Contains("NombreEstudiante"))
                dgvMatriculas.Columns["NombreEstudiante"].HeaderText = "Estudiante";
            if (dgvMatriculas.Columns.Contains("NombreGrado"))
                dgvMatriculas.Columns["NombreGrado"].HeaderText = "Grado";
            if (dgvMatriculas.Columns.Contains("NombreSeccion"))
                dgvMatriculas.Columns["NombreSeccion"].HeaderText = "Sección";
            if (dgvMatriculas.Columns.Contains("NombreTurno"))
                dgvMatriculas.Columns["NombreTurno"].HeaderText = "Turno";
            if (dgvMatriculas.Columns.Contains("NombreAnioLectivo"))
                dgvMatriculas.Columns["NombreAnioLectivo"].HeaderText = "Año Lectivo";
            if (dgvMatriculas.Columns.Contains("NombreApoderado"))
                dgvMatriculas.Columns["NombreApoderado"].HeaderText = "Apoderado";
            if (dgvMatriculas.Columns.Contains("FechaMatricula"))
                dgvMatriculas.Columns["FechaMatricula"].HeaderText = "Fecha Matrícula";
            if (dgvMatriculas.Columns.Contains("Estado"))
                dgvMatriculas.Columns["Estado"].HeaderText = "Estado";
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe ingresar el ID de la matrícula.");
                return false;
            }
            if (cbEstudiante.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estudiante.");
                return false;
            }
            if (cbGrado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un grado.");
                return false;
            }
            if (cbSeccion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una sección.");
                return false;
            }
            if (cbTurno.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un turno.");
                return false;
            }
            if (cbAnioLectivo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un año lectivo.");
                return false;
            }
            if (cbApoderado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un apoderado.");
                return false;
            }
            if (cbEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado.");
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

                var matricula = new MatriculaM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString(),
                    IdGrado = ((ComboBoxItem)cbGrado.SelectedItem).Value.ToString(),
                    FechaMatricula = dtpFechaMatricula.Value,
                    IdApoderado = ((ComboBoxItem)cbApoderado.SelectedItem).Value.ToString(),
                    IdSeccion = ((ComboBoxItem)cbSeccion.SelectedItem).Value.ToString(),
                    IdTurno = ((ComboBoxItem)cbTurno.SelectedItem).Value.ToString(),
                    IdAnioLectivo = ((ComboBoxItem)cbAnioLectivo.SelectedItem).Value.ToString(),
                    Estado = cbEstado.SelectedItem.ToString()
                };

                _negocio.Insertar(matricula);
                CargarMatriculas();
                LimpiarCampos();
                MessageBox.Show("Matrícula insertada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar matrícula: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var matricula = new MatriculaM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString(),
                    IdGrado = ((ComboBoxItem)cbGrado.SelectedItem).Value.ToString(),
                    FechaMatricula = dtpFechaMatricula.Value,
                    IdApoderado = ((ComboBoxItem)cbApoderado.SelectedItem).Value.ToString(),
                    IdSeccion = ((ComboBoxItem)cbSeccion.SelectedItem).Value.ToString(),
                    IdTurno = ((ComboBoxItem)cbTurno.SelectedItem).Value.ToString(),
                    IdAnioLectivo = ((ComboBoxItem)cbAnioLectivo.SelectedItem).Value.ToString(),
                    Estado = cbEstado.SelectedItem.ToString()
                };

                _negocio.Modificar(matricula);
                CargarMatriculas();
                LimpiarCampos();
                MessageBox.Show("Matrícula modificada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar matrícula: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar una matrícula para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar esta matrícula?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _negocio.Eliminar(txtId.Text);
                    CargarMatriculas();
                    LimpiarCampos();
                    MessageBox.Show("Matrícula eliminada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar matrícula: " + ex.Message);
            }
        }

        private void dgvMatriculas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMatriculas.CurrentRow != null && dgvMatriculas.CurrentRow.Index >= 0)
            {
                var matricula = dgvMatriculas.CurrentRow.DataBoundItem as MatriculaM;
                if (matricula == null)
                {
                    LimpiarCampos();
                    return;
                }

                txtId.Text = matricula.Id;
                SeleccionarComboBoxPorValor(cbEstudiante, matricula.IdEstudiante);
                SeleccionarComboBoxPorValor(cbGrado, matricula.IdGrado);
                SeleccionarComboBoxPorValor(cbSeccion, matricula.IdSeccion);
                SeleccionarComboBoxPorValor(cbTurno, matricula.IdTurno);
                SeleccionarComboBoxPorValor(cbAnioLectivo, matricula.IdAnioLectivo);
                SeleccionarComboBoxPorValor(cbApoderado, matricula.IdApoderado);
                dtpFechaMatricula.Value = matricula.FechaMatricula;
                cbEstado.SelectedItem = matricula.Estado;
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
            cbEstudiante.SelectedIndex = -1;
            cbGrado.SelectedIndex = -1;
            cbSeccion.SelectedIndex = -1;
            cbTurno.SelectedIndex = -1;
            cbAnioLectivo.SelectedIndex = -1;
            cbApoderado.SelectedIndex = -1;
            dtpFechaMatricula.Value = DateTime.Now;
            cbEstado.SelectedIndex = 0;
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