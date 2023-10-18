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
using static Entidades.Listados;
using System.Xml.Serialization;

namespace ProyectoSUBEAlfonzoFatala
{
    
    public partial class FormBajaUsuario : Form
    {
        string mensaje;
        int indice = 1;
        int dni;
        public FormBajaUsuario()
        {
            InitializeComponent();
        }

        public void TraerUsuario(object usuario)
        {
            if (usuario is UsuarioSinTarjeta)
            {
                MessageBox.Show("El usuario no tiene tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBajaTarjetaUsuario.Enabled = false;
            }
            else if (usuario is UsuarioArgentino usuarioArgentino)
            {
                mensaje = $"El usuario {usuarioArgentino.Dni} con la tarjeta {usuarioArgentino.IdSubeArgentina} quiere la baja";
                indice = ArchivoMensaje.obtenerUltimoIndiceListaMensajes(ArchivoMensaje.listaBajas);
                dni = int.Parse(usuarioArgentino.Dni);
            }
            else if (usuario is UsuarioExtranjero usuarioExtranjero)
            {
                mensaje = $"El usuario {usuarioExtranjero.Dni} con la tarjeta {usuarioExtranjero.IdSubeExtranjero} quiere la baja";
                indice = ArchivoMensaje.obtenerUltimoIndiceListaMensajes(ArchivoMensaje.listaBajas);
                dni = int.Parse(usuarioExtranjero.Dni);
            }
        }
        private void btnBajaTarjetaUsuario_Click(object sender, EventArgs e)
        {
            if (!ArchivoMensaje.VerificarNumeroEnListaBajas(dni))
            {
                ArchivoMensaje.listaBajas.Add(new Dictionary<int, string> { { indice, mensaje } });
                ArchivoMensaje.GuardarMensajesBajaEnArchivo(ArchivoMensaje.listaBajas);
                MessageBox.Show("El mensaje fue enviado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Esta tarjeta ya pidio la baja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
    }
}

