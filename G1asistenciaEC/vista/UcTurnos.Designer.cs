namespace G1asistenciaEC.vista
{
    partial class UcTurnos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbNombreTurno;
        private System.Windows.Forms.ComboBox cbEstudiante;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEstudiante;

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
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbNombreTurno = new System.Windows.Forms.ComboBox();
            this.cbEstudiante = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.grpInformacionAdicional = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.grpAcciones.SuspendLayout();
            this.grpInformacionAdicional.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.ColumnHeadersHeight = 29;
            this.dgvTurnos.Location = new System.Drawing.Point(335, 24);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.RowHeadersWidth = 51;
            this.dgvTurnos.Size = new System.Drawing.Size(527, 228);
            this.dgvTurnos.TabIndex = 10;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(3, 21);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(95, 26);
            this.btnInsertar.TabIndex = 7;
            this.btnInsertar.Text = "INSERTAR";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(103, 21);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(101, 26);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "MODIFICAR";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(207, 21);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 26);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "ELIMINAR";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(46, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(80, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Turnos";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(97, 26);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(120, 22);
            this.txtId.TabIndex = 2;
            // 
            // cbNombreTurno
            // 
            this.cbNombreTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNombreTurno.Location = new System.Drawing.Point(97, 56);
            this.cbNombreTurno.Name = "cbNombreTurno";
            this.cbNombreTurno.Size = new System.Drawing.Size(120, 24);
            this.cbNombreTurno.TabIndex = 4;
            // 
            // cbEstudiante
            // 
            this.cbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudiante.Location = new System.Drawing.Point(97, 86);
            this.cbEstudiante.Name = "cbEstudiante";
            this.cbEstudiante.Size = new System.Drawing.Size(120, 24);
            this.cbEstudiante.TabIndex = 6;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(17, 29);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 16);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(17, 59);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(45, 16);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Turno:";
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Location = new System.Drawing.Point(17, 89);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(73, 16);
            this.lblEstudiante.TabIndex = 5;
            this.lblEstudiante.Text = "Estudiante:";
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnInsertar);
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnEliminar);
            this.grpAcciones.Location = new System.Drawing.Point(11, 193);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(310, 59);
            this.grpAcciones.TabIndex = 11;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "ACCIONES";
            // 
            // grpInformacionAdicional
            // 
            this.grpInformacionAdicional.Controls.Add(this.cbNombreTurno);
            this.grpInformacionAdicional.Controls.Add(this.cbEstudiante);
            this.grpInformacionAdicional.Controls.Add(this.lblEstudiante);
            this.grpInformacionAdicional.Controls.Add(this.lblId);
            this.grpInformacionAdicional.Controls.Add(this.lblNombre);
            this.grpInformacionAdicional.Controls.Add(this.txtId);
            this.grpInformacionAdicional.Location = new System.Drawing.Point(11, 47);
            this.grpInformacionAdicional.Name = "grpInformacionAdicional";
            this.grpInformacionAdicional.Size = new System.Drawing.Size(233, 128);
            this.grpInformacionAdicional.TabIndex = 12;
            this.grpInformacionAdicional.TabStop = false;
            // 
            // UcTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpInformacionAdicional);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvTurnos);
            this.Name = "UcTurnos";
            this.Size = new System.Drawing.Size(893, 273);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            this.grpInformacionAdicional.ResumeLayout(false);
            this.grpInformacionAdicional.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.GroupBox grpInformacionAdicional;
    }
}