using Entidades;
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
    public partial class VentenaEmergenteUsuarioSinTarjeta : Form
    {
        private string titulo;
        private string solucion;

        public VentenaEmergenteUsuarioSinTarjeta()
        {
            InitializeComponent();
        }
        public VentenaEmergenteUsuarioSinTarjeta(string titulo, string posibleSolucion)
        {
            InitializeComponent();
            this.titulo = titulo;
            this.solucion = posibleSolucion;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void VentenaEmergenteUsuarioSinTarjeta_Load(object sender, EventArgs e)
        {
            Inicializarlos();
        }

        private void Inicializarlos()
        {
            //string mensaje = r"El usuario no tiene una tarjeta a su nombre,\r\n\r\npuede Comprarla yendo a Mi Sube/Comprarla."
            // Verificar si hay saldo acreditado (solo en caso de la primera sobrecarga)
            if (!string.IsNullOrEmpty(solucion) && !string.IsNullOrEmpty(titulo))
            {
                lblTitulo.Text = this.titulo;
                lblSolucion.Text = this.solucion;
            }

        }
    }
}
