namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormTitularidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTitularidad));
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            TxtDNI = new TextBox();
            txtTarjeta = new TextBox();
            lbNombre = new Label();
            lbApellido = new Label();
            lbDNI = new Label();
            lbTarjeta = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            txtNombre.Location = new Point(190, 69);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(228, 36);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            txtApellido.Location = new Point(190, 111);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(228, 36);
            txtApellido.TabIndex = 1;
            // 
            // TxtDNI
            // 
            TxtDNI.BorderStyle = BorderStyle.None;
            TxtDNI.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            TxtDNI.Location = new Point(190, 153);
            TxtDNI.Name = "TxtDNI";
            TxtDNI.Size = new Size(228, 36);
            TxtDNI.TabIndex = 2;
            // 
            // txtTarjeta
            // 
            txtTarjeta.BorderStyle = BorderStyle.None;
            txtTarjeta.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            txtTarjeta.Location = new Point(190, 195);
            txtTarjeta.Name = "txtTarjeta";
            txtTarjeta.Size = new Size(228, 36);
            txtTarjeta.TabIndex = 3;
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.BackColor = Color.Transparent;
            lbNombre.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lbNombre.Location = new Point(40, 68);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(123, 37);
            lbNombre.TabIndex = 4;
            lbNombre.Text = "Nombre";
            // 
            // lbApellido
            // 
            lbApellido.AutoSize = true;
            lbApellido.BackColor = Color.Transparent;
            lbApellido.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lbApellido.Location = new Point(40, 110);
            lbApellido.Name = "lbApellido";
            lbApellido.Size = new Size(126, 37);
            lbApellido.TabIndex = 5;
            lbApellido.Text = "Apellido";
            // 
            // lbDNI
            // 
            lbDNI.AutoSize = true;
            lbDNI.BackColor = Color.Transparent;
            lbDNI.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lbDNI.Location = new Point(40, 152);
            lbDNI.Name = "lbDNI";
            lbDNI.Size = new Size(67, 37);
            lbDNI.TabIndex = 6;
            lbDNI.Text = "DNI";
            // 
            // lbTarjeta
            // 
            lbTarjeta.AutoSize = true;
            lbTarjeta.BackColor = Color.Transparent;
            lbTarjeta.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lbTarjeta.Location = new Point(40, 194);
            lbTarjeta.Name = "lbTarjeta";
            lbTarjeta.Size = new Size(106, 37);
            lbTarjeta.TabIndex = 7;
            lbTarjeta.Text = "Tarjeta";
            // 
            // FormTitularidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(800, 450);
            Controls.Add(lbTarjeta);
            Controls.Add(lbDNI);
            Controls.Add(lbApellido);
            Controls.Add(lbNombre);
            Controls.Add(txtTarjeta);
            Controls.Add(TxtDNI);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Name = "FormTitularidad";
            Text = "FormTitularidad";
            Load += FormTitularidad_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox TxtDNI;
        private TextBox txtTarjeta;
        private Label lbNombre;
        private Label lbApellido;
        private Label lbDNI;
        private Label lbTarjeta;
    }
}