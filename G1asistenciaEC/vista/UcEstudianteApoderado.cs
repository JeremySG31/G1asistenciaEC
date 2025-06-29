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

        private void btnRegistrarApoderado_Click(object sender, EventArgs e)
        {
            using (var form = new FormNuevoApoderado())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string dni = form.Dni;
                    string nombres = form.Nombres;
                    string apePaterno = form.ApePaterno;
                    string apeMaterno = form.ApeMaterno;
                    string correo = form.Correo;
                    string telefono = form.Telefono;
                    string nombreUsuario = form.NombreUsuario;
                    string contrasena = form.Contrasena;
                    string estado = "activo";

                    try
                    {
                        string idUsuario = "U" + DateTime.Now.Ticks.ToString().Substring(8, 6);
                        string idApoderado = "A" + DateTime.Now.Ticks.ToString().Substring(8, 6);

                        var usuario = new UsuariosM
                        {
                            Id = idUsuario,
                            IdApoderado = idApoderado,
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
        public string Dni => txtDni.Text.Trim();
        public string Nombres => txtNombres.Text.Trim();
        public string ApePaterno => txtApePaterno.Text.Trim();
        public string ApeMaterno => txtApeMaterno.Text.Trim();
        public string Correo => txtCorreo.Text.Trim();
        public string Telefono => txtTelefono.Text.Trim();
        public string NombreUsuario => txtUsuario.Text.Trim();
        public string Contrasena => txtContrasena.Text;

        private TextBox txtDni, txtNombres, txtApePaterno, txtApeMaterno, txtCorreo, txtTelefono, txtUsuario, txtContrasena;
        private CheckBox chkMostrarContrasena;

        public FormNuevoApoderado()
        {
            this.Text = "Nuevo Apoderado";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 400;
            this.Height = 440;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblDni = new Label { Text = "DNI (8 dígitos):", Left = 20, Top = 20, Width = 120 };
            txtDni = new TextBox { Left = 150, Top = 20, Width = 200, MaxLength = 8 };
            txtDni.KeyPress += SoloNumeros_KeyPress;

            var lblNombres = new Label { Text = "Nombres:", Left = 20, Top = 55, Width = 120 };
            txtNombres = new TextBox { Left = 150, Top = 55, Width = 200, MaxLength = 30 };
            txtNombres.KeyPress += SoloLetras_KeyPress;

            var lblApePaterno = new Label { Text = "Apellido paterno:", Left = 20, Top = 90, Width = 120 };
            txtApePaterno = new TextBox { Left = 150, Top = 90, Width = 200, MaxLength = 20 };
            txtApePaterno.KeyPress += SoloLetras_KeyPress;

            var lblApeMaterno = new Label { Text = "Apellido materno:", Left = 20, Top = 125, Width = 120 };
            txtApeMaterno = new TextBox { Left = 150, Top = 125, Width = 200, MaxLength = 20 };
            txtApeMaterno.KeyPress += SoloLetras_KeyPress;

            var lblCorreo = new Label { Text = "Correo:", Left = 20, Top = 160, Width = 120 };
            txtCorreo = new TextBox { Left = 150, Top = 160, Width = 200, MaxLength = 100 };

            var lblTelefono = new Label { Text = "Teléfono (9 dígitos):", Left = 20, Top = 195, Width = 120 };
            txtTelefono = new TextBox { Left = 150, Top = 195, Width = 200, MaxLength = 9 };
            txtTelefono.KeyPress += SoloNumeros_KeyPress;

            var lblUsuario = new Label { Text = "Usuario:", Left = 20, Top = 230, Width = 120 };
            txtUsuario = new TextBox { Left = 150, Top = 230, Width = 200, MaxLength = 20 };

            var lblContrasena = new Label { Text = "Contraseña (máx 12):", Left = 20, Top = 265, Width = 120 };
            txtContrasena = new TextBox { Left = 150, Top = 265, Width = 200, MaxLength = 12, UseSystemPasswordChar = true };

            chkMostrarContrasena = new CheckBox { Text = "Mostrar contraseña", Left = 150, Top = 295, Width = 200 };
            chkMostrarContrasena.CheckedChanged += (s, e) =>
            {
                txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
            };

            var btnAceptar = new Button { Text = "Registrar", Left = 150, Top = 330, Width = 90, DialogResult = DialogResult.OK };
            var btnCancelar = new Button { Text = "Cancelar", Left = 260, Top = 330, Width = 90, DialogResult = DialogResult.Cancel };

            btnAceptar.Click += (s, e) =>
            {
                var errores = "";

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
                    errores += "- El teléfono debe contener solo números y tener 9 dígitos.\n";

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
                lblDni, txtDni, lblNombres, txtNombres, lblApePaterno, txtApePaterno, lblApeMaterno, txtApeMaterno,
                lblCorreo, txtCorreo, lblTelefono, txtTelefono, lblUsuario, txtUsuario, lblContrasena, txtContrasena,
                chkMostrarContrasena, btnAceptar, btnCancelar
            });

            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
        }

        private void LimpiarCampos()
        {
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
