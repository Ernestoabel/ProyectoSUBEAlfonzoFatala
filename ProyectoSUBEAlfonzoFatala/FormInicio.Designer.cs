﻿namespace ProyectoSUBEAlfonzoFatala
{
    partial class FormInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            menuStrip1 = new MenuStrip();
            rEGISTRESEToolStripMenuItem = new ToolStripMenuItem();
            logueateToolStripMenuItem = new ToolStripMenuItem();
            registrateToolStripMenuItem = new ToolStripMenuItem();
            iNICIARSESIONToolStripMenuItem = new ToolStripMenuItem();
            cOMPRARToolStripMenuItem = new ToolStripMenuItem();
            bajaToolStripMenuItem = new ToolStripMenuItem();
            consultaTiToolStripMenuItem = new ToolStripMenuItem();
            viajesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.BackgroundImageLayout = ImageLayout.None;
            menuStrip1.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { rEGISTRESEToolStripMenuItem, iNICIARSESIONToolStripMenuItem, cOMPRARToolStripMenuItem, bajaToolStripMenuItem, consultaTiToolStripMenuItem, viajesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 29);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // rEGISTRESEToolStripMenuItem
            // 
            rEGISTRESEToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logueateToolStripMenuItem, registrateToolStripMenuItem });
            rEGISTRESEToolStripMenuItem.Image = (Image)resources.GetObject("rEGISTRESEToolStripMenuItem.Image");
            rEGISTRESEToolStripMenuItem.Name = "rEGISTRESEToolStripMenuItem";
            rEGISTRESEToolStripMenuItem.Size = new Size(101, 25);
            rEGISTRESEToolStripMenuItem.Text = "Mi Sube";
            // 
            // logueateToolStripMenuItem
            // 
            logueateToolStripMenuItem.Name = "logueateToolStripMenuItem";
            logueateToolStripMenuItem.Size = new Size(156, 26);
            logueateToolStripMenuItem.Text = "Logueate";
            logueateToolStripMenuItem.Click += logueateToolStripMenuItem_Click;
            // 
            // registrateToolStripMenuItem
            // 
            registrateToolStripMenuItem.Name = "registrateToolStripMenuItem";
            registrateToolStripMenuItem.Size = new Size(156, 26);
            registrateToolStripMenuItem.Text = "Registrate";
            registrateToolStripMenuItem.Click += registrateToolStripMenuItem_Click;
            // 
            // iNICIARSESIONToolStripMenuItem
            // 
            iNICIARSESIONToolStripMenuItem.Image = (Image)resources.GetObject("iNICIARSESIONToolStripMenuItem.Image");
            iNICIARSESIONToolStripMenuItem.Name = "iNICIARSESIONToolStripMenuItem";
            iNICIARSESIONToolStripMenuItem.Size = new Size(96, 25);
            iNICIARSESIONToolStripMenuItem.Text = "Cargala";
            iNICIARSESIONToolStripMenuItem.Click += iNICIARSESIONToolStripMenuItem_Click;
            // 
            // cOMPRARToolStripMenuItem
            // 
            cOMPRARToolStripMenuItem.Image = (Image)resources.GetObject("cOMPRARToolStripMenuItem.Image");
            cOMPRARToolStripMenuItem.Name = "cOMPRARToolStripMenuItem";
            cOMPRARToolStripMenuItem.Size = new Size(112, 25);
            cOMPRARToolStripMenuItem.Text = "Comprala";
            cOMPRARToolStripMenuItem.Click += cOMPRARToolStripMenuItem_Click;
            // 
            // bajaToolStripMenuItem
            // 
            bajaToolStripMenuItem.Image = (Image)resources.GetObject("bajaToolStripMenuItem.Image");
            bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            bajaToolStripMenuItem.Size = new Size(126, 25);
            bajaToolStripMenuItem.Text = "Pedi la baja";
            bajaToolStripMenuItem.Click += bajaToolStripMenuItem_Click;
            // 
            // consultaTiToolStripMenuItem
            // 
            consultaTiToolStripMenuItem.Image = (Image)resources.GetObject("consultaTiToolStripMenuItem.Image");
            consultaTiToolStripMenuItem.Name = "consultaTiToolStripMenuItem";
            consultaTiToolStripMenuItem.Size = new Size(191, 25);
            consultaTiToolStripMenuItem.Text = "Consulta Titularidad";
            consultaTiToolStripMenuItem.Click += consultaTiToolStripMenuItem_Click;
            // 
            // viajesToolStripMenuItem
            // 
            viajesToolStripMenuItem.Image = (Image)resources.GetObject("viajesToolStripMenuItem.Image");
            viajesToolStripMenuItem.Name = "viajesToolStripMenuItem";
            viajesToolStripMenuItem.Size = new Size(82, 25);
            viajesToolStripMenuItem.Text = "Viajes";
            viajesToolStripMenuItem.Click += viajesToolStripMenuItem_Click;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormInicio";
            Text = "Programa SUBE";
            FormClosing += FormInicio_FormClosing;
            FormClosed += FormInicio_FormClosed;
            Load += FormInicio_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem rEGISTRESEToolStripMenuItem;
        private ToolStripMenuItem iNICIARSESIONToolStripMenuItem;
        private ToolStripMenuItem cOMPRARToolStripMenuItem;
        private ToolStripMenuItem bajaToolStripMenuItem;
        private ToolStripMenuItem viajesToolStripMenuItem;
        private ToolStripMenuItem logueateToolStripMenuItem;
        private ToolStripMenuItem consultaTiToolStripMenuItem;
        private ToolStripMenuItem registrateToolStripMenuItem;
    }
}