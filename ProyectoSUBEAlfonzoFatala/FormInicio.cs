using Entidades;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormInicio : Form
    {
        Object usuarioLogueado;
        public FormInicio()
        {
            InitializeComponent();

        }
        public void TraerUsuario(object usuario)
        {
            if (usuario is UsuarioSinTarjeta)
            {
                usuarioLogueado = usuario as UsuarioSinTarjeta;
                MessageBox.Show("El usuario es "+ usuarioLogueado, "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usuario is UsuarioArgentino)
            {
                usuarioLogueado = usuario as UsuarioArgentino;
                MessageBox.Show("El usuario es " + usuarioLogueado, "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usuario is UsuarioExtranjero)
            {
                usuarioLogueado = usuario as UsuarioExtranjero;
                MessageBox.Show("El usuario es " + usuarioLogueado, "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        FormViajesPrueba formViajes = new FormViajesPrueba();
        FormTitularidad formTitularidad = new FormTitularidad();
        
        

        public void MostrarUsuariosEnMessageBox()
        {
            StringBuilder mensaje = new StringBuilder("Lista de usuarios:\n");

            foreach (var usuario in Listados.listaUsuarios)
            {
                string texto = usuario.ObtenerInformacionUsuario();
                mensaje.AppendLine(texto);
            }

            MessageBox.Show(mensaje.ToString(), "Lista de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioSinTarjeta nuevoUsuario = new UsuarioSinTarjeta("Ernesto", "Fatala", "10000000", "1234");
            TarjetaNacional tarjeta1001 = new TarjetaNacional(1001, 500, Listados.ViajeTarjeta1001);
            Listados.AgregarTarjetaNacional(tarjeta1001);
            TarjetaInternacional tarjeta5001 = new TarjetaInternacional(5001, 2000, Listados.ViajeTarjeta5001);
            Listados.AgregarTarjetaInternacional(tarjeta5001);
            Listados.GuardarTarjetaNacionalEnArchivo(Listados.listaTarjetasNacionales);
            Listados.GuardarTarjetaInternacionalEnArchivo(Listados.listaTarjetasIntenacionales);
            UsuarioArgentino nuevoUsuArgentino = new UsuarioArgentino("Carlos", "Pepe", "20000000", "1234", "1001", tarjeta1001);
            UsuarioExtranjero nuevoUsuExtrangero = new UsuarioExtranjero("Carlos", "Pepe", "90000000", "1234", "5001", tarjeta5001);
            Listados.AgregarUsuario(nuevoUsuario);
            Listados.AgregarUsuario(nuevoUsuArgentino);
            Listados.AgregarUsuario(nuevoUsuExtrangero);
            Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
            /*
            List<TarjetaNacional> tajetaNacionalCargadas = Listados.CargarTarjetaNacionalsDesdeArchivo();
            List<TarjetaInternacional> tarjetaInternacionalCargadas = Listados.CargarTarjetaInternacionalDesdeArchivo();
            List<Usuario> usuariosCargados = Listados.CargarUsuariosDesdeArchivo();
            Listados.listaTarjetasNacionales = tajetaNacionalCargadas;
            Listados.listaTarjetasIntenacionales = tarjetaInternacionalCargadas;
            Listados.listaUsuarios = usuariosCargados;
            */

        }

        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            formViajes.TopLevel = false;
            formViajes.FormBorderStyle = FormBorderStyle.None;
            formViajes.Dock = DockStyle.Fill;
            this.Controls.Add(formViajes);
            formViajes.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != viajesToolStripMenuItem)
            {
                formViajes.Hide();
            }
            if (e.ClickedItem != consultaTiToolStripMenuItem)
            {
                formTitularidad.Hide();
            }

        }

        private void logueateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioLoguin formLogin = new FormularioLoguin();
            formLogin.Show();

        }

        private void consultaTiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTitularidad.usuarioLogueado = usuarioLogueado;
            formTitularidad.TopLevel = false;
            formTitularidad.FormBorderStyle = FormBorderStyle.None;
            formTitularidad.Dock = DockStyle.Fill;
            this.Controls.Add(formTitularidad);
            formTitularidad.Show();
        }

        private void registrateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();
        }
    }
}