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
        
        
        public FormularioLoguin()
        {
            InitializeComponent();
            CargarJson();
            /*
            Listados.listaBajas.Add(new Dictionary<int, string> { { 1, "Mensajes para el administrador" } });
            Listados.GuardarMensajesBajaEnArchivo(Listados.listaBajas);*/
            ArchivoMensaje.listaBajas = ArchivoMensaje.DeserializarMensajesBajaDesdeArchivo();
        }

        /// <summary>
        /// Metodo para cargar las listas con datos en los Json
        /// </summary>
        private static void CargarJson()
        {
            List<TarjetaNacional> tajetaNacionalCargadas = Listados.CargarTarjetaNacionalsDesdeArchivo();
            List<TarjetaInternacional> tarjetaInternacionalCargadas = Listados.CargarTarjetaInternacionalDesdeArchivo();
            List<Usuario> usuariosCargados = ManejoDeListados.DeserializeUsuarios();
            Listados.listaTarjetasNacionales = tajetaNacionalCargadas;
            Listados.listaTarjetasIntenacionales = tarjetaInternacionalCargadas;
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
            this.Close();
            Application.Exit();
        }

        //boton para llenar el usuario y password con un usuario de la lista
        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            /*
            UsuarioSinTarjeta nuevoUsuario = new UsuarioSinTarjeta("Ernesto", "Fatala", "10000000", "1234");
            TarjetaNacional tarjeta1001 = new TarjetaNacional(1001, 500, Listados.ViajeTarjeta1001);
            Listados.AgregarTarjetaNacional(tarjeta1001);
            TarjetaInternacional tarjeta5001 = new TarjetaInternacional(5001, 2000, Listados.ViajeTarjeta5001);
            Listados.AgregarTarjetaInternacional(tarjeta5001);
            Listados.GuardarTarjetaNacionalEnArchivo(Listados.listaTarjetasNacionales);
            Listados.GuardarTarjetaInternacionalEnArchivo(Listados.listaTarjetasIntenacionales);
            UsuarioArgentino nuevoUsuArgentino = new UsuarioArgentino("Carlos", "Pepe", "20000000", "1234", "1001", tarjeta1001);
            UsuarioExtranjero nuevoUsuExtrangero = new UsuarioExtranjero("Carlos", "Pepe", "90000000", "1234", "5001", tarjeta5001);
            UsuarioAdministrador nuevoUsuarioAdmin = new UsuarioAdministrador("Juan", "Perez", "10000001", "1234");
            Listados.AgregarUsuario(nuevoUsuario);
            Listados.AgregarUsuario(nuevoUsuArgentino);
            Listados.AgregarUsuario(nuevoUsuExtrangero);
            Listados.AgregarUsuario(nuevoUsuarioAdmin);
            Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
            */
            txtUsuario.Text = "000";
            txtPassword.Text = "1234";

        }

        //boton para ir al formulario de alta de cliente
        private void btnAlta_Click(object sender, EventArgs e)
        {

            FormRegistro formRegistro = new FormRegistro();

            formRegistro.Show();

            this.Hide();

        }


    }
}
