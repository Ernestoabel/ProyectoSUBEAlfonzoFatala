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
    public partial class FormTitularidad : Form
    {
        List<object> listaUsuario;
        object usuarioLogueado;
        public FormTitularidad()
        {
            InitializeComponent();
            this.listaUsuario = new List<object>();
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

        private void SetDataGridViewStyle()
        {
            // Establece el estilo de las celdas
            dataGridTitularidad.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridTitularidad.DefaultCellStyle.ForeColor = Color.Black;
            dataGridTitularidad.DefaultCellStyle.BackColor = Color.LightGray;

            // Establece el estilo de la cabecera de las columnas
            dataGridTitularidad.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dataGridTitularidad.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridTitularidad.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Establece el estilo de la selección
            dataGridTitularidad.DefaultCellStyle.SelectionBackColor = Color.Orange;
            dataGridTitularidad.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajusta el estilo de las filas alternadas
            dataGridTitularidad.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            // Ajusta la alineación del contenido
            dataGridTitularidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajusta el modo de redimensionamiento de las columnas
            dataGridTitularidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Las celdas no se puede modificar
            dataGridTitularidad.ReadOnly = true;

            dataGridTitularidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            if (usuarioLogueado is UsuarioArgentino)
            {
                dataGridTitularidad.Columns["TarjetaNacional"].Visible = false;
            }
            else if(usuarioLogueado is UsuarioExtranjero)
            {
                dataGridTitularidad.Columns["tarjetaInternacional"].Visible = false;
            }
                
        }


        private void FormTitularidad_Load_1(object sender, EventArgs e)
        {
            if (usuarioLogueado == null)
            {
                MessageBox.Show("No se logeo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if (usuarioLogueado is UsuarioSinTarjeta)
            {
                MessageBox.Show("Usuario sin trajeta ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listaUsuario.Add(usuarioLogueado);
                dataGridTitularidad.DataSource = listaUsuario;
                SetDataGridViewStyle();
            }
        }
    }
}