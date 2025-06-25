namespace G1asistenciaEC
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.login = new System.Windows.Forms.Button();
            this.titulo_login = new System.Windows.Forms.Label();
            this.usuario_login = new System.Windows.Forms.Label();
            this.contrasenia_login = new System.Windows.Forms.Label();
            this.campo_usuario = new System.Windows.Forms.TextBox();
            this.campo_contrasenia = new System.Windows.Forms.TextBox();
            this.checkBoxMostrar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.Color.Navy;
            this.login.Location = new System.Drawing.Point(236, 162);
            this.login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(170, 32);
            this.login.TabIndex = 0;
            this.login.Text = "INICIAR SESION";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.button1_Click);
            // 
            // titulo_login
            // 
            this.titulo_login.AutoSize = true;
            this.titulo_login.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titulo_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo_login.ForeColor = System.Drawing.Color.Maroon;
            this.titulo_login.Location = new System.Drawing.Point(16, 21);
            this.titulo_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titulo_login.Name = "titulo_login";
            this.titulo_login.Size = new System.Drawing.Size(601, 29);
            this.titulo_login.TabIndex = 1;
            this.titulo_login.Text = "GESTION ESCOLAR DE ASISTENCIA: ACADEMIX";
            // 
            // usuario_login
            // 
            this.usuario_login.AutoSize = true;
            this.usuario_login.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.usuario_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario_login.Location = new System.Drawing.Point(120, 80);
            this.usuario_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usuario_login.Name = "usuario_login";
            this.usuario_login.Size = new System.Drawing.Size(112, 24);
            this.usuario_login.TabIndex = 2;
            this.usuario_login.Text = "USUARIO :";
            // 
            // contrasenia_login
            // 
            this.contrasenia_login.AutoSize = true;
            this.contrasenia_login.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contrasenia_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrasenia_login.Location = new System.Drawing.Point(73, 119);
            this.contrasenia_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.contrasenia_login.Name = "contrasenia_login";
            this.contrasenia_login.Size = new System.Drawing.Size(164, 24);
            this.contrasenia_login.TabIndex = 3;
            this.contrasenia_login.Text = "CONTRASEÑA :";
            // 
            // campo_usuario
            // 
            this.campo_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campo_usuario.Location = new System.Drawing.Point(236, 80);
            this.campo_usuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.campo_usuario.Name = "campo_usuario";
            this.campo_usuario.Size = new System.Drawing.Size(170, 28);
            this.campo_usuario.TabIndex = 4;
            // 
            // campo_contrasenia
            // 
            this.campo_contrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campo_contrasenia.Location = new System.Drawing.Point(236, 119);
            this.campo_contrasenia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.campo_contrasenia.Name = "campo_contrasenia";
            this.campo_contrasenia.Size = new System.Drawing.Size(170, 28);
            this.campo_contrasenia.TabIndex = 5;
            this.campo_contrasenia.UseSystemPasswordChar = true;
            // 
            // checkBoxMostrar
            // 
            this.checkBoxMostrar.AutoSize = true;
            this.checkBoxMostrar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMostrar.Location = new System.Drawing.Point(420, 119);
            this.checkBoxMostrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxMostrar.Name = "checkBoxMostrar";
            this.checkBoxMostrar.Size = new System.Drawing.Size(163, 24);
            this.checkBoxMostrar.TabIndex = 6;
            this.checkBoxMostrar.Text = "Mostrar contraseña";
            this.checkBoxMostrar.UseVisualStyleBackColor = false;
            this.checkBoxMostrar.CheckedChanged += new System.EventHandler(this.checkBoxMostrar_CheckedChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(626, 201);
            this.Controls.Add(this.checkBoxMostrar);
            this.Controls.Add(this.campo_usuario);
            this.Controls.Add(this.campo_contrasenia);
            this.Controls.Add(this.titulo_login);
            this.Controls.Add(this.usuario_login);
            this.Controls.Add(this.contrasenia_login);
            this.Controls.Add(this.login);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label titulo_login;
        private System.Windows.Forms.Label usuario_login;
        private System.Windows.Forms.Label contrasenia_login;
        private System.Windows.Forms.TextBox campo_usuario;
        private System.Windows.Forms.TextBox campo_contrasenia;
        private System.Windows.Forms.CheckBox checkBoxMostrar;
    }
}