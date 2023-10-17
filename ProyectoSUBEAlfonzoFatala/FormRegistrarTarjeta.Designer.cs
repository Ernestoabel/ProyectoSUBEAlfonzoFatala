namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormRegistrarTarjeta
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
            lblDescripcion = new Label();
            lblDocumento = new Label();
            textBox1 = new TextBox();
            txtDocumento = new TextBox();
            lblNacionalidad = new Label();
            label2 = new Label();
            rdoArgentino = new RadioButton();
            rdoExtranjero = new RadioButton();
            lblClave = new Label();
            txtClave = new TextBox();
            btnContinuar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(23, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(215, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Tarjeta";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.White;
            lblDescripcion.Location = new Point(23, 75);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(272, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Ingrese los datos para poner la tarjeta a su nombre";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Gadugi", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDocumento.ForeColor = Color.White;
            lblDocumento.Location = new Point(23, 134);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(90, 19);
            lblDocumento.TabIndex = 3;
            lblDocumento.Text = "Documento";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(-79, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(191, 23);
            textBox1.TabIndex = 4;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(34, 156);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.PlaceholderText = "Ingrese su documento";
            txtDocumento.Size = new Size(160, 23);
            txtDocumento.TabIndex = 4;
            txtDocumento.TextChanged += txtDocumento_TextChanged;
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Font = new Font("Gadugi", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNacionalidad.ForeColor = Color.White;
            lblNacionalidad.Location = new Point(23, 197);
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.Size = new Size(100, 19);
            lblNacionalidad.TabIndex = 5;
            lblNacionalidad.Text = "Nacionalidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gadugi", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(189, 241);
            label2.Name = "label2";
            label2.Size = new Size(0, 19);
            label2.TabIndex = 6;
            // 
            // rdoArgentino
            // 
            rdoArgentino.AutoSize = true;
            rdoArgentino.ForeColor = Color.White;
            rdoArgentino.Location = new Point(34, 228);
            rdoArgentino.Name = "rdoArgentino";
            rdoArgentino.Size = new Size(89, 19);
            rdoArgentino.TabIndex = 7;
            rdoArgentino.TabStop = true;
            rdoArgentino.Text = "Argentino/a";
            rdoArgentino.UseVisualStyleBackColor = true;
            // 
            // rdoExtranjero
            // 
            rdoExtranjero.AutoSize = true;
            rdoExtranjero.ForeColor = Color.White;
            rdoExtranjero.Location = new Point(129, 228);
            rdoExtranjero.Name = "rdoExtranjero";
            rdoExtranjero.Size = new Size(89, 19);
            rdoExtranjero.TabIndex = 8;
            rdoExtranjero.TabStop = true;
            rdoExtranjero.Text = "Extranjero/a";
            rdoExtranjero.UseVisualStyleBackColor = true;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Gadugi", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(23, 264);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(47, 19);
            lblClave.TabIndex = 9;
            lblClave.Text = "Clave";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(34, 286);
            txtClave.Name = "txtClave";
            txtClave.PlaceholderText = "Ingrese su clave";
            txtClave.Size = new Size(160, 23);
            txtClave.TabIndex = 10;
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.FromArgb(0, 0, 64);
            btnContinuar.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnContinuar.ForeColor = Color.White;
            btnContinuar.Location = new Point(339, 356);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(163, 29);
            btnContinuar.TabIndex = 11;
            btnContinuar.Text = "Registrar!";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // FormRegistrarTarjeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
            ClientSize = new Size(549, 422);
            Controls.Add(btnContinuar);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(rdoExtranjero);
            Controls.Add(rdoArgentino);
            Controls.Add(label2);
            Controls.Add(lblNacionalidad);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRegistrarTarjeta";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private SplitContainer splitContainer1;
        private Label lblDocumento;
        private TextBox textBox1;
        private TextBox txtDocumento;
        private Label lblNacionalidad;
        private Label label2;
        private RadioButton rdoArgentino;
        private RadioButton rdoExtranjero;
        private Label lblClave;
        private TextBox txtClave;
        private Button btnContinuar;
    }
}