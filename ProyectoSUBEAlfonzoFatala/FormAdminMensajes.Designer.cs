namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormAdminMensajes
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
            dataGridMensajes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridMensajes).BeginInit();
            SuspendLayout();
            // 
            // dataGridMensajes
            // 
            dataGridMensajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMensajes.Location = new Point(12, 68);
            dataGridMensajes.Name = "dataGridMensajes";
            dataGridMensajes.RowTemplate.Height = 25;
            dataGridMensajes.Size = new Size(767, 370);
            dataGridMensajes.TabIndex = 0;
            // 
            // FormAdminMensajes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridMensajes);
            Name = "FormAdminMensajes";
            Text = "FormAdminMensajes";
            Load += FormAdminMensajes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridMensajes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridMensajes;
    }
}