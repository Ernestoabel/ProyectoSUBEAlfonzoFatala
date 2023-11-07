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
        FormCarga formCarga = new FormCarga();

        public FormCargarSaldo()
        {
            InitializeComponent();
            TopLevel = false;
            CenterToParent();
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (usuarioLogueado is not UsuarioSinTarjeta)
            {
                formCarga.TraerUsuario(usuarioLogueado);
                formCarga.Dock = DockStyle.Fill;
                formCarga.Show();
                
            }
            else
            {
                MessageBox.Show("Usted no tiene tarjeta", "Usted no tiene tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCargar.Enabled = false;
            }
        }

        private void btnVerSaldo_Click(object sender, EventArgs e)
        {
            if (usuarioLogueado is UsuarioArgentino usuarioLogueadoArgentino)
            {
                MessageBox.Show($"Tu saldo es de {usuarioLogueadoArgentino.TarjetaNacional.Saldo}");

            }
            else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
            {
                MessageBox.Show($"Tu saldo es de {usuarioExtranjero.TarjetaInternacional.Saldo}");
            }
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

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
