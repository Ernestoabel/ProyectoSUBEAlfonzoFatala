namespace ProyectoSUBEAlfonzoFatala
{
    partial class LoguinPadre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoguinPadre));
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            panel1 = new Panel();
            lblLoguin = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPassword.Location = new Point(288, 125);
            lblPassword.Name = "lblPassword";
            lblPassword.RightToLeft = RightToLeft.Yes;
            lblPassword.Size = new Size(82, 21);
            lblPassword.TabIndex = 13;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(376, 125);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(235, 29);
            txtPassword.TabIndex = 12;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(288, 68);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.RightToLeft = RightToLeft.Yes;
            lblUsuario.Size = new Size(40, 21);
            lblUsuario.TabIndex = 11;
            lblUsuario.Text = "DNI";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(376, 68);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(235, 29);
            txtUsuario.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(lblLoguin);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 330);
            panel1.TabIndex = 9;
            // 
            // lblLoguin
            // 
            lblLoguin.AutoSize = true;
            lblLoguin.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoguin.Location = new Point(38, 22);
            lblLoguin.Name = "lblLoguin";
            lblLoguin.Size = new Size(123, 45);
            lblLoguin.TabIndex = 1;
            lblLoguin.Text = "Loguin";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(171, 201);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LoguinPadre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(720, 330);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoguinPadre";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoguinPadre";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPassword;
        public TextBox txtPassword;
        private Label lblUsuario;
        public TextBox txtUsuario;
        private Panel panel1;
        private Label lblLoguin;
        private PictureBox pictureBox1;
    }
}