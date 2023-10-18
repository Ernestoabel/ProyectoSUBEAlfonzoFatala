using Entidades;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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


        private bool HabilitarContinuarClave()
        {
            if (string.IsNullOrEmpty(txtDocumento.Text) ||
                string.IsNullOrEmpty(txtClave.Text))
            {
                return false; // Faltan datos obligatorios
            }

            return true; // Todos los datos obligatorios están completos

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            btnContinuar.Enabled = HabilitarContinuarClave();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

            string clave = txtClave.Text;

            // Verifica si la clave es numérica y tiene exactamente 4 dígitos
            if (!string.IsNullOrEmpty(clave) && clave.All(char.IsDigit) && clave.Length == 4)
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

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            bool esArgentino = rdoArgentino.Checked;
            bool esExtranjero = rdoExtranjero.Checked;


            List<Viajes> nuevosViajes = new List<Viajes>();
            TarjetaNacional tarjetaNacional = new TarjetaNacional(1002, 0, nuevosViajes);
            TarjetaInternacional tarjetaInternacional = new TarjetaInternacional(5002, 0, nuevosViajes); ;

            if (txtDocumento.Text == usuarioLogueado.Dni && txtClave.Text == usuarioLogueado.Clave)
            {
                lblTitulo.Text = $"Bienvenido {usuarioLogueado.Nombre}!";

                if (esArgentino)
                {
                    string idEnString = tarjetaNacional.Id.ToString();
                    UsuarioArgentino usuarioArgentino = new UsuarioArgentino(usuarioLogueado.Nombre, usuarioLogueado.Apellido,
                        usuarioLogueado.Dni, usuarioLogueado.Clave, idEnString, tarjetaNacional);

                    Listados.AgregarUsuario(usuarioArgentino);
                    Listados.AgregarTarjetaNacional(tarjetaNacional);
                    Listados.GuardarTarjetaNacionalEnArchivo(Listados.listaTarjetasNacionales);
                    Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);

                    FormInicio usuarioRegistrado = new FormInicio(usuarioArgentino);
                    usuarioRegistrado.Show();

                }
                else if (esExtranjero)
                {
                    string idEnString = tarjetaInternacional.Id.ToString();
                    // UsuarioExtranjero usuarioExtranjero = new UsuarioExtranjero();
                    UsuarioExtranjero usuarioExtranjero = new UsuarioExtranjero(usuarioLogueado.Nombre, usuarioLogueado.Apellido,
                        usuarioLogueado.Dni, usuarioLogueado.Clave, idEnString, tarjetaInternacional);

                    Listados.AgregarUsuario(usuarioExtranjero);
                    Listados.AgregarTarjetaInternacional(tarjetaInternacional);
                    Listados.GuardarTarjetaInternacionalEnArchivo(Listados.listaTarjetasIntenacionales);
                    Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);

                    FormInicio usuarioRegistrado = new FormInicio(usuarioExtranjero);
                    usuarioRegistrado.Show();

                    //ManejoDeListados.ObtenerUsuarioPorDniYTarjeta()

                }

                this.Hide();


            }
            else
            {
                MessageBox.Show("Error los datos no coinciden. Reingreselos. Muchas Gracias");
            }
        }

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();

            FormInicio form = new FormInicio(usuarioLogueado);
            form.Show();

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == 8)
            {
                // Obtener el texto actual del TextBox
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

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtClave.Text.Length >= 4 || !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter
            }
        }
    }
}
