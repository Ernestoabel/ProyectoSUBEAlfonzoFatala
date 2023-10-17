using Entidades;
using System;
using System.Collections;
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
            //dataGridUsuarios.ReadOnly = true;

            // Habilita la edición para la columna de la clave
            dataGridUsuarios.Columns["Nombre"].ReadOnly = true;
            dataGridUsuarios.Columns["Apellido"].ReadOnly = true;
            dataGridUsuarios.Columns["Dni"].ReadOnly = true;
            dataGridUsuarios.Columns["Clave"].ReadOnly = false;
            dataGridUsuarios.Columns["TieneTarjeta"].ReadOnly = true;

            dataGridUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


        }

        private void FormABMUsuarios_Load(object sender, EventArgs e)
        {
            this.dataGridUsuarios.DataSource = Listados.listaUsuarios;
            SetDataGridViewStyle();
            dataGridUsuarios.CellValueChanged += dataGridUsuarios_CellValueChanged;
        }

        private void dataGridUsuarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridUsuarios.Columns["Clave"].Index && e.RowIndex >= 0)
            {
                string nuevaClave = dataGridUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                object usuario = dataGridUsuarios.Rows[e.RowIndex].DataBoundItem;
                if (usuario is UsuarioSinTarjeta)
                {
                    UsuarioSinTarjeta usuarioACambiar = (UsuarioSinTarjeta)usuario;
                    usuarioACambiar.Clave = nuevaClave;
                }
                else if (usuario is UsuarioArgentino)
                {
                    UsuarioArgentino usuarioACambiar = (UsuarioArgentino)usuario;
                    usuarioACambiar.Clave = nuevaClave;
                }
                else if (usuario is UsuarioExtranjero)
                {
                    UsuarioExtranjero usuarioACambiar = (UsuarioExtranjero)usuario;
                    usuarioACambiar.Clave = nuevaClave;
                }
                else if (usuario is UsuarioAdministrador)
                {
                    MessageBox.Show("No puede cambiar su clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
        }
    }
}
