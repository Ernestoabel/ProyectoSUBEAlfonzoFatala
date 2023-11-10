using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormCarga : Form
    {
        object usuarioLogueado;
        private bool contraseñaCheck;
        private bool montoCheck;
        Action<object> pasarObjeto;

        private decimal saldoEnTarjeta;
        TarjetaNacional tarjetaNacional = new TarjetaNacional();
        TarjetaInternacional tarjetaInternacional = new TarjetaInternacional();


        public FormCarga()
        {
            InitializeComponent();
            btnAcreditarSaldo.Enabled = false;
            contraseñaCheck = false;
            montoCheck = false;
        }

        #region Eventos
        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            string monto = txtMonto.Text;

            if (IsNumeric(monto))
            {
                // El contenido es un número válido
                txtMonto.BackColor = System.Drawing.Color.GreenYellow;
                montoCheck = true;
            }
            else
            {
                // El contenido no es un número válido
                txtMonto.BackColor = System.Drawing.Color.LightCoral;
            }
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

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            string clave = txtClave.Text;

            if (usuarioLogueado is Usuario usuario)
            {
                if (!string.IsNullOrEmpty(clave) && clave.All(char.IsDigit) && clave.Length == 4 && clave == usuario.Clave)
                {
                    // La clave es válida, puedes habilitar el botón de continuar o realizar otras acciones.
                    btnAcreditarSaldo.Enabled = true;
                    contraseñaCheck = true;
                }
                else
                {
                    // La clave no cumple con los requisitos, puedes deshabilitar el botón de continuar o mostrar un mensaje de error.
                    btnAcreditarSaldo.Enabled = false;
                }
            }
        }
        #endregion

        private bool IsNumeric(string text)
        {
            return double.TryParse(text, out _);
        }

        private void btnAcreditarSaldo_Click(object sender, EventArgs e)
        {

            if (contraseñaCheck && montoCheck)
            {
                if (usuarioLogueado is UsuarioArgentino usuarioArgentino)
                {

                    //TarjetaNacional tarjetaNacional = new TarjetaNacional();
                    decimal saldoDecimal = decimal.Parse(txtMonto.Text);
                    tarjetaNacional.CargarSaldo(saldoDecimal);

                    string saldoActual = tarjetaNacional.Saldo.ToString();
                    string saldoAcreditado = txtMonto.Text;

                    string condicion = $"Id = {tarjetaNacional.Id}";

                    tarjetaNacional.ActualizarEnBaseDeDatos(condicion);

                    VentanaEmergenteSaldo ventanaEmergenteSaldo = new VentanaEmergenteSaldo(saldoActual, saldoAcreditado);
                    ventanaEmergenteSaldo.ShowDialog();

                    if (ventanaEmergenteSaldo.DialogResult == DialogResult.OK)
                    {
                        this.Close();
                        FormInicio inicio = new FormInicio();
                        this.pasarObjeto += inicio.RecivirObjeto;
                        this.pasarObjeto.Invoke(usuarioLogueado);
                        //inicio.Show();
                    }

                }
                else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
                {
                    TarjetaNacional tarjetaNacional = new TarjetaNacional();
                    decimal saldoDecimal = decimal.Parse(txtMonto.Text);
                    tarjetaNacional.CargarSaldo(saldoDecimal);

                    string saldoActual = tarjetaNacional.Saldo.ToString();
                    string saldoAcreditado = txtMonto.Text;

                    string condicion = $"Id = {tarjetaNacional.Id}";

                    tarjetaNacional.ActualizarEnBaseDeDatos(condicion);

                    VentanaEmergenteSaldo ventanaEmergenteSaldo = new VentanaEmergenteSaldo(saldoActual, saldoAcreditado);
                    ventanaEmergenteSaldo.ShowDialog();

                    if (ventanaEmergenteSaldo.DialogResult == DialogResult.OK)
                    {
                        this.Close();
                        FormInicio inicio = new FormInicio();
                        this.pasarObjeto += inicio.RecivirObjeto;
                        this.pasarObjeto.Invoke(usuarioLogueado);
                       // inicio.Show();
                    }
                }

            }
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
                    btnAcreditarSaldo.Enabled = true;
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
                    btnAcreditarSaldo.Enabled = true;
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
                btnAcreditarSaldo.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormInicio form = new FormInicio();
            form.Show();
        }
    }
}
