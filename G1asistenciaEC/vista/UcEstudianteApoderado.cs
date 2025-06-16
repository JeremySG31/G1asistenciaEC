using G1asistenciaEC.dao;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace G1asistenciaEC.vista
{
    public partial class UcEstudianteApoderado : UserControl
    {
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
            // Prioridad
            cbPrioridad.Items.Clear();
            cbPrioridad.Items.Add(new ComboBoxItem("1 - Muy baja", 1));
            cbPrioridad.Items.Add(new ComboBoxItem("2 - Baja", 2));
            cbPrioridad.Items.Add(new ComboBoxItem("3 - Media", 3));
            cbPrioridad.Items.Add(new ComboBoxItem("4 - Alta", 4));
            cbPrioridad.Items.Add(new ComboBoxItem("5 - Muy alta", 5));
            cbPrioridad.SelectedIndex = 2; // Media por defecto

            // Estudiantes (id de la tabla estudiantes y nombre)
            cbIdEstudiante.Items.Clear();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT e.id, u.nombres, u.ape_paterno, u.ape_materno
                      FROM estudiantes e
                      INNER JOIN usuarios u ON e.id_usuario = u.id", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string nombre = $"{reader["nombres"]} {reader["ape_paterno"]} {reader["ape_materno"]}";
                        cbIdEstudiante.Items.Add(new ComboBoxItem($"{id} - {nombre}", id));
                    }
                }
            }

            // Apoderados (id de la tabla apoderados y nombre)
            cbIdApoderado.Items.Clear();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT a.id, u.nombres, u.ape_paterno, u.ape_materno
                      FROM apoderados a
                      INNER JOIN usuarios u ON a.id_usuario = u.id", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string nombre = $"{reader["nombres"]} {reader["ape_paterno"]} {reader["ape_materno"]}";
                        cbIdApoderado.Items.Add(new ComboBoxItem($"{id} - {nombre}", id));
                    }
                }
            }
        }

        private void CargarEstudianteApoderados()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT id, id_estudiante, id_apoderado, parentesco, prioridad, estado FROM estudiante_apoderados";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEstudianteApoderados.DataSource = dt;
                }

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
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    var campos = new System.Collections.Generic.List<string>();
                    var valores = new System.Collections.Generic.List<string>();
                    var parametros = new System.Collections.Generic.List<SqlParameter>();

                    if (!string.IsNullOrWhiteSpace(txtId.Text)) { campos.Add("id"); valores.Add("@id"); parametros.Add(new SqlParameter("@id", txtId.Text)); }
                    if (cbIdEstudiante.SelectedItem != null)
                    {
                        campos.Add("id_estudiante");
                        valores.Add("@id_estudiante");
                        parametros.Add(new SqlParameter("@id_estudiante", ((ComboBoxItem)cbIdEstudiante.SelectedItem).Value));
                    }
                    if (cbIdApoderado.SelectedItem != null)
                    {
                        campos.Add("id_apoderado");
                        valores.Add("@id_apoderado");
                        parametros.Add(new SqlParameter("@id_apoderado", ((ComboBoxItem)cbIdApoderado.SelectedItem).Value));
                    }
                    if (!string.IsNullOrWhiteSpace(txtParentesco.Text)) { campos.Add("parentesco"); valores.Add("@parentesco"); parametros.Add(new SqlParameter("@parentesco", txtParentesco.Text)); }
                    if (cbPrioridad.SelectedItem != null) { campos.Add("prioridad"); valores.Add("@prioridad"); parametros.Add(new SqlParameter("@prioridad", ((ComboBoxItem)cbPrioridad.SelectedItem).Value)); }
                    if (!string.IsNullOrWhiteSpace(cbEstado.Text)) { campos.Add("estado"); valores.Add("@estado"); parametros.Add(new SqlParameter("@estado", cbEstado.Text)); }

                    if (campos.Count == 0)
                    {
                        MessageBox.Show("Debe ingresar al menos un campo para insertar.");
                        return;
                    }

                    string query = $"INSERT INTO estudiante_apoderados ({string.Join(",", campos)}) VALUES ({string.Join(",", valores)})";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
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
                    MessageBox.Show("Debe ingresar el ID del registro a modificar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    var sets = new System.Collections.Generic.List<string>();
                    var parametros = new System.Collections.Generic.List<SqlParameter>();

                    if (cbIdEstudiante.SelectedItem != null)
                    {
                        sets.Add("id_estudiante=@id_estudiante");
                        parametros.Add(new SqlParameter("@id_estudiante", ((ComboBoxItem)cbIdEstudiante.SelectedItem).Value));
                    }
                    if (cbIdApoderado.SelectedItem != null)
                    {
                        sets.Add("id_apoderado=@id_apoderado");
                        parametros.Add(new SqlParameter("@id_apoderado", ((ComboBoxItem)cbIdApoderado.SelectedItem).Value));
                    }
                    if (!string.IsNullOrWhiteSpace(txtParentesco.Text)) { sets.Add("parentesco=@parentesco"); parametros.Add(new SqlParameter("@parentesco", txtParentesco.Text)); }
                    if (cbPrioridad.SelectedItem != null) { sets.Add("prioridad=@prioridad"); parametros.Add(new SqlParameter("@prioridad", ((ComboBoxItem)cbPrioridad.SelectedItem).Value)); }
                    if (!string.IsNullOrWhiteSpace(cbEstado.Text)) { sets.Add("estado=@estado"); parametros.Add(new SqlParameter("@estado", cbEstado.Text)); }

                    if (sets.Count == 0)
                    {
                        MessageBox.Show("Debe ingresar al menos un campo para modificar.");
                        return;
                    }

                    string query = $"UPDATE estudiante_apoderados SET {string.Join(",", sets)} WHERE id=@id";
                    parametros.Add(new SqlParameter("@id", txtId.Text));
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
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
                    MessageBox.Show("Debe ingresar el ID del registro a eliminar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM estudiante_apoderados WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarEstudianteApoderados();
                LimpiarCampos();
                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dgvEstudianteApoderados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstudianteApoderados.CurrentRow != null && dgvEstudianteApoderados.CurrentRow.Index >= 0)
            {
                var row = dgvEstudianteApoderados.CurrentRow;
                txtId.Text = row.Cells["id"].Value?.ToString();

                // Selecciona el ítem correcto por ID
                if (row.Cells["id_estudiante"].Value != null)
                {
                    string idEst = row.Cells["id_estudiante"].Value.ToString();
                    foreach (ComboBoxItem item in cbIdEstudiante.Items)
                        if (item.Value.ToString() == idEst) { cbIdEstudiante.SelectedItem = item; break; }
                }
                if (row.Cells["id_apoderado"].Value != null)
                {
                    string idApo = row.Cells["id_apoderado"].Value.ToString();
                    foreach (ComboBoxItem item in cbIdApoderado.Items)
                        if (item.Value.ToString() == idApo) { cbIdApoderado.SelectedItem = item; break; }
                }

                txtParentesco.Text = row.Cells["parentesco"].Value?.ToString();

                // Selecciona la prioridad por valor
                if (row.Cells["prioridad"].Value != null)
                {
                    string prioridad = row.Cells["prioridad"].Value.ToString();
                    foreach (ComboBoxItem item in cbPrioridad.Items)
                    {
                        if (item.Value.ToString() == prioridad)
                        {
                            cbPrioridad.SelectedItem = item;
                            break;
                        }
                    }
                }
                cbEstado.Text = row.Cells["estado"].Value?.ToString();
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

        private void UcEstudianteApoderado_Load(object sender, EventArgs e)
        {

        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
