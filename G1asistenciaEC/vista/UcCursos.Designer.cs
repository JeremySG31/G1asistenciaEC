using System.Windows.Forms;

namespace G1asistenciaEC.vista
{
    partial class UcCursos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.TextBox txtNombreCurso;
        private System.Windows.Forms.TextBox txtDescripcionCurso;
        private System.Windows.Forms.Button btnInsertarCurso;
        private System.Windows.Forms.Button btnModificarCurso;
        private System.Windows.Forms.Button btnEliminarCurso;
        private System.Windows.Forms.Label lblIdCurso;
        private System.Windows.Forms.Label lblNombreCurso;
        private System.Windows.Forms.Label lblDescripcionCurso;
        private System.Windows.Forms.Label labelTitulo;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.txtNombreCurso = new System.Windows.Forms.TextBox();
            this.txtDescripcionCurso = new System.Windows.Forms.TextBox();
            this.btnInsertarCurso = new System.Windows.Forms.Button();
            this.btnModificarCurso = new System.Windows.Forms.Button();
            this.btnEliminarCurso = new System.Windows.Forms.Button();
            this.lblIdCurso = new System.Windows.Forms.Label();
            this.lblNombreCurso = new System.Windows.Forms.Label();
            this.lblDescripcionCurso = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCursos
            // 
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.Location = new System.Drawing.Point(386, 77);
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.RowHeadersWidth = 51;
            this.dgvCursos.Size = new System.Drawing.Size(446, 205);
            this.dgvCursos.TabIndex = 0;
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.Location = new System.Drawing.Point(120, 77);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(100, 22);
            this.txtIdCurso.TabIndex = 2;
            // 
            // txtNombreCurso
            // 
            this.txtNombreCurso.Location = new System.Drawing.Point(120, 107);
            this.txtNombreCurso.Name = "txtNombreCurso";
            this.txtNombreCurso.Size = new System.Drawing.Size(200, 22);
            this.txtNombreCurso.TabIndex = 4;
            // 
            // txtDescripcionCurso
            // 
            this.txtDescripcionCurso.Location = new System.Drawing.Point(23, 162);
            this.txtDescripcionCurso.Multiline = true;
            this.txtDescripcionCurso.Name = "txtDescripcionCurso";
            this.txtDescripcionCurso.Size = new System.Drawing.Size(347, 72);
            this.txtDescripcionCurso.TabIndex = 6;
            // 
            // btnInsertarCurso
            // 
            this.btnInsertarCurso.Location = new System.Drawing.Point(36, 253);
            this.btnInsertarCurso.Name = "btnInsertarCurso";
            this.btnInsertarCurso.Size = new System.Drawing.Size(85, 29);
            this.btnInsertarCurso.TabIndex = 7;
            this.btnInsertarCurso.Text = "Insertar";
            // 
            // btnModificarCurso
            // 
            this.btnModificarCurso.Location = new System.Drawing.Point(155, 253);
            this.btnModificarCurso.Name = "btnModificarCurso";
            this.btnModificarCurso.Size = new System.Drawing.Size(85, 29);
            this.btnModificarCurso.TabIndex = 8;
            this.btnModificarCurso.Text = "Modificar";
            // 
            // btnEliminarCurso
            // 
            this.btnEliminarCurso.Location = new System.Drawing.Point(275, 253);
            this.btnEliminarCurso.Name = "btnEliminarCurso";
            this.btnEliminarCurso.Size = new System.Drawing.Size(85, 29);
            this.btnEliminarCurso.TabIndex = 9;
            this.btnEliminarCurso.Text = "Eliminar";
            // 
            // lblIdCurso
            // 
            this.lblIdCurso.AutoSize = true;
            this.lblIdCurso.Location = new System.Drawing.Point(20, 80);
            this.lblIdCurso.Name = "lblIdCurso";
            this.lblIdCurso.Size = new System.Drawing.Size(18, 16);
            this.lblIdCurso.TabIndex = 1;
            this.lblIdCurso.Text = "Id";
            // 
            // lblNombreCurso
            // 
            this.lblNombreCurso.AutoSize = true;
            this.lblNombreCurso.Location = new System.Drawing.Point(20, 110);
            this.lblNombreCurso.Name = "lblNombreCurso";
            this.lblNombreCurso.Size = new System.Drawing.Size(56, 16);
            this.lblNombreCurso.TabIndex = 3;
            this.lblNombreCurso.Text = "Nombre";
            // 
            // lblDescripcionCurso
            // 
            this.lblDescripcionCurso.AutoSize = true;
            this.lblDescripcionCurso.Location = new System.Drawing.Point(20, 143);
            this.lblDescripcionCurso.Name = "lblDescripcionCurso";
            this.lblDescripcionCurso.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcionCurso.TabIndex = 5;
            this.lblDescripcionCurso.Text = "Descripción";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(20, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(81, 25);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Cursos";
            // 
            // UcCursos
            // 
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.dgvCursos);
            this.Controls.Add(this.lblIdCurso);
            this.Controls.Add(this.txtIdCurso);
            this.Controls.Add(this.lblNombreCurso);
            this.Controls.Add(this.txtNombreCurso);
            this.Controls.Add(this.lblDescripcionCurso);
            this.Controls.Add(this.txtDescripcionCurso);
            this.Controls.Add(this.btnInsertarCurso);
            this.Controls.Add(this.btnModificarCurso);
            this.Controls.Add(this.btnEliminarCurso);
            this.Name = "UcCursos";
            this.Size = new System.Drawing.Size(865, 384);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
