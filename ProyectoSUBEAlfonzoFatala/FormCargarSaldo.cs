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
    public partial class FormCargarSaldo : Form
    {
        object usuarioLogueado;
        public FormCargarSaldo()
        {
            InitializeComponent();

            TopLevel = false;
        }

        public void TraerUsuario(object usuario)
        {
            if (usuario is UsuarioSinTarjeta)
            {
                usuarioLogueado = usuario;

            }
            else if (usuario is UsuarioArgentino)
            {
                usuarioLogueado = usuario;

            }
            else if (usuario is UsuarioExtranjero)
            {
                usuarioLogueado = usuario;

            }
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {
            FormCarga formCarga = new FormCarga();
            formCarga.ShowDialog();
        }

        private void btnVerSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tu saldo es de ");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No podes salir de aqui");

        }

        private void FormCargarSaldo_Load(object sender, EventArgs e)
        {
            try
            {
                insertarDatos(usuarioLogueado);
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void insertarDatos(object usuario)
        {
            if (usuario is UsuarioArgentino)
            {
                UsuarioArgentino usuarioLogueado = (UsuarioArgentino)usuario;
                lblNombre.Text = usuarioLogueado.Nombre.ToString();
                lblApellido.Text = usuarioLogueado.Apellido.ToString();
                lblDni.Text = usuarioLogueado.Dni.ToString();
                lblIdTarjeta.Text = usuarioLogueado.IdSubeArgentina.ToString();
                //lblSaldo.Text = usuarioLogueado.TarjetaNacional.Saldo.ToString();
            }
            else if (usuario is UsuarioExtranjero)
            {
                UsuarioExtranjero usuarioLogueado = (UsuarioExtranjero)usuario;
                lblNombre.Text = usuarioLogueado.Nombre.ToString();
                lblApellido.Text = usuarioLogueado.Apellido.ToString();
                lblDni.Text = usuarioLogueado.Dni.ToString();
                lblIdTarjeta.Text = usuarioLogueado.IdSubeExtranjero.ToString();
               // lblSaldo.Text = usuarioLogueado.TarjetaInternacional.Saldo.ToString();
            }
        }

    }
}
