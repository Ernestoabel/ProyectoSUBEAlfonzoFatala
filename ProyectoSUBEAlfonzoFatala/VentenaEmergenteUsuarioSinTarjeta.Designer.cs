namespace ProyectoSUBEAlfonzoFatala
{
    partial class VentenaEmergenteUsuarioSinTarjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentenaEmergenteUsuarioSinTarjeta));
            lblTitulo = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblSolucion = new Label();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("HP Simplified Hans", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.ForeColor = SystemColors.ControlText;
            lblTitulo.Location = new Point(62, 113);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(299, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Usuario Sin Tarjeta";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(143, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(132, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Location = new Point(3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(416, 79);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // lblSolucion
            // 
            lblSolucion.AutoSize = true;
            lblSolucion.Font = new Font("HP Simplified Hans", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            lblSolucion.ForeColor = SystemColors.ControlText;
            lblSolucion.Location = new Point(88, 169);
            lblSolucion.Name = "lblSolucion";
            lblSolucion.Size = new Size(246, 39);
            lblSolucion.TabIndex = 4;
            lblSolucion.Text = "El usuario no tiene una tarjeta a su nombre,\r\n\r\npuede Comprarla yendo a Mi Sube/Comprarla.";
            lblSolucion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.DarkRed;
            btnOk.ForeColor = SystemColors.ControlLight;
            btnOk.Location = new Point(160, 232);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(91, 28);
            btnOk.TabIndex = 5;
            btnOk.Text = "ok";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // VentenaEmergenteUsuarioSinTarjeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 272);
            ControlBox = false;
            Controls.Add(btnOk);
            Controls.Add(lblSolucion);
            Controls.Add(pictureBox1);
            Controls.Add(lblTitulo);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentenaEmergenteUsuarioSinTarjeta";
            Text = "VentenaEmergenteUsuarioSinTarjeta";
            Load += VentenaEmergenteUsuarioSinTarjeta_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblSolucion;
        private Button btnOk;
    }
}