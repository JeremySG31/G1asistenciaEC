using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using G1asistenciaEC.negocio;
using G1asistenciaEC.modelo;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC.vista
{
    public partial class UcCursosMatriculados : UserControl
    {
        private CursosMatriculadosN negocio = new CursosMatriculadosN();
        private CursosMatriculadosC controlador = new CursosMatriculadosC();

        public UcCursosMatriculados()
        {
            InitializeComponent();
            CargarMatriculas();
            CargarCursos();
            CargarEstudiantes();
            CargarCursosMatriculados();
            dgvCursosMatriculados.SelectionChanged += dgvCursosMatriculados_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            txtIdCM.Leave += txtIdCM_Leave;
            this.Load += UcCursosMatriculados_Load;
        }

        private void CargarMatriculas()
        {
            cbMatricula.Items.Clear();
            var lista = negocio.ObtenerMatriculas();
            foreach (var item in lista)
                cbMatricula.Items.Add(new ComboBoxItem(item.Key, item.Value));
            if (cbMatricula.Items.Count > 0)
                cbMatricula.SelectedIndex = 0;
        }

        private void CargarCursos()
        {
            cbCurso.Items.Clear();
            var lista = negocio.ObtenerCursos();
            foreach (var item in lista)
                cbCurso.Items.Add(new ComboBoxItem(item.Key, item.Value));
            if (cbCurso.Items.Count > 0)
                cbCurso.SelectedIndex = 0;
        }

        private void CargarEstudiantes()
        {
            cbEstudiante.Items.Clear();
            var lista = negocio.ObtenerEstudiantes();
            foreach (var item in lista)
                cbEstudiante.Items.Add(new ComboBoxItem(item.Key, item.Value));
            if (cbEstudiante.Items.Count > 0)
                cbEstudiante.SelectedIndex = 0;
        }

        private void CargarCursosMatriculados()
        {
            try
            {
                var lista = negocio.ObtenerTodos();
                dgvCursosMatriculados.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cursos matriculados: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdCM.Text))
                {
                    MessageBox.Show("Debe ingresar el ID de registro.");
                    return;
                }
                if (controlador.ExisteIdCM(txtIdCM.Text))
                {
                    MessageBox.Show("El ID ya existe. Se recomienda usar: " + controlador.ObtenerSiguienteIdCM(), "ID Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdCM.Text = controlador.ObtenerSiguienteIdCM();
                    txtIdCM.Focus();
                    return;
                }
                var cursoMat = new CursosMatriculadosM
                {
                    Id = txtIdCM.Text,
                    IdMatricula = ((ComboBoxItem)cbMatricula.SelectedItem).Value.ToString(),
                    IdCursos = ((ComboBoxItem)cbCurso.SelectedItem).Value.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString()
                };
                negocio.Insertar(cursoMat);
                CargarCursosMatriculados();
                LimpiarCampos();
                txtIdCM.Text = controlador.ObtenerSiguienteIdCM();
                MessageBox.Show("Curso matriculado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCM.Text))
            {
                MessageBox.Show("Debe ingresar el ID de registro a modificar.");
                return;
            }
            try
            {
                var cursoMat = new CursosMatriculadosM
                {
                    Id = txtIdCM.Text,
                    IdMatricula = ((ComboBoxItem)cbMatricula.SelectedItem).Value.ToString(),
                    IdCursos = ((ComboBoxItem)cbCurso.SelectedItem).Value.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString()
                };
                negocio.Modificar(cursoMat);
                CargarCursosMatriculados();
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
            if (string.IsNullOrWhiteSpace(txtIdCM.Text))
            {
                MessageBox.Show("Debe ingresar el ID de registro a eliminar.");
                return;
            }
            try
            {
                negocio.Eliminar(txtIdCM.Text);
                CargarCursosMatriculados();
                LimpiarCampos();
                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dgvCursosMatriculados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCursosMatriculados.CurrentRow != null && dgvCursosMatriculados.CurrentRow.Index >= 0)
            {
                var row = dgvCursosMatriculados.CurrentRow.DataBoundItem as CursosMatriculadosM;
                if (row != null)
                {
                    txtIdCM.Text = row.Id;
                    SeleccionarComboBoxPorValor(cbMatricula, row.IdMatricula);
                    SeleccionarComboBoxPorValor(cbCurso, row.IdCursos);
                    SeleccionarComboBoxPorValor(cbEstudiante, row.IdEstudiante);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarCursosMatriculados(txtBuscar.Text.Trim());
        }

        private void FiltrarCursosMatriculados(string filtro)
        {
            var lista = negocio.ObtenerTodos();
            var filtrada = lista.Where(x =>
                x.Id.Contains(filtro) ||
                x.IdMatricula.Contains(filtro) ||
                x.IdCursos.Contains(filtro) ||
                x.IdEstudiante.Contains(filtro)
            ).ToList();
            dgvCursosMatriculados.DataSource = filtrada;
        }

        private void SeleccionarComboBoxPorValor(ComboBox combo, object valor)
        {
            foreach (var item in combo.Items)
            {
                if (item is ComboBoxItem cbi && cbi.Value.ToString() == valor?.ToString())
                {
                    combo.SelectedItem = item;
                    break;
                }
                else if (item is string s && s == valor?.ToString())
                {
                    combo.SelectedItem = item;
                    break;
                }
            }
        }

        private void LimpiarCampos()
        {
            if (cbMatricula.Items.Count > 0) cbMatricula.SelectedIndex = 0;
            if (cbCurso.Items.Count > 0) cbCurso.SelectedIndex = 0;
            if (cbEstudiante.Items.Count > 0) cbEstudiante.SelectedIndex = 0;
        }

        private void LimpiarTodo()
        {
            if (cbMatricula.Items.Count > 0) cbMatricula.SelectedIndex = 0;
            if (cbCurso.Items.Count > 0) cbCurso.SelectedIndex = 0;
            if (cbEstudiante.Items.Count > 0) cbEstudiante.SelectedIndex = 0;
        }

        private void UcCursosMatriculados_Load(object sender, EventArgs e)
        {
            txtIdCM.Text = controlador.ObtenerSiguienteIdCM();
        }

        private void txtIdCM_Leave(object sender, EventArgs e)
        {
            if (controlador.ExisteIdCM(txtIdCM.Text))
            {
                MessageBox.Show("El ID ya existe. Se recomienda usar: " + controlador.ObtenerSiguienteIdCM(), "ID Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdCM.Text = controlador.ObtenerSiguienteIdCM();
                txtIdCM.Focus();
            }
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

        private void txtIdCM_TextChanged(object sender, EventArgs e)
        {

        }
    }
}