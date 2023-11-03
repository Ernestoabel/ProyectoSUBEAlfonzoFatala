using Entidades;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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

        #region Controlers

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();

            FormInicio form = new FormInicio(usuarioLogueado);
            form.Show();

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            bool esArgentino = rdoArgentino.Checked;
            bool esExtranjero = rdoExtranjero.Checked;
            string dni = txtDocumento.Text;
            string clave = txtClave.Text;


            List<Viajes> nuevosViajes = new List<Viajes>();
            TarjetaNacional tarjetaNacional = new TarjetaNacional(1002, 0, nuevosViajes);
            TarjetaInternacional tarjetaInternacional = new TarjetaInternacional(5002, 0, nuevosViajes); ;

            if (dni == usuarioLogueado.Dni && clave == usuarioLogueado.Clave)
            {
                lblTitulo.Text = $"Bienvenido {usuarioLogueado.Nombre}!";

                //Aca esta el problema de por que se duplica el usuario
                //Vos estas agregando un nuevo usuario con datos del usuario que te traes a la lista con una tarjeta
                //Pero como no quitas al usuario anterior de la lista se duplica el usuario
                if (esArgentino)
                {
                    string idEnString = tarjetaNacional.Id.ToString();
                    UsuarioArgentino usuarioArgentino = new UsuarioArgentino(usuarioLogueado.Nombre, usuarioLogueado.Apellido,
                        usuarioLogueado.Dni, usuarioLogueado.Clave, idEnString, tarjetaNacional);
                    TarjetaNacional tarjetaNac = new TarjetaNacional();

                    Listados.AgregarUsuario(usuarioArgentino);
                    RemoverUsuarioSinTarjetaLocalizado();

                    TarjetaNacional.listaTarjetasNacionales.Add(tarjetaNacional);
                    //tarjetaNacional.AgregarElementoSQL();
                    tarjetaNac.GuardarEnArchivo(TarjetaNacional.listaTarjetasNacionales, "tarjetaNacional.json");
                    Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
                    //Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);

                    FormInicio usuarioRegistrado = new FormInicio(usuarioArgentino);
                    usuarioRegistrado.Show();

                }
                else if (esExtranjero)
                {
                    string idEnString = tarjetaInternacional.Id.ToString();
                    // UsuarioExtranjero usuarioExtranjero = new UsuarioExtranjero();
                    UsuarioExtranjero usuarioExtranjero = new UsuarioExtranjero(usuarioLogueado.Nombre, usuarioLogueado.Apellido,
                        usuarioLogueado.Dni, usuarioLogueado.Clave, idEnString, tarjetaInternacional);
                    TarjetaInternacional tarjetaInt = new TarjetaInternacional();
                    Listados.AgregarUsuario(usuarioExtranjero);
                    RemoverUsuarioSinTarjetaLocalizado();
                    TarjetaInternacional.listaTarjetasIntenacionales.Add(tarjetaInternacional);
                    //tarjetaInternacional.AgregarElementoSQL();
                    tarjetaInt.GuardarEnArchivo(TarjetaInternacional.listaTarjetasIntenacionales, "tarjetaInternacional.json");
                    Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
                    //Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);

                    FormInicio usuarioRegistrado = new FormInicio(usuarioExtranjero);
                    usuarioRegistrado.Show();

                }

                this.Hide();


            }
            else
            {
                MessageBox.Show("Error los datos no coinciden. Reingreselos. Muchas Gracias");
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        ///  Permite habilitar el boton continuar si los datos fueron ingresados
        /// </summary>
        /// <returns></returns>
        private bool HabilitarContinuarClave()
        {
            if (string.IsNullOrEmpty(txtDocumento.Text) ||
                string.IsNullOrEmpty(txtClave.Text))
            {
                return false; // Faltan datos obligatorios
            }

            return true; // Todos los datos obligatorios están completos

        }

        private void RemoverUsuarioSinTarjetaLocalizado()
        {

            UsuarioSinTarjeta usuarioArgentinoExistente = Listados.listaUsuarios
           .OfType<UsuarioSinTarjeta>()
           .FirstOrDefault(u => u.Dni == usuarioLogueado.Dni);

            if (usuarioArgentinoExistente != null)
            {
                // Eliminamos el usuario anterior del mismo tipo
                Listados.listaUsuarios.Remove(usuarioArgentinoExistente);
            }
        }



        #endregion

        #region Eventos Controlers


        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuarClave();
            string dni = txtDocumento.Text;

            if (dni.Length == 8)
            {
                // El DNI tiene 8 dígitos, por lo que se considera "Argentino"
                rdoArgentino.Checked = true;
                rdoExtranjero.Checked = false;
            }
            else if (dni.Length == 9)
            {
                // El DNI tiene 9 dígitos, por lo que se considera "Extranjero"
                rdoArgentino.Checked = false;
                rdoExtranjero.Checked = true;
            }
            else
            {
                // Longitud de DNI no válida, deseleccionar ambos botones
                rdoArgentino.Checked = false;
                rdoExtranjero.Checked = false;
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

            string clave = txtClave.Text;

            // Verifica si la clave es numérica y tiene exactamente 4 dígitos
            if (!string.IsNullOrEmpty(clave) && clave.All(char.IsDigit) && clave.Length == 4 && clave == usuarioLogueado.Clave)
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
        /// Solo deja ingresar hasta 9 numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == 8)
            {

                string dniIngresado = txtDocumento.Text;

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

        /// <summary>
        ///     Solo deja ingresar numeros hasta 4digitos.
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

        #endregion

    }
}
