﻿namespace ProyectoSUBEAlfonzoFatala
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
            ((System.ComponentModel.ISupportInitialize)dtgViajes).BeginInit();
            SuspendLayout();
            // 
            // dtgViajes
            // 
            dtgViajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgViajes.Location = new Point(40, 32);
            dtgViajes.Name = "dtgViajes";
            dtgViajes.Size = new Size(658, 361);
            dtgViajes.TabIndex = 0;
            // 
            // FormViajesPrueba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 405);
            Controls.Add(dtgViajes);
            Name = "FormViajesPrueba";
            Text = "FormViajesPrueba";
            Load += FormViajesPrueba_Load;
            ((System.ComponentModel.ISupportInitialize)dtgViajes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgViajes;
    }
}