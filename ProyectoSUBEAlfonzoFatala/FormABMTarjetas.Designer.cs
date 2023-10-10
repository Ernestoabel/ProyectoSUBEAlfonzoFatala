namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormABMTarjetas
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
            dataGridABMTarjetas = new DataGridView();
            rdArgentinas = new RadioButton();
            rdExtranjeras = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridABMTarjetas).BeginInit();
            SuspendLayout();
            // 
            // dataGridABMTarjetas
            // 
            dataGridABMTarjetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridABMTarjetas.Location = new Point(12, 107);
            dataGridABMTarjetas.Name = "dataGridABMTarjetas";
            dataGridABMTarjetas.RowTemplate.Height = 25;
            dataGridABMTarjetas.Size = new Size(776, 331);
            dataGridABMTarjetas.TabIndex = 0;
            // 
            // rdArgentinas
            // 
            rdArgentinas.AutoSize = true;
            rdArgentinas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdArgentinas.Location = new Point(198, 65);
            rdArgentinas.Name = "rdArgentinas";
            rdArgentinas.Size = new Size(172, 25);
            rdArgentinas.TabIndex = 1;
            rdArgentinas.TabStop = true;
            rdArgentinas.Text = "Tarjetas argentinas";
            rdArgentinas.UseVisualStyleBackColor = true;
            // 
            // rdExtranjeras
            // 
            rdExtranjeras.AutoSize = true;
            rdExtranjeras.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdExtranjeras.Location = new Point(395, 65);
            rdExtranjeras.Name = "rdExtranjeras";
            rdExtranjeras.Size = new Size(176, 25);
            rdExtranjeras.TabIndex = 2;
            rdExtranjeras.TabStop = true;
            rdExtranjeras.Text = "Tarjetas extranjeras";
            rdExtranjeras.UseVisualStyleBackColor = true;
            // 
            // FormABMTarjetas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rdExtranjeras);
            Controls.Add(rdArgentinas);
            Controls.Add(dataGridABMTarjetas);
            Name = "FormABMTarjetas";
            Text = "FormABMTarjetas";
            Load += FormABMTarjetas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridABMTarjetas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridABMTarjetas;
        private RadioButton rdArgentinas;
        private RadioButton rdExtranjeras;
    }
}