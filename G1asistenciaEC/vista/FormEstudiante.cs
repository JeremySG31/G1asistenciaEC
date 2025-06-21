using System;
using System.Linq;
using System.Windows.Forms;
using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using G1asistenciaEC.controlador;

namespace G1asistenciaEC
{
    public partial class FormEstudiante : Form
    {
        private estudianteM _estudiante;
        private string _idEstudiante; // <-- Agregado

        public FormEstudiante(string usuario)
        {
            InitializeComponent();
            this.Text = "Panel del Estudiante";

            var negocio = new estudianteN(); // <-- Corregido
            _estudiante = negocio.ObtenerInformacionEstudiante(usuario);

            // Obtener el id real del estudiante usando el Dni
            _idEstudiante = ObtenerIdEstudiantePorDni(_estudiante.Dni);

            lblNombreEstudiante.Text = $"{_estudiante.Nombres} {_estudiante.ApellidoPaterno} {_estudiante.ApellidoMaterno}";
            dtpFechaHistorial.Value = DateTime.Today;

            ConfigurarDataGridViewHistorial();
            btnBuscar.Click += btnBuscar_Click;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            btnInfoPersonal.Click -= btnInfoPersonal_Click;
            btnInfoPersonal.Click += btnInfoPersonal_Click;
        }

        // Método para obtener el id de la tabla estudiantes usando el Dni
        private string ObtenerIdEstudiantePorDni(string dni)
        {
            var estudiante = new estudianteN().ObtenerPorDni(dni);
            return estudiante?.Id;
        }

        private void ConfigurarDataGridViewHistorial()
        {
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.Columns.Clear();

            // 1. Fecha
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                ReadOnly = true,
                Width = 100
            });

            // 2. Correo
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CorreoUsuario",
                DataPropertyName = "CorreoUsuario",
                HeaderText = "Correo",
                ReadOnly = true,
                Width = 200
            });

            // 3. Grado y Sección
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GradoSeccion",
                DataPropertyName = "GradoSeccion",
                HeaderText = "Grado y Sección",
                ReadOnly = true,
                Width = 200
            });

            // 4. Estado
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                ReadOnly = true,
                Width = 100
            });

            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var fecha = dtpFechaHistorial.Value.Date;

                var asistenciasN = new asistenciasMatriculadosN();
                var asistencias = asistenciasN.ObtenerAsistenciasPorFecha(fecha);

                var matriculasN = new MatriculasN();
                var matriculasEstudiante = matriculasN.ObtenerTodos()
                    .Where(m => m.IdEstudiante == _idEstudiante && m.Estado == "activo")
                    .Select(m => m.Id)
                    .ToList();

                var asistenciasEstudiante = asistencias
                    .Where(a => matriculasEstudiante.Contains(a.IdMatricula))
                    .Select(a => new
                    {
                        Fecha = a.Fecha.ToShortDateString(),
                        CorreoUsuario = a.CorreoUsuario,
                        GradoSeccion = $"{a.NombreGrado} - {a.NombreSeccion}",
                        Estado = a.Estado
                    })
                    .ToList();

                dgvHistorial.DataSource = asistenciasEstudiante;
                dgvHistorial.Refresh();

                if (!asistenciasEstudiante.Any())
                {
                    MessageBox.Show("No se encontraron asistencias registradas para esta fecha.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfoPersonal_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Información del estudiante:\n\n" +
                $"Nombre: {_estudiante.Nombres} {_estudiante.ApellidoPaterno} {_estudiante.ApellidoMaterno}\n" +
                $"DNI: {_estudiante.Dni}\n" +
                $"Correo: {_estudiante.Correo}\n" +
                $"Teléfono: {_estudiante.Telefono}\n" +
                $"Estado: {_estudiante.Estado}"

            );
        }
    }
}
