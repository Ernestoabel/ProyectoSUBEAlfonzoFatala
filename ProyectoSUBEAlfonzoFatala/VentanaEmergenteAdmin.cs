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
    public partial class VentanaEmergenteAdmin : Form
    {
        private string nombreUsuario;
        private string nombreTitulo;
        public VentanaEmergenteAdmin(string nombreUsuario, string titulo)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            this.nombreTitulo = titulo;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void VentanaEmergenteAdmin_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = this.nombreUsuario;
            lblTitulo.Text = this.nombreTitulo;
        }
    }
}
