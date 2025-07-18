﻿namespace G1asistenciaEC.vista
{
    partial class UcGradosSecciones
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvGrados;
        private System.Windows.Forms.DataGridView dgvSecciones;
        private System.Windows.Forms.TextBox txtIdGrado;
        private System.Windows.Forms.ComboBox cbNombreGrado;
        private System.Windows.Forms.ComboBox cbEstudianteGrado;
        private System.Windows.Forms.Button btnInsertarGrado;
        private System.Windows.Forms.Button btnModificarGrado;
        private System.Windows.Forms.Button btnEliminarGrado;
        private System.Windows.Forms.TextBox txtIdSeccion;
        private System.Windows.Forms.ComboBox cbNombreSeccion;
        private System.Windows.Forms.ComboBox cbEstudianteSeccion;
        private System.Windows.Forms.Button btnInsertarSeccion;
        private System.Windows.Forms.Button btnModificarSeccion;
        private System.Windows.Forms.Button btnEliminarSeccion;
        private System.Windows.Forms.Label lblIdGrado;
        private System.Windows.Forms.Label lblNombreGrado;
        private System.Windows.Forms.Label lblEstudianteGrado;
        private System.Windows.Forms.Label lblIdSeccion;
        private System.Windows.Forms.Label lblNombreSeccion;
        private System.Windows.Forms.Label lblEstudianteSeccion;
        private System.Windows.Forms.ComboBox cbNivelGrado;
        private System.Windows.Forms.Label lblNivelGrado;

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
            this.dgvGrados = new System.Windows.Forms.DataGridView();
            this.dgvSecciones = new System.Windows.Forms.DataGridView();
            this.txtIdGrado = new System.Windows.Forms.TextBox();
            this.cbNombreGrado = new System.Windows.Forms.ComboBox();
            this.cbEstudianteGrado = new System.Windows.Forms.ComboBox();
            this.btnInsertarGrado = new System.Windows.Forms.Button();
            this.btnModificarGrado = new System.Windows.Forms.Button();
            this.btnEliminarGrado = new System.Windows.Forms.Button();
            this.txtIdSeccion = new System.Windows.Forms.TextBox();
            this.cbNombreSeccion = new System.Windows.Forms.ComboBox();
            this.cbEstudianteSeccion = new System.Windows.Forms.ComboBox();
            this.btnInsertarSeccion = new System.Windows.Forms.Button();
            this.btnModificarSeccion = new System.Windows.Forms.Button();
            this.btnEliminarSeccion = new System.Windows.Forms.Button();
            this.lblIdGrado = new System.Windows.Forms.Label();
            this.lblNombreGrado = new System.Windows.Forms.Label();
            this.lblEstudianteGrado = new System.Windows.Forms.Label();
            this.lblIdSeccion = new System.Windows.Forms.Label();
            this.lblNombreSeccion = new System.Windows.Forms.Label();
            this.lblEstudianteSeccion = new System.Windows.Forms.Label();
            this.cbNivelGrado = new System.Windows.Forms.ComboBox();
            this.lblNivelGrado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).BeginInit();
            this.grpAcciones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGrados
            // 
            this.dgvGrados.AllowUserToDeleteRows = false;
            this.dgvGrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrados.Location = new System.Drawing.Point(42, 47);
            this.dgvGrados.Name = "dgvGrados";
            this.dgvGrados.RowHeadersWidth = 51;
            this.dgvGrados.Size = new System.Drawing.Size(467, 166);
            this.dgvGrados.TabIndex = 0;
            this.dgvGrados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrados_CellContentClick);
            // 
            // dgvSecciones
            // 
            this.dgvSecciones.AllowUserToDeleteRows = false;
            this.dgvSecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecciones.Location = new System.Drawing.Point(575, 47);
            this.dgvSecciones.Name = "dgvSecciones";
            this.dgvSecciones.RowHeadersWidth = 51;
            this.dgvSecciones.Size = new System.Drawing.Size(436, 190);
            this.dgvSecciones.TabIndex = 1;
            // 
            // txtIdGrado
            // 
            this.txtIdGrado.Location = new System.Drawing.Point(135, 219);
            this.txtIdGrado.Name = "txtIdGrado";
            this.txtIdGrado.Size = new System.Drawing.Size(100, 22);
            this.txtIdGrado.TabIndex = 2;
            // 
            // cbNombreGrado
            // 
            this.cbNombreGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNombreGrado.Location = new System.Drawing.Point(135, 248);
            this.cbNombreGrado.Name = "cbNombreGrado";
            this.cbNombreGrado.Size = new System.Drawing.Size(150, 24);
            this.cbNombreGrado.TabIndex = 4;
            // 
            // cbEstudianteGrado
            // 
            this.cbEstudianteGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudianteGrado.Location = new System.Drawing.Point(135, 314);
            this.cbEstudianteGrado.Name = "cbEstudianteGrado";
            this.cbEstudianteGrado.Size = new System.Drawing.Size(200, 24);
            this.cbEstudianteGrado.TabIndex = 13;
            // 
            // btnInsertarGrado
            // 
            this.btnInsertarGrado.Location = new System.Drawing.Point(6, 21);
            this.btnInsertarGrado.Name = "btnInsertarGrado";
            this.btnInsertarGrado.Size = new System.Drawing.Size(94, 29);
            this.btnInsertarGrado.TabIndex = 14;
            this.btnInsertarGrado.Text = "INSERTAR";
            // 
            // btnModificarGrado
            // 
            this.btnModificarGrado.Location = new System.Drawing.Point(106, 21);
            this.btnModificarGrado.Name = "btnModificarGrado";
            this.btnModificarGrado.Size = new System.Drawing.Size(107, 29);
            this.btnModificarGrado.TabIndex = 15;
            this.btnModificarGrado.Text = "MODIFICAR";
            // 
            // btnEliminarGrado
            // 
            this.btnEliminarGrado.Location = new System.Drawing.Point(218, 21);
            this.btnEliminarGrado.Name = "btnEliminarGrado";
            this.btnEliminarGrado.Size = new System.Drawing.Size(93, 29);
            this.btnEliminarGrado.TabIndex = 16;
            this.btnEliminarGrado.Text = "ELIMINAR";
            // 
            // txtIdSeccion
            // 
            this.txtIdSeccion.Location = new System.Drawing.Point(651, 244);
            this.txtIdSeccion.Name = "txtIdSeccion";
            this.txtIdSeccion.Size = new System.Drawing.Size(100, 22);
            this.txtIdSeccion.TabIndex = 18;
            // 
            // cbNombreSeccion
            // 
            this.cbNombreSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNombreSeccion.Location = new System.Drawing.Point(651, 277);
            this.cbNombreSeccion.Name = "cbNombreSeccion";
            this.cbNombreSeccion.Size = new System.Drawing.Size(150, 24);
            this.cbNombreSeccion.TabIndex = 20;
            // 
            // cbEstudianteSeccion
            // 
            this.cbEstudianteSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudianteSeccion.Location = new System.Drawing.Point(651, 314);
            this.cbEstudianteSeccion.Name = "cbEstudianteSeccion";
            this.cbEstudianteSeccion.Size = new System.Drawing.Size(233, 24);
            this.cbEstudianteSeccion.TabIndex = 22;
            // 
            // btnInsertarSeccion
            // 
            this.btnInsertarSeccion.Location = new System.Drawing.Point(3, 21);
            this.btnInsertarSeccion.Name = "btnInsertarSeccion";
            this.btnInsertarSeccion.Size = new System.Drawing.Size(102, 32);
            this.btnInsertarSeccion.TabIndex = 23;
            this.btnInsertarSeccion.Text = "INSERTAR";
            // 
            // btnModificarSeccion
            // 
            this.btnModificarSeccion.Location = new System.Drawing.Point(107, 21);
            this.btnModificarSeccion.Name = "btnModificarSeccion";
            this.btnModificarSeccion.Size = new System.Drawing.Size(98, 32);
            this.btnModificarSeccion.TabIndex = 24;
            this.btnModificarSeccion.Text = "MODIFICAR";
            // 
            // btnEliminarSeccion
            // 
            this.btnEliminarSeccion.Location = new System.Drawing.Point(211, 21);
            this.btnEliminarSeccion.Name = "btnEliminarSeccion";
            this.btnEliminarSeccion.Size = new System.Drawing.Size(99, 32);
            this.btnEliminarSeccion.TabIndex = 25;
            this.btnEliminarSeccion.Text = "ELIMINAR";
            // 
            // lblIdGrado
            // 
            this.lblIdGrado.AutoSize = true;
            this.lblIdGrado.Location = new System.Drawing.Point(59, 221);
            this.lblIdGrado.Name = "lblIdGrado";
            this.lblIdGrado.Size = new System.Drawing.Size(18, 16);
            this.lblIdGrado.TabIndex = 1;
            this.lblIdGrado.Text = "Id";
            // 
            // lblNombreGrado
            // 
            this.lblNombreGrado.AutoSize = true;
            this.lblNombreGrado.Location = new System.Drawing.Point(59, 251);
            this.lblNombreGrado.Name = "lblNombreGrado";
            this.lblNombreGrado.Size = new System.Drawing.Size(56, 16);
            this.lblNombreGrado.TabIndex = 3;
            this.lblNombreGrado.Text = "Nombre";
            // 
            // lblEstudianteGrado
            // 
            this.lblEstudianteGrado.AutoSize = true;
            this.lblEstudianteGrado.Location = new System.Drawing.Point(59, 317);
            this.lblEstudianteGrado.Name = "lblEstudianteGrado";
            this.lblEstudianteGrado.Size = new System.Drawing.Size(70, 16);
            this.lblEstudianteGrado.TabIndex = 12;
            this.lblEstudianteGrado.Text = "Estudiante";
            // 
            // lblIdSeccion
            // 
            this.lblIdSeccion.AutoSize = true;
            this.lblIdSeccion.Location = new System.Drawing.Point(575, 247);
            this.lblIdSeccion.Name = "lblIdSeccion";
            this.lblIdSeccion.Size = new System.Drawing.Size(18, 16);
            this.lblIdSeccion.TabIndex = 17;
            this.lblIdSeccion.Text = "Id";
            // 
            // lblNombreSeccion
            // 
            this.lblNombreSeccion.AutoSize = true;
            this.lblNombreSeccion.Location = new System.Drawing.Point(575, 281);
            this.lblNombreSeccion.Name = "lblNombreSeccion";
            this.lblNombreSeccion.Size = new System.Drawing.Size(56, 16);
            this.lblNombreSeccion.TabIndex = 19;
            this.lblNombreSeccion.Text = "Nombre";
            this.lblNombreSeccion.Click += new System.EventHandler(this.lblNombreSeccion_Click);
            // 
            // lblEstudianteSeccion
            // 
            this.lblEstudianteSeccion.AutoSize = true;
            this.lblEstudianteSeccion.Location = new System.Drawing.Point(575, 317);
            this.lblEstudianteSeccion.Name = "lblEstudianteSeccion";
            this.lblEstudianteSeccion.Size = new System.Drawing.Size(70, 16);
            this.lblEstudianteSeccion.TabIndex = 21;
            this.lblEstudianteSeccion.Text = "Estudiante";
            // 
            // cbNivelGrado
            // 
            this.cbNivelGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivelGrado.FormattingEnabled = true;
            this.cbNivelGrado.Items.AddRange(new object[] {
            "1-Primaria",
            "2-Secundaria"});
            this.cbNivelGrado.Location = new System.Drawing.Point(135, 279);
            this.cbNivelGrado.Name = "cbNivelGrado";
            this.cbNivelGrado.Size = new System.Drawing.Size(121, 24);
            this.cbNivelGrado.TabIndex = 11;
            this.cbNivelGrado.SelectedIndexChanged += new System.EventHandler(this.cbNivelGrado_SelectedIndexChanged);
            // 
            // lblNivelGrado
            // 
            this.lblNivelGrado.AutoSize = true;
            this.lblNivelGrado.Location = new System.Drawing.Point(59, 281);
            this.lblNivelGrado.Name = "lblNivelGrado";
            this.lblNivelGrado.Size = new System.Drawing.Size(41, 16);
            this.lblNivelGrado.TabIndex = 10;
            this.lblNivelGrado.Text = "Nivel:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(37, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Grados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(573, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Secciones";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnInsertarGrado);
            this.grpAcciones.Controls.Add(this.btnModificarGrado);
            this.grpAcciones.Controls.Add(this.btnEliminarGrado);
            this.grpAcciones.Location = new System.Drawing.Point(42, 350);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(315, 65);
            this.grpAcciones.TabIndex = 28;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "ACCIONES";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInsertarSeccion);
            this.groupBox1.Controls.Add(this.btnModificarSeccion);
            this.groupBox1.Controls.Add(this.btnEliminarSeccion);
            this.groupBox1.Location = new System.Drawing.Point(578, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 65);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACCIONES";
            // 
            // UcGradosSecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGrados);
            this.Controls.Add(this.lblIdGrado);
            this.Controls.Add(this.txtIdGrado);
            this.Controls.Add(this.lblNombreGrado);
            this.Controls.Add(this.cbNombreGrado);
            this.Controls.Add(this.lblNivelGrado);
            this.Controls.Add(this.cbNivelGrado);
            this.Controls.Add(this.lblEstudianteGrado);
            this.Controls.Add(this.cbEstudianteGrado);
            this.Controls.Add(this.dgvSecciones);
            this.Controls.Add(this.lblIdSeccion);
            this.Controls.Add(this.txtIdSeccion);
            this.Controls.Add(this.lblNombreSeccion);
            this.Controls.Add(this.cbNombreSeccion);
            this.Controls.Add(this.lblEstudianteSeccion);
            this.Controls.Add(this.cbEstudianteSeccion);
            this.Name = "UcGradosSecciones";
            this.Size = new System.Drawing.Size(1072, 433);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
