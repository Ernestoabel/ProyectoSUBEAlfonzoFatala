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
            dataGridTitularidad = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridTitularidad).BeginInit();
            SuspendLayout();
            // 
            // dataGridTitularidad
            // 
            dataGridTitularidad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTitularidad.Location = new Point(12, 67);
            dataGridTitularidad.Name = "dataGridTitularidad";
            dataGridTitularidad.RowTemplate.Height = 25;
            dataGridTitularidad.Size = new Size(776, 371);
            dataGridTitularidad.TabIndex = 0;
            // 
            // FormTitularidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridTitularidad);
            Name = "FormTitularidad";
            Text = "FormTitularidad";
            Load += FormTitularidad_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridTitularidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridTitularidad;
    }
}