namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormRegistro
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
            lblRegistrar = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblNumTarjeta = new Label();
            txtNumTarjeta = new TextBox();
            btnContinuar = new Button();
            pbrPasos = new ProgressBar();
            lblPaso1 = new Label();
            SuspendLayout();
            // 
            // lblRegistrar
            // 
            lblRegistrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRegistrar.AutoSize = true;
            lblRegistrar.Font = new Font("Trebuchet MS", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblRegistrar.ForeColor = SystemColors.ControlLightLight;
            lblRegistrar.Location = new Point(26, 22);
            lblRegistrar.Name = "lblRegistrar";
            lblRegistrar.Size = new Size(178, 43);
            lblRegistrar.TabIndex = 0;
            lblRegistrar.Text = "Regístrate";
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(26, 95);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 16);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(39, 114);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(182, 23);
            txtNombre.TabIndex = 2;
            // 
            // lblApellido
            // 
            lblApellido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(26, 155);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(58, 16);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Location = new Point(39, 174);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(182, 23);
            txtApellido.TabIndex = 4;
            // 
            // lblDni
            // 
            lblDni.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblDni.ForeColor = Color.White;
            lblDni.Location = new Point(26, 214);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(29, 16);
            lblDni.TabIndex = 5;
            lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            txtDni.BorderStyle = BorderStyle.FixedSingle;
            txtDni.Location = new Point(38, 233);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(182, 23);
            txtDni.TabIndex = 6;
            // 
            // lblNumTarjeta
            // 
            lblNumTarjeta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNumTarjeta.AutoSize = true;
            lblNumTarjeta.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumTarjeta.ForeColor = Color.White;
            lblNumTarjeta.Location = new Point(26, 270);
            lblNumTarjeta.Name = "lblNumTarjeta";
            lblNumTarjeta.Size = new Size(92, 16);
            lblNumTarjeta.TabIndex = 7;
            lblNumTarjeta.Text = "N° de tarjeta";
            // 
            // txtNumTarjeta
            // 
            txtNumTarjeta.BorderStyle = BorderStyle.FixedSingle;
            txtNumTarjeta.Location = new Point(38, 289);
            txtNumTarjeta.Name = "txtNumTarjeta";
            txtNumTarjeta.Size = new Size(183, 23);
            txtNumTarjeta.TabIndex = 8;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.MediumBlue;
            btnContinuar.FlatStyle = FlatStyle.Flat;
            btnContinuar.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContinuar.ForeColor = SystemColors.ControlLightLight;
            btnContinuar.Location = new Point(39, 357);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(183, 36);
            btnContinuar.TabIndex = 9;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // pbrPasos
            // 
            pbrPasos.BackColor = SystemColors.ButtonFace;
            pbrPasos.Location = new Point(400, 44);
            pbrPasos.Name = "pbrPasos";
            pbrPasos.Size = new Size(163, 20);
            pbrPasos.Step = 50;
            pbrPasos.TabIndex = 10;
            // 
            // lblPaso1
            // 
            lblPaso1.AutoSize = true;
            lblPaso1.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPaso1.ForeColor = Color.White;
            lblPaso1.Location = new Point(515, 22);
            lblPaso1.Name = "lblPaso1";
            lblPaso1.Size = new Size(43, 18);
            lblPaso1.TabIndex = 11;
            lblPaso1.Text = "Paso 1";
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(596, 435);
            Controls.Add(lblPaso1);
            Controls.Add(pbrPasos);
            Controls.Add(btnContinuar);
            Controls.Add(txtNumTarjeta);
            Controls.Add(lblNumTarjeta);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblRegistrar);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "FormRegistro";
            Text = "FormRegistro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegistrar;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblNumTarjeta;
        private TextBox txtNumTarjeta;
        private Button btnContinuar;
        private ProgressBar pbrPasos;
        private Label lblPaso1;
    }
}