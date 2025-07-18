﻿using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace G1asistenciaEC
{
    public partial class FormProfesor : Form
    {
        private profesorM _profesor;
        private Dictionary<string, Dictionary<DateTime, string>> _asistenciasCache;

        public FormProfesor(string usuario)
        {
            InitializeComponent();
            this.Size = new Size(900, 550);
            this.MaximumSize = new Size(850, 550);
            this.MinimumSize = new Size(850, 550);
            this.MaximizeBox = false;
            this.Text = "Panel del Profesor";
            _asistenciasCache = new Dictionary<string, Dictionary<DateTime, string>>();

            var negocio = new profesorN();
            _profesor = negocio.ObtenerInformacionProfesor(usuario);

            lblNombreProfesor.Text = _profesor.NombreCompleto;

            tabControl.SelectedIndex = 0; 

            dtpFecha.Value = DateTime.Today;
            dtpFechaHistorial.Value = DateTime.Today;

            ConfigurarDataGridView();
            ConfigurarDataGridViewHistorial();
            btnBuscar.Click -= btnBuscar_Click;
            ConfigurarEventos();
            CargarFiltros();
            CargarNiveles();
        }

        private void CargarNiveles()
        {
            cbNivel.Items.Clear();
            cbNivel.Items.Add("Primaria");
            cbNivel.Items.Add("Secundaria");
            cbNivel.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            dgvAsistencia.AutoGenerateColumns = false;
            dgvAsistencia.Columns.Clear();

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdMatricula",
                DataPropertyName = "IdMatricula",
                HeaderText = "ID Matrícula",
                Width = 100,
                ReadOnly = true
            });

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreEstudiante",
                DataPropertyName = "NombreEstudiante",
                HeaderText = "Estudiante",
                ReadOnly = true,
                Width = 200
            });

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 100,
                ReadOnly = true
            });

            dgvAsistencia.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvAsistencia.AllowUserToAddRows = false;
            dgvAsistencia.MultiSelect = true;
            dgvAsistencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigurarDataGridViewHistorial()
        {
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.Columns.Clear();

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreEstudiante",
                DataPropertyName = "NombreEstudiante",
                HeaderText = "Estudiante",
                ReadOnly = true,
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CorreoUsuario",
                DataPropertyName = "CorreoUsuario",
                HeaderText = "Correo",
                ReadOnly = true,
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GradoSeccion",
                DataPropertyName = "GradoSeccion",
                HeaderText = "Grado y Sección",
                ReadOnly = true,
                Width = 150
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                ReadOnly = true,
                Width = 100
            });

            dgvHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigurarEventos()
        {
            cbNivel.SelectedIndexChanged += cbNivel_Changed;
            cbGrado.SelectedIndexChanged += cbGrado_Seccion_Changed;
            cbSeccion.SelectedIndexChanged += cbGrado_Seccion_Changed;
            chkA.CheckedChanged += chkA_CheckedChanged;
            chkT.CheckedChanged += chkT_CheckedChanged;
            chkF.CheckedChanged += chkF_CheckedChanged;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            dgvAsistencia.CellClick += dgvAsistencia_CellClick;
            btnBuscar.Click += btnBuscar_Click;
        }

        private void CargarFiltros()
        {
            // Guardar selección previa
            string gradoPrevio = cbGrado.SelectedItem?.ToString();
            string seccionPrevia = cbSeccion.SelectedItem?.ToString();

            cbGrado.Items.Clear();
            string nivel = cbNivel.SelectedItem?.ToString();
            if (nivel == "Secundaria")
            {
                cbGrado.Items.AddRange(new[] { "Primero", "Segundo", "Tercero", "Cuarto", "Quinto" });
            }
            else
            {
                cbGrado.Items.AddRange(new[] { "Primero", "Segundo", "Tercero", "Cuarto", "Quinto", "Sexto" });
            }

            // Restaurar selección previa si existe
            if (!string.IsNullOrEmpty(gradoPrevio) && cbGrado.Items.Contains(gradoPrevio))
                cbGrado.SelectedItem = gradoPrevio;
            else if (cbGrado.Items.Count > 0)
                cbGrado.SelectedIndex = 0;

            cbSeccion.Items.Clear();
            cbSeccion.Items.AddRange(Enumerable.Range('A', 26).Select(c => ((char)c).ToString()).ToArray());
            // Restaurar selección previa si existe
            if (!string.IsNullOrEmpty(seccionPrevia) && cbSeccion.Items.Contains(seccionPrevia))
                cbSeccion.SelectedItem = seccionPrevia;
            else if (cbSeccion.Items.Count > 0)
                cbSeccion.SelectedIndex = 0;
        }

        private void cbNivel_Changed(object sender, EventArgs e)
        {
            string gradoPrevio = cbGrado.SelectedItem?.ToString();
            string seccionPrevia = cbSeccion.SelectedItem?.ToString();
            CargarFiltros();
            // Restaurar selección previa si existe
            if (!string.IsNullOrEmpty(gradoPrevio) && cbGrado.Items.Contains(gradoPrevio))
                cbGrado.SelectedItem = gradoPrevio;
            if (!string.IsNullOrEmpty(seccionPrevia) && cbSeccion.Items.Contains(seccionPrevia))
                cbSeccion.SelectedItem = seccionPrevia;
            if (cbGrado.SelectedItem != null && cbSeccion.SelectedItem != null)
            {
                cbGrado_Seccion_Changed(sender, e);
            }
        }

        private void cbGrado_Seccion_Changed(object sender, EventArgs e)
        {
            if (cbGrado.SelectedItem == null || cbSeccion.SelectedItem == null || cbNivel.SelectedItem == null) return;

            var gradoSeleccionado = cbGrado.SelectedItem.ToString();
            var seccionSeleccionada = cbSeccion.SelectedItem.ToString();
            var nivelSeleccionado = cbNivel.SelectedItem.ToString();
            var fecha = dtpFecha.Value.Date;

            ActualizarGrilla(gradoSeleccionado, seccionSeleccionada, nivelSeleccionado, fecha);
        }

        private void ActualizarGrilla(string grado, string seccion, string nivel, DateTime fecha)
        {
            try
            {
                var asistenciasN = new asistenciasMatriculadosN();
                var asistenciasDB = asistenciasN.ObtenerPorGradoYSeccionYFecha(grado, seccion, fecha);
                var asistenciasPorMatriculaDB = asistenciasDB.ToDictionary(a => a.IdMatricula);

                // Obtener grados con su nivel real (por IdGrado)
                var grados = new GradosSeccionesN().ObtenerGrados();
                var gradosPorId = grados.ToDictionary(g => g.Id);

                // Filtrar alumnos por grado, seccion y nivel real usando IdGrado
                var alumnos = new MatriculasN().ObtenerTodos()
                    .Where(m => m.NombreGrado.Equals(grado, StringComparison.OrdinalIgnoreCase)
                                && m.NombreSeccion.Equals(seccion, StringComparison.OrdinalIgnoreCase)
                                && m.Estado.Equals("activo", StringComparison.OrdinalIgnoreCase)
                                && m.IdGrado != null
                                && gradosPorId.ContainsKey(m.IdGrado)
                                && gradosPorId[m.IdGrado].Nivel.Equals(nivel, StringComparison.OrdinalIgnoreCase)
                         )
                    .ToList();

                var source = alumnos.Select(a =>
                {
                    string estadoActual;

                    if (asistenciasPorMatriculaDB.TryGetValue(a.Id, out var asistenciaDB))
                    {
                        estadoActual = asistenciaDB.Estado;
                        if (!_asistenciasCache.ContainsKey(a.Id))
                        {
                            _asistenciasCache[a.Id] = new Dictionary<DateTime, string>();
                        }
                        _asistenciasCache[a.Id][fecha] = estadoActual;
                    }
                    else if (_asistenciasCache.TryGetValue(a.Id, out var asistenciasPorFechaEnCache) &&
                             asistenciasPorFechaEnCache.TryGetValue(fecha, out var estadoEnCache))
                    {
                        estadoActual = estadoEnCache;
                    }
                    else
                    {
                        estadoActual = "Sin registro";
                    }

                    return new AsistenciaViewModel
                    {
                        IdMatricula = a.Id,
                        NombreEstudiante = a.NombreEstudiante,
                        Estado = estadoActual
                    };
                }).ToList();

                dgvAsistencia.DataSource = null;
                dgvAsistencia.DataSource = source;
                dgvAsistencia.Refresh();

                if (dgvAsistencia.SelectedRows.Count > 0)
                {
                    var estado = dgvAsistencia.SelectedRows[0].Cells["Estado"].Value?.ToString();
                    ActualizarCheckboxes(estado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la grilla: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkA.Checked)
            {
                chkT.Checked = false;
                chkF.Checked = false;
                MarcarAsistencia("A");
            }
        }

        private void chkT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkT.Checked)
            {
                chkA.Checked = false;
                chkF.Checked = false;
                MarcarAsistencia("T");
            }
        }

        private void chkF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkF.Checked)
            {
                chkA.Checked = false;
                chkT.Checked = false;
                MarcarAsistencia("F");
            }
        }

        private void MarcarAsistencia(string estado)
        {
            if (dtpFecha.Value.Date != DateTime.Today)
            {
                MessageBox.Show("Solo se puede registrar asistencia para el día actual.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DesmarcarCheckboxes();
                return;
            }

            if (dgvAsistencia.SelectedRows.Count == 0) return;

            var negocio = new asistenciasMatriculadosN();
            var fecha = dtpFecha.Value.Date;

            foreach (DataGridViewRow row in dgvAsistencia.SelectedRows)
            {
                var idMatricula = row.Cells["IdMatricula"].Value?.ToString();
                if (string.IsNullOrEmpty(idMatricula)) continue;

                var asistenciaExistente = negocio.ObtenerPorMatriculaYFecha(idMatricula, fecha);
                if (asistenciaExistente != null)
                {
                    asistenciaExistente.Estado = estado;
                    negocio.Modificar(asistenciaExistente);
                }
                else
                {
                    var nuevaAsistencia = new asistenciasMatriculadosM
                    {
                        IdMatricula = idMatricula,
                        Estado = estado,
                        Fecha = fecha
                    };
                    negocio.Insertar(nuevaAsistencia);
                }

                if (!_asistenciasCache.ContainsKey(idMatricula))
                {
                    _asistenciasCache[idMatricula] = new Dictionary<DateTime, string>();
                }
                _asistenciasCache[idMatricula][fecha] = estado; 

                row.Cells["Estado"].Value = estado;
            }

            dgvAsistencia.Refresh();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            bool esDiaActual = dtpFecha.Value.Date == DateTime.Today;
            chkA.Enabled = esDiaActual;
            chkT.Enabled = esDiaActual;
            chkF.Enabled = esDiaActual;

            DesmarcarCheckboxes();

            if (cbGrado.SelectedItem != null && cbSeccion.SelectedItem != null)
            {
                cbGrado_Seccion_Changed(sender, e);
            }
        }

        private void DesmarcarCheckboxes()
        {
            chkA.Checked = false;
            chkT.Checked = false;
            chkF.Checked = false;
        }

        private void ActualizarCheckboxes(string estado)
        {
            chkA.Checked = estado == "A";
            chkT.Checked = estado == "T";
            chkF.Checked = estado == "F";
        }

        private void dgvAsistencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var estado = dgvAsistencia.Rows[e.RowIndex].Cells["Estado"].Value?.ToString();
                ActualizarCheckboxes(estado);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormProfesor_Load(object sender, EventArgs e)
        {

        }
        private void btnInfoPersonal_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Información del profesor:\n\nNombre: {_profesor.NombreCompleto}\nDNI: {_profesor.Dni}\nCorreo: {_profesor.Correo}\nEstado: {_profesor.Estado}");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var fecha = dtpFechaHistorial.Value.Date;
                var asistenciasN = new asistenciasMatriculadosN();
                var asistencias = asistenciasN.ObtenerAsistenciasPorFecha(fecha);

                dgvHistorial.DataSource = null;
                if (asistencias == null || !asistencias.Any())
                {
                    MessageBox.Show("No se encontraron registros de asistencia para la fecha seleccionada.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var historialViewModel = asistencias.Select(a => new
                {
                    NombreEstudiante = a.NombreEstudiante ?? "Sin nombre",
                    CorreoUsuario = a.CorreoUsuario ?? "Sin correo",
                    GradoSeccion = $"{a.NombreGrado ?? "Sin grado"} - {a.NombreSeccion ?? "Sin sección"}",
                    Estado = a.Estado ?? "Sin registro"
                }).OrderBy(x => x.GradoSeccion)
                  .ThenBy(x => x.NombreEstudiante)
                  .ToList();

                dgvHistorial.DataSource = historialViewModel;
                dgvHistorial.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public class AsistenciaViewModel
        {
            public string IdMatricula { get; set; }
            public string NombreEstudiante { get; set; }
            public string Estado { get; set; }
        }

        private void groupBoxFiltros_Enter(object sender, EventArgs e)
        {

        }
    }
}