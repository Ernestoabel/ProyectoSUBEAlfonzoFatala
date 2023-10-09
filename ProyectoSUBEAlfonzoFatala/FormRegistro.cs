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
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            pbrPasos.PerformStep();
            lblPaso1.Text = "Paso 2";

            /*FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();*/
        }

    }
}
