using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.vista
{
    public partial class UcGradosSecciones : UserControl
    {
        public UcGradosSecciones()
        {
            InitializeComponent();
            CargarEstudiantes();
            CargarGrados();
            CargarSecciones();
            dgvGrados.SelectionChanged += dgvGrados_SelectionChanged;
            dgvSecciones.SelectionChanged += dgvSecciones_SelectionChanged;
            btnInsertarGrado.Click += btnInsertarGrado_Click;
            btnModificarGrado.Click += btnModificarGrado_Click;
            btnEliminarGrado.Click += btnEliminarGrado_Click;
            btnInsertarSeccion.Click += btnInsertarSeccion_Click;
            btnModificarSeccion.Click += btnModificarSeccion_Click;
            btnEliminarSeccion.Click += btnEliminarSeccion_Click;

            cbNivelGrado.Items.Clear();
            cbNivelGrado.Items.Add("Primaria");
            cbNivelGrado.Items.Add("Secundaria");
            cbNivelGrado.SelectedIndex = 0;
        }

        private void CargarEstudiantes()
        {
            cbEstudianteGrado.Items.Clear();
            cbEstudianteSeccion.Items.Clear();
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
                    var item = new ComboBoxItem(display, dr["id"]);
                    cbEstudianteGrado.Items.Add(item);
                    cbEstudianteSeccion.Items.Add(item);
                }
                dr.Close();
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
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            g.id, 
                            g.nombres, 
                            g.id_estudiante,
                            g.nivel
                        FROM grados g";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvGrados.DataSource = dt;

                    if (dgvGrados.Columns.Contains("id"))
                        dgvGrados.Columns["id"].HeaderText = "id";
                    if (dgvGrados.Columns.Contains("id_estudiante"))
                        dgvGrados.Columns["id_estudiante"].HeaderText = "id_estudiante";
                    if (dgvGrados.Columns.Contains("nombres"))
                    {
                        dgvGrados.Columns["nombres"].HeaderText = "grados";
                        dgvGrados.Columns["nombres"].HeaderCell.Style.Font = new System.Drawing.Font(
                            dgvGrados.Font, System.Drawing.FontStyle.Bold);
                    }
                    if (dgvGrados.Columns.Contains("nivel"))
                        dgvGrados.Columns["nivel"].HeaderText = "nivel";

                    if (dgvGrados.Columns.Contains("id") && dgvGrados.Columns.Contains("id_estudiante") && dgvGrados.Columns.Contains("nombres") && dgvGrados.Columns.Contains("nivel"))
                    {
                        dgvGrados.Columns["id"].DisplayIndex = 0;
                        dgvGrados.Columns["id_estudiante"].DisplayIndex = 1;
                        dgvGrados.Columns["nombres"].DisplayIndex = 2;
                        dgvGrados.Columns["nivel"].DisplayIndex = 3;
                    }
                }
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
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.id, 
                            s.nombre, 
                            s.id_estudiante
                        FROM secciones s";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSecciones.DataSource = dt;

                    if (dgvSecciones.Columns.Contains("id"))
                        dgvSecciones.Columns["id"].HeaderText = "id";
                    if (dgvSecciones.Columns.Contains("id_estudiante"))
                        dgvSecciones.Columns["id_estudiante"].HeaderText = "id_estudiante";
                    if (dgvSecciones.Columns.Contains("nombre"))
                    {
                        dgvSecciones.Columns["nombre"].HeaderText = "seccion";
                        dgvSecciones.Columns["nombre"].HeaderCell.Style.Font = new System.Drawing.Font(
                            dgvSecciones.Font, System.Drawing.FontStyle.Bold);
                    }

                    if (dgvSecciones.Columns.Contains("id") && dgvSecciones.Columns.Contains("id_estudiante") && dgvSecciones.Columns.Contains("nombre"))
                    {
                        dgvSecciones.Columns["id"].DisplayIndex = 0;
                        dgvSecciones.Columns["id_estudiante"].DisplayIndex = 1;
                        dgvSecciones.Columns["nombre"].DisplayIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar secciones: " + ex.Message);
            }
        }

        private void btnInsertarGrado_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO grados (id, nombres, id_estudiante, nivel) VALUES (@id, @nombres, @id_estudiante, @nivel)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtIdGrado.Text);
                        cmd.Parameters.AddWithValue("@nombres", txtNombreGrado.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudianteGrado.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@nivel", cbNivelGrado.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
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
                if (string.IsNullOrWhiteSpace(txtIdGrado.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del grado a modificar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "UPDATE grados SET nombres=@nombres, id_estudiante=@id_estudiante, nivel=@nivel WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombres", txtNombreGrado.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudianteGrado.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@nivel", cbNivelGrado.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@id", txtIdGrado.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
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
                    MessageBox.Show("Debe ingresar el ID del grado a eliminar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM grados WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtIdGrado.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarGrados();
                LimpiarCamposGrado();
                MessageBox.Show("Grado eliminado correctamente.");
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
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO secciones (id, nombre, id_estudiante) VALUES (@id, @nombre, @id_estudiante)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtIdSeccion.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombreSeccion.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudianteSeccion.SelectedItem).Value);
                        cmd.ExecuteNonQuery();
                    }
                }
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
                if (string.IsNullOrWhiteSpace(txtIdSeccion.Text))
                {
                    MessageBox.Show("Debe ingresar el ID de la sección a modificar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "UPDATE secciones SET nombre=@nombre, id_estudiante=@id_estudiante WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombreSeccion.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudianteSeccion.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id", txtIdSeccion.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
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
                    MessageBox.Show("Debe ingresar el ID de la sección a eliminar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM secciones WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtIdSeccion.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarSecciones();
                LimpiarCamposSeccion();
                MessageBox.Show("Sección eliminada correctamente.");
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
                var row = dgvGrados.CurrentRow;
                txtIdGrado.Text = row.Cells["id"].Value?.ToString();
                txtNombreGrado.Text = row.Cells["nombres"].Value?.ToString();
                SeleccionarComboBoxPorValor(cbEstudianteGrado, row.Cells["id_estudiante"].Value);
                cbNivelGrado.SelectedItem = row.Cells["nivel"].Value?.ToString();
            }
        }

        private void dgvSecciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSecciones.CurrentRow != null && dgvSecciones.CurrentRow.Index >= 0)
            {
                var row = dgvSecciones.CurrentRow;
                txtIdSeccion.Text = row.Cells["id"].Value?.ToString();
                txtNombreSeccion.Text = row.Cells["nombre"].Value?.ToString();
                SeleccionarComboBoxPorValor(cbEstudianteSeccion, row.Cells["id_estudiante"].Value);
            }
        }

        private void SeleccionarComboBoxPorValor(ComboBox combo, object valor)
        {
            foreach (ComboBoxItem item in combo.Items)
            {
                if ((item.Value == null && valor == null) || (item.Value != null && item.Value.ToString() == valor?.ToString()))
                {
                    combo.SelectedItem = item;
                    break;
                }
            }
        }

        private void LimpiarCamposGrado()
        {
            txtIdGrado.Text = "";
            txtNombreGrado.Text = "";
            cbEstudianteGrado.SelectedIndex = 0;
            cbNivelGrado.SelectedIndex = 0;
        }

        private void LimpiarCamposSeccion()
        {
            txtIdSeccion.Text = "";
            txtNombreSeccion.Text = "";
            cbEstudianteSeccion.SelectedIndex = 0;
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

        private void cbNivelGrado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvGrados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}