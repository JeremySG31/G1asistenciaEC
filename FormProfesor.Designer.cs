public partial class FormProfesor
{
    // Agregar los nuevos controles
    private System.Windows.Forms.TabPage tabHistorial;
    private System.Windows.Forms.DataGridView dgvHistorial;
    private System.Windows.Forms.GroupBox groupBoxFiltrosHistorial;
    private System.Windows.Forms.DateTimePicker dtpFechaInicio;
    private System.Windows.Forms.DateTimePicker dtpFechaFin;
    private System.Windows.Forms.Label lblFechaInicio;
    private System.Windows.Forms.Label lblFechaFin;
    private System.Windows.Forms.Button btnFiltrar;

    private void InitializeComponent()
    {
        // ... código existente ...

        this.tabHistorial = new System.Windows.Forms.TabPage();
        this.dgvHistorial = new System.Windows.Forms.DataGridView();
        this.groupBoxFiltrosHistorial = new System.Windows.Forms.GroupBox();
        this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
        this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
        this.lblFechaInicio = new System.Windows.Forms.Label();
        this.lblFechaFin = new System.Windows.Forms.Label();
        this.btnFiltrar = new System.Windows.Forms.Button();

        // ... código existente del tabControl ...
        this.tabControl.Controls.Add(this.tabHistorial);

        // Configuración de la pestaña Historial
        this.tabHistorial.Controls.Add(this.groupBoxFiltrosHistorial);
        this.tabHistorial.Controls.Add(this.dgvHistorial);
        this.tabHistorial.Location = new System.Drawing.Point(4, 25);
        this.tabHistorial.Name = "tabHistorial";
        this.tabHistorial.Size = new System.Drawing.Size(852, 311);
        this.tabHistorial.TabIndex = 1;
        this.tabHistorial.Text = "Historial de Asistencias";
        this.tabHistorial.UseVisualStyleBackColor = true;

        // Configuración del GroupBox de filtros
        this.groupBoxFiltrosHistorial.Controls.Add(this.lblFechaInicio);
        this.groupBoxFiltrosHistorial.Controls.Add(this.lblFechaFin);
        this.groupBoxFiltrosHistorial.Controls.Add(this.dtpFechaInicio);
        this.groupBoxFiltrosHistorial.Controls.Add(this.dtpFechaFin);
        this.groupBoxFiltrosHistorial.Controls.Add(this.btnFiltrar);
        this.groupBoxFiltrosHistorial.Location = new System.Drawing.Point(20, 20);
        this.groupBoxFiltrosHistorial.Name = "groupBoxFiltrosHistorial";
        this.groupBoxFiltrosHistorial.Size = new System.Drawing.Size(800, 100);
        this.groupBoxFiltrosHistorial.TabIndex = 0;
        this.groupBoxFiltrosHistorial.TabStop = false;
        this.groupBoxFiltrosHistorial.Text = "Filtros de Historial";

        // Labels
        this.lblFechaInicio.AutoSize = true;
        this.lblFechaInicio.Location = new System.Drawing.Point(20, 30);
        this.lblFechaInicio.Name = "lblFechaInicio";
        this.lblFechaInicio.Size = new System.Drawing.Size(82, 16);
        this.lblFechaInicio.Text = "Fecha Inicio:";

        this.lblFechaFin.AutoSize = true;
        this.lblFechaFin.Location = new System.Drawing.Point(300, 30);
        this.lblFechaFin.Name = "lblFechaFin";
        this.lblFechaFin.Size = new System.Drawing.Size(69, 16);
        this.lblFechaFin.Text = "Fecha Fin:";

        // DateTimePickers
        this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpFechaInicio.Location = new System.Drawing.Point(110, 28);
        this.dtpFechaInicio.Name = "dtpFechaInicio";
        this.dtpFechaInicio.Size = new System.Drawing.Size(150, 22);

        this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpFechaFin.Location = new System.Drawing.Point(380, 28);
        this.dtpFechaFin.Name = "dtpFechaFin";
        this.dtpFechaFin.Size = new System.Drawing.Size(150, 22);

        // Botón Filtrar
        this.btnFiltrar.Location = new System.Drawing.Point(580, 25);
        this.btnFiltrar.Name = "btnFiltrar";
        this.btnFiltrar.Size = new System.Drawing.Size(100, 30);
        this.btnFiltrar.TabIndex = 4;
        this.btnFiltrar.Text = "Filtrar";
        this.btnFiltrar.UseVisualStyleBackColor = true;

        // DataGridView Historial
        this.dgvHistorial.AllowUserToAddRows = false;
        this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvHistorial.Location = new System.Drawing.Point(20, 150);
        this.dgvHistorial.Name = "dgvHistorial";
        this.dgvHistorial.RowHeadersWidth = 51;
        this.dgvHistorial.Size = new System.Drawing.Size(800, 200);
        this.dgvHistorial.TabIndex = 1;

        // ... resto del código existente ...
    }
}