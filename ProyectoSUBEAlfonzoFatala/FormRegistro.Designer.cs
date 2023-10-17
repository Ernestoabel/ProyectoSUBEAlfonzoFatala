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
            components = new System.ComponentModel.Container();
            lblRegistrar = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            btnContinuar = new Button();
            pbrPasos = new ProgressBar();
            lblPaso1 = new Label();
            btnCancelar = new Button();
            txtClave = new TextBox();
            lblClave = new Label();
            lblRepetirClave = new Label();
            txtRepetirClave = new TextBox();
            errorProviderRegistro = new ErrorProvider(components);
            toolTipClave = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderRegistro).BeginInit();
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
            txtNombre.PlaceholderText = "Ingrese su nombre";
            txtNombre.Size = new Size(182, 23);
            txtNombre.TabIndex = 2;
            toolTipClave.SetToolTip(txtNombre, "Ingrese solo letras por favor.");
            txtNombre.TextChanged += txtNombre_TextChanged;
            txtNombre.KeyPress += txtNombre_KeyPress;
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
            txtApellido.PlaceholderText = "Ingrese su apellido";
            txtApellido.Size = new Size(182, 23);
            txtApellido.TabIndex = 4;
            toolTipClave.SetToolTip(txtApellido, "Ingrese solo letras por favor.");
            txtApellido.TextChanged += txtApellido_TextChanged;
            txtApellido.KeyPress += txtApellido_KeyPress;
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
            txtDni.PlaceholderText = "Ingrese su documento ";
            txtDni.Size = new Size(182, 23);
            txtDni.TabIndex = 6;
            toolTipClave.SetToolTip(txtDni, "El documento tiene de 8 o 9 caracteres. \r\n");
            txtDni.TextChanged += txtDni_TextChanged;
            txtDni.KeyPress += txtDni_KeyPress;
            txtDni.Validating += txtDni_Validating;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.MediumBlue;
            btnContinuar.FlatStyle = FlatStyle.Flat;
            btnContinuar.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContinuar.ForeColor = SystemColors.ControlLightLight;
            btnContinuar.Location = new Point(207, 345);
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
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.OrangeRed;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(207, 387);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(181, 36);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtClave
            // 
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Location = new Point(338, 114);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese clave numerica";
            txtClave.Size = new Size(182, 23);
            txtClave.TabIndex = 13;
            toolTipClave.SetToolTip(txtClave, "La clave debe ser de 4 digitos numericos.");
            txtClave.Visible = false;
            txtClave.TextChanged += txtClave_TextChanged;
            txtClave.KeyPress += txtClave_KeyPress;
            // 
            // lblClave
            // 
            lblClave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(321, 95);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(42, 16);
            lblClave.TabIndex = 14;
            lblClave.Text = "Clave";
            lblClave.Visible = false;
            // 
            // lblRepetirClave
            // 
            lblRepetirClave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRepetirClave.AutoSize = true;
            lblRepetirClave.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblRepetirClave.ForeColor = Color.White;
            lblRepetirClave.Location = new Point(321, 155);
            lblRepetirClave.Name = "lblRepetirClave";
            lblRepetirClave.Size = new Size(94, 16);
            lblRepetirClave.TabIndex = 15;
            lblRepetirClave.Text = "Repetir Clave";
            lblRepetirClave.Visible = false;
            // 
            // txtRepetirClave
            // 
            txtRepetirClave.BorderStyle = BorderStyle.FixedSingle;
            txtRepetirClave.Location = new Point(338, 174);
            txtRepetirClave.Name = "txtRepetirClave";
            txtRepetirClave.PasswordChar = '*';
            txtRepetirClave.PlaceholderText = "Ingrese de nuevo su clave";
            txtRepetirClave.Size = new Size(182, 23);
            txtRepetirClave.TabIndex = 16;
            toolTipClave.SetToolTip(txtRepetirClave, "La clave debe ser de 4 digitos numericos.");
            txtRepetirClave.Visible = false;
            txtRepetirClave.TextChanged += txtRepetirClave_TextChanged;
            txtRepetirClave.KeyPress += txtRepetirClave_KeyPress;
            // 
            // errorProviderRegistro
            // 
            errorProviderRegistro.ContainerControl = this;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(596, 435);
            Controls.Add(txtRepetirClave);
            Controls.Add(lblRepetirClave);
            Controls.Add(lblClave);
            Controls.Add(txtClave);
            Controls.Add(btnCancelar);
            Controls.Add(lblPaso1);
            Controls.Add(pbrPasos);
            Controls.Add(btnContinuar);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblRegistrar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistro";
            Load += FormRegistro_Load;
            ((System.ComponentModel.ISupportInitialize)errorProviderRegistro).EndInit();
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
        private Button btnContinuar;
        private ProgressBar pbrPasos;
        private Label lblPaso1;
        private Button btnCancelar;
        private TextBox txtClave;
        private Label lblClave;
        private Label lblRepetirClave;
        private TextBox txtRepetirClave;
        private ErrorProvider errorProviderRegistro;
        private ToolTip toolTipClave;
    }
}