namespace G1asistenciaEC
{
    partial class FormProfesor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTomar = new System.Windows.Forms.TabPage();
            this.cbCursos = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.cbFiltroCurso = new System.Windows.Forms.ComboBox();
            this.dtpFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.tabClases = new System.Windows.Forms.TabPage();
            this.dgvClases = new System.Windows.Forms.DataGridView();
            this.tabBuscar = new System.Windows.Forms.TabPage();
            this.txtBuscarEstudiante = new System.Windows.Forms.TextBox();
            this.btnBuscarEstudiante = new System.Windows.Forms.Button();
            this.dgvBuscarEstudiante = new System.Windows.Forms.DataGridView();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblNombreProfesor = new System.Windows.Forms.Label();
            this.btnInfoPersonal = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabTomar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.tabClases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).BeginInit();
            this.tabBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarEstudiante)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTomar);
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Controls.Add(this.tabClases);
            this.tabControl.Controls.Add(this.tabBuscar);
            this.tabControl.Location = new System.Drawing.Point(12, 48);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 340);
            this.tabControl.TabIndex = 0;
            // 
            // tabTomar
            // 
            this.tabTomar.Controls.Add(this.cbCursos);
            this.tabTomar.Controls.Add(this.dtpFecha);
            this.tabTomar.Controls.Add(this.dgvAsistencia);
            this.tabTomar.Controls.Add(this.btnGuardar);
            this.tabTomar.Location = new System.Drawing.Point(4, 25);
            this.tabTomar.Name = "tabTomar";
            this.tabTomar.Size = new System.Drawing.Size(852, 311);
            this.tabTomar.TabIndex = 0;
            this.tabTomar.Text = "Tomar Asistencia";
            // 
            // cbCursos
            // 
            this.cbCursos.Location = new System.Drawing.Point(20, 20);
            this.cbCursos.Name = "cbCursos";
            this.cbCursos.Size = new System.Drawing.Size(200, 24);
            this.cbCursos.TabIndex = 0;
            this.cbCursos.SelectedIndexChanged += new System.EventHandler(this.cbCursos_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(240, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 1;
            // 
            // dgvAsistencia
            // 
            this.dgvAsistencia.AllowUserToAddRows = false;
            this.dgvAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistencia.ColumnHeadersHeight = 29;
            this.dgvAsistencia.Location = new System.Drawing.Point(20, 60);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.RowHeadersWidth = 51;
            this.dgvAsistencia.Size = new System.Drawing.Size(800, 200);
            this.dgvAsistencia.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(20, 270);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 30);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar asistencia";
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.cbFiltroCurso);
            this.tabHistorial.Controls.Add(this.dtpFiltroFecha);
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Location = new System.Drawing.Point(4, 25);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Size = new System.Drawing.Size(852, 311);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "Historial";
            // 
            // cbFiltroCurso
            // 
            this.cbFiltroCurso.Location = new System.Drawing.Point(20, 20);
            this.cbFiltroCurso.Name = "cbFiltroCurso";
            this.cbFiltroCurso.Size = new System.Drawing.Size(200, 24);
            this.cbFiltroCurso.TabIndex = 0;
            // 
            // dtpFiltroFecha
            // 
            this.dtpFiltroFecha.Location = new System.Drawing.Point(240, 20);
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFiltroFecha.TabIndex = 1;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeight = 29;
            this.dgvHistorial.Location = new System.Drawing.Point(20, 60);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(800, 200);
            this.dgvHistorial.TabIndex = 2;
            // 
            // tabClases
            // 
            this.tabClases.Controls.Add(this.dgvClases);
            this.tabClases.Location = new System.Drawing.Point(4, 25);
            this.tabClases.Name = "tabClases";
            this.tabClases.Size = new System.Drawing.Size(852, 311);
            this.tabClases.TabIndex = 2;
            this.tabClases.Text = "Clases Programadas";
            // 
            // dgvClases
            // 
            this.dgvClases.AllowUserToAddRows = false;
            this.dgvClases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClases.ColumnHeadersHeight = 29;
            this.dgvClases.Location = new System.Drawing.Point(20, 20);
            this.dgvClases.Name = "dgvClases";
            this.dgvClases.RowHeadersWidth = 51;
            this.dgvClases.Size = new System.Drawing.Size(800, 240);
            this.dgvClases.TabIndex = 0;
            // 
            // tabBuscar
            // 
            this.tabBuscar.Controls.Add(this.txtBuscarEstudiante);
            this.tabBuscar.Controls.Add(this.btnBuscarEstudiante);
            this.tabBuscar.Controls.Add(this.dgvBuscarEstudiante);
            this.tabBuscar.Location = new System.Drawing.Point(4, 25);
            this.tabBuscar.Name = "tabBuscar";
            this.tabBuscar.Size = new System.Drawing.Size(852, 311);
            this.tabBuscar.TabIndex = 3;
            this.tabBuscar.Text = "Buscar Estudiante";
            // 
            // txtBuscarEstudiante
            // 
            this.txtBuscarEstudiante.Location = new System.Drawing.Point(20, 20);
            this.txtBuscarEstudiante.Name = "txtBuscarEstudiante";
            this.txtBuscarEstudiante.Size = new System.Drawing.Size(300, 22);
            this.txtBuscarEstudiante.TabIndex = 0;
            // 
            // btnBuscarEstudiante
            // 
            this.btnBuscarEstudiante.Location = new System.Drawing.Point(340, 18);
            this.btnBuscarEstudiante.Name = "btnBuscarEstudiante";
            this.btnBuscarEstudiante.Size = new System.Drawing.Size(100, 26);
            this.btnBuscarEstudiante.TabIndex = 1;
            this.btnBuscarEstudiante.Text = "Buscar";
            // 
            // dgvBuscarEstudiante
            // 
            this.dgvBuscarEstudiante.AllowUserToAddRows = false;
            this.dgvBuscarEstudiante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuscarEstudiante.ColumnHeadersHeight = 29;
            this.dgvBuscarEstudiante.Location = new System.Drawing.Point(20, 60);
            this.dgvBuscarEstudiante.Name = "dgvBuscarEstudiante";
            this.dgvBuscarEstudiante.RowHeadersWidth = 51;
            this.dgvBuscarEstudiante.Size = new System.Drawing.Size(800, 200);
            this.dgvBuscarEstudiante.TabIndex = 2;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(748, 12);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 30);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblNombreProfesor
            // 
            this.lblNombreProfesor.AutoSize = true;
            this.lblNombreProfesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreProfesor.Location = new System.Drawing.Point(20, 12);
            this.lblNombreProfesor.Name = "lblNombreProfesor";
            this.lblNombreProfesor.Size = new System.Drawing.Size(183, 20);
            this.lblNombreProfesor.TabIndex = 100;
            this.lblNombreProfesor.Text = "Nombre del Profesor";
            // 
            // btnInfoPersonal
            // 
            this.btnInfoPersonal.Location = new System.Drawing.Point(551, 12);
            this.btnInfoPersonal.Name = "btnInfoPersonal";
            this.btnInfoPersonal.Size = new System.Drawing.Size(170, 30);
            this.btnInfoPersonal.TabIndex = 101;
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
            this.tabControl.ResumeLayout(false);
            this.tabTomar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.tabClases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).EndInit();
            this.tabBuscar.ResumeLayout(false);
            this.tabBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarEstudiante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTomar;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.TabPage tabClases;
        private System.Windows.Forms.TabPage tabBuscar;
        private System.Windows.Forms.ComboBox cbCursos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvAsistencia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.ComboBox cbFiltroCurso;
        private System.Windows.Forms.DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridView dgvClases;
        private System.Windows.Forms.TextBox txtBuscarEstudiante;
        private System.Windows.Forms.Button btnBuscarEstudiante;
        private System.Windows.Forms.DataGridView dgvBuscarEstudiante;
        private System.Windows.Forms.Label lblNombreProfesor;
        private System.Windows.Forms.Button btnInfoPersonal;
    }
}