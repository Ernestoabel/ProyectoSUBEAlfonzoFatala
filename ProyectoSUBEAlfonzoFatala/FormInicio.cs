using Entidades;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

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
            FormViajesPrueba formLoguin = new FormViajesPrueba();

            formLoguin.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logueateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioLoguin formLogin = new FormularioLoguin();
            formLogin.Show();

        }
    }
}