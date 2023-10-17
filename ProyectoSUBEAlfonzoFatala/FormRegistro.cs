using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormRegistro : Form
    {
        // Listados listado = new Listados();
        private int contador = 0;
        Usuario nuevoUsuarioRegistrado = new Usuario();
        Tarjeta nuevaTarjetaNacional = new TarjetaNacional();
        Tarjeta nuevaTarjetaInternacional = new TarjetaInternacional();


        public FormRegistro()
        {
            InitializeComponent();
            //this.IsMdiContainer = true;


        }
        private void FormRegistro_Load(object sender, EventArgs e)
        {
            btnContinuar.Enabled = false;

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            bool claveValida = ValidarClaves();

            BorrarMensajeError();
            if (ValidarCampos())
            {
                MessageBox.Show("Datos ingresados correctamente");

                contador++;

                pbrPasos.PerformStep();
                lblPaso1.Text = "Paso 2";


                lblClave.Visible = true;
                txtClave.Visible = true;
                lblRepetirClave.Visible = true;
                txtRepetirClave.Visible = true;

                GuardarDatos();

            }
            if (claveValida)
            {

                GuardarDatos();
                MessageBox.Show($"Bienvenido {nuevoUsuarioRegistrado.Nombre}! ");
                //this.Hide();
                Usuario usuario = nuevoUsuarioRegistrado;
                MostrarUsuarioEnControles(usuario);
                Listados.AgregarUsuario(usuario);
                Listados.listaUsuarios.Add(usuario);

                FormInicio formInicio = new FormInicio(usuario);
                formInicio.Show();
            }



        }

        /// <summary>
        /// Guarda los datos ingresados en un objeto usuario y luego lo agrega a la lista
        /// </summary>
        /// <returns></returns>
        private bool GuardarDatos()
        {

            if (contador == 1)
            {

                // Tarjeta nuevaTarjeta = new TarjetaNacional();
                //Tarjeta nuevaTarjetaInternacional = new TarjetaInternacional();


                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string dni = txtDni.Text;
                bool tieneTarjeta = false;



                nuevoUsuarioRegistrado.Nombre = nombre;
                nuevoUsuarioRegistrado.Apellido = apellido;
                nuevoUsuarioRegistrado.Dni = dni;
                nuevoUsuarioRegistrado.TieneTarjeta = tieneTarjeta;
                nuevoUsuarioRegistrado = new UsuarioSinTarjeta();


            }
            else
            {
                if (contador > 1)
                {
                    string clave = txtClave.Text;
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string dni = txtDni.Text;
                    bool tieneTarjeta = false;

                    nuevoUsuarioRegistrado.Nombre = nombre;
                    nuevoUsuarioRegistrado.Apellido = apellido;
                    nuevoUsuarioRegistrado.Dni = dni;
                    nuevoUsuarioRegistrado.TieneTarjeta = tieneTarjeta;
                    nuevoUsuarioRegistrado.Clave = clave;


                }


            }


            return true;
        }

        private void MostrarUsuarioEnControles(Usuario usuario)
        {
            string informacion = $"Nombre: {usuario.Nombre}\nApellido: {usuario.Apellido}\nDNI: {usuario.Dni}\nClave: {usuario.Clave}\nTieneTarjeta: {(usuario.TieneTarjeta ? "Sí" : "No")}";

            MessageBox.Show(informacion, "Datos del Usuario Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        /// <summary>
        /// Verifica si un string es solo alfabetico
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool EsCadenaDeCaracteres(string input)
        {
            // Patrón de expresión regular que coincide con letras mayúsculas y minúsculas.
            string patron = "^[A-Za-z]+$";

            // Usar Regex.IsMatch para verificar si el input coincide con el patrón.
            return Regex.IsMatch(input, patron);
        }

        private bool ValidarCampos()
        {
            bool ok;
            ok = true;

            if (txtNombre.Text == "")
            {
                ok = false;
                errorProviderRegistro.SetError(txtNombre, "Ingresar Nombre");
            }
            if (txtApellido.Text == "")
            {
                ok = false;
                errorProviderRegistro.SetError(txtApellido, "Ingresar Apellido");
            }
            if (txtDni.Text == "")
            {
                ok = false;
                errorProviderRegistro.SetError(txtDni, "Ingresar DNI");
            }

            return ok;
        }

        private bool ValidarClaves()
        {
            bool ok;
            ok = true;

            if (txtClave.Text == "")
            {
                ok = false;
                errorProviderRegistro.SetError(txtClave, "Ingresar Clave");
            }
            if (txtRepetirClave.Text == "")
            {
                ok = false;
                errorProviderRegistro.SetError(txtRepetirClave, "Repetir Clave");
            }
            if (txtClave.Text != txtRepetirClave.Text)
            {
                ok = false;
                errorProviderRegistro.SetError(txtRepetirClave, "Las Claves no coinciden");
            }

            return ok;
        }

        private bool HabilitarContinuar()
        {


            if (string.IsNullOrEmpty(txtNombre.Text) ||
             string.IsNullOrEmpty(txtApellido.Text) ||
             string.IsNullOrEmpty(txtDni.Text))
            {
                return false; // Faltan datos obligatorios
            }

            return true; // Todos los datos obligatorios están completos

        }

        private bool HabilitarContinuarClave()
        {
            string clave = txtClave.Text;
            string repetirClave = txtRepetirClave.Text;

            if (string.IsNullOrEmpty(clave) && clave.All(char.IsDigit) && clave.Length == 4 ||
             string.IsNullOrEmpty(repetirClave) && repetirClave.All(char.IsDigit) && repetirClave.Length == 4)
            {
                return false; // Faltan datos obligatorios
            }

            return true; // Todos los datos obligatorios están completos

        }




        private void BorrarMensajeError()
        {
            errorProviderRegistro.SetError(txtNombre, "");
            errorProviderRegistro.SetError(txtApellido, "");
            errorProviderRegistro.SetError(txtDni, "");
            errorProviderRegistro.SetError(txtClave, "");
            errorProviderRegistro.SetError(txtRepetirClave, "");

        }

        private void txtDni_Validating(object sender, CancelEventArgs e)
        {
            int num;

            //si el valor ingresado no es correcto, que devuelva el valor en variable nmum
            if (!int.TryParse(txtDni.Text, out num))
            {
                errorProviderRegistro.SetError(txtDni, "Ingrese valor numerico");
            }

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuar();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuar();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuar();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

            btnContinuar.Enabled = HabilitarContinuarClave();

        }

        private void txtRepetirClave_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuarClave();
        }

        /// <summary>
        /// metodopara agregar solo 4 digitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtClave.Text.Length >= 4 || !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter
            }
        }

        /// <summary>
        /// metodo para solo ingresar 4 digitos en la clave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRepetirClave_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtRepetirClave.Text.Length >= 4 || !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada de caracteres no deseados
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada de caracteres no deseados
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == 8)
            {
                // Obtener el texto actual del TextBox
                string dniIngresado = txtDni.Text;

                // Permitir la edición si no se alcanza el límite de 9 caracteres
                if (dniIngresado.Length < 9 || e.KeyChar == 8)
                {
                    e.Handled = false; // Permitir la entrada del carácter
                }
                else
                {
                    e.Handled = true; // Cancelar la entrada si ya hay 9 caracteres
                }
            }
            else
            {
                e.Handled = true; // Cancelar la entrada de caracteres no deseados
            }
        }
    }
}
