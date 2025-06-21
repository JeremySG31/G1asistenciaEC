namespace G1asistenciaEC.vista
{
    partial class UcGradosSecciones
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvGrados;
        private System.Windows.Forms.DataGridView dgvSecciones;
        private System.Windows.Forms.TextBox txtIdGrado;
        private System.Windows.Forms.TextBox txtNombreGrado;
        private System.Windows.Forms.ComboBox cbEstudianteGrado;
        private System.Windows.Forms.Button btnInsertarGrado;
        private System.Windows.Forms.Button btnModificarGrado;
        private System.Windows.Forms.Button btnEliminarGrado;
        private System.Windows.Forms.TextBox txtIdSeccion;
        private System.Windows.Forms.TextBox txtNombreSeccion;
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
            this.txtNombreGrado = new System.Windows.Forms.TextBox();
            this.cbEstudianteGrado = new System.Windows.Forms.ComboBox();
            this.btnInsertarGrado = new System.Windows.Forms.Button();
            this.btnModificarGrado = new System.Windows.Forms.Button();
            this.btnEliminarGrado = new System.Windows.Forms.Button();
            this.txtIdSeccion = new System.Windows.Forms.TextBox();
            this.txtNombreSeccion = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).BeginInit();
            this.SuspendLayout();

            this.dgvGrados.AllowUserToDeleteRows = false;
            this.dgvGrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrados.Location = new System.Drawing.Point(42, 47);
            this.dgvGrados.Name = "dgvGrados";
            this.dgvGrados.RowHeadersWidth = 51;
            this.dgvGrados.Size = new System.Drawing.Size(467, 190);
            this.dgvGrados.TabIndex = 0;
            this.dgvGrados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrados_CellContentClick);

            this.dgvSecciones.AllowUserToDeleteRows = false;
            this.dgvSecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecciones.Location = new System.Drawing.Point(575, 47);
            this.dgvSecciones.Name = "dgvSecciones";
            this.dgvSecciones.RowHeadersWidth = 51;
            this.dgvSecciones.Size = new System.Drawing.Size(436, 190);
            this.dgvSecciones.TabIndex = 1;

            this.txtIdGrado.Location = new System.Drawing.Point(135, 243);
            this.txtIdGrado.Name = "txtIdGrado";
            this.txtIdGrado.Size = new System.Drawing.Size(100, 22);
            this.txtIdGrado.TabIndex = 2;
 
            this.txtNombreGrado.Location = new System.Drawing.Point(135, 272);
            this.txtNombreGrado.Name = "txtNombreGrado";
            this.txtNombreGrado.Size = new System.Drawing.Size(150, 22);
            this.txtNombreGrado.TabIndex = 4;

            this.cbEstudianteGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudianteGrado.Location = new System.Drawing.Point(135, 338);
            this.cbEstudianteGrado.Name = "cbEstudianteGrado";
            this.cbEstudianteGrado.Size = new System.Drawing.Size(200, 24);
            this.cbEstudianteGrado.TabIndex = 13;

            this.btnInsertarGrado.Location = new System.Drawing.Point(87, 374);
            this.btnInsertarGrado.Name = "btnInsertarGrado";
            this.btnInsertarGrado.Size = new System.Drawing.Size(84, 29);
            this.btnInsertarGrado.TabIndex = 14;
            this.btnInsertarGrado.Text = "Insertar";
   
            this.btnModificarGrado.Location = new System.Drawing.Point(186, 374);
            this.btnModificarGrado.Name = "btnModificarGrado";
            this.btnModificarGrado.Size = new System.Drawing.Size(87, 29);
            this.btnModificarGrado.TabIndex = 15;
            this.btnModificarGrado.Text = "Modificar";

            this.btnEliminarGrado.Location = new System.Drawing.Point(289, 374);
            this.btnEliminarGrado.Name = "btnEliminarGrado";
            this.btnEliminarGrado.Size = new System.Drawing.Size(75, 29);
            this.btnEliminarGrado.TabIndex = 16;
            this.btnEliminarGrado.Text = "Eliminar";

            this.txtIdSeccion.Location = new System.Drawing.Point(651, 244);
            this.txtIdSeccion.Name = "txtIdSeccion";
            this.txtIdSeccion.Size = new System.Drawing.Size(100, 22);
            this.txtIdSeccion.TabIndex = 18;

            this.txtNombreSeccion.Location = new System.Drawing.Point(651, 287);
            this.txtNombreSeccion.Name = "txtNombreSeccion";
            this.txtNombreSeccion.Size = new System.Drawing.Size(150, 22);
            this.txtNombreSeccion.TabIndex = 20;

            this.cbEstudianteSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudianteSeccion.Location = new System.Drawing.Point(651, 333);
            this.cbEstudianteSeccion.Name = "cbEstudianteSeccion";
            this.cbEstudianteSeccion.Size = new System.Drawing.Size(233, 24);
            this.cbEstudianteSeccion.TabIndex = 22;

            this.btnInsertarSeccion.Location = new System.Drawing.Point(620, 371);
            this.btnInsertarSeccion.Name = "btnInsertarSeccion";
            this.btnInsertarSeccion.Size = new System.Drawing.Size(87, 32);
            this.btnInsertarSeccion.TabIndex = 23;
            this.btnInsertarSeccion.Text = "Insertar";
  
            this.btnModificarSeccion.Location = new System.Drawing.Point(721, 371);
            this.btnModificarSeccion.Name = "btnModificarSeccion";
            this.btnModificarSeccion.Size = new System.Drawing.Size(80, 32);
            this.btnModificarSeccion.TabIndex = 24;
            this.btnModificarSeccion.Text = "Modificar";

            this.btnEliminarSeccion.Location = new System.Drawing.Point(821, 371);
            this.btnEliminarSeccion.Name = "btnEliminarSeccion";
            this.btnEliminarSeccion.Size = new System.Drawing.Size(75, 32);
            this.btnEliminarSeccion.TabIndex = 25;
            this.btnEliminarSeccion.Text = "Eliminar";

            this.lblIdGrado.AutoSize = true;
            this.lblIdGrado.Location = new System.Drawing.Point(59, 245);
            this.lblIdGrado.Name = "lblIdGrado";
            this.lblIdGrado.Size = new System.Drawing.Size(18, 16);
            this.lblIdGrado.TabIndex = 1;
            this.lblIdGrado.Text = "Id";

            this.lblNombreGrado.AutoSize = true;
            this.lblNombreGrado.Location = new System.Drawing.Point(59, 275);
            this.lblNombreGrado.Name = "lblNombreGrado";
            this.lblNombreGrado.Size = new System.Drawing.Size(56, 16);
            this.lblNombreGrado.TabIndex = 3;
            this.lblNombreGrado.Text = "Nombre";

            this.lblEstudianteGrado.AutoSize = true;
            this.lblEstudianteGrado.Location = new System.Drawing.Point(59, 341);
            this.lblEstudianteGrado.Name = "lblEstudianteGrado";
            this.lblEstudianteGrado.Size = new System.Drawing.Size(70, 16);
            this.lblEstudianteGrado.TabIndex = 12;
            this.lblEstudianteGrado.Text = "Estudiante";

            this.lblIdSeccion.AutoSize = true;
            this.lblIdSeccion.Location = new System.Drawing.Point(575, 247);
            this.lblIdSeccion.Name = "lblIdSeccion";
            this.lblIdSeccion.Size = new System.Drawing.Size(18, 16);
            this.lblIdSeccion.TabIndex = 17;
            this.lblIdSeccion.Text = "Id";

            this.lblNombreSeccion.AutoSize = true;
            this.lblNombreSeccion.Location = new System.Drawing.Point(575, 290);
            this.lblNombreSeccion.Name = "lblNombreSeccion";
            this.lblNombreSeccion.Size = new System.Drawing.Size(56, 16);
            this.lblNombreSeccion.TabIndex = 19;
            this.lblNombreSeccion.Text = "Nombre";

            this.lblEstudianteSeccion.AutoSize = true;
            this.lblEstudianteSeccion.Location = new System.Drawing.Point(575, 338);
            this.lblEstudianteSeccion.Name = "lblEstudianteSeccion";
            this.lblEstudianteSeccion.Size = new System.Drawing.Size(70, 16);
            this.lblEstudianteSeccion.TabIndex = 21;
            this.lblEstudianteSeccion.Text = "Estudiante";

            this.cbNivelGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivelGrado.FormattingEnabled = true;
            this.cbNivelGrado.Items.AddRange(new object[] {
            "1-Primaria",
            "2-Secundaria"});
            this.cbNivelGrado.Location = new System.Drawing.Point(135, 303);
            this.cbNivelGrado.Name = "cbNivelGrado";
            this.cbNivelGrado.Size = new System.Drawing.Size(121, 24);
            this.cbNivelGrado.TabIndex = 11;
            this.cbNivelGrado.SelectedIndexChanged += new System.EventHandler(this.cbNivelGrado_SelectedIndexChanged);

            this.lblNivelGrado.AutoSize = true;
            this.lblNivelGrado.Location = new System.Drawing.Point(59, 305);
            this.lblNivelGrado.Name = "lblNivelGrado";
            this.lblNivelGrado.Size = new System.Drawing.Size(41, 16);
            this.lblNivelGrado.TabIndex = 10;
            this.lblNivelGrado.Text = "Nivel:";

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(37, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Grados";

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(573, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Secciones";
            this.label2.Click += new System.EventHandler(this.label2_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGrados);
            this.Controls.Add(this.lblIdGrado);
            this.Controls.Add(this.txtIdGrado);
            this.Controls.Add(this.lblNombreGrado);
            this.Controls.Add(this.txtNombreGrado);
            this.Controls.Add(this.lblNivelGrado);
            this.Controls.Add(this.cbNivelGrado);
            this.Controls.Add(this.lblEstudianteGrado);
            this.Controls.Add(this.cbEstudianteGrado);
            this.Controls.Add(this.btnInsertarGrado);
            this.Controls.Add(this.btnModificarGrado);
            this.Controls.Add(this.btnEliminarGrado);
            this.Controls.Add(this.dgvSecciones);
            this.Controls.Add(this.lblIdSeccion);
            this.Controls.Add(this.txtIdSeccion);
            this.Controls.Add(this.lblNombreSeccion);
            this.Controls.Add(this.txtNombreSeccion);
            this.Controls.Add(this.lblEstudianteSeccion);
            this.Controls.Add(this.cbEstudianteSeccion);
            this.Controls.Add(this.btnInsertarSeccion);
            this.Controls.Add(this.btnModificarSeccion);
            this.Controls.Add(this.btnEliminarSeccion);
            this.Name = "UcGradosSecciones";
            this.Size = new System.Drawing.Size(1072, 420);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
