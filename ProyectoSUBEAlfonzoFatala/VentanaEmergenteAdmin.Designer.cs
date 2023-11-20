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
            lblTitulo = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            lblUsuario = new Label();
            lblSubTitulo = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(45, 49);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "¿Desea Modificar la Clave";
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.Navy;
            btnConfirmar.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(188, 197);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(117, 38);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(45, 197);
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
            lblUsuario.Location = new Point(98, 141);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(144, 19);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Catriel Alfonso";
            // 
            // lblSubTitulo
            // 
            lblSubTitulo.AutoSize = true;
            lblSubTitulo.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubTitulo.Location = new Point(98, 84);
            lblSubTitulo.Name = "lblSubTitulo";
            lblSubTitulo.Size = new Size(129, 25);
            lblSubTitulo.TabIndex = 4;
            lblSubTitulo.Text = "del Usuario..";
            // 
            // VentanaEmergenteAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(358, 271);
            ControlBox = false;
            Controls.Add(lblSubTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentanaEmergenteAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VentanaEmergenteAdmin";
            Load += VentanaEmergenteAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblUsuario;
        private Label lblSubTitulo;
    }
}