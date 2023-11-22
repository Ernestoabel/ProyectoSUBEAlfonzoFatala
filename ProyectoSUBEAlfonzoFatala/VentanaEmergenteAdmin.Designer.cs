namespace ProyectoSUBEAlfonzoFatala
{
    partial class VentanaEmergenteAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaEmergenteAdmin));
            lblTitulo = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            lblUsuario = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(45, 75);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "¿Desea Modificar la Clave";
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.OliveDrab;
            btnConfirmar.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(45, 197);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(117, 38);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Firebrick;
            btnCancelar.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(178, 197);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 38);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.FlatStyle = FlatStyle.Flat;
            lblUsuario.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.ForeColor = SystemColors.ControlLightLight;
            lblUsuario.Location = new Point(98, 141);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(144, 19);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Catriel Alfonso";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(358, 61);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(132, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(82, 61);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // VentanaEmergenteAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
            ClientSize = new Size(358, 271);
            ControlBox = false;
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblUsuario);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentanaEmergenteAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VentanaEmergenteAdmin";
            Load += VentanaEmergenteAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblUsuario;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}