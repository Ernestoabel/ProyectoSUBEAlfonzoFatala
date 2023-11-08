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
using static Entidades.ArchivoMensaje;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormAdminMensajes : Form, IDataGridViewStyler
    {
        public static List<Dictionary<int, BajaData>> listaMostrarMensajes;
        public FormAdminMensajes()
        {
            InitializeComponent();
            listaMostrarMensajes = ArchivoMensaje.listaBajas;
        }



        public void SetDataGridViewStyle()
        {
            this.dataGridMensajes.DataBindingComplete += (sender, e) =>
            {
                // Establece el ancho de la primera columna (índice 0) a 200 pixels
                if (this.dataGridMensajes.Columns.Count > 0)
                    this.dataGridMensajes.Columns[0].Width = 80;
            };
            // Establece el estilo de las celdas
            this.dataGridMensajes.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridMensajes.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridMensajes.DefaultCellStyle.BackColor = Color.LightGray;

            // Establece el estilo de la cabecera de las columnas
            this.dataGridMensajes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            this.dataGridMensajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridMensajes.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Establece el estilo de la selección
            this.dataGridMensajes.DefaultCellStyle.SelectionBackColor = Color.Orange;
            this.dataGridMensajes.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajusta el estilo de las filas alternadas
            this.dataGridMensajes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            // Ajusta la alineación del contenido
            this.dataGridMensajes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajusta el modo de redimensionamiento de las columnas
            this.dataGridMensajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Las celdas no se puede modificar
            this.dataGridMensajes.ReadOnly = true;

            this.dataGridMensajes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //this.dtgViajes.Dock = DockStyle.Fill;
        }

        private void FormAdminMensajes_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Indice", typeof(int));
            dataTable.Columns.Add("Mensaje", typeof(string));
            dataTable.Columns.Add("Leido", typeof(bool)); // Agregar columna para el booleano

            foreach (var dict in listaMostrarMensajes)
            {
                foreach (var kvp in dict)
                {
                    dataTable.Rows.Add(kvp.Key, kvp.Value.Mensaje, kvp.Value.confirmacion); // Agregar el valor de NamespaceEntidades
                }
            }

            this.dataGridMensajes.DataSource = dataTable;
            SetDataGridViewStyle();
        }
    }
}
