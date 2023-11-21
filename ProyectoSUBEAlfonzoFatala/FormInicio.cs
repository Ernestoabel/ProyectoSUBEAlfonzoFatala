using Entidades;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;
using System;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormInicio : Form
    {
        FormViajesPrueba formViajes = new FormViajesPrueba();
        FormTitularidad formTitularidad = new FormTitularidad();
        FormularioLoguin formLogin = new FormularioLoguin();
        FormBajaUsuario formBaja = new FormBajaUsuario();
        FormCargarSaldo formCargarSaldo = new FormCargarSaldo();
        private Configuraciones configuraciones;
        public Usuario usuarioLogueado;
        private string configuracionesFilePath = @"..\..\..\Archivos\configuraciones.json";
        Action<Usuario> pasarObjeto; //Delegado para el envio de un objeto a los formularios


        /// <summary>
        /// Formulario parametrizado
        /// trae el usuario del loguin
        /// </summary>
        /// <param name="usuario"></param>
        public FormInicio()
        {

            InitializeComponent();
            configuraciones = new Configuraciones();
            ConfiguracionInicial();

        }

        /// <summary>
        /// Metodo para utilizar en un delegado
        /// </summary>
        /// <param name="objeto"></param>
        public void RecivirObjeto(Usuario objeto)
        {
            this.usuarioLogueado = objeto;
        }


        /// <summary>
        /// evento para traer el fomulario de viajes
        /// con un delegado para enviar el usuario logueado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formViajes = new FormViajesPrueba();
            if (usuarioLogueado is not UsuarioSinTarjeta)
            {
                // Primer hilo
                await Task.Run(() =>
                {
                this.pasarObjeto += formViajes.TraerUsuario;
                this.pasarObjeto.Invoke(usuarioLogueado);
                });

                // Segundo hilo después de un retraso
                await Task.Delay(1000); // Puedes ajustar el tiempo de retraso según tus necesidades

                // Operaciones en el hilo principal (interfaz de usuario)
                this.Invoke((MethodInvoker)delegate
                {
                    // Segundo hilo
                    this.pasarObjeto -= formViajes.TraerUsuario;

                    // Operaciones adicionales si es necesario
                    formViajes.TopLevel = false;
                    formViajes.FormBorderStyle = FormBorderStyle.None;
                    formViajes.Dock = DockStyle.Fill;
                    this.Controls.Add(formViajes);
                    formViajes.Show();
                });
            }
            else
            {
                DesabilitarEntradaUsuarioSinTarjeta();
                viajesToolStripMenuItem.Enabled = false;
            }

        }

        /// <summary>
        /// evento para ir cambiando entre formularios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != viajesToolStripMenuItem)
            {
                formViajes.Close();
            }
            if (e.ClickedItem != consultaTiToolStripMenuItem)
            {
                formTitularidad.Close();
            }
            if (e.ClickedItem != bajaToolStripMenuItem)
            {
                formBaja.Close();
            }
            if (e.ClickedItem != iNICIARSESIONToolStripMenuItem)
            {
                formCargarSaldo.Close();
            }


        }

        /// <summary>
        /// evento para volver al formulario de logueo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logueateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLogin.Show();
            this.Close();
        }

        /// <summary>
        /// evento para mostrar el formulario de titularidad
        /// con un delegado para enviar el usuario logueado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void consultaTiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTitularidad = new FormTitularidad();
            // Primer hilo
            await Task.Run(() =>
            {
                this.pasarObjeto += formTitularidad.TraerUsuario;
                this.pasarObjeto.Invoke(usuarioLogueado);
            });

            // Segundo hilo después de un retraso
            await Task.Delay(1000); // Puedes ajustar el tiempo de retraso según tus necesidades

            // Operaciones en el hilo principal (interfaz de usuario)
            this.Invoke((MethodInvoker)delegate
            {
                // Segundo hilo
                this.pasarObjeto -= formTitularidad.TraerUsuario;

                formTitularidad.TopLevel = false;
                formTitularidad.FormBorderStyle = FormBorderStyle.None;
                formTitularidad.Dock = DockStyle.Fill;
                this.Controls.Add(formTitularidad);
                formTitularidad.Show();
            });
        }



        /// <summary>
        /// Evento para cerrar el formulario
        /// Volver al Loguin
        /// Y guardar la configuracion del usuario en JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfiguracionManager.GuardarConfiguraciones(configuracionesFilePath, configuraciones);
            formLogin.Show();
        }

        /// <summary>
        /// Evento para mostrar el formulario de baja tarjeta
        /// Con un delegado para enviar el objeto usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBaja = new FormBajaUsuario();
            await Task.Run(() =>
            {
                this.pasarObjeto += formBaja.TraerUsuario;
                this.pasarObjeto.Invoke(usuarioLogueado);
            });

            // Segundo hilo después de un retraso
            await Task.Delay(1000); // Puedes ajustar el tiempo de retraso según tus necesidades

            if (usuarioLogueado is not UsuarioSinTarjeta)
            {
                // Operaciones en el hilo principal (interfaz de usuario)
                this.Invoke((MethodInvoker)delegate
                {
                    // Segundo hilo
                    this.pasarObjeto -= formBaja.TraerUsuario;

                    formBaja.TopLevel = false;
                    formBaja.FormBorderStyle = FormBorderStyle.None;
                    formBaja.Dock = DockStyle.Fill;
                    this.Controls.Add(formBaja);
                    formBaja.Show();
                });
            }
            else
            {
                DesabilitarEntradaUsuarioSinTarjeta();
                bajaToolStripMenuItem.Enabled = false;
            }

        }

        /// <summary>
        /// Metodo para setaear la ventana personalizada
        /// sin sobrecarga
        /// </summary>
        private static void DesabilitarEntradaUsuarioSinTarjeta()
        {
            VentenaEmergenteUsuarioSinTarjeta ve = new VentenaEmergenteUsuarioSinTarjeta();
            ve.ShowDialog();

            if (ve.DialogResult == DialogResult.OK)
            {
                ve.Close();
            }
        }

        /// <summary>
        /// metodo para desabilitar los movimientos del usuario 
        /// que ya tiene ese dominio
        /// </summary>
        private static void DesabilitarEntradaUsuarioConTarjeta()
        {
            VentenaEmergenteUsuarioSinTarjeta ve = new VentenaEmergenteUsuarioSinTarjeta("Usted Tiene Tarjeta", "Usted no necesita comprar una tarjeta,\r\n\r\n puede cargarla! Yendo a Inicio/Cargala.");
            ve.ShowDialog();

            if (ve.DialogResult == DialogResult.OK)
            {
                ve.Close();
            }
        }

        private void cOMPRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuarioLogueado is UsuarioSinTarjeta)
            {
                FormRegistrarTarjeta formComprar = new FormRegistrarTarjeta((Usuario)usuarioLogueado);
                formComprar.Show();

                this.Hide();
            }
            else
            {
                DesabilitarEntradaUsuarioConTarjeta();
                cOMPRARToolStripMenuItem.Enabled = false;
            }
        }

        private async void iNICIARSESIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Cargar sube
            /// 
            formCargarSaldo = new FormCargarSaldo();
            if (usuarioLogueado is not UsuarioSinTarjeta)
            {

                // Primer hilo
                await Task.Run(() =>
                {
                    this.pasarObjeto += formCargarSaldo.TraerUsuario;
                    this.pasarObjeto.Invoke(usuarioLogueado);
                });

                // Segundo hilo después de un retraso
                await Task.Delay(1000); // Puedes ajustar el tiempo de retraso según tus necesidades

                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        // Segundo hilo
                        this.pasarObjeto -= formCargarSaldo.TraerUsuario;

                        formCargarSaldo.FormBorderStyle = FormBorderStyle.None;
                        formCargarSaldo.Dock = DockStyle.Fill;
                        formCargarSaldo.MdiParent = this;
                        formCargarSaldo.Show();
                    });
                // Operaciones en el hilo principal (interfaz de usuario)

                }
                catch(System.ObjectDisposedException ex)
                {
                    CatchError.LogError(nameof(FormInicio), nameof(iNICIARSESIONToolStripMenuItem), "Error al iniciar sesion ", ex);
                }
                catch (Exception ex)
                {
                    CatchError.LogError(nameof(FormInicio), nameof(iNICIARSESIONToolStripMenuItem), "Error al iniciar sesion ", ex);
                }
                

            }
            else
            {

                DesabilitarEntradaUsuarioSinTarjeta();
                iNICIARSESIONToolStripMenuItem.Enabled = false;


            }

        }

        private void chkCheckedCh(object sender, EventArgs e)
        {
            string rutaImagenUncheck = Path.Combine(Application.StartupPath, "Assets", "IcBaselineRadioButtonUnchecked.png");
            string rutaImagenCheck = Path.Combine(Application.StartupPath, "Assets", "IcBaselineCheckCircleOutline.png");
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
                checkBox.Image = Image.FromFile(rutaImagenUncheck);
            else
                checkBox.Image = Image.FromFile(rutaImagenCheck);
        }

        /// <summary>
        /// Evento para cambiar el tema de la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbTema_CheckedChanged(object sender, EventArgs e)
        {
            string rutaImagenUncheck = @"..\..\..\Assets\IcBaselineRadioButtonUnchecked.png";
            string rutaImagenCheck = @"..\..\..\Assets\IcBaselineCheckCircleOutline.png";

            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                checkBox.Image = Image.FromFile(rutaImagenCheck);
            }
            else
            {
                checkBox.Image = Image.FromFile(rutaImagenUncheck);
            }

            if (!chbTema.Checked)
            {
                configuraciones.ConfiguracionNacional();
            }
            else
            {
                configuraciones.ConfiguracionSovietical();
            }
            BackgroundImage = Image.FromFile(configuraciones.ImagenFondo);
            menuStrip1.BackColor = Color.FromName(configuraciones.ColorFondo);
            menuStrip1.Font = new Font(configuraciones.FuenteTexto, 12);


        }

        /// <summary>
        /// metodo para cargar la configuracion guardada en un JSON
        /// </summary>
        private void ConfiguracionInicial()
        {
            configuraciones = ConfiguracionManager.CargarConfiguraciones(configuracionesFilePath);
            BackgroundImage = Image.FromFile(configuraciones.ImagenFondo);
            menuStrip1.BackColor = Color.FromName(configuraciones.ColorFondo);
            menuStrip1.Font = new Font(configuraciones.FuenteTexto, 12);
        }
    }
}