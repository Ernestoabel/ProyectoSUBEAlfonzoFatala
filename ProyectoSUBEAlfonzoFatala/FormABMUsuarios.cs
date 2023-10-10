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
    public partial class FormABMUsuarios : Form
    {
        public FormABMUsuarios()
        {
            InitializeComponent();
        }

        private void SetDataGridViewStyle()
        {
            // Establece el estilo de las celdas
            dataGridUsuarios.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridUsuarios.DefaultCellStyle.ForeColor = Color.Black;
            dataGridUsuarios.DefaultCellStyle.BackColor = Color.LightGray;

            // Establece el estilo de la cabecera de las columnas
            dataGridUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dataGridUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Establece el estilo de la selección
            dataGridUsuarios.DefaultCellStyle.SelectionBackColor = Color.Orange;
            dataGridUsuarios.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajusta el estilo de las filas alternadas
            dataGridUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            // Ajusta la alineación del contenido
            dataGridUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajusta el modo de redimensionamiento de las columnas
            dataGridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Las celdas no se puede modificar
            dataGridUsuarios.ReadOnly = true;

            dataGridUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            

        }

        private void FormABMUsuarios_Load(object sender, EventArgs e)
        {
            this.dataGridUsuarios.DataSource = Listados.listaUsuarios;
            SetDataGridViewStyle();
        }
    }
}
