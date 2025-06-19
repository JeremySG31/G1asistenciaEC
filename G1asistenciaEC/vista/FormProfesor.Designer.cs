namespace G1asistenciaEC
{
    partial class FormProfesor
    {
        private System.Windows.Forms.DataGridView dgvAsistencia;
        private System.Windows.Forms.CheckBox chkA;
        private System.Windows.Forms.CheckBox chkT;
        private System.Windows.Forms.CheckBox chkF;
        private System.Windows.Forms.ComboBox cbGrado;
        private System.Windows.Forms.ComboBox cbSeccion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTomar;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.GroupBox groupBoxFiltrosHistorial;
        private System.Windows.Forms.DateTimePicker dtpFechaHistorial;
        private System.Windows.Forms.Label lblFechaHistorial;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNombreProfesor;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnInfoPersonal;

        private void InitializeComponent()
        {
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();
            this.chkA = new System.Windows.Forms.CheckBox();
            this.chkT = new System.Windows.Forms.CheckBox();
            this.chkF = new System.Windows.Forms.CheckBox();
            this.cbGrado = new System.Windows.Forms.ComboBox();
            this.cbSeccion = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTomar = new System.Windows.Forms.TabPage();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.groupBoxFiltrosHistorial = new System.Windows.Forms.GroupBox();
            this.dtpFechaHistorial = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHistorial = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNombreProfesor = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnInfoPersonal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabTomar.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            this.groupBoxFiltros.SuspendLayout();
            this.groupBoxFiltrosHistorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAsistencia
            // 
            this.dgvAsistencia.AllowUserToAddRows = false;
            this.dgvAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencia.Location = new System.Drawing.Point(20, 150);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.RowHeadersWidth = 51;
            this.dgvAsistencia.Size = new System.Drawing.Size(800, 200);
            this.dgvAsistencia.TabIndex = 0;
            // 
            // chkA
            // 
            this.chkA.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkA.Location = new System.Drawing.Point(20, 30);
            this.chkA.Name = "chkA";
            this.chkA.Size = new System.Drawing.Size(40, 40);
            this.chkA.TabIndex = 1;
            this.chkA.Text = "A";
            this.chkA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkA.UseVisualStyleBackColor = true;
            // 
            // chkT
            // 
            this.chkT.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkT.Location = new System.Drawing.Point(70, 30);
            this.chkT.Name = "chkT";
            this.chkT.Size = new System.Drawing.Size(40, 40);
            this.chkT.TabIndex = 2;
            this.chkT.Text = "T";
            this.chkT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkT.UseVisualStyleBackColor = true;
            // 
            // chkF
            // 
            this.chkF.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkF.Location = new System.Drawing.Point(120, 30);
            this.chkF.Name = "chkF";
            this.chkF.Size = new System.Drawing.Size(40, 40);
            this.chkF.TabIndex = 3;
            this.chkF.Text = "F";
            this.chkF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkF.UseVisualStyleBackColor = true;
            // 
            // cbGrado
            // 
            this.cbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrado.FormattingEnabled = true;
            this.cbGrado.Location = new System.Drawing.Point(200, 30);
            this.cbGrado.Name = "cbGrado";
            this.cbGrado.Size = new System.Drawing.Size(150, 24);
            this.cbGrado.TabIndex = 4;
            // 
            // cbSeccion
            // 
            this.cbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeccion.FormattingEnabled = true;
            this.cbSeccion.Location = new System.Drawing.Point(370, 30);
            this.cbSeccion.Name = "cbSeccion";
            this.cbSeccion.Size = new System.Drawing.Size(150, 24);
            this.cbSeccion.TabIndex = 5;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(540, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 6;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTomar);
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Location = new System.Drawing.Point(12, 48);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 340);
            this.tabControl.TabIndex = 7;
            // 
            // tabTomar
            // 
            this.tabTomar.Controls.Add(this.groupBoxFiltros);
            this.tabTomar.Controls.Add(this.dgvAsistencia);
            this.tabTomar.Location = new System.Drawing.Point(4, 25);
            this.tabTomar.Name = "tabTomar";
            this.tabTomar.Size = new System.Drawing.Size(852, 311);
            this.tabTomar.TabIndex = 0;
            this.tabTomar.Text = "Tomar Asistencia";
            this.tabTomar.UseVisualStyleBackColor = true;
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.groupBoxFiltrosHistorial);
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Location = new System.Drawing.Point(4, 25);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Size = new System.Drawing.Size(852, 311);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "Historial de Asistencias";
            this.tabHistorial.UseVisualStyleBackColor = true;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(20, 150);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(800, 200);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.ReadOnly = true;
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.chkA);
            this.groupBoxFiltros.Controls.Add(this.chkT);
            this.groupBoxFiltros.Controls.Add(this.chkF);
            this.groupBoxFiltros.Controls.Add(this.cbGrado);
            this.groupBoxFiltros.Controls.Add(this.cbSeccion);
            this.groupBoxFiltros.Controls.Add(this.dtpFecha);
            this.groupBoxFiltros.Location = new System.Drawing.Point(20, 20);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(800, 100);
            this.groupBoxFiltros.TabIndex = 11;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de Asistencia";
            // 
            // groupBoxFiltrosHistorial
            // 
            this.groupBoxFiltrosHistorial.Controls.Add(this.lblFechaHistorial);
            this.groupBoxFiltrosHistorial.Controls.Add(this.dtpFechaHistorial);
            this.groupBoxFiltrosHistorial.Controls.Add(this.btnBuscar);
            this.groupBoxFiltrosHistorial.Location = new System.Drawing.Point(20, 20);
            this.groupBoxFiltrosHistorial.Name = "groupBoxFiltrosHistorial";
            this.groupBoxFiltrosHistorial.Size = new System.Drawing.Size(800, 100);
            this.groupBoxFiltrosHistorial.TabIndex = 0;
            this.groupBoxFiltrosHistorial.TabStop = false;
            this.groupBoxFiltrosHistorial.Text = "Filtros de Historial";
            // 
            // lblFechaHistorial
            // 
            this.lblFechaHistorial.AutoSize = true;
            this.lblFechaHistorial.Location = new System.Drawing.Point(20, 30);
            this.lblFechaHistorial.Name = "lblFechaHistorial";
            this.lblFechaHistorial.Size = new System.Drawing.Size(48, 16);
            this.lblFechaHistorial.Text = "Fecha:";
            // 
            // dtpFechaHistorial
            // 
            this.dtpFechaHistorial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHistorial.Location = new System.Drawing.Point(80, 28);
            this.dtpFechaHistorial.Name = "dtpFechaHistorial";
            this.dtpFechaHistorial.Size = new System.Drawing.Size(150, 22);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(250, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblNombreProfesor
            // 
            this.lblNombreProfesor.AutoSize = true;
            this.lblNombreProfesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreProfesor.Location = new System.Drawing.Point(20, 12);
            this.lblNombreProfesor.Name = "lblNombreProfesor";
            this.lblNombreProfesor.Size = new System.Drawing.Size(183, 20);
            this.lblNombreProfesor.TabIndex = 8;
            this.lblNombreProfesor.Text = "Nombre del Profesor";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(748, 12);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 30);
            this.btnCerrarSesion.TabIndex = 9;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // btnInfoPersonal
            // 
            this.btnInfoPersonal.Location = new System.Drawing.Point(551, 12);
            this.btnInfoPersonal.Name = "btnInfoPersonal";
            this.btnInfoPersonal.Size = new System.Drawing.Size(170, 30);
            this.btnInfoPersonal.TabIndex = 10;
            this.btnInfoPersonal.Text = "Información personal";
            this.btnInfoPersonal.UseVisualStyleBackColor = true;
            // 
            // FormProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 394);
            this.Controls.Add(this.lblNombreProfesor);
            this.Controls.Add(this.btnInfoPersonal);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCerrarSesion);
            this.Name = "FormProfesor";
            this.Text = "FormProfesor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabTomar.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltrosHistorial.ResumeLayout(false);
            this.groupBoxFiltrosHistorial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}