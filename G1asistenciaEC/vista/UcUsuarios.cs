using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.vista
{
    public partial class UcUsuarios : UserControl
    {
        public UcUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarCombos();
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            u.id, 
                            e.id AS id_estudiante,
                            p.id AS id_profesor,
                            a.id AS id_apoderado,
                            u.nombre_usuario, 
                            u.nombres, 
                            u.ape_paterno, 
                            u.ape_materno, 
                            u.dni, 
                            u.correo, 
                            u.contrasena, 
                            u.rol, 
                            u.estado, 
                            u.telefono
                        FROM usuarios u
                        LEFT JOIN estudiantes e ON e.id_usuario = u.id
                        LEFT JOIN profesores p ON p.id_usuario = u.id
                        LEFT JOIN apoderados a ON a.id_usuario = u.id";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsuarios.DataSource = dt;

                    // Llenar columnas para filtrar
                    cbBuscarColumna.Items.Clear();
                    foreach (DataColumn col in dt.Columns)
                        cbBuscarColumna.Items.Add(col.ColumnName);
                    if (cbBuscarColumna.Items.Count > 0)
                        cbBuscarColumna.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void CargarCombos()
        {
            cbRol.Items.Clear();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id, nombre_rol FROM roles";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbRol.Items.Add(new ComboBoxItem
                        {
                            Text = reader["nombre_rol"].ToString(),
                            Value = reader["id"].ToString()
                        });
                    }
                }
            }
            cbRol.DisplayMember = "Text";
            cbRol.ValueMember = "Value";

            cbEstado.Items.Clear();
            cbEstado.Items.Add("activo");
            cbEstado.Items.Add("inactivo");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    var campos = new List<string>();
                    var valores = new List<string>();
                    var parametros = new List<SqlParameter>();

                    if (!string.IsNullOrWhiteSpace(txtId.Text)) { campos.Add("id"); valores.Add("@id"); parametros.Add(new SqlParameter("@id", txtId.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtNombreUsuario.Text)) { campos.Add("nombre_usuario"); valores.Add("@nombre_usuario"); parametros.Add(new SqlParameter("@nombre_usuario", txtNombreUsuario.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtNombres.Text)) { campos.Add("nombres"); valores.Add("@nombres"); parametros.Add(new SqlParameter("@nombres", txtNombres.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtApePaterno.Text)) { campos.Add("ape_paterno"); valores.Add("@ape_paterno"); parametros.Add(new SqlParameter("@ape_paterno", txtApePaterno.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtApeMaterno.Text)) { campos.Add("ape_materno"); valores.Add("@ape_materno"); parametros.Add(new SqlParameter("@ape_materno", txtApeMaterno.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtDni.Text)) { campos.Add("dni"); valores.Add("@dni"); parametros.Add(new SqlParameter("@dni", txtDni.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtCorreo.Text)) { campos.Add("correo"); valores.Add("@correo"); parametros.Add(new SqlParameter("@correo", txtCorreo.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtContrasena.Text)) { campos.Add("contrasena"); valores.Add("@contrasena"); parametros.Add(new SqlParameter("@contrasena", txtContrasena.Text)); }
                    if (!string.IsNullOrWhiteSpace(cbRol.Text)) { campos.Add("rol"); valores.Add("@rol"); parametros.Add(new SqlParameter("@rol", (cbRol.SelectedItem as ComboBoxItem)?.Value ?? "")); }
                    if (!string.IsNullOrWhiteSpace(cbEstado.Text)) { campos.Add("estado"); valores.Add("@estado"); parametros.Add(new SqlParameter("@estado", cbEstado.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtTelefono.Text)) { campos.Add("telefono"); valores.Add("@telefono"); parametros.Add(new SqlParameter("@telefono", txtTelefono.Text)); }

                    if (campos.Count == 0)
                    {
                        MessageBox.Show("Debe ingresar al menos un campo para insertar.");
                        return;
                    }

                    string query = $"INSERT INTO usuarios ({string.Join(",", campos)}) VALUES ({string.Join(",", valores)})";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                        cmd.ExecuteNonQuery();
                    }

                    // Insertar secundarios
                    InsertarSecundarios(
                        txtId.Text,
                        txtIdEstudiante.Text,
                        txtIdProfesor.Text,
                        txtIdApoderado.Text
                    );
                }
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del usuario a modificar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    var sets = new List<string>();
                    var parametros = new List<SqlParameter>();

                    if (!string.IsNullOrWhiteSpace(txtNombreUsuario.Text)) { sets.Add("nombre_usuario=@nombre_usuario"); parametros.Add(new SqlParameter("@nombre_usuario", txtNombreUsuario.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtNombres.Text)) { sets.Add("nombres=@nombres"); parametros.Add(new SqlParameter("@nombres", txtNombres.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtApePaterno.Text)) { sets.Add("ape_paterno=@ape_paterno"); parametros.Add(new SqlParameter("@ape_paterno", txtApePaterno.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtApeMaterno.Text)) { sets.Add("ape_materno=@ape_materno"); parametros.Add(new SqlParameter("@ape_materno", txtApeMaterno.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtDni.Text)) { sets.Add("dni=@dni"); parametros.Add(new SqlParameter("@dni", txtDni.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtCorreo.Text)) { sets.Add("correo=@correo"); parametros.Add(new SqlParameter("@correo", txtCorreo.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtContrasena.Text)) { sets.Add("contrasena=@contrasena"); parametros.Add(new SqlParameter("@contrasena", txtContrasena.Text)); }
                    if (!string.IsNullOrWhiteSpace(cbRol.Text)) { sets.Add("rol=@rol"); parametros.Add(new SqlParameter("@rol", (cbRol.SelectedItem as ComboBoxItem)?.Value ?? "")); }
                    if (!string.IsNullOrWhiteSpace(cbEstado.Text)) { sets.Add("estado=@estado"); parametros.Add(new SqlParameter("@estado", cbEstado.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtTelefono.Text)) { sets.Add("telefono=@telefono"); parametros.Add(new SqlParameter("@telefono", txtTelefono.Text)); }

                    if (sets.Count == 0)
                    {
                        MessageBox.Show("Debe ingresar al menos un campo para modificar.");
                        return;
                    }

                    string query = $"UPDATE usuarios SET {string.Join(",", sets)} WHERE id=@id";
                    parametros.Add(new SqlParameter("@id", txtId.Text));
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                        cmd.ExecuteNonQuery();
                    }

                    // Modificar secundarios
                    ModificarSecundarios(
                        txtId.Text,
                        txtIdEstudiante.Text,
                        txtIdProfesor.Text,
                        txtIdApoderado.Text
                    );
                }
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del usuario a eliminar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    // Eliminar secundarios
                    EliminarSecundarios(txtId.Text);

                    string query = "DELETE FROM usuarios WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.Index >= 0)
            {
                var row = dgvUsuarios.CurrentRow;
                txtId.Text = row.Cells["id"].Value?.ToString();
                txtIdEstudiante.Text = row.Cells["id_estudiante"].Value?.ToString();
                txtIdProfesor.Text = row.Cells["id_profesor"].Value?.ToString();
                txtIdApoderado.Text = row.Cells["id_apoderado"].Value?.ToString();
                txtNombreUsuario.Text = row.Cells["nombre_usuario"].Value?.ToString();
                txtNombres.Text = row.Cells["nombres"].Value?.ToString();
                txtApePaterno.Text = row.Cells["ape_paterno"].Value?.ToString();
                txtApeMaterno.Text = row.Cells["ape_materno"].Value?.ToString();
                txtDni.Text = row.Cells["dni"].Value?.ToString();
                txtCorreo.Text = row.Cells["correo"].Value?.ToString();
                txtContrasena.Text = row.Cells["contrasena"].Value?.ToString();
                cbRol.Text = row.Cells["rol"].Value?.ToString();
                cbEstado.Text = row.Cells["estado"].Value?.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value?.ToString();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.DataSource is DataTable dt && cbBuscarColumna.SelectedItem != null)
            {
                string columna = cbBuscarColumna.SelectedItem.ToString();
                string filtro = txtBuscar.Text.Replace("'", "''");
                (dgvUsuarios.DataSource as DataTable).DefaultView.RowFilter =
                    string.IsNullOrEmpty(filtro) ? "" : $"CONVERT([{columna}], System.String) LIKE '%{filtro}%'";
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtIdEstudiante.Text = "";
            txtIdProfesor.Text = "";
            txtIdApoderado.Text = "";
            txtNombreUsuario.Text = "";
            txtNombres.Text = "";
            txtApePaterno.Text = "";
            txtApeMaterno.Text = "";
            txtDni.Text = "";
            txtCorreo.Text = "";
            txtContrasena.Text = "";
            cbRol.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtTelefono.Text = "";
        }

        // Métodos auxiliares para gestionar secundarios
        private void InsertarSecundarios(string idUsuario, string idEstudiante, string idProfesor, string idApoderado)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                if (!string.IsNullOrWhiteSpace(idEstudiante))
                {
                    var cmd = new SqlCommand("INSERT INTO estudiantes (id, id_usuario) VALUES (@id, @id_usuario)", conn);
                    cmd.Parameters.AddWithValue("@id", idEstudiante);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(idProfesor))
                {
                    var cmd = new SqlCommand("INSERT INTO profesores (id, id_usuario) VALUES (@id, @id_usuario)", conn);
                    cmd.Parameters.AddWithValue("@id", idProfesor);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(idApoderado))
                {
                    var cmd = new SqlCommand("INSERT INTO apoderados (id, id_usuario) VALUES (@id, @id_usuario)", conn);
                    cmd.Parameters.AddWithValue("@id", idApoderado);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ModificarSecundarios(string idUsuario, string idEstudiante, string idProfesor, string idApoderado)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                // Estudiante
                if (!string.IsNullOrWhiteSpace(idEstudiante))
                {
                    var cmd = new SqlCommand(
                        "IF EXISTS (SELECT 1 FROM estudiantes WHERE id = @id) " +
                        "UPDATE estudiantes SET id_usuario = @id_usuario WHERE id = @id " +
                        "ELSE INSERT INTO estudiantes (id, id_usuario) VALUES (@id, @id_usuario)", conn);
                    cmd.Parameters.AddWithValue("@id", idEstudiante);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
                // Profesor
                if (!string.IsNullOrWhiteSpace(idProfesor))
                {
                    var cmd = new SqlCommand(
                        "IF EXISTS (SELECT 1 FROM profesores WHERE id = @id) " +
                        "UPDATE profesores SET id_usuario = @id_usuario WHERE id = @id " +
                        "ELSE INSERT INTO profesores (id, id_usuario) VALUES (@id, @id_usuario)", conn);
                    cmd.Parameters.AddWithValue("@id", idProfesor);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
                // Apoderado
                if (!string.IsNullOrWhiteSpace(idApoderado))
                {
                    var cmd = new SqlCommand(
                        "IF EXISTS (SELECT 1 FROM apoderados WHERE id = @id) " +
                        "UPDATE apoderados SET id_usuario = @id_usuario WHERE id = @id " +
                        "ELSE INSERT INTO apoderados (id, id_usuario) VALUES (@id, @id_usuario)", conn);
                    cmd.Parameters.AddWithValue("@id", idApoderado);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void EliminarSecundarios(string idUsuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd1 = new SqlCommand("DELETE FROM estudiantes WHERE id_usuario = @id_usuario", conn);
                cmd1.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd1.ExecuteNonQuery();

                var cmd2 = new SqlCommand("DELETE FROM profesores WHERE id_usuario = @id_usuario", conn);
                cmd2.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd2.ExecuteNonQuery();

                var cmd3 = new SqlCommand("DELETE FROM apoderados WHERE id_usuario = @id_usuario", conn);
                cmd3.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd3.ExecuteNonQuery();
            }
        }

        // Clase auxiliar para el ComboBox
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UcUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void lblNombreUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
