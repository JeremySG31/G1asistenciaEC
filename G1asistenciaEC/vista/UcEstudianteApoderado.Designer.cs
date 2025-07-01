namespace G1asistenciaEC.vista
{
    partial class UcEstudianteApoderado
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbIdEstudiante;
        private System.Windows.Forms.ComboBox cbIdApoderado;
        private System.Windows.Forms.TextBox txtParentesco;
        private System.Windows.Forms.ComboBox cbPrioridad;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label lblIdEstudiante;
        private System.Windows.Forms.Label lblIdApoderado;
        private System.Windows.Forms.Label lblParentesco;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox grpListadoBusqueda;
        private System.Windows.Forms.ComboBox cbBuscarColumna;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDatosPrincipales;
        private System.Windows.Forms.GroupBox grpInformacionAdicional;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnRegistrarApoderado;
        private System.Windows.Forms.Button btnActualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbIdEstudiante = new System.Windows.Forms.ComboBox();
            this.cbIdApoderado = new System.Windows.Forms.ComboBox();
            this.txtParentesco = new System.Windows.Forms.TextBox();
            this.cbPrioridad = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.lblIdEstudiante = new System.Windows.Forms.Label();
            this.lblIdApoderado = new System.Windows.Forms.Label();
            this.lblParentesco = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.grpListadoBusqueda = new System.Windows.Forms.GroupBox();
            this.cbBuscarColumna = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDatosPrincipales = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.grpInformacionAdicional = new System.Windows.Forms.GroupBox();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnRegistrarApoderado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpListadoBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grpDatosPrincipales.SuspendLayout();
            this.grpInformacionAdicional.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(28, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(235, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Asignar apoderado";
            // 
            // cbIdEstudiante
            // 
            this.cbIdEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdEstudiante.Location = new System.Drawing.Point(120, 52);
            this.cbIdEstudiante.Name = "cbIdEstudiante";
            this.cbIdEstudiante.Size = new System.Drawing.Size(200, 24);
            this.cbIdEstudiante.TabIndex = 1;
            // 
            // cbIdApoderado
            // 
            this.cbIdApoderado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdApoderado.Location = new System.Drawing.Point(120, 86);
            this.cbIdApoderado.Name = "cbIdApoderado";
            this.cbIdApoderado.Size = new System.Drawing.Size(200, 24);
            this.cbIdApoderado.TabIndex = 3;
            // 
            // txtParentesco
            // 
            this.txtParentesco.Location = new System.Drawing.Point(120, 119);
            this.txtParentesco.Name = "txtParentesco";
            this.txtParentesco.Size = new System.Drawing.Size(200, 22);
            this.txtParentesco.TabIndex = 5;
            // 
            // cbPrioridad
            // 
            this.cbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrioridad.Location = new System.Drawing.Point(120, 27);
            this.cbPrioridad.Name = "cbPrioridad";
            this.cbPrioridad.Size = new System.Drawing.Size(200, 24);
            this.cbPrioridad.TabIndex = 1;
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Location = new System.Drawing.Point(120, 52);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(200, 24);
            this.cbEstado.TabIndex = 3;
            // 
            // lblIdEstudiante
            // 
            this.lblIdEstudiante.AutoSize = true;
            this.lblIdEstudiante.Location = new System.Drawing.Point(16, 55);
            this.lblIdEstudiante.Name = "lblIdEstudiante";
            this.lblIdEstudiante.Size = new System.Drawing.Size(89, 16);
            this.lblIdEstudiante.TabIndex = 0;
            this.lblIdEstudiante.Text = "ID Estudiante:";
            // 
            // lblIdApoderado
            // 
            this.lblIdApoderado.AutoSize = true;
            this.lblIdApoderado.Location = new System.Drawing.Point(16, 89);
            this.lblIdApoderado.Name = "lblIdApoderado";
            this.lblIdApoderado.Size = new System.Drawing.Size(95, 16);
            this.lblIdApoderado.TabIndex = 2;
            this.lblIdApoderado.Text = "ID Apoderado:";
            // 
            // lblParentesco
            // 
            this.lblParentesco.AutoSize = true;
            this.lblParentesco.Location = new System.Drawing.Point(16, 122);
            this.lblParentesco.Name = "lblParentesco";
            this.lblParentesco.Size = new System.Drawing.Size(79, 16);
            this.lblParentesco.TabIndex = 4;
            this.lblParentesco.Text = "Parentesco:";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Location = new System.Drawing.Point(10, 30);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(65, 16);
            this.lblPrioridad.TabIndex = 0;
            this.lblPrioridad.Text = "Prioridad:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(10, 55);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(53, 16);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";
            // 
            // grpListadoBusqueda
            // 
            this.grpListadoBusqueda.Controls.Add(this.cbBuscarColumna);
            this.grpListadoBusqueda.Controls.Add(this.txtBuscar);
            this.grpListadoBusqueda.Controls.Add(this.dgvUsuarios);
            this.grpListadoBusqueda.Controls.Add(this.label1);
            this.grpListadoBusqueda.Location = new System.Drawing.Point(456, 24);
            this.grpListadoBusqueda.Name = "grpListadoBusqueda";
            this.grpListadoBusqueda.Size = new System.Drawing.Size(573, 450);
            this.grpListadoBusqueda.TabIndex = 4;
            this.grpListadoBusqueda.TabStop = false;
            this.grpListadoBusqueda.Text = "LISTADO Y BUSQUEDA";
            // 
            // cbBuscarColumna
            // 
            this.cbBuscarColumna.Location = new System.Drawing.Point(70, 17);
            this.cbBuscarColumna.Name = "cbBuscarColumna";
            this.cbBuscarColumna.Size = new System.Drawing.Size(140, 24);
            this.cbBuscarColumna.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(247, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(230, 22);
            this.txtBuscar.TabIndex = 2;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.ColumnHeadersHeight = 29;
            this.dgvUsuarios.Location = new System.Drawing.Point(13, 45);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.Size = new System.Drawing.Size(554, 399);
            this.dgvUsuarios.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar:";
            // 
            // grpDatosPrincipales
            // 
            this.grpDatosPrincipales.Controls.Add(this.label2);
            this.grpDatosPrincipales.Controls.Add(this.txtId);
            this.grpDatosPrincipales.Controls.Add(this.lblIdEstudiante);
            this.grpDatosPrincipales.Controls.Add(this.cbIdEstudiante);
            this.grpDatosPrincipales.Controls.Add(this.lblIdApoderado);
            this.grpDatosPrincipales.Controls.Add(this.cbIdApoderado);
            this.grpDatosPrincipales.Controls.Add(this.lblParentesco);
            this.grpDatosPrincipales.Controls.Add(this.txtParentesco);
            this.grpDatosPrincipales.Location = new System.Drawing.Point(33, 62);
            this.grpDatosPrincipales.Name = "grpDatosPrincipales";
            this.grpDatosPrincipales.Size = new System.Drawing.Size(350, 156);
            this.grpDatosPrincipales.TabIndex = 1;
            this.grpDatosPrincipales.TabStop = false;
            this.grpDatosPrincipales.Text = "DATOS PRINCIPALES";
            this.grpDatosPrincipales.Enter += new System.EventHandler(this.grpDatosPrincipales_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(120, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 22);
            this.txtId.TabIndex = 0;
            // 
            // grpInformacionAdicional
            // 
            this.grpInformacionAdicional.Controls.Add(this.lblPrioridad);
            this.grpInformacionAdicional.Controls.Add(this.cbPrioridad);
            this.grpInformacionAdicional.Controls.Add(this.lblEstado);
            this.grpInformacionAdicional.Controls.Add(this.cbEstado);
            this.grpInformacionAdicional.Location = new System.Drawing.Point(33, 238);
            this.grpInformacionAdicional.Name = "grpInformacionAdicional";
            this.grpInformacionAdicional.Size = new System.Drawing.Size(350, 85);
            this.grpInformacionAdicional.TabIndex = 2;
            this.grpInformacionAdicional.TabStop = false;
            this.grpInformacionAdicional.Text = "INFORMACION ADICIONAL";
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.button1);
            this.grpAcciones.Controls.Add(this.button2);
            this.grpAcciones.Controls.Add(this.button3);
            this.grpAcciones.Location = new System.Drawing.Point(52, 339);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(136, 107);
            this.grpAcciones.TabIndex = 3;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "ACCIONES";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "INSERTAR";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "MODIFICAR";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "ELIMINAR";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(630, 480);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(229, 25);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "ACTUALIZAR TABLA";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarApoderado
            // 
            this.btnRegistrarApoderado.Location = new System.Drawing.Point(6, 10);
            this.btnRegistrarApoderado.Name = "btnRegistrarApoderado";
            this.btnRegistrarApoderado.Size = new System.Drawing.Size(177, 45);
            this.btnRegistrarApoderado.TabIndex = 4;
            this.btnRegistrarApoderado.Text = "REGISTRAR NUEVO APODERADO";
            this.btnRegistrarApoderado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegistrarApoderado);
            this.groupBox1.Location = new System.Drawing.Point(194, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // UcEstudianteApoderado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.grpInformacionAdicional);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.grpDatosPrincipales);
            this.Controls.Add(this.grpListadoBusqueda);
            this.Controls.Add(this.lblTitulo);
            this.Name = "UcEstudianteApoderado";
            this.Size = new System.Drawing.Size(1126, 535);
            this.grpListadoBusqueda.ResumeLayout(false);
            this.grpListadoBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpDatosPrincipales.ResumeLayout(false);
            this.grpDatosPrincipales.PerformLayout();
            this.grpInformacionAdicional.ResumeLayout(false);
            this.grpInformacionAdicional.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
