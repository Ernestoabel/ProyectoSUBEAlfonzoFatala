namespace ProyectoSUBEAlfonzoFatala
{
    //Formulario de alta de usuario, que hereda de un formulario padre su diseño
    public partial class FormularioAltaLoguin : LoguinPadre
    {
        public FormularioAltaLoguin()
        {
            InitializeComponent();
        }


        //Comportamiento del boton alta para ingresar el usuario a la lista validando que no se repita el nombre
        private void btnAlta_Click(object sender, EventArgs e)
        {

        }

        //Comportamiento del boton cancelar para volver al formulario de loguin
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormularioLoguin formLogin = new FormularioLoguin();
            formLogin.Show();
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
