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
    /// <summary>
    /// Formulario de administrador para ver la lista de tarjetas
    /// </summary>
    public partial class FormABMTarjetas : Form, IDataGridViewStyler
    {
        public FormABMTarjetas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo de interfaz para darle estilo al dataGrid
        /// </summary>
        public void SetDataGridViewStyle()
        {
            // Establece el estilo de las celdas
            dataGridABMTarjetas.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridABMTarjetas.DefaultCellStyle.ForeColor = Color.Black;
            dataGridABMTarjetas.DefaultCellStyle.BackColor = Color.LightGray;

            // Establece el estilo de la cabecera de las columnas
            dataGridABMTarjetas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dataGridABMTarjetas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridABMTarjetas.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Establece el estilo de la selección
            dataGridABMTarjetas.DefaultCellStyle.SelectionBackColor = Color.Orange;
            dataGridABMTarjetas.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajusta el estilo de las filas alternadas
            dataGridABMTarjetas.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            // Ajusta la alineación del contenido
            dataGridABMTarjetas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajusta el modo de redimensionamiento de las columnas
            dataGridABMTarjetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Las celdas no se puede modificar
            dataGridABMTarjetas.ReadOnly = true;

            dataGridABMTarjetas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //dataGridABMTarjetas.Columns["Viajes"].Visible = false;

        }

        private void FormABMTarjetas_Load(object sender, EventArgs e)
        {
            rdArgentinas.CheckedChanged += RadioButton_CheckedChanged;
            rdExtranjeras.CheckedChanged += RadioButton_CheckedChanged;

            SetDataGridView();
        }
        /// <summary>
        /// evento para captar el cambio en el radio boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetDataGridView();
        }
        /// <summary>
        /// Metodo para setear el dataGrid segun radio button
        /// </summary>
        private void SetDataGridView()
        {
            if (rdArgentinas.Checked)
            {
                this.dataGridABMTarjetas.DataSource = TarjetaNacional.listaTarjetasNacionales;
                SetDataGridViewStyle();
            }
            else if (rdExtranjeras.Checked)
            {
                this.dataGridABMTarjetas.DataSource = TarjetaInternacional.listaTarjetasIntenacionales;
                SetDataGridViewStyle();
            }
            else
            {
                this.dataGridABMTarjetas.DataSource = null;
                // Limpia cualquier estilo si no hay selección
            }
        }

    }
}
