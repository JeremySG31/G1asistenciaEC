namespace G1asistenciaEC.vista
{
    partial class UcUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApePaterno;
        private System.Windows.Forms.TextBox txtApeMaterno;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApePaterno;
        private System.Windows.Forms.Label lblApeMaterno;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbBuscarColumna;
        private System.Windows.Forms.TextBox txtIdEstudiante;
        private System.Windows.Forms.TextBox txtIdProfesor;
        private System.Windows.Forms.TextBox txtIdApoderado;
        private System.Windows.Forms.Label lblIdEstudiante; 
        private System.Windows.Forms.Label lblIdProfesor;
        private System.Windows.Forms.Label lblIdApoderado;
        private System.Windows.Forms.CheckBox chkIdEstudiante;
        private System.Windows.Forms.CheckBox chkIdProfesor;
        private System.Windows.Forms.CheckBox chkIdApoderado;
        private System.Windows.Forms.GroupBox grpDatosPrincipales;
        private System.Windows.Forms.GroupBox grpInformacionAdicional;
        private System.Windows.Forms.GroupBox grpIdentificadoresEspecificos;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.GroupBox grpListadoBusqueda;


        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                txtId.MaxLength = 5;
                txtNombreUsuario.MaxLength = 20;
                txtDni.MaxLength = 8;
                txtContrasena.MaxLength = 12;
                txtTelefono.MaxLength = 9;






            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApePaterno = new System.Windows.Forms.TextBox();
            this.txtApeMaterno = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblApePaterno = new System.Windows.Forms.Label();
            this.lblApeMaterno = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbBuscarColumna = new System.Windows.Forms.ComboBox();
            this.txtIdEstudiante = new System.Windows.Forms.TextBox();
            this.txtIdProfesor = new System.Windows.Forms.TextBox();
            this.txtIdApoderado = new System.Windows.Forms.TextBox();
            this.lblIdEstudiante = new System.Windows.Forms.Label();
            this.lblIdProfesor = new System.Windows.Forms.Label();
            this.lblIdApoderado = new System.Windows.Forms.Label();
            this.chkIdEstudiante = new System.Windows.Forms.CheckBox();
            this.chkIdProfesor = new System.Windows.Forms.CheckBox();
            this.chkIdApoderado = new System.Windows.Forms.CheckBox();
            this.grpDatosPrincipales = new System.Windows.Forms.GroupBox();
            this.grpInformacionAdicional = new System.Windows.Forms.GroupBox();
            this.grpIdentificadoresEspecificos = new System.Windows.Forms.GroupBox();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.grpListadoBusqueda = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grpDatosPrincipales.SuspendLayout();
            this.grpInformacionAdicional.SuspendLayout();
            this.grpIdentificadoresEspecificos.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.grpListadoBusqueda.SuspendLayout();
            this.SuspendLayout();

            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.ColumnHeadersHeight = 29;
            this.dgvUsuarios.Location = new System.Drawing.Point(10, 45);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.Size = new System.Drawing.Size(521, 395);
            this.dgvUsuarios.TabIndex = 3;
  
            this.btnInsertar.Location = new System.Drawing.Point(15, 20);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(108, 25);
            this.btnInsertar.TabIndex = 0;
            this.btnInsertar.Text = "INSERTAR";

            this.btnModificar.Location = new System.Drawing.Point(15, 48);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(108, 25);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "MODIFICAR";

            this.btnEliminar.Location = new System.Drawing.Point(15, 76);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 25);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "ELIMINAR";

            this.txtId.Location = new System.Drawing.Point(120, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 22);
            this.txtId.TabIndex = 1;

            this.txtNombreUsuario.Location = new System.Drawing.Point(120, 48);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(200, 22);
            this.txtNombreUsuario.TabIndex = 3;

            this.txtNombres.Location = new System.Drawing.Point(120, 76);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(200, 22);
            this.txtNombres.TabIndex = 5;
 
            this.txtApePaterno.Location = new System.Drawing.Point(120, 104);
            this.txtApePaterno.Name = "txtApePaterno";
            this.txtApePaterno.Size = new System.Drawing.Size(200, 22);
            this.txtApePaterno.TabIndex = 7;

            this.txtApeMaterno.Location = new System.Drawing.Point(120, 132);
            this.txtApeMaterno.Name = "txtApeMaterno";
            this.txtApeMaterno.Size = new System.Drawing.Size(200, 22);
            this.txtApeMaterno.TabIndex = 9;

            this.txtDni.Location = new System.Drawing.Point(120, 160);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(200, 22);
            this.txtDni.TabIndex = 11;

            this.txtCorreo.Location = new System.Drawing.Point(120, 188);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(200, 22);
            this.txtCorreo.TabIndex = 13;

            this.txtContrasena.Location = new System.Drawing.Point(120, 216);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(200, 22);
            this.txtContrasena.TabIndex = 15;
 
            this.cbRol.Location = new System.Drawing.Point(70, 20);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(200, 24);
            this.cbRol.TabIndex = 1;

            this.cbEstado.Location = new System.Drawing.Point(70, 48);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(200, 24);
            this.cbEstado.TabIndex = 3;

            this.txtTelefono.Location = new System.Drawing.Point(120, 244);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 22);
            this.txtTelefono.TabIndex = 17;
 
            this.lblId.Location = new System.Drawing.Point(10, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 23);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";

            this.lblNombreUsuario.Location = new System.Drawing.Point(10, 48);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(100, 23);
            this.lblNombreUsuario.TabIndex = 2;
            this.lblNombreUsuario.Text = "Usuario:";

            this.lblNombres.Location = new System.Drawing.Point(10, 76);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(100, 23);
            this.lblNombres.TabIndex = 4;
            this.lblNombres.Text = "Nombres:";

            this.lblApePaterno.Location = new System.Drawing.Point(8, 104);
            this.lblApePaterno.Name = "lblApePaterno";
            this.lblApePaterno.Size = new System.Drawing.Size(123, 23);
            this.lblApePaterno.TabIndex = 6;
            this.lblApePaterno.Text = "Apellido Paterno:";

            this.lblApeMaterno.Location = new System.Drawing.Point(8, 132);
            this.lblApeMaterno.Name = "lblApeMaterno";
            this.lblApeMaterno.Size = new System.Drawing.Size(123, 23);
            this.lblApeMaterno.TabIndex = 8;
            this.lblApeMaterno.Text = "Apellido Materno:";

            this.lblDni.Location = new System.Drawing.Point(10, 160);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(100, 23);
            this.lblDni.TabIndex = 10;
            this.lblDni.Text = "DNI:";

            this.lblCorreo.Location = new System.Drawing.Point(10, 188);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(100, 23);
            this.lblCorreo.TabIndex = 12;
            this.lblCorreo.Text = "Correo:";

            this.lblContrasena.Location = new System.Drawing.Point(10, 216);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(100, 23);
            this.lblContrasena.TabIndex = 14;
            this.lblContrasena.Text = "Contraseña:";

            this.lblRol.Location = new System.Drawing.Point(10, 20);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(54, 23);
            this.lblRol.TabIndex = 0;
            this.lblRol.Text = "Rol:";

            this.lblEstado.Location = new System.Drawing.Point(10, 48);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(54, 23);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";

            this.lblTelefono.Location = new System.Drawing.Point(10, 244);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(100, 23);
            this.lblTelefono.TabIndex = 16;
            this.lblTelefono.Text = "Teléfono:";

            this.txtBuscar.Location = new System.Drawing.Point(247, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(230, 22);
            this.txtBuscar.TabIndex = 2;

            this.cbBuscarColumna.Location = new System.Drawing.Point(70, 17);
            this.cbBuscarColumna.Name = "cbBuscarColumna";
            this.cbBuscarColumna.Size = new System.Drawing.Size(140, 24);
            this.cbBuscarColumna.TabIndex = 1;

            this.txtIdEstudiante.Enabled = false;
            this.txtIdEstudiante.Location = new System.Drawing.Point(315, 18);
            this.txtIdEstudiante.Name = "txtIdEstudiante";
            this.txtIdEstudiante.Size = new System.Drawing.Size(150, 22);
            this.txtIdEstudiante.TabIndex = 2;
            this.txtIdEstudiante.Visible = false;

            this.txtIdProfesor.Enabled = false;
            this.txtIdProfesor.Location = new System.Drawing.Point(315, 43);
            this.txtIdProfesor.Name = "txtIdProfesor";
            this.txtIdProfesor.Size = new System.Drawing.Size(150, 22);
            this.txtIdProfesor.TabIndex = 5;
            this.txtIdProfesor.Visible = false;

            this.txtIdApoderado.Enabled = false;
            this.txtIdApoderado.Location = new System.Drawing.Point(315, 69);
            this.txtIdApoderado.Name = "txtIdApoderado";
            this.txtIdApoderado.Size = new System.Drawing.Size(150, 22);
            this.txtIdApoderado.TabIndex = 8;
            this.txtIdApoderado.Visible = false;

            this.lblIdEstudiante.Location = new System.Drawing.Point(202, 20);
            this.lblIdEstudiante.Name = "lblIdEstudiante";
            this.lblIdEstudiante.Size = new System.Drawing.Size(112, 23);
            this.lblIdEstudiante.TabIndex = 1;
            this.lblIdEstudiante.Text = "ID Estudiante:";
            this.lblIdEstudiante.Visible = false;

            this.lblIdProfesor.Location = new System.Drawing.Point(202, 45);
            this.lblIdProfesor.Name = "lblIdProfesor";
            this.lblIdProfesor.Size = new System.Drawing.Size(84, 23);
            this.lblIdProfesor.TabIndex = 4;
            this.lblIdProfesor.Text = "ID Profesor:";
            this.lblIdProfesor.Visible = false;

            this.lblIdApoderado.Location = new System.Drawing.Point(202, 71);
            this.lblIdApoderado.Name = "lblIdApoderado";
            this.lblIdApoderado.Size = new System.Drawing.Size(112, 23);
            this.lblIdApoderado.TabIndex = 7;
            this.lblIdApoderado.Text = "ID Apoderado:";
            this.lblIdApoderado.Visible = false;

            this.chkIdEstudiante.Location = new System.Drawing.Point(10, 20);
            this.chkIdEstudiante.Name = "chkIdEstudiante";
            this.chkIdEstudiante.Size = new System.Drawing.Size(148, 23);
            this.chkIdEstudiante.TabIndex = 0;
            this.chkIdEstudiante.Text = "ID Estudiante";

            this.chkIdProfesor.Location = new System.Drawing.Point(10, 45);
            this.chkIdProfesor.Name = "chkIdProfesor";
            this.chkIdProfesor.Size = new System.Drawing.Size(148, 23);
            this.chkIdProfesor.TabIndex = 3;
            this.chkIdProfesor.Text = "ID Profesor";

            this.chkIdApoderado.Location = new System.Drawing.Point(10, 70);
            this.chkIdApoderado.Name = "chkIdApoderado";
            this.chkIdApoderado.Size = new System.Drawing.Size(148, 23);
            this.chkIdApoderado.TabIndex = 6;
            this.chkIdApoderado.Text = "ID Apoderado";

            this.grpDatosPrincipales.Controls.Add(this.txtApeMaterno);
            this.grpDatosPrincipales.Controls.Add(this.lblApeMaterno);
            this.grpDatosPrincipales.Controls.Add(this.txtApePaterno);
            this.grpDatosPrincipales.Controls.Add(this.lblApePaterno);
            this.grpDatosPrincipales.Controls.Add(this.lblId);
            this.grpDatosPrincipales.Controls.Add(this.txtId);
            this.grpDatosPrincipales.Controls.Add(this.lblNombreUsuario);
            this.grpDatosPrincipales.Controls.Add(this.txtNombreUsuario);
            this.grpDatosPrincipales.Controls.Add(this.lblNombres);
            this.grpDatosPrincipales.Controls.Add(this.txtNombres);
            this.grpDatosPrincipales.Controls.Add(this.lblDni);
            this.grpDatosPrincipales.Controls.Add(this.txtDni);
            this.grpDatosPrincipales.Controls.Add(this.lblCorreo);
            this.grpDatosPrincipales.Controls.Add(this.txtCorreo);
            this.grpDatosPrincipales.Controls.Add(this.lblContrasena);
            this.grpDatosPrincipales.Controls.Add(this.txtContrasena);
            this.grpDatosPrincipales.Controls.Add(this.lblTelefono);
            this.grpDatosPrincipales.Controls.Add(this.txtTelefono);
            this.grpDatosPrincipales.Location = new System.Drawing.Point(12, 53);
            this.grpDatosPrincipales.Name = "grpDatosPrincipales";
            this.grpDatosPrincipales.Size = new System.Drawing.Size(350, 275);
            this.grpDatosPrincipales.TabIndex = 0;
            this.grpDatosPrincipales.TabStop = false;
            this.grpDatosPrincipales.Text = "DATOS PRINCIPALES";

            this.grpInformacionAdicional.Controls.Add(this.lblRol);
            this.grpInformacionAdicional.Controls.Add(this.cbRol);
            this.grpInformacionAdicional.Controls.Add(this.lblEstado);
            this.grpInformacionAdicional.Controls.Add(this.cbEstado);
            this.grpInformacionAdicional.Location = new System.Drawing.Point(25, 332);
            this.grpInformacionAdicional.Name = "grpInformacionAdicional";
            this.grpInformacionAdicional.Size = new System.Drawing.Size(283, 80);
            this.grpInformacionAdicional.TabIndex = 1;
            this.grpInformacionAdicional.TabStop = false;
            this.grpInformacionAdicional.Text = "INFO. ADICIONAL";

            this.grpIdentificadoresEspecificos.Controls.Add(this.txtIdEstudiante);
            this.grpIdentificadoresEspecificos.Controls.Add(this.txtIdApoderado);
            this.grpIdentificadoresEspecificos.Controls.Add(this.txtIdProfesor);
            this.grpIdentificadoresEspecificos.Controls.Add(this.chkIdEstudiante);
            this.grpIdentificadoresEspecificos.Controls.Add(this.chkIdProfesor);
            this.grpIdentificadoresEspecificos.Controls.Add(this.chkIdApoderado);
            this.grpIdentificadoresEspecificos.Controls.Add(this.lblIdApoderado);
            this.grpIdentificadoresEspecificos.Controls.Add(this.lblIdProfesor);
            this.grpIdentificadoresEspecificos.Controls.Add(this.lblIdEstudiante);
            this.grpIdentificadoresEspecificos.Location = new System.Drawing.Point(25, 413);
            this.grpIdentificadoresEspecificos.Name = "grpIdentificadoresEspecificos";
            this.grpIdentificadoresEspecificos.Size = new System.Drawing.Size(502, 100);
            this.grpIdentificadoresEspecificos.TabIndex = 2;
            this.grpIdentificadoresEspecificos.TabStop = false;
            this.grpIdentificadoresEspecificos.Text = "IDENTIFICADOR ESPECÍFICO";

            this.grpAcciones.Controls.Add(this.btnInsertar);
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnEliminar);
            this.grpAcciones.Location = new System.Drawing.Point(413, 218);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(129, 110);
            this.grpAcciones.TabIndex = 3;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "ACCIONES";

            this.grpListadoBusqueda.Controls.Add(this.cbBuscarColumna);
            this.grpListadoBusqueda.Controls.Add(this.txtBuscar);
            this.grpListadoBusqueda.Controls.Add(this.dgvUsuarios);
            this.grpListadoBusqueda.Controls.Add(this.label1);
            this.grpListadoBusqueda.Location = new System.Drawing.Point(565, 43);
            this.grpListadoBusqueda.Name = "grpListadoBusqueda";
            this.grpListadoBusqueda.Size = new System.Drawing.Size(541, 450);
            this.grpListadoBusqueda.TabIndex = 4;
            this.grpListadoBusqueda.TabStop = false;
            this.grpListadoBusqueda.Text = "LISTADO Y BÚSQUEDA";

            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar:";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 29);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Gestion de Usuarios";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpInformacionAdicional);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.grpListadoBusqueda);
            this.Controls.Add(this.grpDatosPrincipales);
            this.Controls.Add(this.grpIdentificadoresEspecificos);
            this.Name = "UcUsuarios";
            this.Size = new System.Drawing.Size(1126, 535);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpDatosPrincipales.ResumeLayout(false);
            this.grpDatosPrincipales.PerformLayout();
            this.grpInformacionAdicional.ResumeLayout(false);
            this.grpIdentificadoresEspecificos.ResumeLayout(false);
            this.grpIdentificadoresEspecificos.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.grpListadoBusqueda.ResumeLayout(false);
            this.grpListadoBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
    }
}