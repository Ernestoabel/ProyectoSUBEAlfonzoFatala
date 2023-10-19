﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormViajesPrueba : Form
    {
        List<Viajes> listaViajes;
        object usuarioLogueado;

        public FormViajesPrueba()
        {
            InitializeComponent();
            this.listaViajes = new List<Viajes>();
        }

        public void TraerUsuario(object usuario)
        {
            if (usuario is UsuarioSinTarjeta)
            {
                MessageBox.Show("El usuario no tiene tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (usuario is UsuarioArgentino)
            {
                usuarioLogueado = usuario;

                if (usuario is UsuarioArgentino usuarioArgentino)
                {
                    List<Viajes> viajes = usuarioArgentino.TarjetaNacional.Viajes;

                    listaViajes.AddRange(viajes);
                }

            }
            else if (usuario is UsuarioExtranjero)
            {
                usuarioLogueado = usuario;
                if (usuario is UsuarioExtranjero usuarioExtranjero)
                {
                    List<Viajes> viajes = usuarioExtranjero.TarjetaInternacional.Viajes;

                    listaViajes.AddRange(viajes);
                }
            }
        }


        private void SetDataGridViewStyle()
        {
            // Establece el estilo de las celdas
            this.dtgViajes.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dtgViajes.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgViajes.DefaultCellStyle.BackColor = Color.LightGray;

            // Establece el estilo de la cabecera de las columnas
            this.dtgViajes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            this.dtgViajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dtgViajes.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Establece el estilo de la selección
            this.dtgViajes.DefaultCellStyle.SelectionBackColor = Color.Orange;
            this.dtgViajes.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajusta el estilo de las filas alternadas
            this.dtgViajes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            // Ajusta la alineación del contenido
            this.dtgViajes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajusta el modo de redimensionamiento de las columnas
            this.dtgViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Las celdas no se puede modificar
            this.dtgViajes.ReadOnly = true;

            this.dtgViajes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //this.dtgViajes.Dock = DockStyle.Fill;
        }

        private void FormViajesPrueba_Load(object sender, EventArgs e)
        {
            /*
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-09-30 10:30:12"), "Autobus", 36));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-07-30 10:40:31"), "Subte", 56));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-05-30 09:47:00"), "Tren", 23));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-05-22 12:00:00"), "Autobus", 12));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-05-18 13:00:00"), "Autobus", 31));
            */
            this.dtgViajes.DataSource = this.listaViajes;
            SetDataGridViewStyle();
            this.dtgViajes.Columns[nameof(Viajes.FechaHora)].HeaderText = "Fecha y hora";
            this.dtgViajes.Columns[nameof(Viajes.MedioTransporte)].HeaderText = "Medio de Transporte";
            this.dtgViajes.Columns[nameof(Viajes.ValorBoleto)].HeaderText = "Costo del viaje";
        }

        private void btnViajar_Click(object sender, EventArgs e)
        {
            Viajes nuevoViaje = Viajes.GenerarViajeAleatorio();
            listaViajes = listaViajes + nuevoViaje;
            if (usuarioLogueado is UsuarioArgentino usuarioArgentino)
            {
                int indice = Listados.listaUsuarios.FindIndex(u => u.Dni == usuarioArgentino.Dni);
                if (indice >= 0)
                {
                    usuarioArgentino.TarjetaNacional.Viajes = listaViajes;
                    Listados.listaUsuarios.RemoveAt(indice);
                    Listados.listaUsuarios.Add(usuarioArgentino);
                    Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
                }

            }
            else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
            {
                int indice = Listados.listaUsuarios.FindIndex(u => u == usuarioExtranjero);
                if (indice >= 0)
                {
                    usuarioExtranjero.TarjetaInternacional.Viajes = listaViajes;
                }
                usuarioExtranjero.TarjetaInternacional.Viajes = listaViajes;
            }
            dtgViajes.DataSource = null;
            dtgViajes.DataSource = listaViajes;
        }
    }
}
