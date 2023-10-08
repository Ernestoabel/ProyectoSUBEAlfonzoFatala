using Entidades;
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
    //Primer formulario que se inicializa al ejecutar la aplicacion
    //hereda el diseño de un formulario padre
    public partial class FormularioLoguin : LoguinPadre
    {
        public FormularioLoguin()
        {
            InitializeComponent();
        }
        
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
                        }
                        
                    }
                    else if (usuario is UsuarioArgentino)
                    {
                        
                        UsuarioArgentino usuarioLogueado = (UsuarioArgentino)usuario;
                        if (usuarioLogueado.ValidarClave(clave))
                        {
                            MessageBox.Show("El usuario tiene tarjeta argentina", "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                            
                    }
                    else if (usuario is UsuarioExtranjero)
                    {
                        UsuarioExtranjero usuarioLogueado = (UsuarioExtranjero)usuario;
                        if (usuarioLogueado.ValidarClave(clave))
                        {
                            MessageBox.Show("El usuario tiene tarjeta extranjera", "Logueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al intentar iniciar sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //boton para cerrar la aplicacion
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //boton para llenar el usuario y password con un usuario de la lista
        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            
        }

        //boton para ir al formulario de alta de cliente
        private void btnAlta_Click(object sender, EventArgs e)
        {
            FormularioAltaLoguin formAlta = new FormularioAltaLoguin();

            formAlta.Show();
            this.Hide();

        }
    }
}
