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
            btnIngresar = new Button();
            btnCancelar = new Button();
            btnAdministrador = new Button();
            btnAlta = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Gray;
            btnIngresar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.Location = new Point(288, 228);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(323, 42);
            btnIngresar.TabIndex = 14;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Gray;
            btnCancelar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(288, 276);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(323, 42);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAdministrador
            // 
            btnAdministrador.BackColor = Color.Gray;
            btnAdministrador.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdministrador.Location = new Point(288, 180);
            btnAdministrador.Name = "btnAdministrador";
            btnAdministrador.Size = new Size(144, 42);
            btnAdministrador.TabIndex = 16;
            btnAdministrador.Text = "Administrador";
            btnAdministrador.UseVisualStyleBackColor = false;
            btnAdministrador.Click += btnAdministrador_Click;
            // 
            // btnAlta
            // 
            btnAlta.BackColor = Color.Gray;
            btnAlta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlta.Location = new Point(467, 180);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(144, 42);
            btnAlta.TabIndex = 17;
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
            // FormularioLoguin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 330);
            Controls.Add(lblError);
            Controls.Add(btnAlta);
            Controls.Add(btnAdministrador);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Name = "FormularioLoguin";
            Text = "FormularioLoguin";
            Controls.SetChildIndex(txtUsuario, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(btnIngresar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(btnAdministrador, 0);
            Controls.SetChildIndex(btnAlta, 0);
            Controls.SetChildIndex(lblError, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIngresar;
        private Button btnCancelar;
        private Button btnAdministrador;
        private Button btnAlta;
        private Label lblError;
    }
}