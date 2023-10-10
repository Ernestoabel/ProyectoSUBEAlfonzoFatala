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
    public partial class FormRegistro : Form
    {
        private int contador = 0;
        


        public FormRegistro()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            contador++;

            FormRegistro2 formClave = new FormRegistro2();
            formClave.MdiParent = this;

            pbrPasos.PerformStep();
            lblPaso1.Text = "Paso 2";

            formClave.Show();

            btnContinuar.Location = new System.Drawing.Point(400, 357);

            if (contador > 1)
            {
                GuardarDatos();
                this.Close();
            }


            //btnContinuar.Location = new System.Drawing.Point(114, 357);

            /*FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();*/
        }


        private bool GuardarDatos()
        {

            if (contador == 1)
            {
                Usuario nuevoUsuarioRegistrado = new Usuario();
                Tarjeta nuevaTarjeta = new TarjetaNacional();
                Tarjeta nuevaTarjetaInternacional = new TarjetaInternacional();
               

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string dni = txtDni.Text;
                bool tieneTarjeta = true;

                nuevoUsuarioRegistrado.Nombre = nombre;
                nuevoUsuarioRegistrado.Apellido = apellido;
                nuevoUsuarioRegistrado.Dni = dni; 
                nuevoUsuarioRegistrado.TieneTarjeta = tieneTarjeta;

                if( dni.Length < 9)
                {
                    nuevoUsuarioRegistrado.ValidarDni(dni);

                }


            }
                      
            return true;
        }
    }
}
