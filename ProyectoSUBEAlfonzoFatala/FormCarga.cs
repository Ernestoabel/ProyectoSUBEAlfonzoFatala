using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormCarga : Form
    {
        public FormCarga()
        {
            InitializeComponent();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            string monto = txtMonto.Text;

            if (IsNumeric(txtMonto.Text))
            {
                // El contenido es un número válido
                txtMonto.BackColor = System.Drawing.Color.White;
            }
            else
            {
                // El contenido no es un número válido
                txtMonto.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private bool IsNumeric(string text)
        {
           
            return double.TryParse(text, out _);
            
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Permite un solo punto (.) en la cadena
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
