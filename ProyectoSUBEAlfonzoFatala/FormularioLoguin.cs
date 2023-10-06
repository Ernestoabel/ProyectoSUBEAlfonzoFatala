﻿using Entidades;
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
                
                string usuario = txtUsuario.Text;
                string contrasena = txtPassword.Text;

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Se produjo un error al intentar iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
        }
    }
}
