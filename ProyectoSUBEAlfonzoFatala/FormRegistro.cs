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
        public bool ProcesoCompletado { get; private set; }
        private int contador = 0;
        public UsuarioSinTarjeta nuevoUsuarioRegistrado = new UsuarioSinTarjeta();


        public FormRegistro()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormRegistro_Load(object sender, EventArgs e)
        {
            btnContinuar.Enabled = false;
        }

        /// <summary>
        ///  Se cancelan los procesos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ProcesoCompletado = false;
            this.Close();
        }

        /// <summary>
        /// Permite comprar la tarjeta y ponerla a su nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            bool claveValida = ValidarClaves();

            BorrarMensajeError();
            if (ValidarCampos())
            {
                //MessageBox.Show("Datos ingresados correctamente");

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
                //MessageBox.Show($"Bienvenido {nuevoUsuarioRegistrado.Nombre}! ");
                //this.Hide();
                UsuarioSinTarjeta usuario = nuevoUsuarioRegistrado;
                MostrarUsuarioEnControles(usuario);

                this.DialogResult = DialogResult.OK;
                ProcesoCompletado = true;
                //FormInicio formInicio = new FormInicio(usuario);
                //formInicio.Show();
                this.Close();
            }



        }

        /// <summary>
        /// valida los error provider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDni_Validating(object sender, CancelEventArgs e)
        {
            int num;

            //si el valor ingresado no es correcto, que devuelva el valor en variable nmum
            if (!int.TryParse(txtDni.Text, out num))
            {
                errorProviderRegistro.SetError(txtDni, "Ingrese valor numerico");
            }

        }

        /// <summary>
        /// si se cumple la verificaracion es posible continuar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuar();
        }

        /// <summary>
        /// si se cumple la verificacion es posible continuar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuar();
        }

        /// <summary>
        /// evento para corroborar el dni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            bool dniEncontrado = EncontrarDni();
            string dniIngresado = txtDni.Text;


            if (!dniEncontrado && dniIngresado.Length >= 8)
            {
                btnContinuar.Enabled = HabilitarContinuar();
            }
            else
            {
                btnContinuar.Enabled = false;
            }

        }

        /// <summary>
        /// Evento para verificar clave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClave_TextChanged(object sender, EventArgs e)
        {

            string claveIngresada = txtClave.Text;

            // Verifica si la clave es numérica y tiene exactamente 4 dígitos
            if (!string.IsNullOrEmpty(claveIngresada) && claveIngresada.All(char.IsDigit) && claveIngresada.Length == 4)
            {
                // La clave es válida, puedes habilitar el botón de continuar o realizar otras acciones.
                btnContinuar.Enabled = HabilitarContinuarClave();
            }
            else
            {
                // La clave no cumple con los requisitos, puedes deshabilitar el botón de continuar o mostrar un mensaje de error.
                btnContinuar.Enabled = HabilitarContinuarClave();
            }

        }

        /// <summary>
        /// Corrobora si la claves coinciden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRepetirClave_TextChanged(object sender, EventArgs e)
        {
            string claveConfirmada = txtRepetirClave.Text;

            if (!string.IsNullOrEmpty(claveConfirmada) && claveConfirmada.All(char.IsDigit) && claveConfirmada.Length == 4 && claveConfirmada == txtClave.Text)
            {
                // La clave es válida, puedes habilitar el botón de continuar o realizar otras acciones.
                btnContinuar.Enabled = true;
            }
            else
            {
                // La clave no cumple con los requisitos, puedes deshabilitar el botón de continuar o mostrar un mensaje de error.
                btnContinuar.Enabled = false;
            }
        }

        /// <summary>
        /// eventp para agregar solo 4 digitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == 8)
            {
                string claveIngresada = txtClave.Text;

                // Permitir la edición si no se alcanza el límite de 9 caracteres
                if (claveIngresada.Length <= 3 || e.KeyChar == 8)
                {
                    e.Handled = false; // Permitir la entrada del carácter
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true; // Cancelar la entrada de caracteres no deseados
            }
        }

        /// <summary>
        /// metodo para solo ingresar 4 digitos en la clave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRepetirClave_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == 8)
            {
                string claveIngresada = txtRepetirClave.Text;

                // Permitir la edición si no se alcanza el límite de 9 caracteres
                if (claveIngresada.Length <= 3 || e.KeyChar == 8)
                {
                    e.Handled = false; // Permitir la entrada del carácter
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true; // Cancelar la entrada de caracteres no deseados
            }
        }

        /// <summary>
        /// Corrobora que se esten ingresando los datos del teclado correctos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada de caracteres no deseados
            }
        }

        /// <summary>
        /// Corrobora que se esten ingresando los datos del teclado correctos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar la entrada de caracteres no deseados
            }
        }

        /// <summary>
        /// Corrobora que se esten ingresando los datos del teclado correctos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion

        #region Metodos
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
                //nuevoUsuarioRegistrado = new UsuarioSinTarjeta();


            }
            else
            {
                if (contador > 1)
                {
                    string clave = txtClave.Text;
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string dni = txtDni.Text;
                    //bool tieneTarjeta = false;

                    nuevoUsuarioRegistrado.Nombre = nombre;
                    nuevoUsuarioRegistrado.Apellido = apellido;
                    nuevoUsuarioRegistrado.Dni = dni;
                    //nuevoUsuarioRegistrado.TieneTarjeta = tieneTarjeta;
                    nuevoUsuarioRegistrado.Clave = clave;


                }


            }


            return true;
        }

        /// <summary>
        /// Muestra los datos del usuario actual
        /// </summary>
        /// <param name="usuario"></param>
        private void MostrarUsuarioEnControles(Usuario usuario)
        {
            string informacion = $"Nombre: {usuario.Nombre}\nApellido: {usuario.Apellido}\nDNI: {usuario.Dni}\nClave: {usuario.Clave}\nTieneTarjeta: {(usuario.TieneTarjeta ? "Sí" : "No")}";
            string nombre = $"{usuario.Nombre} {usuario.Apellido}";

            VentanaBienvenida bienvenida = new VentanaBienvenida(nombre);
            bienvenida.ShowDialog();

            if(bienvenida.DialogResult == DialogResult.OK)
            {
                bienvenida.Close();

            }
           // MessageBox.Show(informacion, "Datos del Usuario Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Valida que el usuario haya colocado en el textbox los datos pertinentes
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Verifica que el usuario escriba en el text box las claves
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Una vez verifica los textbox permite continuar con el registro
        /// </summary>
        /// <returns></returns>
        private bool HabilitarContinuar()
        {
            string dniIngresado = txtDni.Text;

            bool dniNoIngresado = EncontrarDni();

            if (string.IsNullOrEmpty(txtNombre.Text) ||
             string.IsNullOrEmpty(txtApellido.Text) ||
             string.IsNullOrEmpty(dniIngresado) && dniIngresado.Length >= 8 && dniIngresado.Length <= 9 && dniNoIngresado)
            {
                return false; // Faltan datos obligatorios
            }

            return true; // Todos los datos obligatorios están completos

        }

        /// <summary>
        /// En el paso 2 del registro permite continuar con las claves
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Recorre la lista de usuarios  y corrovora si el usuario ya 
        /// tiene una tarjeta registrada
        /// </summary>
        /// <returns></returns>
        private bool EncontrarDni()
        {

            string dniBuscado = txtDni.Text; // DNI que deseas buscar

            bool dniEncontrado = false;

            foreach (Usuario usuario in Listados.listaUsuarios)
            {
                if (usuario.Dni == dniBuscado)
                {
                    dniEncontrado = true;
                    
                    MessageBox.Show("El usuario ya está registrado. No se puede registrar nuevamente.", "Usuario Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDni.Clear();
                    break; 
                }
            }

            return dniEncontrado;
        }

        /// <summary>
        /// Elimina los error provider
        /// </summary>
        private void BorrarMensajeError()
        {
            errorProviderRegistro.SetError(txtNombre, "");
            errorProviderRegistro.SetError(txtApellido, "");
            errorProviderRegistro.SetError(txtDni, "");
            errorProviderRegistro.SetError(txtClave, "");
            errorProviderRegistro.SetError(txtRepetirClave, "");

        }

        #endregion

    }
}