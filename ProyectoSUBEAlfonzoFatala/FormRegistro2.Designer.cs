namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormRegistro2
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            lblClave = new Label();
            lblRepetirClave = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(324, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(324, 169);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(182, 23);
            textBox2.TabIndex = 1;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(317, 84);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(39, 14);
            lblClave.TabIndex = 2;
            lblClave.Text = "Clave";
            // 
            // lblRepetirClave
            // 
            lblRepetirClave.AutoSize = true;
            lblRepetirClave.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblRepetirClave.ForeColor = Color.White;
            lblRepetirClave.Location = new Point(317, 145);
            lblRepetirClave.Name = "lblRepetirClave";
            lblRepetirClave.Size = new Size(88, 14);
            lblRepetirClave.TabIndex = 3;
            lblRepetirClave.Text = "Repetir Clave";
            // 
            // FormRegistro2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(569, 415);
            ControlBox = false;
            Controls.Add(lblRepetirClave);
            Controls.Add(lblClave);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "FormRegistro2";
            Text = "FormRegistro2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblClave;
        private Label lblRepetirClave;
    }
}