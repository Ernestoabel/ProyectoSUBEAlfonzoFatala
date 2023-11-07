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
        
        public object usuarioLogueado;


        /// <summary>
        /// Formulario parametrizado
        /// trae el usuario del loguin
        /// </summary>
        /// <param name="usuario"></param>
        public FormInicio(object usuario)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;
           
        }

        /// <summary>
        /// evento para traer el fomulario de viajes
        /// con un metodo para enviar el usuario logueado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formViajes.TraerUsuario(usuarioLogueado);
            formViajes.TopLevel = false;
            formViajes.FormBorderStyle = FormBorderStyle.None;
            formViajes.Dock = DockStyle.Fill;
            this.Controls.Add(formViajes);
            formViajes.Show();

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
                try
                {
                    formViajes.Hide();
                }catch (Exception ex) { }
                
            }
            if (e.ClickedItem != consultaTiToolStripMenuItem)
            {
                formTitularidad.Hide();
            }
            if (e.ClickedItem != bajaToolStripMenuItem)
            {
                formBaja.Hide();
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
        /// con un metodo para enviar el usuario logueado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultaTiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            formTitularidad.TraerUsuario(usuarioLogueado);
            formTitularidad.TopLevel = false;
            formTitularidad.FormBorderStyle = FormBorderStyle.None;
            formTitularidad.Dock = DockStyle.Fill;
            this.Controls.Add(formTitularidad);
            formTitularidad.Show();
        }

        private void registrateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();
            this.Close();*/

        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void FormInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin.Show();
        }

        private void FormInicio_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBaja.TraerUsuario(usuarioLogueado);
            formBaja.TopLevel = false;
            formBaja.FormBorderStyle = FormBorderStyle.None;
            formBaja.Dock = DockStyle.Fill;
            this.Controls.Add(formBaja);
            formBaja.Show();
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
                MessageBox.Show("Usted ya tiene tarjeta", "Usted tiene tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cOMPRARToolStripMenuItem.Enabled = false;
            }
        }

        private void iNICIARSESIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Cargar sube
            /// 

            if (usuarioLogueado is not UsuarioSinTarjeta)
            {
                //formCargarSaldo.TraerUsuario(usuarioLogueado);
                //formCargarSaldo.FormBorderStyle = FormBorderStyle.None;
                //formCargarSaldo.Dock = DockStyle.Fill;
                //formCargarSaldo.MdiParent = this;
                //formCargarSaldo.Show();

                FormCargarSaldo formCargarSaldo = new FormCargarSaldo();
                formCargarSaldo.TraerUsuario(usuarioLogueado);
                formCargarSaldo.FormBorderStyle = FormBorderStyle.None;
                formCargarSaldo.Dock = DockStyle.Fill;
                formCargarSaldo.MdiParent = this;
                formCargarSaldo.Show();

               

            }
            else
            {
                MessageBox.Show("Usted no tiene tarjeta", "Usted no tiene tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iNICIARSESIONToolStripMenuItem.Enabled = false;
            }

        }
    }
}