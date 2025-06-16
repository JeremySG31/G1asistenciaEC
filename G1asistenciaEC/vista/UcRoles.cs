using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using G1asistenciaEC.dao;

namespace G1asistenciaEC.vista
{
    public partial class UcRoles : UserControl
    {
        public UcRoles()
        {
            InitializeComponent();
            CargarRoles();
            dgvRoles.SelectionChanged += dgvRoles_SelectionChanged;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void CargarRoles()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT id, nombre_rol FROM roles";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRoles.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    // Solo insertamos los campos que el usuario haya escrito
                    var campos = new List<string>();
                    var valores = new List<string>();
                    var parametros = new List<SqlParameter>();

                    if (!string.IsNullOrWhiteSpace(txtId.Text)) { campos.Add("id"); valores.Add("@id"); parametros.Add(new SqlParameter("@id", txtId.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtNombreRol.Text)) { campos.Add("nombre_rol"); valores.Add("@nombre_rol"); parametros.Add(new SqlParameter("@nombre_rol", txtNombreRol.Text)); }
  

                    if (campos.Count == 0)
                    {
                        MessageBox.Show("Debe ingresar al menos un campo para insertar.");
                        return;
                    }

                    string query = $"INSERT INTO roles ({string.Join(",", campos)}) VALUES ({string.Join(",", valores)})";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarRoles();
                LimpiarCampos();
                MessageBox.Show("Usuario insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar roles: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del rol a modificar.");
                    return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    var sets = new List<string>();
                    var parametros = new List<SqlParameter>();

                    if (!string.IsNullOrWhiteSpace(txtId.Text)) { sets.Add("id=@id"); parametros.Add(new SqlParameter("@id", txtId.Text)); }
                    if (!string.IsNullOrWhiteSpace(txtNombreRol.Text)) { sets.Add("nombre_rol=@nombre_rol"); parametros.Add(new SqlParameter("@nombre_rol", txtNombreRol.Text)); }

                    if (sets.Count == 0)
                    {
                        MessageBox.Show("Debe ingresar al menos un campo para modificar.");
                        return;
                    }

                    string query = $"UPDATE roles SET {string.Join(",", sets)} WHERE id=@id";
                    parametros.Add(new SqlParameter("@id", txtId.Text));
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarRoles();
                LimpiarCampos();
                MessageBox.Show("Usuario modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar rol: " + ex.Message);
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
                    string query = "DELETE FROM roles WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarRoles();
                LimpiarCampos();
                MessageBox.Show("Rol eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar rol: " + ex.Message);
            }
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow != null && dgvRoles.CurrentRow.Index >= 0)
            {
                var row = dgvRoles.CurrentRow;
                txtId.Text = row.Cells["id"].Value?.ToString();
                txtNombreRol.Text = row.Cells["nombre_rol"].Value?.ToString();
         
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombreRol.Text = "";

        }

        // Clase auxiliar para el ComboBox
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
