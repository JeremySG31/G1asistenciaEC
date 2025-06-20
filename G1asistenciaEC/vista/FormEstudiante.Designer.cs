namespace G1asistenciaEC
{
    partial class FormEstudiante
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombreEstudiante;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnInfoPersonal;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DateTimePicker dtpFechaHistorial;
        private System.Windows.Forms.Button btnBuscar;

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
            this.lblNombreEstudiante = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnInfoPersonal = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.dtpFechaHistorial = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreEstudiante
            // 
            this.lblNombreEstudiante.AutoSize = true;
            this.lblNombreEstudiante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombreEstudiante.Location = new System.Drawing.Point(26, 27);
            this.lblNombreEstudiante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreEstudiante.Name = "lblNombreEstudiante";
            this.lblNombreEstudiante.Size = new System.Drawing.Size(230, 28);
            this.lblNombreEstudiante.TabIndex = 0;
            this.lblNombreEstudiante.Text = "Nombre del Estudiante";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(942, 36);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(119, 28);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // btnInfoPersonal
            // 
            this.btnInfoPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfoPersonal.Location = new System.Drawing.Point(787, 36);
            this.btnInfoPersonal.Margin = new System.Windows.Forms.Padding(4);
            this.btnInfoPersonal.Name = "btnInfoPersonal";
            this.btnInfoPersonal.Size = new System.Drawing.Size(147, 28);
            this.btnInfoPersonal.TabIndex = 2;
            this.btnInfoPersonal.Text = "Información Personal";
            this.btnInfoPersonal.UseVisualStyleBackColor = true;
            this.btnInfoPersonal.Click += new System.EventHandler(this.btnInfoPersonal_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Location = new System.Drawing.Point(27, 74);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1040, 517);
            this.tabControl.TabIndex = 3;
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Controls.Add(this.dtpFechaHistorial);
            this.tabHistorial.Controls.Add(this.btnBuscar);
            this.tabHistorial.Location = new System.Drawing.Point(4, 25);
            this.tabHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(4);
            this.tabHistorial.Size = new System.Drawing.Size(1032, 488);
            this.tabHistorial.TabIndex = 0;
            this.tabHistorial.Text = "Historial de Asistencias";
            this.tabHistorial.UseVisualStyleBackColor = true;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(27, 74);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(973, 394);
            this.dgvHistorial.TabIndex = 0;
            // 
            // dtpFechaHistorial
            // 
            this.dtpFechaHistorial.Location = new System.Drawing.Point(27, 25);
            this.dtpFechaHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaHistorial.Name = "dtpFechaHistorial";
            this.dtpFechaHistorial.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaHistorial.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(320, 18);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 37);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // FormEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 615);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnInfoPersonal);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblNombreEstudiante);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEstudiante";
            this.Text = "Panel del Estudiante";
            this.tabControl.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}