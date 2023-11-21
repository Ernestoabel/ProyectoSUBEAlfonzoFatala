namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormularioLoguin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioLoguin));
            btnIngresar = new Button();
            btnCancelar = new Button();
            btnAdministrador = new Button();
            btnAlta = new Button();
            lblError = new Label();
            btnUsuarioArgentino = new Button();
            btnUsuarioExtranjero = new Button();
            pbAdmin = new PictureBox();
            pbNacional = new PictureBox();
            pbExtranjero = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbAdmin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNacional).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbExtranjero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(376, 133);
            txtPassword.PlaceholderText = "Ingrese su Contraseña";
            txtPassword.Size = new Size(264, 29);
            txtPassword.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(376, 87);
            txtUsuario.PlaceholderText = "Ingrese su Documento";
            txtUsuario.Size = new Size(264, 29);
            txtUsuario.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.MidnightBlue;
            btnIngresar.FlatStyle = FlatStyle.Popup;
            btnIngresar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(297, 178);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(171, 42);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.OrangeRed;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(297, 228);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(343, 42);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAdministrador
            // 
            btnAdministrador.BackColor = Color.LightSlateGray;
            btnAdministrador.FlatStyle = FlatStyle.Popup;
            btnAdministrador.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdministrador.ForeColor = SystemColors.Window;
            btnAdministrador.Location = new Point(297, 287);
            btnAdministrador.Name = "btnAdministrador";
            btnAdministrador.Size = new Size(289, 40);
            btnAdministrador.TabIndex = 6;
            btnAdministrador.Text = "Usuario administrador";
            btnAdministrador.UseVisualStyleBackColor = false;
            btnAdministrador.Click += btnAdministrador_Click;
            // 
            // btnAlta
            // 
            btnAlta.BackColor = Color.MidnightBlue;
            btnAlta.FlatStyle = FlatStyle.Popup;
            btnAlta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlta.ForeColor = Color.White;
            btnAlta.Location = new Point(474, 178);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(166, 42);
            btnAlta.TabIndex = 4;
            btnAlta.Text = "Registrarse";
            btnAlta.UseVisualStyleBackColor = false;
            btnAlta.Click += btnAlta_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(376, 157);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 18;
            // 
            // btnUsuarioArgentino
            // 
            btnUsuarioArgentino.BackColor = Color.LightSlateGray;
            btnUsuarioArgentino.BackgroundImageLayout = ImageLayout.Center;
            btnUsuarioArgentino.FlatStyle = FlatStyle.Popup;
            btnUsuarioArgentino.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsuarioArgentino.ForeColor = SystemColors.Info;
            btnUsuarioArgentino.Location = new Point(297, 333);
            btnUsuarioArgentino.Name = "btnUsuarioArgentino";
            btnUsuarioArgentino.Size = new Size(289, 36);
            btnUsuarioArgentino.TabIndex = 7;
            btnUsuarioArgentino.Text = "Usuario nacional";
            btnUsuarioArgentino.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarioArgentino.UseVisualStyleBackColor = false;
            btnUsuarioArgentino.Click += btnUsuarioArgentino_Click;
            // 
            // btnUsuarioExtranjero
            // 
            btnUsuarioExtranjero.BackColor = Color.LightSlateGray;
            btnUsuarioExtranjero.BackgroundImageLayout = ImageLayout.Center;
            btnUsuarioExtranjero.FlatStyle = FlatStyle.Popup;
            btnUsuarioExtranjero.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsuarioExtranjero.ForeColor = SystemColors.Info;
            btnUsuarioExtranjero.Location = new Point(297, 375);
            btnUsuarioExtranjero.Name = "btnUsuarioExtranjero";
            btnUsuarioExtranjero.Size = new Size(289, 38);
            btnUsuarioExtranjero.TabIndex = 8;
            btnUsuarioExtranjero.Text = "Usuario extranjero";
            btnUsuarioExtranjero.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarioExtranjero.UseVisualStyleBackColor = false;
            btnUsuarioExtranjero.Click += btnUsuarioExtranjero_Click;
            // 
            // pbAdmin
            // 
            pbAdmin.BackColor = Color.Transparent;
            pbAdmin.Image = (Image)resources.GetObject("pbAdmin.Image");
            pbAdmin.Location = new Point(592, 288);
            pbAdmin.Name = "pbAdmin";
            pbAdmin.Size = new Size(48, 39);
            pbAdmin.SizeMode = PictureBoxSizeMode.CenterImage;
            pbAdmin.TabIndex = 21;
            pbAdmin.TabStop = false;
            // 
            // pbNacional
            // 
            pbNacional.BackColor = Color.Transparent;
            pbNacional.Image = (Image)resources.GetObject("pbNacional.Image");
            pbNacional.Location = new Point(592, 333);
            pbNacional.Name = "pbNacional";
            pbNacional.Size = new Size(48, 39);
            pbNacional.SizeMode = PictureBoxSizeMode.CenterImage;
            pbNacional.TabIndex = 22;
            pbNacional.TabStop = false;
            // 
            // pbExtranjero
            // 
            pbExtranjero.BackColor = Color.Transparent;
            pbExtranjero.Image = (Image)resources.GetObject("pbExtranjero.Image");
            pbExtranjero.Location = new Point(592, 374);
            pbExtranjero.Name = "pbExtranjero";
            pbExtranjero.Size = new Size(48, 39);
            pbExtranjero.SizeMode = PictureBoxSizeMode.Zoom;
            pbExtranjero.TabIndex = 23;
            pbExtranjero.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(413, 12);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(113, 60);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 24;
            pictureBox4.TabStop = false;
            // 
            // FormularioLoguin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(739, 440);
            Controls.Add(pictureBox4);
            Controls.Add(pbExtranjero);
            Controls.Add(pbNacional);
            Controls.Add(pbAdmin);
            Controls.Add(btnUsuarioExtranjero);
            Controls.Add(btnUsuarioArgentino);
            Controls.Add(lblError);
            Controls.Add(btnAlta);
            Controls.Add(btnAdministrador);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            ForeColor = SystemColors.ControlText;
            Name = "FormularioLoguin";
            Text = "FormularioLoguin";
            Controls.SetChildIndex(txtUsuario, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(btnIngresar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(btnAdministrador, 0);
            Controls.SetChildIndex(btnAlta, 0);
            Controls.SetChildIndex(lblError, 0);
            Controls.SetChildIndex(btnUsuarioArgentino, 0);
            Controls.SetChildIndex(btnUsuarioExtranjero, 0);
            Controls.SetChildIndex(pbAdmin, 0);
            Controls.SetChildIndex(pbNacional, 0);
            Controls.SetChildIndex(pbExtranjero, 0);
            Controls.SetChildIndex(pictureBox4, 0);
            ((System.ComponentModel.ISupportInitialize)pbAdmin).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNacional).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbExtranjero).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIngresar;
        private Button btnCancelar;
        private Button btnAdministrador;
        private Button btnAlta;
        private Label lblError;
        private Button btnUsuarioArgentino;
        private Button btnUsuarioExtranjero;
        private PictureBox pbAdmin;
        private PictureBox pbNacional;
        private PictureBox pbExtranjero;
        private PictureBox pictureBox4;
    }
}