using Entidades;
using Newtonsoft.Json;
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

    /// <summary>
    /// Primer formulario que se inicializa al ejecutar la aplicacion
    /// hereda el diseño de un formulario padre
    /// </summary>
    public partial class FormularioLoguin : LoguinPadre
    {
        TarjetaInternacional tarjetaInt = new TarjetaInternacional();
        TarjetaNacional tarjetaNac = new TarjetaNacional();

        public FormularioLoguin()
        {
            InitializeComponent();
            CargarJson();
            ArchivoMensaje.listaBajas = ArchivoMensaje.DeserializarMensajesBajaDesdeArchivo();
        }

        /// <summary>
        /// Metodo para cargar las listas con datos en los Json
        /// </summary>
        private void CargarJson()
        {
            List<TarjetaNacional> tajetaNacionalCargadas = tarjetaNac.CargarDesdeArchivo("tarjetaNacional.json");
            List<TarjetaInternacional> tarjetaInternacionalCargadas = tarjetaInt.CargarDesdeArchivo("tarjetaInternacional.json");
            List<Usuario> usuariosCargados = ManejoDeListados.DeserializeUsuarios();
            TarjetaNacional.listaTarjetasNacionales = tajetaNacionalCargadas;
            TarjetaInternacional.listaTarjetasIntenacionales = tarjetaInternacionalCargadas;
            Listados.listaUsuarios = usuariosCargados;
            
        }
        
        /// <summary>
        /// Evento para el logeo
        /// Pide dni y clave
        /// Lo busca en la lista
        /// Castea segun su clade heredada
        /// Lo manda al formulario inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            try
            {
                string dni = txtUsuario.Text;
                string clave = txtPassword.Text;
                object usuario = ManejoDeListados.ObtenerUsuarioPorDniYTarjeta(dni);
                if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(clave) )
                {
                    throw new Exception();
                }

                if (usuario != null)
                {
                    if (usuario is UsuarioSinTarjeta)
                    {

                        UsuarioSinTarjeta usuarioLogueado = (UsuarioSinTarjeta)usuario;
                        if (usuarioLogueado.ValidarClave(clave))
                        {
                            MessageBox.Show("El usuario no tiene tarjeta", "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormInicio inicio = new FormInicio(usuarioLogueado);
                            inicio.Show();
                            this.Hide();
                        }
                        else { throw new ClaveInvalidaException(); }
                    }
                    else if (usuario is UsuarioArgentino)
                    {
                        
                        UsuarioArgentino usuarioLogueado = (UsuarioArgentino)usuario;
                        if (usuarioLogueado.ValidarClave(clave))
                        {
                            MessageBox.Show("El usuario tiene tarjeta argentina", "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormInicio inicio = new FormInicio(usuarioLogueado);
                            inicio.Show();
                            this.Hide();
                        }
                        else { throw new ClaveInvalidaException(); }
                    }
                    else if (usuario is UsuarioExtranjero)
                    {
                        UsuarioExtranjero usuarioLogueado = (UsuarioExtranjero)usuario;
                        if (usuarioLogueado.ValidarClave(clave))
                        {
                            MessageBox.Show("El usuario tiene tarjeta extranjera", "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            FormInicio inicio = new FormInicio(usuarioLogueado);
                            inicio.Show();
                            this.Hide();
                        }
                        else { throw new ClaveInvalidaException(); }

                    }
                    else if (usuario is UsuarioAdministrador)
                    {
                        MessageBox.Show("Administrador", "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UsuarioAdministrador usuarioLogueado = (UsuarioAdministrador)usuario;
                        if (usuarioLogueado.ValidarClave(clave))
                        {
                            FormAdministrador admin = new FormAdministrador();
                            admin.Show();
                            this.Hide();
                        }
                        else { throw new ClaveInvalidaException(); }
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (ClaveInvalidaException ex)
            {
                MessageBox.Show("La clave ingresada es incorrecta. Por favor, inténtelo de nuevo.", "Error de clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error al intentar iniciar sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// evento para cerrar la apliicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            tarjetaInt.GuardarEnArchivo(TarjetaInternacional.listaTarjetasIntenacionales, "tarjetaInternacional.json");
            tarjetaNac.GuardarEnArchivo(TarjetaNacional.listaTarjetasNacionales, "tarjetaNacional.json");
            Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
            this.Close();
            Application.Exit();
        }

        //boton para llenar el usuario y password con un usuario de la lista
        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "000";
            txtPassword.Text = "1234";

        }

        /// <summary>
        /// Boton para el registro con dialogo entre formularios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();
            /*
            using (FormRegistro formRegistro = new FormRegistro())
            {
                formRegistro.ShowDialog();

                if (formRegistro.ProcesoCompletado)
                {
                    Listados.listaUsuarios.Add(formRegistro.nuevoUsuarioRegistrado);
                }
            }*/

        }


    }
}
