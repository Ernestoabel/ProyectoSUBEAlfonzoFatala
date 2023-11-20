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
    public partial class VentanaEmergenteCorreoEnviado : Form
    {
        public VentanaEmergenteCorreoEnviado()
        {
            InitializeComponent();
        }

        private void VentanaEmergenteCorreoEnviado_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Usuario\\source\\repos\\ProyectoSUBEAlfonzoFatala\\ProyectoSUBEAlfonzoFatala\\Assets\\enviandoEmail.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
