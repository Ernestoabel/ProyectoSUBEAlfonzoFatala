namespace ProyectoSUBEAlfonzoFatala
{
    partial class VentanaBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaBienvenida));
            pbFondoArriba = new PictureBox();
            pbSube = new PictureBox();
            lblTitulo = new Label();
            btnIngresa = new Button();
            lblNombre = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFondoArriba).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSube).BeginInit();
            SuspendLayout();
            // 
            // pbFondoArriba
            // 
            pbFondoArriba.BackColor = Color.FromArgb(0, 132, 196);
            pbFondoArriba.Location = new Point(0, -1);
            pbFondoArriba.Name = "pbFondoArriba";
            pbFondoArriba.Size = new Size(452, 81);
            pbFondoArriba.TabIndex = 0;
            pbFondoArriba.TabStop = false;
            // 
            // pbSube
            // 
            pbSube.BackColor = Color.FromArgb(0, 132, 196);
            pbSube.Image = (Image)resources.GetObject("pbSube.Image");
            pbSube.Location = new Point(154, -1);
            pbSube.Name = "pbSube";
            pbSube.Size = new Size(136, 81);
            pbSube.SizeMode = PictureBoxSizeMode.Zoom;
            pbSube.TabIndex = 1;
            pbSube.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(0, 132, 196);
            lblTitulo.Location = new Point(85, 150);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(274, 33);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Bienvenido a Sube!";
            // 
            // btnIngresa
            // 
            btnIngresa.BackColor = Color.FromArgb(0, 132, 196);
            btnIngresa.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresa.ForeColor = Color.White;
            btnIngresa.Location = new Point(142, 240);
            btnIngresa.Name = "btnIngresa";
            btnIngresa.Size = new Size(162, 45);
            btnIngresa.TabIndex = 3;
            btnIngresa.Text = "Ingresá!";
            btnIngresa.UseVisualStyleBackColor = false;
            btnIngresa.Click += btnIngresa_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.Black;
            lblNombre.Location = new Point(154, 106);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(129, 22);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "nombre usuario";
            // 
            // VentanaBienvenida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 336);
            ControlBox = false;
            Controls.Add(lblNombre);
            Controls.Add(btnIngresa);
            Controls.Add(lblTitulo);
            Controls.Add(pbSube);
            Controls.Add(pbFondoArriba);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentanaBienvenida";
            Text = "VentanaBienvenida";
            Load += VentanaBienvenida_Load;
            ((System.ComponentModel.ISupportInitialize)pbFondoArriba).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSube).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbFondoArriba;
        private PictureBox pbSube;
        private Label lblTitulo;
        private Button btnIngresa;
        private Label lblNombre;
    }
}