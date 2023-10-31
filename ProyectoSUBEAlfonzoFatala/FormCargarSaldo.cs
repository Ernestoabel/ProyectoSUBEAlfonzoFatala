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
    public partial class FormCargarSaldo : Form
    {
        object usuario;
        public FormCargarSaldo(object usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            TopLevel = false;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saldo Acreditado");
        }

        private void btnVerSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tenes saldo pa");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
