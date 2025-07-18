﻿using G1asistenciaEC.modelo;
using G1asistenciaEC.negocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace G1asistenciaEC
{
    public partial class FormApoderado : Form
    {
        private apoderadoM _apoderado;
        private apoderadoN _negocio;

        public FormApoderado(string usuario)
        {
            InitializeComponent();
            this.Size = new Size(769, 500);
            this.MaximumSize = new Size(769, 500);
            this.MinimumSize = new Size(769, 500);
            this.MaximizeBox = false;
            this.Text = "Panel del Apoderado";

            _negocio = new apoderadoN();
            _apoderado = _negocio.ObtenerInformacionApoderado(usuario);

            lblNombreApoderado.Text = $"{_apoderado.Nombres} {_apoderado.ApellidoPaterno} {_apoderado.ApellidoMaterno}";

            btnBuscar.Click += BtnBuscar_Click;
            btnInfoPersonal.Click += BtnInfoPersonal_Click;
            btnCerrarSesion.Click += BtnCerrarSesion_Click;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable asistencias = _negocio.ObtenerAsistencias(_apoderado.Id);
                dgvHistorial.DataSource = asistencias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar asistencias: {ex.Message}");
            }
        }

        private void BtnInfoPersonal_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Información del Apoderado:\n\n" +
                            $"Nombre: {_apoderado.Nombres} {_apoderado.ApellidoPaterno} {_apoderado.ApellidoMaterno}\n" +
                            $"DNI: {_apoderado.Dni}\n" +
                            $"Correo: {_apoderado.Correo}\n" +
                            $"Teléfono: {_apoderado.Telefono}\n" +
                            $"Estado: {_apoderado.Estado}");
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
