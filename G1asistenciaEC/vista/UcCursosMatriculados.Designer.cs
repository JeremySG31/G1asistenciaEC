namespace G1asistenciaEC.vista
{
    partial class UcCursosMatriculados
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCursosMatriculados;
        private System.Windows.Forms.ComboBox cbMatricula;
        private System.Windows.Forms.ComboBox cbCurso;
        private System.Windows.Forms.ComboBox cbEstudiante;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblIdCursosMatriculados;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtIdCM;

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
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblIdCursosMatriculados = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtIdCM = new System.Windows.Forms.TextBox();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosMatriculados)).BeginInit();
            this.grpAcciones.SuspendLayout();
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
            this.cbMatricula.TabIndex = 3;
            // 
            // cbCurso
            // 
            this.cbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurso.Location = new System.Drawing.Point(120, 147);
            this.cbCurso.Name = "cbCurso";
            this.cbCurso.Size = new System.Drawing.Size(200, 24);
            this.cbCurso.TabIndex = 4;
            // 
            // cbEstudiante
            // 
            this.cbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudiante.Location = new System.Drawing.Point(120, 187);
            this.cbEstudiante.Name = "cbEstudiante";
            this.cbEstudiante.Size = new System.Drawing.Size(200, 24);
            this.cbEstudiante.TabIndex = 5;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(17, 21);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(89, 29);
            this.btnInsertar.TabIndex = 6;
            this.btnInsertar.Text = "INSERTAR";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(112, 21);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(95, 29);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "MODIFICAR";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(224, 21);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(85, 29);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR";
            // 
            // lblIdCursosMatriculados
            // 
            this.lblIdCursosMatriculados.AutoSize = true;
            this.lblIdCursosMatriculados.Location = new System.Drawing.Point(20, 70);
            this.lblIdCursosMatriculados.Name = "lblIdCursosMatriculados";
            this.lblIdCursosMatriculados.Size = new System.Drawing.Size(74, 16);
            this.lblIdCursosMatriculados.TabIndex = 0;
            this.lblIdCursosMatriculados.Text = "ID Registro";
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(20, 110);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(61, 16);
            this.lblMatricula.TabIndex = 9;
            this.lblMatricula.Text = "Matrícula";
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(20, 150);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(42, 16);
            this.lblCurso.TabIndex = 10;
            this.lblCurso.Text = "Curso";
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Location = new System.Drawing.Point(20, 190);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(70, 16);
            this.lblEstudiante.TabIndex = 11;
            this.lblEstudiante.Text = "Estudiante";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(20, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(210, 25);
            this.labelTitulo.TabIndex = 12;
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
            // txtIdCM
            // 
            this.txtIdCM.Location = new System.Drawing.Point(120, 70);
            this.txtIdCM.Name = "txtIdCM";
            this.txtIdCM.Size = new System.Drawing.Size(200, 22);
            this.txtIdCM.TabIndex = 1;
            this.txtIdCM.TextChanged += new System.EventHandler(this.txtIdCM_TextChanged);
            this.txtIdCM.Leave += new System.EventHandler(this.txtIdCM_Leave);
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnInsertar);
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnEliminar);
            this.grpAcciones.Location = new System.Drawing.Point(25, 239);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(315, 65);
            this.grpAcciones.TabIndex = 22;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "ACCIONES";
            // 
            // UcCursosMatriculados
            // 
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.txtIdCM);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.dgvCursosMatriculados);
            this.Controls.Add(this.lblIdCursosMatriculados);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.cbMatricula);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.cbCurso);
            this.Controls.Add(this.lblEstudiante);
            this.Controls.Add(this.cbEstudiante);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Name = "UcCursosMatriculados";
            this.Size = new System.Drawing.Size(874, 371);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosMatriculados)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAcciones;
    }
}