using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormAdministrador : Form
    {
        FormABMUsuarios formABMUsuarios = new FormABMUsuarios();
        FormABMTarjetas formABMTarjetas = new FormABMTarjetas();
        FormAdminMensajes formMensajes = new FormAdminMensajes();

        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formABMUsuarios.TopLevel = false;
            formABMUsuarios.FormBorderStyle = FormBorderStyle.None;
            formABMUsuarios.Dock = DockStyle.Fill;
            this.Controls.Add(formABMUsuarios);
            formABMUsuarios.Show();
        }

        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formABMTarjetas.TopLevel = false;
            formABMTarjetas.FormBorderStyle = FormBorderStyle.None;
            formABMTarjetas.Dock = DockStyle.Fill;
            this.Controls.Add(formABMTarjetas);
            formABMTarjetas.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != tarjetasToolStripMenuItem)
            {
                formABMTarjetas.Hide();
            }
            if (e.ClickedItem != usuariosToolStripMenuItem)
            {
                formABMUsuarios.Hide();
            }
            if (e.ClickedItem != mensajesToolStripMenuItem1)
            {
                formABMUsuarios.Hide();
            }
        }

        private void mensajesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formMensajes.TopLevel = false;
            formMensajes.FormBorderStyle = FormBorderStyle.None;
            formMensajes.Dock = DockStyle.Fill;
            this.Controls.Add(formMensajes);
            formMensajes.Show();
        }
    }
}
