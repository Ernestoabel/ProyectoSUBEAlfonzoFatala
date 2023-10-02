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
            Usuario nuevoUsuario = new Usuario("Ernesto", "Fatala", "30555191", "ernestoabel@hotmail.com", "1234");
            Listados.AgregarUsuario(nuevoUsuario);
            Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
        }
    }
}