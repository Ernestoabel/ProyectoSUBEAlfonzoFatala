using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormRegistro : Form
    {
        private int contador = 0;
        Usuario nuevoUsuarioRegistrado = new Usuario();

        public FormRegistro()
        {
            InitializeComponent();
            //this.IsMdiContainer = true;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidarCampos())
            {
                MessageBox.Show("Datos ingresados correctamente");

                contador++;

                //FormRegistro2 formClave = new FormRegistro2();
                //formClave.MdiParent = this;

                pbrPasos.PerformStep();
                lblPaso1.Text = "Paso 2";

                //formClave.Show();

                btnContinuar.Location = new System.Drawing.Point(377, 300);

                lblClave.Visible = true;
                txtClave.Visible = true;
                lblRepetirClave.Visible = true;
                txtRepetirClave.Visible = true;

                GuardarDatos();

                if(ValidarClaves())
                {
                    MessageBox.Show("Clave valida");
                }

                //if (contador >= 1)
                //{

                //    //this.Close();
                //}


                //btnContinuar.Location = new System.Drawing.Point(114, 357);

                /*FormRegistro formRegistro = new FormRegistro();
                formRegistro.Show();*/

            }


        }


        private bool GuardarDatos()
        {

            if (contador == 1)
            {

                //Tarjeta nuevaTarjeta = new TarjetaNacional();
                //Tarjeta nuevaTarjetaInternacional = new TarjetaInternacional();


                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string dni = txtDni.Text;
                bool tieneTarjeta = true;


                nuevoUsuarioRegistrado.Nombre = nombre;
                nuevoUsuarioRegistrado.Apellido = apellido;
                nuevoUsuarioRegistrado.Dni = dni;

                nuevoUsuarioRegistrado.TieneTarjeta = tieneTarjeta;

            }
            else
            {
                string clave = txtClave.Text;
                nuevoUsuarioRegistrado.Clave = clave;

                Usuario usuario = nuevoUsuarioRegistrado;
                MostrarUsuarioEnControles(usuario);

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
           

           /* if (txtClave.Text == "")
            {
                ok = false;
                errorProviderRegistro.SetError(txtClave, "Ingresar Clave");
            }
            if (txtRepetirClave.Text == "")
            {
                ok = false;
                errorProviderRegistro.SetError(txtRepetirClave, "Ingresar Clave");
            }*/


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
                errorProviderRegistro.SetError(txtRepetirClave, "Ingresar Clave");
            }
            return ok;
        }

        private void BorrarMensajeError()
        {
            errorProviderRegistro.SetError(txtNombre, "");
            errorProviderRegistro.SetError(txtApellido, "");
            errorProviderRegistro.SetError(txtDni, "");
            errorProviderRegistro.SetError(txtClave, "");
            errorProviderRegistro.SetError(txtRepetirClave, "");

        }

    }
}
