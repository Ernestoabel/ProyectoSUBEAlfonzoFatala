using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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
        Action<Usuario> pasarObjeto;

        public FormularioLoguin()
        {
            InitializeComponent();
            if (Listados.listaUsuarios.Count == 0)
            {
                CargarSQL();
            }
            PruebaTestUnitario();
            //CargarJson();
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
            //PruebaTestUnitario();
        }

        private void CargarSQL()
        {
            TarjetaNacional.listaTarjetasNacionales = TarjetaNacional.ObtenerDeBaseDeDatos();
            TarjetaInternacional.listaTarjetasIntenacionales = TarjetaInternacional.ObtenerDeBaseDeDatos();
            Listados.listaUsuarios.AddRange(UsuarioSinTarjeta.ObtenerElementosSQL());
            UsuarioArgentino.ObtenerElementosSQL();
            UsuarioExtranjero.ObtenerElementosSQL();
            Listados.listaUsuarios.AddRange(UsuarioAdministrador.ObtenerElementosSQL());
        }
        /// <summary>
        /// Metodo para la implementacion de los test unitarios
        /// </summary>
        public void PruebaTestUnitario()
        {
            var tarjetaIntTests = new TarjetaInternacionalTestsUnitario();
            var tarjetaNacTests = new TarjetaNacionalTestsUnitario();
            tarjetaIntTests.GuardarEnArchivo_SerializaListaCorrectamente();
            tarjetaIntTests.CargarDesdeArchivo_DeserializaListaCorrectamente();
            tarjetaNacTests.GuardarEnArchivo_SerializaListaCorrectamente();
            tarjetaNacTests.CargarDesdeArchivo_DeserializaListaCorrectamente();
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
        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            FormInicio inicio = null;
            lblError.Text = "";
            try
            {
                string dni = txtUsuario.Text;
                string clave = txtPassword.Text;
                object usuario = ManejoDeListados.ObtenerUsuarioPorDniYTarjeta(dni);
                if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(clave))
                {
                    throw new Exception();
                }

                if (usuario != null)
                {
                    inicio = new FormInicio();
                    if (usuario is UsuarioSinTarjeta)
                    {

                        UsuarioSinTarjeta usuarioLogueado = (UsuarioSinTarjeta)usuario;
                        if (usuarioLogueado.ValidarClave(clave))
                        {
                            await Task.Run(() => SuscribirEvento(inicio, usuarioLogueado));

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
                            await Task.Run(() => SuscribirEvento(inicio, usuarioLogueado));
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
                            await Task.Run(() => SuscribirEvento(inicio, usuarioLogueado));
                            inicio.Show();
                            this.Hide();
                        }
                        else { throw new ClaveInvalidaException(); }

                    }
                    else if (usuario is UsuarioAdministrador)
                    {
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
            catch (ClaveInvalidaException)
            {
                PopUpError();
            }
            catch (Exception)
            {
                //lblError.Text = "Error de logueo";
                PopUpError();

            }
            finally
            {
                await Task.Run(() => DesuscribirEvento(inicio));
            }

        }

        /// <summary>
        /// Metodo que usa la nuget Notification Popup
        /// configurado en el error de logueo
        /// </summary>
        private static void PopUpError()
        {
            string rutaImagen = @"..\..\..\Assets\errorLogueo.png";
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Image.FromFile(rutaImagen);
            popup.BodyColor = Color.FromArgb(220, 53, 69);
            popup.TitleText = "Error de Logueo";
            popup.TitleColor = Color.White;
            popup.TitleFont = new Font("Century Gothic", 15, FontStyle.Bold);

            popup.ContentText = "Verifique que los datos esten bien ingresados";
            popup.ContentColor = Color.White;
            popup.ContentFont = new Font("Century Gothic", 12);
            popup.Popup();
        }

        /// <summary>
        /// Metodos para utilizar delegados
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="usuario"></param>
        private void SuscribirEvento(FormInicio inicio, Usuario usuario)
        {
            try
            {
                pasarObjeto += inicio.RecivirObjeto;
                pasarObjeto.Invoke(usuario);
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(FormInicio), nameof(SuscribirEvento), "Error en el metodo", ex);
            }
        }

        private void DesuscribirEvento(FormInicio inicio)
        {
            try
            {
                pasarObjeto -= inicio.RecivirObjeto;

            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(FormInicio), nameof(DesuscribirEvento), "Error en el metodo", ex);
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

        /// <summary>
        /// Boton para cargar por default el administrador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            using (FormRegistro formRegistro = new FormRegistro())
            {

                if (formRegistro.ShowDialog() == DialogResult.OK)
                {
                    Listados.listaUsuarios.Add(formRegistro.nuevoUsuarioRegistrado);
                    UsuarioSinTarjeta.InsertarElementoSQL(formRegistro.nuevoUsuarioRegistrado);
                    Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
                }
            }

        }

        private void btnUsuarioArgentino_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "45393559";
            txtPassword.Text = "7777";
        }

        private void btnUsuarioExtranjero_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "90000000";
            txtPassword.Text = "1234";
        }

    }
}
