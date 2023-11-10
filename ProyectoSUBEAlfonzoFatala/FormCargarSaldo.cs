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
        private decimal saldoEnTarjeta;
        FormCarga formCarga = new FormCarga();
        Action<object> pasarObjeto;
        TarjetaNacional tarjetaNacional = new TarjetaNacional();
        TarjetaInternacional tarjetaInternacional = new TarjetaInternacional();

        public FormCargarSaldo()
        {
            InitializeComponent();
            TopLevel = false;
            CenterToParent();

        }

        public void RecibirObjeto(object objeto)
        {
            this.usuarioLogueado = objeto;
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
            try
            {
                if (usuarioLogueado is UsuarioArgentino)
                {
                    this.TraerUsuario(usuarioLogueado);
                    MessageBox.Show($"Su saldo es de {tarjetaNacional.Saldo}");

                }
                else if (usuarioLogueado is UsuarioExtranjero)
                {
                    this.TraerUsuario(usuarioLogueado);
                    MessageBox.Show($"Su saldo es de {tarjetaInternacional.Saldo}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar el saldo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        public void TraerUsuario(object usuario)
        {
            try
            {
                if (usuario is UsuarioSinTarjeta)
                {
                    throw new UsuarioSinTarjetaException();
                }
                else if (usuario is UsuarioArgentino)
                {
                    usuarioLogueado = usuario;
                    btnCargar.Enabled = true;
                    btnVerSaldo.Enabled = true;
                    if (usuario is UsuarioArgentino usuarioArgentino)
                    {

                        int idTarjeta = int.Parse(usuarioArgentino.IdSubeArgentina);
                        tarjetaNacional = TarjetaNacional.listaTarjetasNacionales.FirstOrDefault(tarjeta => tarjeta.Id == idTarjeta);
                        saldoEnTarjeta = tarjetaNacional.Saldo;

                    }

                }
                else if (usuario is UsuarioExtranjero)
                {
                    usuarioLogueado = usuario;
                    btnCargar.Enabled = true;
                    btnVerSaldo.Enabled = true;
                    if (usuario is UsuarioExtranjero usuarioExtranjero)
                    {
                        int idTarjeta = int.Parse(usuarioExtranjero.IdSubeExtranjero);
                        tarjetaInternacional = TarjetaInternacional.listaTarjetasIntenacionales.FirstOrDefault(tarjeta => tarjeta.Id == idTarjeta);
                        saldoEnTarjeta = tarjetaInternacional.Saldo;
                    }
                }
            }
            catch (UsuarioSinTarjetaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCargar.Enabled = false;
                btnVerSaldo.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FormCargarSaldo_Load(object sender, EventArgs e)
        {
            this.insertarDatos(usuarioLogueado);
        }
    }
}
