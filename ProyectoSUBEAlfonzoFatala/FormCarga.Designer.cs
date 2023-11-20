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
            components = new System.ComponentModel.Container();
            txtMonto = new TextBox();
            txtClave = new TextBox();
            lblMonto = new Label();
            lblClave = new Label();
            toolTip1 = new ToolTip(components);
            btnAcreditarSaldo = new Button();
            SuspendLayout();
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMonto.Location = new Point(83, 41);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ingrese el monto";
            txtMonto.Size = new Size(149, 21);
            txtMonto.TabIndex = 0;
            toolTip1.SetToolTip(txtMonto, "Ingrese el monto en digitos decimales.");
            txtMonto.TextChanged += txtMonto_TextChanged;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(83, 96);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese su clave";
            txtClave.Size = new Size(149, 21);
            txtClave.TabIndex = 1;
            toolTip1.SetToolTip(txtClave, "Ingrese la clave de usuario.");
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Bahnschrift SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMonto.ForeColor = Color.White;
            lblMonto.Location = new Point(12, 38);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(62, 23);
            lblMonto.TabIndex = 2;
            lblMonto.Text = "Monto";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Bahnschrift SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(17, 93);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(58, 23);
            lblClave.TabIndex = 3;
            lblClave.Text = "Clave";
            // 
            // btnAcreditarSaldo
            // 
            btnAcreditarSaldo.BackColor = Color.Gold;
            btnAcreditarSaldo.FlatStyle = FlatStyle.Flat;
            btnAcreditarSaldo.Font = new Font("Bahnschrift SemiLight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAcreditarSaldo.ForeColor = SystemColors.ActiveCaptionText;
            btnAcreditarSaldo.Location = new Point(73, 168);
            btnAcreditarSaldo.Name = "btnAcreditarSaldo";
            btnAcreditarSaldo.Size = new Size(107, 34);
            btnAcreditarSaldo.TabIndex = 4;
            btnAcreditarSaldo.Text = "Acreditar";
            toolTip1.SetToolTip(btnAcreditarSaldo, "Verifique que haya ingresado un saldo correcto.");
            btnAcreditarSaldo.UseVisualStyleBackColor = false;
            btnAcreditarSaldo.Click += btnAcreditarSaldo_Click;
            // 
            // FormCarga
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
            ClientSize = new Size(256, 233);
            Controls.Add(btnAcreditarSaldo);
            Controls.Add(lblClave);
            Controls.Add(lblMonto);
            Controls.Add(txtClave);
            Controls.Add(txtMonto);
            Name = "FormCarga";
            Text = "FormCarga";
            Load += FormCarga_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMonto;
        private TextBox txtClave;
        private Label lblMonto;
        private Label lblClave;
        private ToolTip toolTip1;
        private Button btnAcreditarSaldo;
    }
}