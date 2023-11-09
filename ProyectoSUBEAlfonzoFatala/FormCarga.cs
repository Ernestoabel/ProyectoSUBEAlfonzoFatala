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
                    decimal saldoDecimal = decimal.Parse(txtMonto.Text);
                    usuarioArgentino.TarjetaNacional.CargarSaldo(saldoDecimal);

                    string saldoActual = usuarioArgentino.TarjetaNacional.Saldo.ToString();
                    string saldoAcreditado = txtMonto.Text;

                    int indice = Listados.listaUsuarios.FindIndex(u => u.Dni == usuarioArgentino.Dni);
                    if (indice >= 0)
                    {
                        usuarioArgentino.TarjetaNacional.GuardarEnArchivo(TarjetaNacional.listaTarjetasNacionales, "tarjetaNacional.json");
                        Listados.listaUsuarios.RemoveAt(indice);
                        Listados.listaUsuarios.Add(usuarioArgentino);
                        Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
                    }

                    VentanaEmergenteSaldo ventanaEmergenteSaldo = new VentanaEmergenteSaldo(saldoActual, saldoAcreditado);
                    ventanaEmergenteSaldo.ShowDialog();

                    if (ventanaEmergenteSaldo.DialogResult == DialogResult.OK)
                    {
                        this.Close();
                        //FormInicio form = new FormInicio(usuarioLogueado);
                        //form.Show();
                    }

                }
                else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
                {
                    decimal saldoDecimal = decimal.Parse(txtMonto.Text);
                    usuarioExtranjero.TarjetaInternacional.CargarSaldo(saldoDecimal);

                    string saldoActual = usuarioExtranjero.TarjetaInternacional.Saldo.ToString();
                    string saldoAcreditado = txtMonto.Text;

                    int indice = Listados.listaUsuarios.FindIndex(u => u.Dni == usuarioExtranjero.Dni);
                    if (indice >= 0)
                    {
                        usuarioExtranjero.TarjetaInternacional.GuardarEnArchivo(TarjetaInternacional.listaTarjetasIntenacionales, "tarjetaInternacional.json");
                        Listados.listaUsuarios.RemoveAt(indice);
                        Listados.listaUsuarios.Add(usuarioExtranjero);
                        Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
                    }

                    VentanaEmergenteSaldo ventanaEmergenteSaldo = new VentanaEmergenteSaldo(saldoActual, saldoAcreditado);
                    ventanaEmergenteSaldo.ShowDialog();

                    if (ventanaEmergenteSaldo.DialogResult == DialogResult.OK)
                    {
                        this.Close();
                        //FormInicio form = new FormInicio(usuarioLogueado);
                        //form.Show();
                    }
                }

            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
        }

        private void insertarDatos(object usuario)
        {
            string clave;

            if (usuario is UsuarioArgentino)
            {
                UsuarioArgentino usuarioLogueado = (UsuarioArgentino)usuario;
                //MessageBox.Show($"El usuario es {usuarioLogueado.Nombre}");
            }
            else if (usuario is UsuarioExtranjero)
            {
                UsuarioExtranjero usuarioLogueado = (UsuarioExtranjero)usuario;
                //MessageBox.Show($"El usuario es {usuarioLogueado.Nombre}");
            }
        }
        private void FormCarga_Load(object sender, EventArgs e)
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

            if (usuario is UsuarioArgentino)
            {
                usuarioLogueado = usuario;

            }
            else if (usuario is UsuarioExtranjero)
            {
                usuarioLogueado = usuario;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //FormInicio form = new FormInicio(usuarioLogueado);
            //form.Show();
        }
    }
}
