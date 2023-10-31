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
            SuspendLayout();
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.White;
            btnCargar.BackgroundImage = (Image)resources.GetObject("btnCargar.BackgroundImage");
            btnCargar.BackgroundImageLayout = ImageLayout.Stretch;
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Location = new Point(83, 136);
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
            btnVerSaldo.Location = new Point(83, 273);
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
            lblCargarSaldo.Location = new Point(83, 208);
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
            lblVerSaldo.Location = new Point(83, 345);
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
            btnSalir.Location = new Point(611, 273);
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
            lblSalir.Location = new Point(629, 345);
            lblSalir.Name = "lblSalir";
            lblSalir.Size = new Size(50, 24);
            lblSalir.TabIndex = 5;
            lblSalir.Text = "Salir";
            // 
            // FormCargarSaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(lblSalir);
            Controls.Add(btnSalir);
            Controls.Add(lblVerSaldo);
            Controls.Add(lblCargarSaldo);
            Controls.Add(btnVerSaldo);
            Controls.Add(btnCargar);
            Name = "FormCargarSaldo";
            Text = "FormCargarSaldo";
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
    }
}