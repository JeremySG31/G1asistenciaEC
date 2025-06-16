namespace G1asistenciaEC.vista
{
    partial class UcCursosMatriculados
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCursosMatriculados;
        private System.Windows.Forms.ComboBox cbMatricula;
        private System.Windows.Forms.ComboBox cbCurso;
        private System.Windows.Forms.ComboBox cbEstudiante;
        private System.Windows.Forms.ComboBox cbIdCursosMatriculados;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.Label lblIdCursosMatriculados;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;

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
            this.dgvCursosMatriculados = new System.Windows.Forms.DataGridView();
            this.cbMatricula = new System.Windows.Forms.ComboBox();
            this.cbCurso = new System.Windows.Forms.ComboBox();
            this.cbEstudiante = new System.Windows.Forms.ComboBox();
            this.cbIdCursosMatriculados = new System.Windows.Forms.ComboBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.lblIdCursosMatriculados = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosMatriculados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCursosMatriculados
            // 
            this.dgvCursosMatriculados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursosMatriculados.Location = new System.Drawing.Point(369, 20);
            this.dgvCursosMatriculados.Name = "dgvCursosMatriculados";
            this.dgvCursosMatriculados.RowHeadersWidth = 51;
            this.dgvCursosMatriculados.Size = new System.Drawing.Size(453, 300);
            this.dgvCursosMatriculados.TabIndex = 1;
            // 
            // cbMatricula
            // 
            this.cbMatricula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatricula.Location = new System.Drawing.Point(120, 107);
            this.cbMatricula.Name = "cbMatricula";
            this.cbMatricula.Size = new System.Drawing.Size(200, 24);
            this.cbMatricula.TabIndex = 5;
            // 
            // cbCurso
            // 
            this.cbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurso.Location = new System.Drawing.Point(120, 147);
            this.cbCurso.Name = "cbCurso";
            this.cbCurso.Size = new System.Drawing.Size(200, 24);
            this.cbCurso.TabIndex = 7;
            // 
            // cbEstudiante
            // 
            this.cbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudiante.Location = new System.Drawing.Point(120, 187);
            this.cbEstudiante.Name = "cbEstudiante";
            this.cbEstudiante.Size = new System.Drawing.Size(200, 24);
            this.cbEstudiante.TabIndex = 9;
            // 
            // cbIdCursosMatriculados
            // 
            this.cbIdCursosMatriculados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdCursosMatriculados.Location = new System.Drawing.Point(120, 67);
            this.cbIdCursosMatriculados.Name = "cbIdCursosMatriculados";
            this.cbIdCursosMatriculados.Size = new System.Drawing.Size(120, 24);
            this.cbIdCursosMatriculados.TabIndex = 3;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(30, 240);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(85, 29);
            this.btnInsertar.TabIndex = 10;
            this.btnInsertar.Text = "Insertar";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(130, 240);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(85, 29);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(230, 240);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(85, 29);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 70);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 16);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Id";
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(20, 110);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(61, 16);
            this.lblMatricula.TabIndex = 4;
            this.lblMatricula.Text = "Matrícula";
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(20, 150);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(42, 16);
            this.lblCurso.TabIndex = 6;
            this.lblCurso.Text = "Curso";
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Location = new System.Drawing.Point(20, 190);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(70, 16);
            this.lblEstudiante.TabIndex = 8;
            this.lblEstudiante.Text = "Estudiante";
            // 
            // lblIdCursosMatriculados
            // 
            this.lblIdCursosMatriculados.AutoSize = true;
            this.lblIdCursosMatriculados.Location = new System.Drawing.Point(20, 70);
            this.lblIdCursosMatriculados.Name = "lblIdCursosMatriculados";
            this.lblIdCursosMatriculados.Size = new System.Drawing.Size(74, 16);
            this.lblIdCursosMatriculados.TabIndex = 2;
            this.lblIdCursosMatriculados.Text = "ID Registro";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(20, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(210, 25);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Cursos Matriculados";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(428, 335);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 22);
            this.txtBuscar.TabIndex = 13;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(368, 338);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 16);
            this.lblBuscar.TabIndex = 14;
            this.lblBuscar.Text = "Buscar:";
            // 
            // UcCursosMatriculados
            // 
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.dgvCursosMatriculados);
            this.Controls.Add(this.lblIdCursosMatriculados);
            this.Controls.Add(this.cbIdCursosMatriculados);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.cbMatricula);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.cbCurso);
            this.Controls.Add(this.lblEstudiante);
            this.Controls.Add(this.cbEstudiante);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Name = "UcCursosMatriculados";
            this.Size = new System.Drawing.Size(874, 371);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosMatriculados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
