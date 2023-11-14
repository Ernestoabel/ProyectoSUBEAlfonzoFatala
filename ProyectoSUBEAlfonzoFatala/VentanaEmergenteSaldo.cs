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
    public partial class VentanaEmergenteSaldo : Form
    {
        
        private string saldoActual;
        private string saldoAcreditado;

        public VentanaEmergenteSaldo(string saldoActual, string saldoAcreditado)
        {
            InitializeComponent();
            this.saldoActual = saldoActual;
            this.saldoAcreditado = saldoAcreditado;
        }
        
        /// <summary>
        /// Evento para corroborar el dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// evento para setear el load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VentanaEmergenteSaldo_Load(object sender, EventArgs e)
        {
            lblSaldoDisponible.Text = this.saldoActual;
            lblSaldoAcreditado.Text = this.saldoAcreditado;
        }

    }
}
