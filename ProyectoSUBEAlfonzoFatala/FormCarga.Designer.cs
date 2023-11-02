namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormCarga
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
            txtMonto = new TextBox();
            txtClave = new TextBox();
            lblMonto = new Label();
            lblClave = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            SuspendLayout();
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(173, 94);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ingrese el monto";
            txtMonto.Size = new Size(149, 23);
            txtMonto.TabIndex = 0;
            txtMonto.TextChanged += txtMonto_TextChanged;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(173, 156);
            txtClave.Name = "txtClave";
            txtClave.PlaceholderText = "Ingrese su clave";
            txtClave.Size = new Size(149, 23);
            txtClave.TabIndex = 1;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMonto.ForeColor = Color.White;
            lblMonto.Location = new Point(82, 94);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(65, 24);
            lblMonto.TabIndex = 2;
            lblMonto.Text = "Monto";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(82, 156);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(60, 24);
            lblClave.TabIndex = 3;
            lblClave.Text = "Clave";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.Gainsboro;
            lblNombre.Location = new Point(116, 282);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(86, 23);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblApellido.ForeColor = Color.Gainsboro;
            lblApellido.Location = new Point(252, 282);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(88, 23);
            lblApellido.TabIndex = 5;
            lblApellido.Text = "Apellido";
            // 
            // FormCarga
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Olive;
            ClientSize = new Size(491, 356);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblClave);
            Controls.Add(lblMonto);
            Controls.Add(txtClave);
            Controls.Add(txtMonto);
            Name = "FormCarga";
            Text = "FormCarga";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMonto;
        private TextBox txtClave;
        private Label lblMonto;
        private Label lblClave;
        private Label lblNombre;
        private Label lblApellido;
    }
}