namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormBajaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBajaUsuario));
            labelBajaUsuario = new Label();
            btnBajaTarjetaUsuario = new Button();
            lblMensaje = new Label();
            pbBajaTarjeta = new PictureBox();
            btnCorreo = new Button();
            txtDe = new TextBox();
            txtAsunto = new TextBox();
            txtPara = new TextBox();
            txtMensaje = new TextBox();
            lblDe = new Label();
            lblPara = new Label();
            lblAsunto = new Label();
            lblMsj = new Label();
            btnEnviarEmail = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pbBajaTarjeta).BeginInit();
            SuspendLayout();
            // 
            // labelBajaUsuario
            // 
            labelBajaUsuario.AutoSize = true;
            labelBajaUsuario.Font = new Font("Tahoma", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelBajaUsuario.ForeColor = SystemColors.ControlLightLight;
            labelBajaUsuario.Location = new Point(218, 202);
            labelBajaUsuario.Name = "labelBajaUsuario";
            labelBajaUsuario.Size = new Size(367, 35);
            labelBajaUsuario.TabIndex = 0;
            labelBajaUsuario.Text = "Solicitar Baja de Tarjeta";
            // 
            // btnBajaTarjetaUsuario
            // 
            btnBajaTarjetaUsuario.BackColor = Color.White;
            btnBajaTarjetaUsuario.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBajaTarjetaUsuario.ForeColor = Color.OliveDrab;
            btnBajaTarjetaUsuario.Image = (Image)resources.GetObject("btnBajaTarjetaUsuario.Image");
            btnBajaTarjetaUsuario.Location = new Point(59, 280);
            btnBajaTarjetaUsuario.Name = "btnBajaTarjetaUsuario";
            btnBajaTarjetaUsuario.Size = new Size(272, 65);
            btnBajaTarjetaUsuario.TabIndex = 6;
            btnBajaTarjetaUsuario.Text = "Mandar mensaje";
            btnBajaTarjetaUsuario.TextImageRelation = TextImageRelation.TextBeforeImage;
            toolTip1.SetToolTip(btnBajaTarjetaUsuario, "La solicitud de la baja de tarjeta Sube, se realizará mediante un *mensaje enviado al administrador de los usuarios. ");
            btnBajaTarjetaUsuario.UseVisualStyleBackColor = false;
            btnBajaTarjetaUsuario.Click += btnBajaTarjetaUsuario_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMensaje.Location = new Point(238, 237);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 21);
            lblMensaje.TabIndex = 2;
            // 
            // pbBajaTarjeta
            // 
            pbBajaTarjeta.BackgroundImageLayout = ImageLayout.None;
            pbBajaTarjeta.BorderStyle = BorderStyle.FixedSingle;
            pbBajaTarjeta.Image = (Image)resources.GetObject("pbBajaTarjeta.Image");
            pbBajaTarjeta.Location = new Point(12, 45);
            pbBajaTarjeta.Name = "pbBajaTarjeta";
            pbBajaTarjeta.Size = new Size(776, 144);
            pbBajaTarjeta.SizeMode = PictureBoxSizeMode.CenterImage;
            pbBajaTarjeta.TabIndex = 3;
            pbBajaTarjeta.TabStop = false;
            // 
            // btnCorreo
            // 
            btnCorreo.BackColor = Color.DarkOliveGreen;
            btnCorreo.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCorreo.ForeColor = SystemColors.ControlLightLight;
            btnCorreo.Image = (Image)resources.GetObject("btnCorreo.Image");
            btnCorreo.Location = new Point(59, 354);
            btnCorreo.Name = "btnCorreo";
            btnCorreo.Size = new Size(272, 65);
            btnCorreo.TabIndex = 7;
            btnCorreo.Text = "Enviar Correo";
            btnCorreo.TextImageRelation = TextImageRelation.TextBeforeImage;
            toolTip1.SetToolTip(btnCorreo, "Envia un correo detallando a la administración, para solucionar un error en específico.");
            btnCorreo.UseVisualStyleBackColor = false;
            btnCorreo.Click += btnCorreo_Click;
            // 
            // txtDe
            // 
            txtDe.Location = new Point(400, 275);
            txtDe.Name = "txtDe";
            txtDe.PlaceholderText = "ingrese su email";
            txtDe.Size = new Size(175, 23);
            txtDe.TabIndex = 1;
            txtDe.Visible = false;
            // 
            // txtAsunto
            // 
            txtAsunto.Location = new Point(400, 369);
            txtAsunto.Name = "txtAsunto";
            txtAsunto.PlaceholderText = "Ej: cambio tarjeta";
            txtAsunto.Size = new Size(175, 23);
            txtAsunto.TabIndex = 3;
            txtAsunto.Visible = false;
            // 
            // txtPara
            // 
            txtPara.Location = new Point(400, 322);
            txtPara.Name = "txtPara";
            txtPara.PlaceholderText = "vuelva a ingresar su mail";
            txtPara.Size = new Size(175, 23);
            txtPara.TabIndex = 2;
            txtPara.Visible = false;
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(590, 275);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.PlaceholderText = "comentarios al administrador";
            txtMensaje.Size = new Size(175, 116);
            txtMensaje.TabIndex = 4;
            txtMensaje.Visible = false;
            // 
            // lblDe
            // 
            lblDe.AutoSize = true;
            lblDe.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDe.ForeColor = SystemColors.ControlLightLight;
            lblDe.Location = new Point(400, 254);
            lblDe.Name = "lblDe";
            lblDe.Size = new Size(50, 18);
            lblDe.TabIndex = 10;
            lblDe.Text = "Correo:";
            lblDe.Visible = false;
            // 
            // lblPara
            // 
            lblPara.AutoSize = true;
            lblPara.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPara.ForeColor = SystemColors.ControlLightLight;
            lblPara.Location = new Point(400, 301);
            lblPara.Name = "lblPara";
            lblPara.Size = new Size(109, 18);
            lblPara.TabIndex = 11;
            lblPara.Text = "Confirmar Correo:";
            lblPara.Visible = false;
            // 
            // lblAsunto
            // 
            lblAsunto.AutoSize = true;
            lblAsunto.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblAsunto.ForeColor = SystemColors.ControlLightLight;
            lblAsunto.Location = new Point(400, 348);
            lblAsunto.Name = "lblAsunto";
            lblAsunto.Size = new Size(51, 18);
            lblAsunto.TabIndex = 12;
            lblAsunto.Text = "Asunto:";
            lblAsunto.Visible = false;
            // 
            // lblMsj
            // 
            lblMsj.AutoSize = true;
            lblMsj.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblMsj.ForeColor = SystemColors.ControlLightLight;
            lblMsj.Location = new Point(590, 254);
            lblMsj.Name = "lblMsj";
            lblMsj.Size = new Size(58, 18);
            lblMsj.TabIndex = 13;
            lblMsj.Text = "Mensaje:";
            lblMsj.Visible = false;
            // 
            // btnEnviarEmail
            // 
            btnEnviarEmail.BackColor = Color.DarkOliveGreen;
            btnEnviarEmail.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEnviarEmail.ForeColor = Color.Snow;
            btnEnviarEmail.Location = new Point(400, 398);
            btnEnviarEmail.Name = "btnEnviarEmail";
            btnEnviarEmail.Size = new Size(365, 40);
            btnEnviarEmail.TabIndex = 5;
            btnEnviarEmail.Text = "Enviar Email";
            btnEnviarEmail.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnEnviarEmail, "Corrobore que los datos esten ingresados correctamente.");
            btnEnviarEmail.UseVisualStyleBackColor = false;
            btnEnviarEmail.Visible = false;
            btnEnviarEmail.Click += btnEnviarEmail_Click;
            // 
            // FormBajaUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
            ClientSize = new Size(800, 450);
            Controls.Add(btnEnviarEmail);
            Controls.Add(lblMsj);
            Controls.Add(lblAsunto);
            Controls.Add(lblPara);
            Controls.Add(lblDe);
            Controls.Add(txtMensaje);
            Controls.Add(txtPara);
            Controls.Add(txtAsunto);
            Controls.Add(txtDe);
            Controls.Add(btnCorreo);
            Controls.Add(lblMensaje);
            Controls.Add(btnBajaTarjetaUsuario);
            Controls.Add(labelBajaUsuario);
            Controls.Add(pbBajaTarjeta);
            Name = "FormBajaUsuario";
            Text = "FormBajaUsuario";
            ((System.ComponentModel.ISupportInitialize)pbBajaTarjeta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBajaUsuario;
        private Button btnBajaTarjetaUsuario;
        private Label lblMensaje;
        private PictureBox pbBajaTarjeta;
        private Button btnCorreo;
        private TextBox txtDe;
        private TextBox txtAsunto;
        private TextBox txtPara;
        private TextBox txtMensaje;
        private Label lblDe;
        private Label lblPara;
        private Label lblAsunto;
        private Label lblMsj;
        private Button btnEnviarEmail;
        private ToolTip toolTip1;
    }
}