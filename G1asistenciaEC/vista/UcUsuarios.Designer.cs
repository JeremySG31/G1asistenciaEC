namespace G1asistenciaEC.vista
{
    partial class UcUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
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
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtIdEstudiante;
        private System.Windows.Forms.TextBox txtIdProfesor;
        private System.Windows.Forms.TextBox txtIdApoderado;
        private System.Windows.Forms.Label lblIdEstudiante;
        private System.Windows.Forms.Label lblIdProfesor;
        private System.Windows.Forms.Label lblIdApoderado;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.lblTitulo = new System.Windows.Forms.Label();
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
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbBuscarColumna = new System.Windows.Forms.ComboBox();
            this.txtIdEstudiante = new System.Windows.Forms.TextBox();
            this.txtIdProfesor = new System.Windows.Forms.TextBox();
            this.txtIdApoderado = new System.Windows.Forms.TextBox();
            this.lblIdEstudiante = new System.Windows.Forms.Label();
            this.lblIdProfesor = new System.Windows.Forms.Label();
            this.lblIdApoderado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(424, 53);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.Size = new System.Drawing.Size(683, 342);
            this.dgvUsuarios.TabIndex = 26;

            this.btnInsertar.Location = new System.Drawing.Point(313, 53);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(90, 30);
            this.btnInsertar.TabIndex = 23;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;

            this.btnModificar.Location = new System.Drawing.Point(313, 93);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 30);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;

            this.btnEliminar.Location = new System.Drawing.Point(313, 133);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(116, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Usuarios";

            this.txtId.Location = new System.Drawing.Point(141, 53);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(60, 22);
            this.txtId.TabIndex = 2;
   
            this.txtNombreUsuario.Location = new System.Drawing.Point(141, 177);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(150, 22);
            this.txtNombreUsuario.TabIndex = 4;

            this.txtNombres.Location = new System.Drawing.Point(141, 213);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(150, 22);
            this.txtNombres.TabIndex = 6;

            this.txtApePaterno.Location = new System.Drawing.Point(141, 241);
            this.txtApePaterno.Name = "txtApePaterno";
            this.txtApePaterno.Size = new System.Drawing.Size(150, 22);
            this.txtApePaterno.TabIndex = 8;

            this.txtApeMaterno.Location = new System.Drawing.Point(141, 271);
            this.txtApeMaterno.Name = "txtApeMaterno";
            this.txtApeMaterno.Size = new System.Drawing.Size(150, 22);
            this.txtApeMaterno.TabIndex = 10;
   
            this.txtDni.Location = new System.Drawing.Point(141, 301);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(150, 22);
            this.txtDni.TabIndex = 12;

            this.txtCorreo.Location = new System.Drawing.Point(141, 331);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(150, 22);
            this.txtCorreo.TabIndex = 14;

            this.txtContrasena.Location = new System.Drawing.Point(141, 361);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(150, 22);
            this.txtContrasena.TabIndex = 16;

            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.Location = new System.Drawing.Point(141, 391);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(150, 24);
            this.cbRol.TabIndex = 18;

            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Location = new System.Drawing.Point(141, 421);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(150, 24);
            this.cbEstado.TabIndex = 20;

            this.txtTelefono.Location = new System.Drawing.Point(141, 451);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(150, 22);
            this.txtTelefono.TabIndex = 22;

            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(113, 56);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(20, 16);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";

            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(27, 180);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(106, 16);
            this.lblNombreUsuario.TabIndex = 3;
            this.lblNombreUsuario.Text = "Nombre Usuario";
  
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(70, 213);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(63, 16);
            this.lblNombres.TabIndex = 5;
            this.lblNombres.Text = "Nombres";

            this.lblApePaterno.AutoSize = true;
            this.lblApePaterno.Location = new System.Drawing.Point(29, 244);
            this.lblApePaterno.Name = "lblApePaterno";
            this.lblApePaterno.Size = new System.Drawing.Size(107, 16);
            this.lblApePaterno.TabIndex = 7;
            this.lblApePaterno.Text = "Apellido Paterno";

            this.lblApeMaterno.AutoSize = true;
            this.lblApeMaterno.Location = new System.Drawing.Point(29, 274);
            this.lblApeMaterno.Name = "lblApeMaterno";
            this.lblApeMaterno.Size = new System.Drawing.Size(109, 16);
            this.lblApeMaterno.TabIndex = 9;
            this.lblApeMaterno.Text = "Apellido Materno";

            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(99, 304);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(30, 16);
            this.lblDni.TabIndex = 11;
            this.lblDni.Text = "DNI";

            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(81, 334);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(48, 16);
            this.lblCorreo.TabIndex = 13;
            this.lblCorreo.Text = "Correo";

            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(57, 361);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(76, 16);
            this.lblContrasena.TabIndex = 15;
            this.lblContrasena.Text = "Contraseña";

            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(99, 394);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(28, 16);
            this.lblRol.TabIndex = 17;
            this.lblRol.Text = "Rol";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(83, 424);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(50, 16);
            this.lblEstado.TabIndex = 19;
            this.lblEstado.Text = "Estado";

            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(68, 454);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 16);
            this.lblTelefono.TabIndex = 21;
            this.lblTelefono.Text = "Teléfono";

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(424, 406);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 16);
            this.lblBuscar.TabIndex = 27;
            this.lblBuscar.Text = "Buscar:";
 
            this.txtBuscar.Location = new System.Drawing.Point(644, 403);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 22);
            this.txtBuscar.TabIndex = 29;

            this.cbBuscarColumna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuscarColumna.Location = new System.Drawing.Point(484, 403);
            this.cbBuscarColumna.Name = "cbBuscarColumna";
            this.cbBuscarColumna.Size = new System.Drawing.Size(150, 24);
            this.cbBuscarColumna.TabIndex = 28;

            this.txtIdEstudiante.Location = new System.Drawing.Point(141, 85);
            this.txtIdEstudiante.Name = "txtIdEstudiante";
            this.txtIdEstudiante.Size = new System.Drawing.Size(60, 22);
            this.txtIdEstudiante.TabIndex = 31;

            this.txtIdProfesor.Location = new System.Drawing.Point(141, 116);
            this.txtIdProfesor.Name = "txtIdProfesor";
            this.txtIdProfesor.Size = new System.Drawing.Size(60, 22);
            this.txtIdProfesor.TabIndex = 33;
 
            this.txtIdApoderado.Location = new System.Drawing.Point(141, 144);
            this.txtIdApoderado.Name = "txtIdApoderado";
            this.txtIdApoderado.Size = new System.Drawing.Size(60, 22);
            this.txtIdApoderado.TabIndex = 35;

            this.lblIdEstudiante.AutoSize = true;
            this.lblIdEstudiante.Location = new System.Drawing.Point(47, 88);
            this.lblIdEstudiante.Name = "lblIdEstudiante";
            this.lblIdEstudiante.Size = new System.Drawing.Size(86, 16);
            this.lblIdEstudiante.TabIndex = 30;
            this.lblIdEstudiante.Text = "ID Estudiante";

            this.lblIdProfesor.AutoSize = true;
            this.lblIdProfesor.Location = new System.Drawing.Point(55, 119);
            this.lblIdProfesor.Name = "lblIdProfesor";
            this.lblIdProfesor.Size = new System.Drawing.Size(74, 16);
            this.lblIdProfesor.TabIndex = 32;
            this.lblIdProfesor.Text = "ID Profesor";

            this.lblIdApoderado.AutoSize = true;
            this.lblIdApoderado.Location = new System.Drawing.Point(41, 144);
            this.lblIdApoderado.Name = "lblIdApoderado";
            this.lblIdApoderado.Size = new System.Drawing.Size(92, 16);
            this.lblIdApoderado.TabIndex = 34;
            this.lblIdApoderado.Text = "ID Apoderado";

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblApePaterno);
            this.Controls.Add(this.txtApePaterno);
            this.Controls.Add(this.lblApeMaterno);
            this.Controls.Add(this.txtApeMaterno);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblIdEstudiante);
            this.Controls.Add(this.txtIdEstudiante);
            this.Controls.Add(this.lblIdProfesor);
            this.Controls.Add(this.txtIdProfesor);
            this.Controls.Add(this.lblIdApoderado);
            this.Controls.Add(this.txtIdApoderado);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.cbBuscarColumna);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "UcUsuarios";
            this.Size = new System.Drawing.Size(1151, 501);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
