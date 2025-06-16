namespace G1asistenciaEC.vista
{
    partial class UcEstudianteApoderado
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEstudianteApoderados;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbIdEstudiante;
        private System.Windows.Forms.ComboBox cbIdApoderado;
        private System.Windows.Forms.TextBox txtParentesco;
        private System.Windows.Forms.ComboBox cbPrioridad;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblIdEstudiante;
        private System.Windows.Forms.Label lblIdApoderado;
        private System.Windows.Forms.Label lblParentesco;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblEstado;

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
            this.dgvEstudianteApoderados = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbIdEstudiante = new System.Windows.Forms.ComboBox();
            this.cbIdApoderado = new System.Windows.Forms.ComboBox();
            this.txtParentesco = new System.Windows.Forms.TextBox();
            this.cbPrioridad = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblIdEstudiante = new System.Windows.Forms.Label();
            this.lblIdApoderado = new System.Windows.Forms.Label();
            this.lblParentesco = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudianteApoderados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstudianteApoderados
            // 
            this.dgvEstudianteApoderados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudianteApoderados.Location = new System.Drawing.Point(411, 27);
            this.dgvEstudianteApoderados.Name = "dgvEstudianteApoderados";
            this.dgvEstudianteApoderados.RowHeadersWidth = 51;
            this.dgvEstudianteApoderados.Size = new System.Drawing.Size(705, 324);
            this.dgvEstudianteApoderados.TabIndex = 12;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(150, 249);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(90, 30);
            this.btnInsertar.TabIndex = 7;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(150, 285);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 30);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(150, 321);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(274, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Estudiante-Apoderado";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(150, 57);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(150, 22);
            this.txtId.TabIndex = 2;
            // 
            // cbIdEstudiante
            // 
            this.cbIdEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdEstudiante.Location = new System.Drawing.Point(150, 87);
            this.cbIdEstudiante.Name = "cbIdEstudiante";
            this.cbIdEstudiante.Size = new System.Drawing.Size(233, 24);
            this.cbIdEstudiante.TabIndex = 3;
            // 
            // cbIdApoderado
            // 
            this.cbIdApoderado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdApoderado.Location = new System.Drawing.Point(150, 117);
            this.cbIdApoderado.Name = "cbIdApoderado";
            this.cbIdApoderado.Size = new System.Drawing.Size(233, 24);
            this.cbIdApoderado.TabIndex = 4;
            // 
            // txtParentesco
            // 
            this.txtParentesco.Location = new System.Drawing.Point(150, 147);
            this.txtParentesco.Name = "txtParentesco";
            this.txtParentesco.Size = new System.Drawing.Size(150, 22);
            this.txtParentesco.TabIndex = 5;
            // 
            // cbPrioridad
            // 
            this.cbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrioridad.Location = new System.Drawing.Point(150, 177);
            this.cbPrioridad.Name = "cbPrioridad";
            this.cbPrioridad.Size = new System.Drawing.Size(150, 24);
            this.cbPrioridad.TabIndex = 6;
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Items.AddRange(new object[] {
            "activo",
            "inactivo"});
            this.cbEstado.Location = new System.Drawing.Point(150, 207);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(150, 24);
            this.cbEstado.TabIndex = 8;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(30, 60);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(20, 16);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";
            // 
            // lblIdEstudiante
            // 
            this.lblIdEstudiante.AutoSize = true;
            this.lblIdEstudiante.Location = new System.Drawing.Point(30, 90);
            this.lblIdEstudiante.Name = "lblIdEstudiante";
            this.lblIdEstudiante.Size = new System.Drawing.Size(86, 16);
            this.lblIdEstudiante.TabIndex = 3;
            this.lblIdEstudiante.Text = "ID Estudiante";
            // 
            // lblIdApoderado
            // 
            this.lblIdApoderado.AutoSize = true;
            this.lblIdApoderado.Location = new System.Drawing.Point(30, 120);
            this.lblIdApoderado.Name = "lblIdApoderado";
            this.lblIdApoderado.Size = new System.Drawing.Size(92, 16);
            this.lblIdApoderado.TabIndex = 4;
            this.lblIdApoderado.Text = "ID Apoderado";
            // 
            // lblParentesco
            // 
            this.lblParentesco.AutoSize = true;
            this.lblParentesco.Location = new System.Drawing.Point(30, 150);
            this.lblParentesco.Name = "lblParentesco";
            this.lblParentesco.Size = new System.Drawing.Size(76, 16);
            this.lblParentesco.TabIndex = 5;
            this.lblParentesco.Text = "Parentesco";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Location = new System.Drawing.Point(30, 180);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(62, 16);
            this.lblPrioridad.TabIndex = 6;
            this.lblPrioridad.Text = "Prioridad";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(30, 210);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(50, 16);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            // 
            // UcEstudianteApoderado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblIdEstudiante);
            this.Controls.Add(this.cbIdEstudiante);
            this.Controls.Add(this.lblIdApoderado);
            this.Controls.Add(this.cbIdApoderado);
            this.Controls.Add(this.lblParentesco);
            this.Controls.Add(this.txtParentesco);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.cbPrioridad);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvEstudianteApoderados);
            this.Name = "UcEstudianteApoderado";
            this.Size = new System.Drawing.Size(1144, 368);
            this.Load += new System.EventHandler(this.UcEstudianteApoderado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudianteApoderados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
