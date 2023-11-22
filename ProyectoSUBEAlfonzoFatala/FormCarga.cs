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
using Tulpep.NotificationWindow;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormCarga : Form
    {
        Usuario usuarioLogueado;
        private bool contraseñaCheck;
        private bool montoCheck;
        Action<Usuario> pasarObjeto;
        private string saldo;

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

        public string devolverDato
        {
            get { return saldo; }
            set { saldo = value; }
        }

        #region Eventos

        /// <summary>
        /// Verifica si el saldo ingresado es correct0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            string monto = txtMonto.Text;
            int numero;

            if (IsNumeric(monto))
            {
                numero = Convert.ToInt32(monto);

                if (numero < 6000)
                {
                    // El contenido es un número válido
                    txtMonto.BackColor = System.Drawing.Color.GreenYellow;
                    montoCheck = true;

                }
            }
            else
            {
                // El contenido no es un número válido
                txtMonto.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        /// <summary>
        /// al momento de acreditar el saldo por medio de la tarjta
        /// lo carga a ese nuevo saldo en la base de datos y genera 
        /// una factura pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    TarjetaNacional.GenerarFacturaPDF(tarjetaNacional, saldoAcreditado);

                    devolverDato = tarjetaNacional.Saldo.ToString();

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
                    //TarjetaInternacional tarjetaInternacional = new TarjetaNacional();
                    decimal saldoDecimal = decimal.Parse(txtMonto.Text);
                    tarjetaInternacional.CargarSaldo(saldoDecimal);

                    string saldoActual = tarjetaInternacional.Saldo.ToString();
                    string saldoAcreditado = txtMonto.Text;

                    string condicion = $"Id = {tarjetaInternacional.Id}";

                    tarjetaInternacional.ActualizarEnBaseDeDatos(condicion);
                    TarjetaInternacional.GenerarFacturaPDF(tarjetaInternacional, saldoAcreditado);

                    devolverDato = tarjetaInternacional.Saldo.ToString();

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

        /// <summary>
        /// evento para el ingreso del teclado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// metodo para verificar los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region Metodos

        /// <summary>
        /// verifica que el numero sea entero
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool IsNumeric(string text)
        {
            return double.TryParse(text, out _);
        }

        /// <summary>
        /// Trae los datos de la tarjeta delusuario
        /// </summary>
        /// <param name="usuario"></param>
        public void TraerUsuario(Usuario usuario)
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
                PopUpUsuarioError("Error", "Usuario sin tarjeta");
                btnAcreditarSaldo.Enabled = false;
            }
            catch (Exception)
            {
                PopUpUsuarioError("Error", "sucedio un error desconocido");
                // MessageBox.Show("Ocurrio un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private static void PopUpUsuarioError(string titulo, string subtitulo)
        {

            string rutaImagen = @"..\..\..\Assets\errorLogueo.png";

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Image.FromFile(rutaImagen);
            popup.BodyColor = Color.FromArgb(220, 53, 69);
            popup.TitleText = titulo;
            popup.TitleColor = Color.White;
            popup.TitleFont = new Font("Century Gothic", 15, FontStyle.Bold);

            popup.ContentText = subtitulo;
            popup.ContentColor = Color.White;
            popup.ContentFont = new Font("Century Gothic", 12);
            popup.Popup();
        }

        private void FormCarga_Load(object sender, EventArgs e)
        {

        }
    }

}
