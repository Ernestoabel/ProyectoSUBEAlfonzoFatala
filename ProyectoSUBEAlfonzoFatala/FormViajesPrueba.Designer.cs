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
            ((System.ComponentModel.ISupportInitialize)dtgViajes).BeginInit();
            SuspendLayout();
            // 
            // dtgViajes
            // 
            dtgViajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgViajes.Location = new Point(12, 84);
            dtgViajes.Name = "dtgViajes";
            dtgViajes.Size = new Size(776, 354);
            dtgViajes.TabIndex = 0;
            // 
            // btnViajar
            // 
            btnViajar.Location = new Point(281, 36);
            btnViajar.Name = "btnViajar";
            btnViajar.Size = new Size(203, 31);
            btnViajar.TabIndex = 1;
            btnViajar.Text = "Viajar!!!";
            btnViajar.UseVisualStyleBackColor = true;
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
            btnViajarx5.Location = new Point(503, 36);
            btnViajarx5.Name = "btnViajarx5";
            btnViajarx5.Size = new Size(203, 31);
            btnViajarx5.TabIndex = 2;
            btnViajarx5.Text = "Viajar x5!!!";
            btnViajarx5.UseVisualStyleBackColor = true;
            btnViajarx5.Click += btnViajarx5_Click;
            // 
            // FormViajesPrueba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnViajarx5);
            Controls.Add(btnViajar);
            Controls.Add(dtgViajes);
            Name = "FormViajesPrueba";
            Text = "FormViajesPrueba";
            Load += FormViajesPrueba_Load;
            ((System.ComponentModel.ISupportInitialize)dtgViajes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgViajes;
        private Button btnViajar;
        private MySqlConnector.MySqlCommand mySqlCommand1;
        private Button btnViajarx5;
    }
}