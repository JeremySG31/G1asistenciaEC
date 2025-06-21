namespace G1asistenciaEC
{
    partial class FormApoderado
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
            this.lblNombreApoderado = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnInfoPersonal = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreApoderado
            // 
            this.lblNombreApoderado.AutoSize = true;
            this.lblNombreApoderado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombreApoderado.Location = new System.Drawing.Point(11, 32);
            this.lblNombreApoderado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreApoderado.Name = "lblNombreApoderado";
            this.lblNombreApoderado.Size = new System.Drawing.Size(234, 28);
            this.lblNombreApoderado.TabIndex = 1;
            this.lblNombreApoderado.Text = "Nombre del Apoderado";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Location = new System.Drawing.Point(12, 74);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(976, 483);
            this.tabControl.TabIndex = 4;
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Controls.Add(this.btnBuscar);
            this.tabHistorial.Location = new System.Drawing.Point(4, 25);
            this.tabHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(4);
            this.tabHistorial.Size = new System.Drawing.Size(968, 454);
            this.tabHistorial.TabIndex = 0;
            this.tabHistorial.Text = "Asistencias del estudiante asociado";
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
            this.dgvHistorial.Size = new System.Drawing.Size(909, 360);
            this.dgvHistorial.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(27, 17);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(229, 37);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Consultar historial de asistencias";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnInfoPersonal
            // 
            this.btnInfoPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfoPersonal.Location = new System.Drawing.Point(706, 36);
            this.btnInfoPersonal.Margin = new System.Windows.Forms.Padding(4);
            this.btnInfoPersonal.Name = "btnInfoPersonal";
            this.btnInfoPersonal.Size = new System.Drawing.Size(147, 28);
            this.btnInfoPersonal.TabIndex = 5;
            this.btnInfoPersonal.Text = "Información Personal";
            this.btnInfoPersonal.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(865, 36);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(119, 28);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // FormApoderado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 580);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnInfoPersonal);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblNombreApoderado);
            this.Name = "FormApoderado";
            this.Text = "FormApoderado";
            this.tabControl.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreApoderado;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnInfoPersonal;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}