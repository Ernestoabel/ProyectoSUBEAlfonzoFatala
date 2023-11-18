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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormTitularidad : Form
    {
        object usuarioLogueado;
        public FormTitularidad()
        {
            InitializeComponent();

        }

        public void TraerUsuario(object usuario)
        {
            if (usuario is UsuarioSinTarjeta)
            {
                usuarioLogueado = usuario;

            }
            else if (usuario is UsuarioArgentino)
            {
                usuarioLogueado = usuario;

            }
            else if (usuario is UsuarioExtranjero)
            {
                usuarioLogueado = usuario;

            }
        }

        private void FormTitularidad_Load_1(object sender, EventArgs e)
        {
            try
            {
                insertarDatos(usuarioLogueado);
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertarDatos(object usuario)
        {
            if (usuario is UsuarioSinTarjeta)
            {
                UsuarioSinTarjeta usuarioLogueado = (UsuarioSinTarjeta)usuario;
                txtNombre.Text = usuarioLogueado.Nombre.ToString();
                txtApellido.Text = usuarioLogueado.Apellido.ToString();
                TxtDNI.Text = usuarioLogueado.Dni.ToString();
                txtTarjeta.Visible = false;
                lbTarjeta.Visible = false;
            }
            else if (usuario is UsuarioArgentino)
            {
                UsuarioArgentino usuarioLogueado = (UsuarioArgentino)usuario;
                txtNombre.Text = usuarioLogueado.Nombre.ToString();
                txtApellido.Text = usuarioLogueado.Apellido.ToString();
                TxtDNI.Text = usuarioLogueado.Dni.ToString();
                txtTarjeta.Text = usuarioLogueado.IdSubeArgentina.ToString();
            }
            else if (usuario is UsuarioExtranjero)
            {
                UsuarioExtranjero usuarioLogueado = (UsuarioExtranjero)usuario;
                txtNombre.Text = usuarioLogueado.Nombre.ToString();
                txtApellido.Text = usuarioLogueado.Apellido.ToString();
                TxtDNI.Text = usuarioLogueado.Dni.ToString();
                txtTarjeta.Text = usuarioLogueado.IdSubeExtranjero.ToString();
            }
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            TxtDNI.ReadOnly = true;
            txtTarjeta.ReadOnly = true;
        }

     

    }
}
