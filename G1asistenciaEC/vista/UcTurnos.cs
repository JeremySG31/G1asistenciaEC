using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.vista
{
    public partial class UcTurnos : UserControl
    {
        public UcTurnos()
        {
            InitializeComponent();
            CargarEstudiantes();
            CargarTurnos();
            dgvTurnos.SelectionChanged += dgvTurnos_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void CargarEstudiantes()
        {
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
            if (cbEstudiante.Items.Count > 0)
                cbEstudiante.SelectedIndex = 0;
        }

        private void CargarTurnos()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    t.id, 
                    t.nombre, 
                    t.id_estudiante
                FROM turnos t";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTurnos.DataSource = dt;

                    if (dgvTurnos.Columns.Contains("id"))
                        dgvTurnos.Columns["id"].HeaderText = "id";
                    if (dgvTurnos.Columns.Contains("nombre"))
                        dgvTurnos.Columns["nombre"].HeaderText = "nombre";
                    if (dgvTurnos.Columns.Contains("id_estudiante"))
                        dgvTurnos.Columns["id_estudiante"].HeaderText = "id_estudiante";

                    // Cambiar el orden de las columnas
                    if (dgvTurnos.Columns.Contains("id") && dgvTurnos.Columns.Contains("id_estudiante") && dgvTurnos.Columns.Contains("nombre"))
                    {
                        dgvTurnos.Columns["id"].DisplayIndex = 0;
                        dgvTurnos.Columns["id_estudiante"].DisplayIndex = 1;
                        dgvTurnos.Columns["nombre"].DisplayIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO turnos (id, nombre, id_estudiante) VALUES (@id, @nombre, @id_estudiante)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudiante.SelectedItem).Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarTurnos();
                LimpiarCampos();
                MessageBox.Show("Turno insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar turno: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del turno a modificar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "UPDATE turnos SET nombre=@nombre, id_estudiante=@id_estudiante WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@id_estudiante", ((ComboBoxItem)cbEstudiante.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarTurnos();
                LimpiarCampos();
                MessageBox.Show("Turno modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar turno: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del turno a eliminar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM turnos WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarTurnos();
                LimpiarCampos();
                MessageBox.Show("Turno eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar turno: " + ex.Message);
            }
        }

        private void dgvTurnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow != null && dgvTurnos.CurrentRow.Index >= 0)
            {
                var row = dgvTurnos.CurrentRow;
                txtId.Text = row.Cells["id"].Value?.ToString();
                txtNombre.Text = row.Cells["nombre"].Value?.ToString();
                SeleccionarComboBoxPorValor(cbEstudiante, row.Cells["id_estudiante"].Value);
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

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cbEstudiante.SelectedIndex = 0;
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
