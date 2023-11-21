namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormViajesPrueba
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
            dtgViajes = new DataGridView();
            btnViajar = new Button();
            mySqlCommand1 = new MySqlConnector.MySqlCommand();
            btnViajarx5 = new Button();
            lblMensaje = new Label();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgViajes).BeginInit();
            SuspendLayout();
            // 
            // dtgViajes
            // 
            dtgViajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgViajes.Location = new Point(12, 115);
            dtgViajes.Name = "dtgViajes";
            dtgViajes.Size = new Size(776, 323);
            dtgViajes.TabIndex = 0;
            // 
            // btnViajar
            // 
            btnViajar.BackColor = Color.Beige;
            btnViajar.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnViajar.ForeColor = Color.Indigo;
            btnViajar.Location = new Point(363, 38);
            btnViajar.Name = "btnViajar";
            btnViajar.Size = new Size(203, 31);
            btnViajar.TabIndex = 1;
            btnViajar.Text = "Viaje Corto";
            btnViajar.UseVisualStyleBackColor = false;
            btnViajar.Click += btnViajar_Click;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CommandTimeout = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.Transaction = null;
            mySqlCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // btnViajarx5
            // 
            btnViajarx5.BackColor = Color.Beige;
            btnViajarx5.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnViajarx5.ForeColor = Color.Indigo;
            btnViajarx5.Location = new Point(572, 38);
            btnViajarx5.Name = "btnViajarx5";
            btnViajarx5.Size = new Size(203, 31);
            btnViajarx5.TabIndex = 2;
            btnViajarx5.Text = "Viaje Largo";
            btnViajarx5.UseVisualStyleBackColor = false;
            btnViajarx5.Click += btnViajarx5_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMensaje.Location = new Point(281, 79);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 21);
            lblMensaje.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Indigo;
            btnCancelar.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(572, 75);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(203, 31);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar Viaje";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormViajesPrueba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 106);
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(lblMensaje);
            Controls.Add(btnViajarx5);
            Controls.Add(btnViajar);
            Controls.Add(dtgViajes);
            Name = "FormViajesPrueba";
            Text = "FormViajesPrueba";
            Load += FormViajesPrueba_Load;
            ((System.ComponentModel.ISupportInitialize)dtgViajes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgViajes;
        private Button btnViajar;
        private MySqlConnector.MySqlCommand mySqlCommand1;
        private Button btnViajarx5;
        private Label lblMensaje;
        private Button btnCancelar;
    }
}