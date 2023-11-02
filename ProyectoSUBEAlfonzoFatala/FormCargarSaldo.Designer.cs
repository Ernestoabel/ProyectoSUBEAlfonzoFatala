namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormCargarSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargarSaldo));
            btnCargar = new Button();
            btnVerSaldo = new Button();
            lblCargarSaldo = new Label();
            lblVerSaldo = new Label();
            btnSalir = new Button();
            lblSalir = new Label();
            pbTarjeta = new PictureBox();
            lblNombre = new Label();
            lblApellido = new Label();
            lblIdTarjeta = new Label();
            lblDni = new Label();
            ((System.ComponentModel.ISupportInitialize)pbTarjeta).BeginInit();
            SuspendLayout();
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.White;
            btnCargar.BackgroundImage = (Image)resources.GetObject("btnCargar.BackgroundImage");
            btnCargar.BackgroundImageLayout = ImageLayout.Stretch;
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Location = new Point(83, 138);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(68, 60);
            btnCargar.TabIndex = 0;
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnVerSaldo
            // 
            btnVerSaldo.BackColor = Color.White;
            btnVerSaldo.BackgroundImage = (Image)resources.GetObject("btnVerSaldo.BackgroundImage");
            btnVerSaldo.BackgroundImageLayout = ImageLayout.Stretch;
            btnVerSaldo.FlatStyle = FlatStyle.Flat;
            btnVerSaldo.Location = new Point(83, 248);
            btnVerSaldo.Name = "btnVerSaldo";
            btnVerSaldo.Size = new Size(68, 60);
            btnVerSaldo.TabIndex = 1;
            btnVerSaldo.UseVisualStyleBackColor = false;
            btnVerSaldo.Click += btnVerSaldo_Click;
            // 
            // lblCargarSaldo
            // 
            lblCargarSaldo.AutoSize = true;
            lblCargarSaldo.BackColor = Color.Transparent;
            lblCargarSaldo.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCargarSaldo.ForeColor = Color.White;
            lblCargarSaldo.Location = new Point(74, 205);
            lblCargarSaldo.Name = "lblCargarSaldo";
            lblCargarSaldo.Size = new Size(122, 24);
            lblCargarSaldo.TabIndex = 2;
            lblCargarSaldo.Text = "Cargar Saldo";
            // 
            // lblVerSaldo
            // 
            lblVerSaldo.AutoSize = true;
            lblVerSaldo.BackColor = Color.Transparent;
            lblVerSaldo.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblVerSaldo.ForeColor = Color.White;
            lblVerSaldo.Location = new Point(74, 311);
            lblVerSaldo.Name = "lblVerSaldo";
            lblVerSaldo.Size = new Size(94, 24);
            lblVerSaldo.TabIndex = 3;
            lblVerSaldo.Text = "Ver Saldo";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.White;
            btnSalir.BackgroundImage = (Image)resources.GetObject("btnSalir.BackgroundImage");
            btnSalir.BackgroundImageLayout = ImageLayout.Stretch;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(83, 35);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(68, 60);
            btnSalir.TabIndex = 4;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblSalir
            // 
            lblSalir.AutoSize = true;
            lblSalir.BackColor = Color.Transparent;
            lblSalir.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSalir.ForeColor = Color.White;
            lblSalir.Location = new Point(74, 98);
            lblSalir.Name = "lblSalir";
            lblSalir.Size = new Size(50, 24);
            lblSalir.TabIndex = 5;
            lblSalir.Text = "Salir";
            // 
            // pbTarjeta
            // 
            pbTarjeta.BackColor = Color.Transparent;
            pbTarjeta.Image = (Image)resources.GetObject("pbTarjeta.Image");
            pbTarjeta.Location = new Point(367, 12);
            pbTarjeta.Name = "pbTarjeta";
            pbTarjeta.Size = new Size(365, 258);
            pbTarjeta.SizeMode = PictureBoxSizeMode.Zoom;
            pbTarjeta.TabIndex = 6;
            pbTarjeta.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.FromArgb(4, 124, 179);
            lblNombre.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(397, 145);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(86, 23);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.BackColor = Color.FromArgb(4, 124, 179);
            lblApellido.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(499, 145);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(88, 23);
            lblApellido.TabIndex = 8;
            lblApellido.Text = "Apellido";
            // 
            // lblIdTarjeta
            // 
            lblIdTarjeta.AutoSize = true;
            lblIdTarjeta.BackColor = Color.FromArgb(4, 124, 179);
            lblIdTarjeta.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblIdTarjeta.ForeColor = Color.White;
            lblIdTarjeta.Location = new Point(397, 205);
            lblIdTarjeta.Name = "lblIdTarjeta";
            lblIdTarjeta.Size = new Size(48, 18);
            lblIdTarjeta.TabIndex = 10;
            lblIdTarjeta.Text = "0000";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.BackColor = Color.FromArgb(4, 124, 179);
            lblDni.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDni.ForeColor = Color.White;
            lblDni.Location = new Point(397, 179);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(99, 19);
            lblDni.TabIndex = 11;
            lblDni.Text = "xx xxx xxx";
            // 
            // FormCargarSaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(791, 424);
            ControlBox = false;
            Controls.Add(lblDni);
            Controls.Add(lblIdTarjeta);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(pbTarjeta);
            Controls.Add(lblSalir);
            Controls.Add(btnSalir);
            Controls.Add(lblVerSaldo);
            Controls.Add(lblCargarSaldo);
            Controls.Add(btnVerSaldo);
            Controls.Add(btnCargar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCargarSaldo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormCargarSaldo";
            Load += FormCargarSaldo_Load;
            ((System.ComponentModel.ISupportInitialize)pbTarjeta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargar;
        private Button btnVerSaldo;
        private Label lblCargarSaldo;
        private Label lblVerSaldo;
        private Button btnSalir;
        private Label lblSalir;
        private PictureBox pbTarjeta;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblIdTarjeta;
        private Label lblDni;
    }
}