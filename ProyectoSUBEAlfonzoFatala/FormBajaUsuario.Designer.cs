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
            labelBajaUsuario = new Label();
            btnBajaTarjetaUsuario = new Button();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // labelBajaUsuario
            // 
            labelBajaUsuario.AutoSize = true;
            labelBajaUsuario.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelBajaUsuario.Location = new Point(236, 96);
            labelBajaUsuario.Name = "labelBajaUsuario";
            labelBajaUsuario.Size = new Size(272, 30);
            labelBajaUsuario.TabIndex = 0;
            labelBajaUsuario.Text = "Pedir la baja de la tarjeta";
            // 
            // btnBajaTarjetaUsuario
            // 
            btnBajaTarjetaUsuario.Location = new Point(236, 151);
            btnBajaTarjetaUsuario.Name = "btnBajaTarjetaUsuario";
            btnBajaTarjetaUsuario.Size = new Size(272, 65);
            btnBajaTarjetaUsuario.TabIndex = 1;
            btnBajaTarjetaUsuario.Text = "Mandar mensaje";
            btnBajaTarjetaUsuario.UseVisualStyleBackColor = true;
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
            // FormBajaUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMensaje);
            Controls.Add(btnBajaTarjetaUsuario);
            Controls.Add(labelBajaUsuario);
            Name = "FormBajaUsuario";
            Text = "FormBajaUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBajaUsuario;
        private Button btnBajaTarjetaUsuario;
        private Label lblMensaje;
    }
}