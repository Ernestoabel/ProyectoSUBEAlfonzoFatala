﻿namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormABMUsuarios
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
            dataGridUsuarios = new DataGridView();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dataGridUsuarios
            // 
            dataGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsuarios.Location = new Point(12, 86);
            dataGridUsuarios.Name = "dataGridUsuarios";
            dataGridUsuarios.RowTemplate.Height = 25;
            dataGridUsuarios.Size = new Size(776, 352);
            dataGridUsuarios.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Blue;
            btnGuardar.BackgroundImageLayout = ImageLayout.None;
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            btnGuardar.FlatAppearance.BorderSize = 2;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.WhiteSmoke;
            btnGuardar.Location = new Point(12, 38);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.RightToLeft = RightToLeft.Yes;
            btnGuardar.Size = new Size(156, 32);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormABMUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(dataGridUsuarios);
            Name = "FormABMUsuarios";
            Text = "FormABMUsuarios";
            Load += FormABMUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridUsuarios;
        private Button btnGuardar;
    }
}