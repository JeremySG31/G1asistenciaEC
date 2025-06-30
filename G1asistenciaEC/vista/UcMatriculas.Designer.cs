namespace G1asistenciaEC.vista
{
    partial class UcMatriculas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMatriculas;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbEstudiante;
        private System.Windows.Forms.ComboBox cbGrado;
        private System.Windows.Forms.ComboBox cbNivel;
        private System.Windows.Forms.ComboBox cbSeccion;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.ComboBox cbAnioLectivo;
        private System.Windows.Forms.ComboBox cbApoderado;
        private System.Windows.Forms.DateTimePicker dtpFechaMatricula;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.Label lblGrado;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblAnioLectivo;
        private System.Windows.Forms.Label lblApoderado;
        private System.Windows.Forms.Label lblFechaMatricula;
        private System.Windows.Forms.Label lblEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvMatriculas = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbEstudiante = new System.Windows.Forms.ComboBox();
            this.cbGrado = new System.Windows.Forms.ComboBox();
            this.cbNivel = new System.Windows.Forms.ComboBox();
            this.cbSeccion = new System.Windows.Forms.ComboBox();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.cbAnioLectivo = new System.Windows.Forms.ComboBox();
            this.cbApoderado = new System.Windows.Forms.ComboBox();
            this.dtpFechaMatricula = new System.Windows.Forms.DateTimePicker();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.lblGrado = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblAnioLectivo = new System.Windows.Forms.Label();
            this.lblApoderado = new System.Windows.Forms.Label();
            this.lblFechaMatricula = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).BeginInit();
            this.grpAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMatriculas
            // 
            this.dgvMatriculas.ColumnHeadersHeight = 29;
            this.dgvMatriculas.Location = new System.Drawing.Point(350, 24);
            this.dgvMatriculas.Name = "dgvMatriculas";
            this.dgvMatriculas.RowHeadersWidth = 51;
            this.dgvMatriculas.Size = new System.Drawing.Size(700, 320);
            this.dgvMatriculas.TabIndex = 20;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(23, 21);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(95, 26);
            this.btnInsertar.TabIndex = 15;
            this.btnInsertar.Text = "INSERTAR";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(121, 21);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 26);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "MODIFICAR";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(224, 21);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(89, 26);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "ELIMINAR";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(46, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(111, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Matrículas";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(150, 59);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(150, 22);
            this.txtId.TabIndex = 1;
            // 
            // cbEstudiante
            // 
            this.cbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudiante.Location = new System.Drawing.Point(150, 89);
            this.cbEstudiante.Name = "cbEstudiante";
            this.cbEstudiante.Size = new System.Drawing.Size(150, 24);
            this.cbEstudiante.TabIndex = 2;
            // 
            // cbGrado
            // 
            this.cbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrado.Location = new System.Drawing.Point(150, 119);
            this.cbGrado.Name = "cbGrado";
            this.cbGrado.Size = new System.Drawing.Size(150, 24);
            this.cbGrado.TabIndex = 3;
            // 
            // cbNivel
            // 
            this.cbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivel.Location = new System.Drawing.Point(150, 149);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(150, 24);
            this.cbNivel.TabIndex = 4;
            // 
            // cbSeccion
            // 
            this.cbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeccion.Location = new System.Drawing.Point(150, 179);
            this.cbSeccion.Name = "cbSeccion";
            this.cbSeccion.Size = new System.Drawing.Size(150, 24);
            this.cbSeccion.TabIndex = 5;
            // 
            // cbTurno
            // 
            this.cbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurno.Location = new System.Drawing.Point(150, 209);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(150, 24);
            this.cbTurno.TabIndex = 6;
            // 
            // cbAnioLectivo
            // 
            this.cbAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnioLectivo.Location = new System.Drawing.Point(150, 239);
            this.cbAnioLectivo.Name = "cbAnioLectivo";
            this.cbAnioLectivo.Size = new System.Drawing.Size(150, 24);
            this.cbAnioLectivo.TabIndex = 7;
            // 
            // cbApoderado
            // 
            this.cbApoderado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApoderado.Location = new System.Drawing.Point(150, 269);
            this.cbApoderado.Name = "cbApoderado";
            this.cbApoderado.Size = new System.Drawing.Size(150, 24);
            this.cbApoderado.TabIndex = 8;
            // 
            // dtpFechaMatricula
            // 
            this.dtpFechaMatricula.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaMatricula.Location = new System.Drawing.Point(150, 299);
            this.dtpFechaMatricula.Name = "dtpFechaMatricula";
            this.dtpFechaMatricula.Size = new System.Drawing.Size(150, 22);
            this.dtpFechaMatricula.TabIndex = 9;
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Location = new System.Drawing.Point(150, 329);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(150, 24);
            this.cbEstado.TabIndex = 10;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(46, 62);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 16);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.Location = new System.Drawing.Point(46, 92);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(100, 16);
            this.lblEstudiante.TabIndex = 2;
            this.lblEstudiante.Text = "Estudiante";
            // 
            // lblGrado
            // 
            this.lblGrado.Location = new System.Drawing.Point(46, 122);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(100, 16);
            this.lblGrado.TabIndex = 3;
            this.lblGrado.Text = "Grado";
            // 
            // lblNivel
            // 
            this.lblNivel.Location = new System.Drawing.Point(46, 152);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(100, 16);
            this.lblNivel.TabIndex = 4;
            this.lblNivel.Text = "Nivel";
            // 
            // lblSeccion
            // 
            this.lblSeccion.Location = new System.Drawing.Point(46, 182);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(100, 16);
            this.lblSeccion.TabIndex = 5;
            this.lblSeccion.Text = "Sección";
            // 
            // lblTurno
            // 
            this.lblTurno.Location = new System.Drawing.Point(46, 212);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(100, 16);
            this.lblTurno.TabIndex = 6;
            this.lblTurno.Text = "Turno";
            // 
            // lblAnioLectivo
            // 
            this.lblAnioLectivo.Location = new System.Drawing.Point(46, 242);
            this.lblAnioLectivo.Name = "lblAnioLectivo";
            this.lblAnioLectivo.Size = new System.Drawing.Size(100, 16);
            this.lblAnioLectivo.TabIndex = 7;
            this.lblAnioLectivo.Text = "Año Lectivo";
            // 
            // lblApoderado
            // 
            this.lblApoderado.Location = new System.Drawing.Point(46, 272);
            this.lblApoderado.Name = "lblApoderado";
            this.lblApoderado.Size = new System.Drawing.Size(100, 16);
            this.lblApoderado.TabIndex = 8;
            this.lblApoderado.Text = "Apoderado";
            // 
            // lblFechaMatricula
            // 
            this.lblFechaMatricula.Location = new System.Drawing.Point(46, 302);
            this.lblFechaMatricula.Name = "lblFechaMatricula";
            this.lblFechaMatricula.Size = new System.Drawing.Size(100, 16);
            this.lblFechaMatricula.TabIndex = 9;
            this.lblFechaMatricula.Text = "Fecha Matrícula";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(46, 332);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 16);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado";
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnEliminar);
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnInsertar);
            this.grpAcciones.Location = new System.Drawing.Point(39, 370);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(323, 65);
            this.grpAcciones.TabIndex = 21;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "ACCIONES";
            // 
            // UcMatriculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblEstudiante);
            this.Controls.Add(this.cbEstudiante);
            this.Controls.Add(this.lblGrado);
            this.Controls.Add(this.cbGrado);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.cbNivel);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.cbSeccion);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.cbTurno);
            this.Controls.Add(this.lblAnioLectivo);
            this.Controls.Add(this.cbAnioLectivo);
            this.Controls.Add(this.lblApoderado);
            this.Controls.Add(this.cbApoderado);
            this.Controls.Add(this.lblFechaMatricula);
            this.Controls.Add(this.dtpFechaMatricula);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.dgvMatriculas);
            this.Name = "UcMatriculas";
            this.Size = new System.Drawing.Size(1100, 470);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox grpAcciones;
    }
}