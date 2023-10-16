namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormAdministrador
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
            menuStrip1 = new MenuStrip();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            tarjetasToolStripMenuItem = new ToolStripMenuItem();
            mensajesToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem, tarjetasToolStripMenuItem, mensajesToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(101, 29);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // tarjetasToolStripMenuItem
            // 
            tarjetasToolStripMenuItem.Name = "tarjetasToolStripMenuItem";
            tarjetasToolStripMenuItem.Size = new Size(91, 29);
            tarjetasToolStripMenuItem.Text = "Tarjetas";
            tarjetasToolStripMenuItem.Click += tarjetasToolStripMenuItem_Click;
            // 
            // mensajesToolStripMenuItem1
            // 
            mensajesToolStripMenuItem1.Name = "mensajesToolStripMenuItem1";
            mensajesToolStripMenuItem1.Size = new Size(105, 29);
            mensajesToolStripMenuItem1.Text = "Mensajes";
            mensajesToolStripMenuItem1.Click += mensajesToolStripMenuItem1_Click;
            // 
            // FormAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormAdministrador";
            Text = "FormAdministrador";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem tarjetasToolStripMenuItem;
        private ToolStripMenuItem mensajesToolStripMenuItem1;
    }
}