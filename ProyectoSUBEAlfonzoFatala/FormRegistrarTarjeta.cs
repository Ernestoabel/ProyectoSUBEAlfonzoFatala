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
    public partial class FormRegistrarTarjeta : Form
    {
        public Usuario usuarioLogueado;
        public FormRegistrarTarjeta(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;

            

        }


        private bool HabilitarContinuarClave()
        {
            if (string.IsNullOrEmpty(txtDocumento.Text) ||
                string.IsNullOrEmpty(txtClave.Text))
            {
                return false; // Faltan datos obligatorios
            }

            return true; // Todos los datos obligatorios están completos

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuarClave();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuarClave();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            bool esArgentino = rdoArgentino.Checked;
            bool esExtranjero = rdoExtranjero.Checked;

            if (txtDocumento.Text == usuarioLogueado.Dni && txtClave.Text == usuarioLogueado.Clave )
            {
                lblTitulo.Text = $"Bienvenido {usuarioLogueado.Nombre}!";

                if (esArgentino)
                {
                    usuarioLogueado = new UsuarioArgentino();
                }
                else if (esExtranjero)
                {
                    usuarioLogueado = new UsuarioExtranjero();
                }

                this.Hide();
                FormInicio usuarioRegistrado= new FormInicio(usuarioLogueado);
                usuarioRegistrado.Show();

            }
            else
            {
                MessageBox.Show("Error los datos no coinciden. Reingreselos. Muchas Gracias");
            }
        }
    }
}
