namespace ProyectoSUBEAlfonzoFatala
{
    partial class VentanaEmergenteSaldo
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
            lblSaldoDisponible = new Label();
            lblTituloSaldoDisponible = new Label();
            lblSaldoAcreditado = new Label();
            btnOk = new Button();
            lblSignoPesos2 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.Green;
            lblTitulo.Location = new Point(12, 139);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(138, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Saldo Acreditado";
            // 
            // lblSaldoDisponible
            // 
            lblSaldoDisponible.AutoSize = true;
            lblSaldoDisponible.Font = new Font("Segoe UI Symbol", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSaldoDisponible.ForeColor = Color.DarkGreen;
            lblSaldoDisponible.Location = new Point(46, 59);
            lblSaldoDisponible.Name = "lblSaldoDisponible";
            lblSaldoDisponible.Size = new Size(180, 47);
            lblSaldoDisponible.TabIndex = 1;
            lblSaldoDisponible.Text = "$ 2452.12";
            // 
            // lblTituloSaldoDisponible
            // 
            lblTituloSaldoDisponible.AutoSize = true;
            lblTituloSaldoDisponible.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTituloSaldoDisponible.ForeColor = Color.Black;
            lblTituloSaldoDisponible.Location = new Point(55, 21);
            lblTituloSaldoDisponible.Name = "lblTituloSaldoDisponible";
            lblTituloSaldoDisponible.Size = new Size(171, 27);
            lblTituloSaldoDisponible.TabIndex = 2;
            lblTituloSaldoDisponible.Text = "Saldo Disponible";
            // 
            // lblSaldoAcreditado
            // 
            lblSaldoAcreditado.AutoSize = true;
            lblSaldoAcreditado.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSaldoAcreditado.ForeColor = Color.DarkGreen;
            lblSaldoAcreditado.Location = new Point(177, 131);
            lblSaldoAcreditado.Name = "lblSaldoAcreditado";
            lblSaldoAcreditado.Size = new Size(79, 30);
            lblSaldoAcreditado.TabIndex = 3;
            lblSaldoAcreditado.Text = "450.00";
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnOk.Location = new Point(103, 182);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 27);
            btnOk.TabIndex = 4;
            btnOk.Text = "ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblSignoPesos2
            // 
            lblSignoPesos2.AutoSize = true;
            lblSignoPesos2.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSignoPesos2.ForeColor = Color.DarkGreen;
            lblSignoPesos2.Location = new Point(156, 131);
            lblSignoPesos2.Name = "lblSignoPesos2";
            lblSignoPesos2.Size = new Size(25, 30);
            lblSignoPesos2.TabIndex = 5;
            lblSignoPesos2.Text = "$";
            // 
            // VentanaEmergenteSaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(278, 221);
            Controls.Add(lblSignoPesos2);
            Controls.Add(btnOk);
            Controls.Add(lblSaldoAcreditado);
            Controls.Add(lblTituloSaldoDisponible);
            Controls.Add(lblSaldoDisponible);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentanaEmergenteSaldo";
            Text = "VentanaEmergenteSaldo";
            Load += VentanaEmergenteSaldo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSaldoDisponible;
        private Label lblTituloSaldoDisponible;
        private Label lblSaldoAcreditado;
        private Button btnOk;
        private Label lblSignoPesos2;
    }
}