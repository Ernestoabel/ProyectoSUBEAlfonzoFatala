namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormularioAltaLoguin
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
            btnCancelar = new Button();
            btnAlta = new Button();
            rdbAdministrador = new RadioButton();
            rdbUsuario = new RadioButton();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Gray;
            btnCancelar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(288, 276);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(323, 42);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAlta
            // 
            btnAlta.BackColor = Color.Gray;
            btnAlta.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlta.Location = new Point(288, 228);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(323, 42);
            btnAlta.TabIndex = 16;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = false;
            btnAlta.Click += btnAlta_Click;
            // 
            // rdbAdministrador
            // 
            rdbAdministrador.AutoSize = true;
            rdbAdministrador.Location = new Point(341, 185);
            rdbAdministrador.Name = "rdbAdministrador";
            rdbAdministrador.Size = new Size(101, 19);
            rdbAdministrador.TabIndex = 18;
            rdbAdministrador.Text = "Administrador";
            rdbAdministrador.UseVisualStyleBackColor = true;
            // 
            // rdbUsuario
            // 
            rdbUsuario.AutoSize = true;
            rdbUsuario.Checked = true;
            rdbUsuario.Location = new Point(466, 185);
            rdbUsuario.Name = "rdbUsuario";
            rdbUsuario.Size = new Size(65, 19);
            rdbUsuario.TabIndex = 19;
            rdbUsuario.TabStop = true;
            rdbUsuario.Text = "Usuario";
            rdbUsuario.UseVisualStyleBackColor = true;
            // 
            // FormularioAltaLoguin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 330);
            Controls.Add(rdbUsuario);
            Controls.Add(rdbAdministrador);
            Controls.Add(btnCancelar);
            Controls.Add(btnAlta);
            Name = "FormularioAltaLoguin";
            Text = "FormularioAltaLoguin";
            Controls.SetChildIndex(txtUsuario, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(btnAlta, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(rdbAdministrador, 0);
            Controls.SetChildIndex(rdbUsuario, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAlta;
        private RadioButton rdbAdministrador;
        private RadioButton rdbUsuario;
    }
}