using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.vista
{
    public partial class UcMatriculas : UserControl
    {
        public UcMatriculas()
        {
            InitializeComponent();
            CargarCombos();
            CargarMatriculas();
            dgvMatriculas.SelectionChanged += dgvMatriculas_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void CargarCombos()
        {
            // Cargar estudiantes (formato: id-nombres apellidos)
            cbEstudiante.Items.Clear();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT e.id, u.nombres, u.ape_paterno, u.ape_materno 
              FROM estudiantes e 
              INNER JOIN usuarios u ON e.id_usuario = u.id", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string display = $"{dr["id"]}-{dr["nombres"]} {dr["ape_paterno"]} {dr["ape_materno"]}";
                    cbEstudiante.Items.Add(new ComboBoxItem(display, dr["id"]));
                }
                dr.Close();
            }
            // Cargar grados (formato: id-nombres [nivel])
            cbGrado.Items.Clear();
            cbNivel.Items.Clear(); // Asegúrate de tener cbNivel en el diseñador
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombres, nivel FROM grados", conn);
                var dr = cmd.ExecuteReader();
                var niveles = new System.Collections.Generic.HashSet<string>();
                while (dr.Read())
                {
                    string nivelRaw = dr["nivel"] != DBNull.Value ? dr["nivel"].ToString() : "";
                    string nivelTexto = nivelRaw == "1" ? "1-Primaria" : nivelRaw == "2" ? "2-Secundaria" : nivelRaw;
                    string display = $"{dr["id"]}-{dr["nombres"]} [{nivelTexto}]";
                    cbGrado.Items.Add(new ComboBoxItem(display, dr["id"]));
                    if (!string.IsNullOrWhiteSpace(nivelTexto))
                        niveles.Add(nivelTexto);
                }
                dr.Close();
                // Llenar cbNivel con los niveles únicos encontrados
                foreach (var nivel in niveles)
                    cbNivel.Items.Add(nivel);
                if (cbNivel.Items.Count > 0)
                    cbNivel.SelectedIndex = 0;
            }
            // Cargar secciones
            cbSeccion.Items.Clear();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre FROM secciones", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbSeccion.Items.Add(new ComboBoxItem($"{dr["id"]}-{dr["nombre"]}", dr["id"]));
                }
                dr.Close();
            }
            // Cargar turnos
            cbTurno.Items.Clear();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre FROM turnos", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbTurno.Items.Add(new ComboBoxItem($"{dr["id"]}-{dr["nombre"]}", dr["id"]));
                }
                dr.Close();
            }
            // Cargar años lectivos
            cbAnioLectivo.Items.Clear();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, nombre FROM aniosLectivos", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbAnioLectivo.Items.Add(new ComboBoxItem($"{dr["id"]}-{dr["nombre"]}", dr["id"]));
                }
                dr.Close();
            }
            // Cargar apoderados (formato: id-nombres apellidos)
            cbApoderado.Items.Clear();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT a.id, u.nombres, u.ape_paterno, u.ape_materno 
              FROM apoderados a 
              INNER JOIN usuarios u ON a.id_usuario = u.id", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string display = $"{dr["id"]}-{dr["nombres"]} {dr["ape_paterno"]} {dr["ape_materno"]}";
                    cbApoderado.Items.Add(new ComboBoxItem(display, dr["id"]));
                }
                dr.Close();
            }
            // Estado
            cbEstado.Items.Clear();
            cbEstado.Items.Add("activo");
            cbEstado.Items.Add("inactivo");
            cbEstado.SelectedIndex = 0;
        }

        private void CargarMatriculas()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM matriculas";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMatriculas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar matrículas: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"INSERT INTO matriculas 
                        (id, id_estudiante, id_grado, fecha_matricula, id_apoderado, id_seccion, id_turno, id_aniolectivo, estado)
                        VALUES (@id, @id_estudiante, @id_grado, @fecha_matricula, @id_apoderado, @id_seccion, @id_turno, @id_aniolectivo, @estado)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudiante.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_grado", ((ComboBoxItem)cbGrado.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@fecha_matricula", dtpFechaMatricula.Value);
                        cmd.Parameters.AddWithValue("@id_apoderado", ((ComboBoxItem)cbApoderado.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_seccion", ((ComboBoxItem)cbSeccion.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_turno", ((ComboBoxItem)cbTurno.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_aniolectivo", ((ComboBoxItem)cbAnioLectivo.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
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
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID de la matrícula a modificar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"UPDATE matriculas SET 
                        id_estudiante=@id_estudiante, id_grado=@id_grado, fecha_matricula=@fecha_matricula, 
                        id_apoderado=@id_apoderado, id_seccion=@id_seccion, id_turno=@id_turno, 
                        id_aniolectivo=@id_aniolectivo, estado=@estado WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudiante.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_grado", ((ComboBoxItem)cbGrado.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@fecha_matricula", dtpFechaMatricula.Value);
                        cmd.Parameters.AddWithValue("@id_apoderado", ((ComboBoxItem)cbApoderado.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_seccion", ((ComboBoxItem)cbSeccion.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_turno", ((ComboBoxItem)cbTurno.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id_aniolectivo", ((ComboBoxItem)cbAnioLectivo.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
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
                    MessageBox.Show("Debe ingresar el ID de la matrícula a eliminar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM matriculas WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarMatriculas();
                LimpiarCampos();
                MessageBox.Show("Matrícula eliminada correctamente.");
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
                var row = dgvMatriculas.CurrentRow;

                // Si la fila está vacía (todos los valores son nulos o vacíos), limpiar campos
                bool filaVacia = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value != DBNull.Value && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        filaVacia = false;
                        break;
                    }
                }

                if (filaVacia)
                {
                    LimpiarCampos();
                    return;
                }

                txtId.Text = row.Cells["id"].Value?.ToString() ?? "";
                SeleccionarComboBoxPorValor(cbEstudiante, row.Cells["id_estudiante"].Value);
                SeleccionarComboBoxPorValor(cbGrado, row.Cells["id_grado"].Value);
                SeleccionarComboBoxPorValor(cbSeccion, row.Cells["id_seccion"].Value);
                SeleccionarComboBoxPorValor(cbTurno, row.Cells["id_turno"].Value);
                SeleccionarComboBoxPorValor(cbAnioLectivo, row.Cells["id_aniolectivo"].Value);
                SeleccionarComboBoxPorValor(cbApoderado, row.Cells["id_apoderado"].Value);

                var fechaValue = row.Cells["fecha_matricula"].Value;
                if (fechaValue != null && fechaValue != DBNull.Value)
                    dtpFechaMatricula.Value = Convert.ToDateTime(fechaValue);
                else
                    dtpFechaMatricula.Value = DateTime.Now;

                cbEstado.SelectedItem = row.Cells["estado"].Value?.ToString() ?? "activo";
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

        // Clase auxiliar para mostrar texto y valor en ComboBox
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