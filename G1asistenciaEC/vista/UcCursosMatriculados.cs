using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using G1asistenciaEC.negocio;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.vista
{
    public partial class UcCursosMatriculados : UserControl
    {
        private CursosMatriculadosN negocio = new CursosMatriculadosN();

        public UcCursosMatriculados()
        {
            InitializeComponent();
            CargarMatriculas();
            CargarCursos();
            CargarEstudiantes();
            CargarCursosMatriculados();
            CargarIdsCursosMatriculados();
            cbIdCursosMatriculados.SelectedIndexChanged += cbIdCursosMatriculados_SelectedIndexChanged;
            dgvCursosMatriculados.SelectionChanged += dgvCursosMatriculados_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged; 
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

        private void CargarIdsCursosMatriculados()
        {
            cbIdCursosMatriculados.Items.Clear();
            var lista = negocio.ObtenerTodos();
            foreach (var item in lista)
            {
                cbIdCursosMatriculados.Items.Add(item.Id);
            }
            if (cbIdCursosMatriculados.Items.Count > 0)
                cbIdCursosMatriculados.SelectedIndex = 0;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoId = GenerarNuevoId();
                var cursoMat = new CursosMatriculadosM
                {
                    Id = nuevoId,
                    IdMatricula = ((ComboBoxItem)cbMatricula.SelectedItem).Value.ToString(),
                    IdCursos = ((ComboBoxItem)cbCurso.SelectedItem).Value.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString()
                };
                negocio.Insertar(cursoMat);
                CargarCursosMatriculados();
                CargarIdsCursosMatriculados();
                LimpiarCampos();
                MessageBox.Show("Curso matriculado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cbIdCursosMatriculados.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un ID de registro a modificar.");
                return;
            }
            try
            {
                var cursoMat = new CursosMatriculadosM
                {
                    Id = cbIdCursosMatriculados.SelectedItem.ToString(),
                    IdMatricula = ((ComboBoxItem)cbMatricula.SelectedItem).Value.ToString(),
                    IdCursos = ((ComboBoxItem)cbCurso.SelectedItem).Value.ToString(),
                    IdEstudiante = ((ComboBoxItem)cbEstudiante.SelectedItem).Value.ToString()
                };
                negocio.Modificar(cursoMat);
                CargarCursosMatriculados();
                CargarIdsCursosMatriculados();
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
            if (cbIdCursosMatriculados.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un ID de registro a eliminar.");
                return;
            }
            try
            {
                negocio.Eliminar(cbIdCursosMatriculados.SelectedItem.ToString());
                CargarCursosMatriculados();
                CargarIdsCursosMatriculados();
                LimpiarCampos();
                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void cbIdCursosMatriculados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIdCursosMatriculados.SelectedItem == null) return;
            var lista = negocio.ObtenerTodos();
            var seleccionado = lista.FirstOrDefault(x => x.Id == cbIdCursosMatriculados.SelectedItem.ToString());
            if (seleccionado != null)
            {
                SeleccionarComboBoxPorValor(cbMatricula, seleccionado.IdMatricula);
                SeleccionarComboBoxPorValor(cbCurso, seleccionado.IdCursos);
                SeleccionarComboBoxPorValor(cbEstudiante, seleccionado.IdEstudiante);
            }
        }

        private void dgvCursosMatriculados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCursosMatriculados.CurrentRow != null && dgvCursosMatriculados.CurrentRow.Index >= 0)
            {
                var row = dgvCursosMatriculados.CurrentRow.DataBoundItem as CursosMatriculadosM;
                if (row != null)
                {
                    cbIdCursosMatriculados.SelectedItem = row.Id;
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
            cbIdCursosMatriculados.SelectedIndex = -1;
        }

        private string GenerarNuevoId()
        {
            return "CM01"; 
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