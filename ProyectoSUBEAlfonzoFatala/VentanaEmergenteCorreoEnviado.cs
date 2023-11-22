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
        string rutaGif;
        string titulo;

        public VentanaEmergenteCorreoEnviado(string rutaGif, string titulo)
        {
            InitializeComponent();
            this.rutaGif = rutaGif;
            this.titulo = titulo;
        }

        private void VentanaEmergenteCorreoEnviado_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(rutaGif);
            label1.Text = titulo;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
