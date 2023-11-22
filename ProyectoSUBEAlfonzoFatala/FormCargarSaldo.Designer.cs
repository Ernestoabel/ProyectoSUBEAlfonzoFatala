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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargarSaldo));
            btnCargar = new Button();
            btnVerSaldo = new Button();
            lblCargarSaldo = new Label();
            lblVerSaldo = new Label();
            pbTarjeta = new PictureBox();
            lblNombre = new Label();
            lblApellido = new Label();
            lblIdTarjeta = new Label();
            lblDni = new Label();
            lblSaldo = new Label();
            pictureBox1 = new PictureBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pbTarjeta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.White;
            btnCargar.BackgroundImageLayout = ImageLayout.Zoom;
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCargar.ForeColor = Color.FromArgb(0, 64, 64);
            btnCargar.Image = (Image)resources.GetObject("btnCargar.Image");
            btnCargar.Location = new Point(50, 165);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(164, 60);
            btnCargar.TabIndex = 0;
            btnCargar.Text = "Cargar";
            btnCargar.TextImageRelation = TextImageRelation.TextBeforeImage;
            toolTip1.SetToolTip(btnCargar, "Acredite el saldo deseado, ingresando el monto y su pin de sube.");
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnVerSaldo
            // 
            btnVerSaldo.BackColor = Color.White;
            btnVerSaldo.BackgroundImageLayout = ImageLayout.Stretch;
            btnVerSaldo.FlatStyle = FlatStyle.Flat;
            btnVerSaldo.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnVerSaldo.ForeColor = Color.FromArgb(0, 64, 64);
            btnVerSaldo.Image = (Image)resources.GetObject("btnVerSaldo.Image");
            btnVerSaldo.Location = new Point(50, 285);
            btnVerSaldo.Name = "btnVerSaldo";
            btnVerSaldo.Size = new Size(164, 60);
            btnVerSaldo.TabIndex = 1;
            btnVerSaldo.Text = "  Ver Saldo";
            btnVerSaldo.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnVerSaldo, "Podra ver el saldo actual de su tarjeta.\r\n");
            btnVerSaldo.UseVisualStyleBackColor = false;
            btnVerSaldo.Click += btnVerSaldo_Click;
            // 
            // lblCargarSaldo
            // 
            lblCargarSaldo.AutoSize = true;
            lblCargarSaldo.BackColor = Color.Transparent;
            lblCargarSaldo.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblCargarSaldo.ForeColor = Color.White;
            lblCargarSaldo.Location = new Point(93, 228);
            lblCargarSaldo.Name = "lblCargarSaldo";
            lblCargarSaldo.Size = new Size(82, 18);
            lblCargarSaldo.TabIndex = 2;
            lblCargarSaldo.Text = "Cargar Saldo";
            // 
            // lblVerSaldo
            // 
            lblVerSaldo.AutoSize = true;
            lblVerSaldo.BackColor = Color.Transparent;
            lblVerSaldo.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblVerSaldo.ForeColor = Color.White;
            lblVerSaldo.Location = new Point(102, 348);
            lblVerSaldo.Name = "lblVerSaldo";
            lblVerSaldo.Size = new Size(61, 18);
            lblVerSaldo.TabIndex = 3;
            lblVerSaldo.Text = "Ver Saldo";
            // 
            // pbTarjeta
            // 
            pbTarjeta.BackColor = Color.Transparent;
            pbTarjeta.Image = (Image)resources.GetObject("pbTarjeta.Image");
            pbTarjeta.Location = new Point(337, 108);
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
            lblNombre.Location = new Point(380, 251);
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
            lblApellido.Location = new Point(482, 251);
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
            lblIdTarjeta.Location = new Point(380, 311);
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
            lblDni.Location = new Point(380, 285);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(99, 19);
            lblDni.TabIndex = 11;
            lblDni.Text = "xx xxx xxx";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.BackColor = Color.FromArgb(4, 124, 179);
            lblSaldo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblSaldo.ForeColor = SystemColors.ActiveCaption;
            lblSaldo.Location = new Point(550, 146);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(0, 30);
            lblSaldo.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(782, 98);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // FormCargarSaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(lblSaldo);
            Controls.Add(lblDni);
            Controls.Add(lblIdTarjeta);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(pbTarjeta);
            Controls.Add(lblVerSaldo);
            Controls.Add(lblCargarSaldo);
            Controls.Add(btnVerSaldo);
            Controls.Add(btnCargar);
            Name = "FormCargarSaldo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormCargarSaldo";
            Load += FormCargarSaldo_Load;
            ((System.ComponentModel.ISupportInitialize)pbTarjeta).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargar;
        private Button btnVerSaldo;
        private Label lblCargarSaldo;
        private Label lblVerSaldo;
        private PictureBox pbTarjeta;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblIdTarjeta;
        private Label lblDni;
        private Label lblSaldo;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
    }
}