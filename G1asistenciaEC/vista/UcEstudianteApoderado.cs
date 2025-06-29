using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace G1asistenciaEC.vista
{
    public partial class UcEstudianteApoderado : UserControl
    {
        private readonly EstudianteApoderadoN _negocio = new EstudianteApoderadoN();
        private List<EstudianteApoderadoM> _listaOriginal = new List<EstudianteApoderadoM>();

        public UcEstudianteApoderado()
        {
            InitializeComponent();
            CargarCombos();
            CargarEstudianteApoderados();
            ConfigurarEventos();
            PoblarColumnasBusqueda();
        }

        private void ConfigurarEventos()
        {
            button1.Click += btnInsertar_Click;
            button2.Click += btnModificar_Click;
            button3.Click += btnEliminar_Click;
            btnRegistrarApoderado.Click += btnRegistrarApoderado_Click;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void CargarCombos()
        {
            cbIdEstudiante.Items.Clear();
            foreach (var est in _negocio.ObtenerEstudiantes())
                cbIdEstudiante.Items.Add(new ComboBoxItem($"{est.Key} - {est.Value}", est.Key));

            cbIdApoderado.Items.Clear();
            foreach (var apo in _negocio.ObtenerApoderados())
                cbIdApoderado.Items.Add(new ComboBoxItem($"{apo.Key} - {apo.Value}", apo.Key));

            cbPrioridad.Items.Clear();
            cbPrioridad.Items.Add(new ComboBoxItem("1 - Muy baja", 1));
            cbPrioridad.Items.Add(new ComboBoxItem("2 - Baja", 2));
            cbPrioridad.Items.Add(new ComboBoxItem("3 - Media", 3));
            cbPrioridad.Items.Add(new ComboBoxItem("4 - Alta", 4));
            cbPrioridad.Items.Add(new ComboBoxItem("5 - Muy alta", 5));
            cbPrioridad.SelectedIndex = 2;

            cbEstado.Items.Clear();
            cbEstado.Items.Add("activo");
            cbEstado.Items.Add("inactivo");
            cbEstado.SelectedIndex = 0;
        }

        private void CargarEstudianteApoderados()
        {
            try
            {
                _listaOriginal = _negocio.ObtenerTodos();
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = _listaOriginal;
                ConfigurarColumnas();
                PoblarColumnasBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiante-apoderados: " + ex.Message);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvUsuarios.Columns.Contains("Id"))
                dgvUsuarios.Columns["Id"].HeaderText = "ID";
            if (dgvUsuarios.Columns.Contains("IdEstudiante"))
                dgvUsuarios.Columns["IdEstudiante"].Visible = false;
            if (dgvUsuarios.Columns.Contains("IdApoderado"))
                dgvUsuarios.Columns["IdApoderado"].Visible = false;
            if (dgvUsuarios.Columns.Contains("NombreEstudiante"))
                dgvUsuarios.Columns["NombreEstudiante"].HeaderText = "Estudiante";
            if (dgvUsuarios.Columns.Contains("NombreApoderado"))
                dgvUsuarios.Columns["NombreApoderado"].HeaderText = "Apoderado";
            if (dgvUsuarios.Columns.Contains("Parentesco"))
                dgvUsuarios.Columns["Parentesco"].HeaderText = "Parentesco";
            if (dgvUsuarios.Columns.Contains("Prioridad"))
                dgvUsuarios.Columns["Prioridad"].HeaderText = "Prioridad";
            if (dgvUsuarios.Columns.Contains("Estado"))
                dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
        }

        private void PoblarColumnasBusqueda()
        {
            cbBuscarColumna.Items.Clear();
            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
            {
                if (col.Visible)
                    cbBuscarColumna.Items.Add(col.HeaderText);
            }
            if (cbBuscarColumna.Items.Count > 0)
                cbBuscarColumna.SelectedIndex = 0;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                {
                    MessageBox.Show("Debe completar todos los campos requeridos.");
                    return;
                }

                var estudianteApoderado = new EstudianteApoderadoM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbIdEstudiante.SelectedItem).Value.ToString(),
                    IdApoderado = ((ComboBoxItem)cbIdApoderado.SelectedItem).Value.ToString(),
                    Parentesco = txtParentesco.Text,
                    Prioridad = (int)((ComboBoxItem)cbPrioridad.SelectedItem).Value,
                    Estado = cbEstado.SelectedItem.ToString()
                };

                _negocio.Insertar(estudianteApoderado);
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
                    MessageBox.Show("Debe seleccionar un registro para modificar.");
                    return;
                }
                if (!ValidarCampos())
                {
                    MessageBox.Show("Debe completar todos los campos requeridos.");
                    return;
                }

                var estudianteApoderado = new EstudianteApoderadoM
                {
                    Id = txtId.Text,
                    IdEstudiante = ((ComboBoxItem)cbIdEstudiante.SelectedItem).Value.ToString(),
                    IdApoderado = ((ComboBoxItem)cbIdApoderado.SelectedItem).Value.ToString(),
                    Parentesco = txtParentesco.Text,
                    Prioridad = (int)((ComboBoxItem)cbPrioridad.SelectedItem).Value,
                    Estado = cbEstado.SelectedItem.ToString()
                };

                _negocio.Modificar(estudianteApoderado);
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
                    MessageBox.Show("Debe seleccionar un registro para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _negocio.Eliminar(txtId.Text);
                    CargarEstudianteApoderados();
                    LimpiarCampos();
                    MessageBox.Show("Registro eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.DataBoundItem is EstudianteApoderadoM ea)
            {
                txtId.Text = ea.Id;
                SeleccionarComboBoxPorValor(cbIdEstudiante, ea.IdEstudiante);
                SeleccionarComboBoxPorValor(cbIdApoderado, ea.IdApoderado);
                txtParentesco.Text = ea.Parentesco;
                SeleccionarComboBoxPorValor(cbPrioridad, ea.Prioridad);
                cbEstado.SelectedItem = ea.Estado;
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
            cbIdEstudiante.SelectedIndex = -1;
            cbIdApoderado.SelectedIndex = -1;
            txtParentesco.Text = "";
            cbPrioridad.SelectedIndex = 2;
            cbEstado.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) return false;
            if (cbIdEstudiante.SelectedItem == null) return false;
            if (cbIdApoderado.SelectedItem == null) return false;
            if (string.IsNullOrWhiteSpace(txtParentesco.Text)) return false;
            if (cbPrioridad.SelectedItem == null) return false;
            if (cbEstado.SelectedItem == null) return false;
            return true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void FiltrarDatos()
        {
            if (_listaOriginal == null) return;

            string columna = cbBuscarColumna.SelectedItem?.ToString();
            string filtro = txtBuscar.Text.Trim().ToLower();

            var filtrada = _listaOriginal;

            if (!string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(columna))
            {
                switch (columna)
                {
                    case "ID":
                        filtrada = _listaOriginal.FindAll(x => (x.Id ?? "").ToLower().Contains(filtro));
                        break;
                    case "Estudiante":
                        filtrada = _listaOriginal.FindAll(x => (x.NombreEstudiante ?? "").ToLower().Contains(filtro));
                        break;
                    case "Apoderado":
                        filtrada = _listaOriginal.FindAll(x => (x.NombreApoderado ?? "").ToLower().Contains(filtro));
                        break;
                    case "Parentesco":
                        filtrada = _listaOriginal.FindAll(x => (x.Parentesco ?? "").ToLower().Contains(filtro));
                        break;
                    case "Prioridad":
                        filtrada = _listaOriginal.FindAll(x => x.Prioridad.ToString().Contains(filtro));
                        break;
                    case "Estado":
                        filtrada = _listaOriginal.FindAll(x => (x.Estado ?? "").ToLower().Contains(filtro));
                        break;
                    default:
                        filtrada = _listaOriginal;
                        break;
                }
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = filtrada;
            ConfigurarColumnas();
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

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private bool ApoderadoIdExiste(string idApoderado)
        {
            // Busca en la lista de apoderados existentes
            foreach (ComboBoxItem item in cbIdApoderado.Items)
            {
                if (item.Value.ToString().Equals(idApoderado, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private bool UsuarioIdExiste(string idUsuario)
        {
            var usuariosNegocio = new UsuariosN();
            var dt = usuariosNegocio.ObtenerTodos();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                if (row["id"].ToString().Equals(idUsuario, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private string SiguienteIdApoderado()
        {
            int max = 0;
            foreach (ComboBoxItem item in cbIdApoderado.Items)
            {
                string value = item.Value.ToString();
                if (value.StartsWith("A") && int.TryParse(value.Substring(1), out int num))
                {
                    if (num > max) max = num;
                }
            }
            return $"A{(max + 1):D2}";
        }

        private string SiguienteIdUsuario()
        {
            // Obtener todos los usuarios desde la base de datos
            var usuariosNegocio = new UsuariosN();
            var dt = usuariosNegocio.ObtenerTodos(); // DataTable con columna "id"
            int max = 0;
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string value = row["id"].ToString();
                if (value.StartsWith("U") && int.TryParse(value.Substring(1), out int num))
                {
                    if (num > max) max = num;
                }
            }
            return $"U{(max + 1):D2}";
        }

        private void btnRegistrarApoderado_Click(object sender, EventArgs e)
        {
            string sugeridoApoderado = SiguienteIdApoderado();
            string sugeridoUsuario = SiguienteIdUsuario();
            using (var form = new FormNuevoApoderado(sugeridoApoderado, sugeridoUsuario))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string idApoderadoManual = form.IdApoderadoManual;
                    string idUsuarioManual = form.IdUsuarioManual;
                    string dni = form.Dni;
                    string nombres = form.Nombres;
                    string apePaterno = form.ApePaterno;
                    string apeMaterno = form.ApeMaterno;
                    string correo = form.Correo;
                    string telefono = form.Telefono;
                    string nombreUsuario = form.NombreUsuario;
                    string contrasena = form.Contrasena;
                    string estado = "activo";

                    if (ApoderadoIdExiste(idApoderadoManual))
                    {
                        MessageBox.Show("El ID de apoderado ya existe. Por favor, ingrese otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (UsuarioIdExiste(idUsuarioManual))
                    {
                        MessageBox.Show("El ID de usuario ya existe. Por favor, ingrese otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        var usuario = new UsuariosM
                        {
                            Id = idUsuarioManual,
                            IdApoderado = idApoderadoManual,
                            NombreUsuario = nombreUsuario,
                            Nombres = nombres,
                            ApePaterno = apePaterno,
                            ApeMaterno = apeMaterno,
                            Dni = dni,
                            Correo = correo,
                            Contrasena = contrasena,
                            Rol = "apoderado",
                            Estado = estado,
                            Telefono = telefono
                        };

                        var usuariosNegocio = new UsuariosN();
                        usuariosNegocio.Insertar(usuario);

                        CargarCombos();

                        foreach (ComboBoxItem item in cbIdApoderado.Items)
                        {
                            if (item.Text.Contains(nombres) && item.Text.Contains(apePaterno))
                            {
                                cbIdApoderado.SelectedItem = item;
                                break;
                            }
                        }

                        MessageBox.Show(
                            $"Apoderado registrado:\n\n" +
                            $"DNI: {dni}\n" +
                            $"Nombres: {nombres}\n" +
                            $"Apellido Paterno: {apePaterno}\n" +
                            $"Apellido Materno: {apeMaterno}\n" +
                            $"Usuario: {nombreUsuario}\n" +
                            $"Rol: apoderado\n" +
                            $"Estado: {estado}",
                            "Nuevo Apoderado Registrado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar apoderado: " + ex.Message);
                    }
                }
            }
        }

        private void grpDatosPrincipales_Enter(object sender, EventArgs e)
        {

        }
    }

    public class FormNuevoApoderado : Form
    {
        public string IdApoderadoManual => txtIdApoderado.Text.Trim();
        public string IdUsuarioManual => txtIdUsuario.Text.Trim();
        public string Dni => txtDni.Text.Trim();
        public string Nombres => txtNombres.Text.Trim();
        public string ApePaterno => txtApePaterno.Text.Trim();
        public string ApeMaterno => txtApeMaterno.Text.Trim();
        public string Correo => txtCorreo.Text.Trim();
        public string Telefono => txtTelefono.Text.Trim();
        public string NombreUsuario => txtUsuario.Text.Trim();
        public string Contrasena => txtContrasena.Text;

        private TextBox txtIdApoderado, txtIdUsuario, txtDni, txtNombres, txtApePaterno, txtApeMaterno, txtCorreo, txtTelefono, txtUsuario, txtContrasena;
        private CheckBox chkMostrarContrasena;

        public FormNuevoApoderado(string idSugeridoApoderado = "", string idSugeridoUsuario = "")
        {
            this.Text = "Nuevo Apoderado";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 400;
            this.Height = 500; // Aumenta el alto para más espacio
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int y = 20;
            int labelWidth = 120;
            int textLeft = 150;
            int textWidth = 200;
            int spacing = 35;

            var lblIdApoderado = new Label { Text = "ID Apoderado:", Left = 20, Top = y, Width = labelWidth };
            txtIdApoderado = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 10, Text = idSugeridoApoderado };
            y += spacing;

            var lblIdUsuario = new Label { Text = "ID Usuario:", Left = 20, Top = y, Width = labelWidth };
            txtIdUsuario = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 10, Text = idSugeridoUsuario };
            y += spacing;

            var lblDni = new Label { Text = "DNI (8 dígitos):", Left = 20, Top = y, Width = labelWidth };
            txtDni = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 8 };
            txtDni.KeyPress += SoloNumeros_KeyPress;
            y += spacing;

            var lblNombres = new Label { Text = "Nombres:", Left = 20, Top = y, Width = labelWidth };
            txtNombres = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 30 };
            txtNombres.KeyPress += SoloLetras_KeyPress;
            y += spacing;

            var lblApePaterno = new Label { Text = "Apellido paterno:", Left = 20, Top = y, Width = labelWidth };
            txtApePaterno = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 20 };
            txtApePaterno.KeyPress += SoloLetras_KeyPress;
            y += spacing;

            var lblApeMaterno = new Label { Text = "Apellido materno:", Left = 20, Top = y, Width = labelWidth };
            txtApeMaterno = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 20 };
            txtApeMaterno.KeyPress += SoloLetras_KeyPress;
            y += spacing;

            var lblCorreo = new Label { Text = "Correo:", Left = 20, Top = y, Width = labelWidth };
            txtCorreo = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 100 };
            y += spacing;

            var lblTelefono = new Label { Text = "Teléfono (9 dígitos):", Left = 20, Top = y, Width = labelWidth };
            txtTelefono = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 9 };
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            y += spacing;

            var lblUsuario = new Label { Text = "Usuario:", Left = 20, Top = y, Width = labelWidth };
            txtUsuario = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 20 };
            y += spacing;

            var lblContrasena = new Label { Text = "Contraseña (máx 12):", Left = 20, Top = y, Width = labelWidth };
            txtContrasena = new TextBox { Left = textLeft, Top = y, Width = textWidth, MaxLength = 12, UseSystemPasswordChar = true };
            y += spacing;

            chkMostrarContrasena = new CheckBox { Text = "Mostrar contraseña", Left = textLeft, Top = y, Width = textWidth };
            chkMostrarContrasena.CheckedChanged += (s, e) =>
            {
                txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
            };
            y += spacing;

            var btnAceptar = new Button { Text = "Registrar", Left = textLeft, Top = y, Width = 90, DialogResult = DialogResult.OK };
            var btnCancelar = new Button { Text = "Cancelar", Left = textLeft + 110, Top = y, Width = 90, DialogResult = DialogResult.Cancel };

            btnAceptar.Click += (s, e) =>
            {
                var errores = "";

                if (string.IsNullOrWhiteSpace(IdApoderadoManual))
                    errores += "- El campo ID Apoderado es obligatorio.\n";
                else if (!System.Text.RegularExpressions.Regex.IsMatch(IdApoderadoManual, @"^A\d{2,}$"))
                    errores += "- El ID Apoderado debe tener el formato A## (ejemplo: A03).\n";

                if (string.IsNullOrWhiteSpace(IdUsuarioManual))
                    errores += "- El campo ID Usuario es obligatorio.\n";
                else if (!System.Text.RegularExpressions.Regex.IsMatch(IdUsuarioManual, @"^U\d{2,}$"))
                    errores += "- El ID Usuario debe tener el formato U## (ejemplo: U03).\n";

                if (string.IsNullOrWhiteSpace(Dni))
                    errores += "- El campo DNI es obligatorio.\n";
                else if (Dni.Length != 8 || !EsNumerico(Dni))
                    errores += "- El DNI debe tener 8 dígitos.\n";

                if (string.IsNullOrWhiteSpace(Nombres))
                    errores += "- El campo Nombres es obligatorio.\n";
                else if (Nombres.Length > 30)
                    errores += "- El campo Nombres no puede exceder 30 caracteres.\n";
                else if (!EsSoloLetras(Nombres))
                    errores += "- El campo Nombres solo puede contener letras y espacios.\n";

                if (string.IsNullOrWhiteSpace(ApePaterno))
                    errores += "- El campo Apellido Paterno es obligatorio.\n";
                else if (ApePaterno.Length > 20)
                    errores += "- El campo Apellido Paterno no puede exceder 20 caracteres.\n";
                else if (!EsSoloLetras(ApePaterno))
                    errores += "- El campo Apellido Paterno solo puede contener letras y espacios.\n";

                if (string.IsNullOrWhiteSpace(ApeMaterno))
                    errores += "- El campo Apellido Materno es obligatorio.\n";
                else if (ApeMaterno.Length > 20)
                    errores += "- El campo Apellido Materno no puede exceder 20 caracteres.\n";
                else if (!EsSoloLetras(ApeMaterno))
                    errores += "- El campo Apellido Materno solo puede contener letras y espacios.\n";

                if (string.IsNullOrWhiteSpace(Correo))
                    errores += "- El campo Correo es obligatorio.\n";
                else if (Correo.Length > 100)
                    errores += "- El correo no puede exceder 100 caracteres.\n";
                else if (!Correo.EndsWith("@cole.edu", StringComparison.OrdinalIgnoreCase))
                    errores += "- El correo debe terminar con @cole.edu.\n";

                if (!string.IsNullOrWhiteSpace(Telefono) && (Telefono.Length != 9 || !EsNumerico(Telefono)))
                    errores += "- El teléfono debe tener 9 dígitos.\n";

                if (string.IsNullOrWhiteSpace(NombreUsuario))
                    errores += "- El campo Usuario es obligatorio.\n";
                else if (NombreUsuario.Length > 20)
                    errores += "- El campo Usuario no puede exceder 20 caracteres.\n";

                if (Contrasena.Length > 12)
                    errores += "- La contraseña no debe exceder 12 caracteres.\n";

                if (!string.IsNullOrEmpty(errores))
                {
                    MessageBox.Show("Por favor corrija los siguientes errores:\n\n" + errores, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }
            };

            this.Controls.AddRange(new Control[] {
                lblIdApoderado, txtIdApoderado,
                lblIdUsuario, txtIdUsuario,
                lblDni, txtDni, lblNombres, txtNombres, lblApePaterno, txtApePaterno, lblApeMaterno, txtApeMaterno,
                lblCorreo, txtCorreo, lblTelefono, txtTelefono, lblUsuario, txtUsuario, lblContrasena, txtContrasena,
                chkMostrarContrasena, btnAceptar, btnCancelar
            });

            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
        }

        private void LimpiarCampos()
        {
            txtIdApoderado.Text = "";
            txtIdUsuario.Text = "";
            txtDni.Text = "";
            txtNombres.Text = "";
            txtApePaterno.Text = "";
            txtApeMaterno.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            chkMostrarContrasena.Checked = false;
        }

        private bool EsNumerico(string texto)
        {
            foreach (char c in texto)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }

        private bool EsSoloLetras(string texto)
        {
            foreach (char c in texto)
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            return true;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
