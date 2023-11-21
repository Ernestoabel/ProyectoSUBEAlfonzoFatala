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
    public partial class FormCargarSaldo : Form
    {
        Usuario usuarioLogueado;
        TarjetaNacional tarjetaNacional = new TarjetaNacional();
        TarjetaInternacional tarjetaInternacional = new TarjetaInternacional();



        public FormCargarSaldo()
        {
            InitializeComponent();
            //TopLevel = false;
            CenterToParent();

        }


        #region Eventos

        /// <summary>
        /// Evento para cargar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (usuarioLogueado is not UsuarioSinTarjeta)
            {
                FormCarga formCarga = new FormCarga();
                formCarga.TraerUsuario(usuarioLogueado);
                formCarga.Dock = DockStyle.Fill;
                formCarga.Show();

            }
            else
            {
                btnCargar.Enabled = false;
            }
        }

        /// <summary>
        /// Trae al usuario y verifica el saldo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerSaldo_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioLogueado is UsuarioArgentino)
                {
                    this.TraerUsuario(usuarioLogueado);
                    string saldo = $" ${tarjetaNacional.Saldo}";
                    // MessageBox.Show($"Su saldo es de {tarjetaNacional.Saldo}");

                    VentanaEmergenteSaldo ve = new VentanaEmergenteSaldo(saldo);
                    ve.ShowDialog();

                    if (ve.DialogResult == DialogResult.OK)
                    {
                        ve.Close();
                    }
                }
                else if (usuarioLogueado is UsuarioExtranjero)
                {
                    this.TraerUsuario(usuarioLogueado);

                    string saldo = $" ${tarjetaInternacional.Saldo}";

                    VentanaEmergenteSaldo ve = new VentanaEmergenteSaldo(saldo);
                    ve.ShowDialog();

                    if (ve.DialogResult == DialogResult.OK)
                    {
                        ve.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(FormCargarSaldo), nameof(btnVerSaldo_Click), "Error en el boton", ex);
            }

        }

        /// <summary>
        /// evento load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCargarSaldo_Load(object sender, EventArgs e)
        {
            this.insertarDatos(usuarioLogueado);

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para insertar los datos en el usuario
        /// </summary>
        /// <param name="usuario"></param>
        private void insertarDatos(object usuario)
        {
            if (usuario is UsuarioArgentino)
            {
                UsuarioArgentino usuarioLogueado = (UsuarioArgentino)usuario;
                lblNombre.Text = usuarioLogueado.Nombre.ToString();
                lblApellido.Text = usuarioLogueado.Apellido.ToString();
                lblDni.Text = usuarioLogueado.Dni.ToString();
                lblIdTarjeta.Text = usuarioLogueado.IdSubeArgentina.ToString();
                lblSaldo.BackColor = Color.Transparent;
                lblSaldo.Text = "$" + tarjetaNacional.Saldo.ToString();
            }
            else if (usuario is UsuarioExtranjero)
            {
                UsuarioExtranjero usuarioLogueado = (UsuarioExtranjero)usuario;
                lblNombre.Text = usuarioLogueado.Nombre.ToString();
                lblApellido.Text = usuarioLogueado.Apellido.ToString();
                lblDni.Text = usuarioLogueado.Dni.ToString();
                lblIdTarjeta.Text = usuarioLogueado.IdSubeExtranjero.ToString();
                lblSaldo.BackColor = Color.Transparent;
                lblSaldo.Text = "$" + tarjetaInternacional.Saldo.ToString();
            }
        }

        /// <summary>
        /// Trae al usuario por dni y carga la tarjeta con los datos
        /// </summary>
        /// <param name="usuario"></param>
        public void TraerUsuario(Usuario usuario)
        {
            try
            {
                if (usuario is UsuarioSinTarjeta)
                {
                    throw new UsuarioSinTarjetaException();
                }
                else if (usuario is UsuarioArgentino)
                {
                    usuarioLogueado = usuario;
                    btnCargar.Enabled = true;
                    btnVerSaldo.Enabled = true;

                    if (usuario is UsuarioArgentino usuarioArgentino)
                    {
                        ///trae la tarjeta por el dni, en la lista de tarjeta
                        int idTarjeta = int.Parse(usuarioArgentino.IdSubeArgentina);
                        tarjetaNacional = TarjetaNacional.listaTarjetasNacionales.FirstOrDefault(tarjeta => tarjeta.Id == idTarjeta);


                    }

                }
                else if (usuario is UsuarioExtranjero)
                {
                    usuarioLogueado = usuario;
                    btnCargar.Enabled = true;
                    btnVerSaldo.Enabled = true;
                    if (usuario is UsuarioExtranjero usuarioExtranjero)
                    {
                        int idTarjeta = int.Parse(usuarioExtranjero.IdSubeExtranjero);
                        tarjetaInternacional = TarjetaInternacional.listaTarjetasIntenacionales.FirstOrDefault(tarjeta => tarjeta.Id == idTarjeta);

                    }
                }
            }
            catch (UsuarioSinTarjetaException ex)
            {
                CatchError.LogError(nameof(UsuarioSinTarjetaException), nameof(TraerUsuario), "Error en el metodo", ex);
                btnCargar.Enabled = false;
                btnVerSaldo.Enabled = false;
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(FormCargarSaldo), nameof(TraerUsuario), "Error en el metodo", ex);
            }
        }

    }
    #endregion

}
