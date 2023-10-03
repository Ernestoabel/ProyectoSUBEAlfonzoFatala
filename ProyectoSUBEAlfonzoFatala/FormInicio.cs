using Entidades;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario("Ernesto", "Fatala", "30555191", "1234");
            UsuarioArgentino nuevoUsuArgentino = new UsuarioArgentino("Carlos", "Pepe", "30555199", "1234", "1001");
            UsuarioExtranjero nuevoUsuExtrangero = new UsuarioExtranjero("Carlos", "Pepe", "30555199", "1234", "5001");
            Listados.AgregarUsuario(nuevoUsuario);
            Listados.AgregarUsuario(nuevoUsuArgentino);
            Listados.AgregarUsuario(nuevoUsuExtrangero);
            Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
        }
    }
}