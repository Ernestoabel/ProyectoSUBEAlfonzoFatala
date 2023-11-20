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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABMTarjetas));
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
            rdArgentinas.Appearance = Appearance.Button;
            rdArgentinas.AutoSize = true;
            rdArgentinas.BackColor = SystemColors.Control;
            rdArgentinas.BackgroundImageLayout = ImageLayout.Zoom;
            rdArgentinas.CheckAlign = ContentAlignment.MiddleCenter;
            rdArgentinas.FlatStyle = FlatStyle.Flat;
            rdArgentinas.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdArgentinas.ForeColor = SystemColors.ActiveCaptionText;
            rdArgentinas.Image = (Image)resources.GetObject("rdArgentinas.Image");
            rdArgentinas.ImageAlign = ContentAlignment.MiddleLeft;
            rdArgentinas.Location = new Point(173, 55);
            rdArgentinas.Name = "rdArgentinas";
            rdArgentinas.Size = new Size(204, 43);
            rdArgentinas.TabIndex = 1;
            rdArgentinas.Text = "Tarjetas Argentinas";
            rdArgentinas.TextAlign = ContentAlignment.MiddleCenter;
            rdArgentinas.TextImageRelation = TextImageRelation.ImageBeforeText;
            rdArgentinas.UseVisualStyleBackColor = false;
            // 
            // rdExtranjeras
            // 
            rdExtranjeras.Appearance = Appearance.Button;
            rdExtranjeras.AutoSize = true;
            rdExtranjeras.BackColor = SystemColors.Control;
            rdExtranjeras.BackgroundImageLayout = ImageLayout.Zoom;
            rdExtranjeras.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdExtranjeras.Image = (Image)resources.GetObject("rdExtranjeras.Image");
            rdExtranjeras.Location = new Point(406, 55);
            rdExtranjeras.Name = "rdExtranjeras";
            rdExtranjeras.Size = new Size(204, 41);
            rdExtranjeras.TabIndex = 2;
            rdExtranjeras.Text = "Tarjetas Extranjeras";
            rdExtranjeras.TextAlign = ContentAlignment.MiddleCenter;
            rdExtranjeras.TextImageRelation = TextImageRelation.ImageBeforeText;
            rdExtranjeras.UseVisualStyleBackColor = false;
            // 
            // FormABMTarjetas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
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