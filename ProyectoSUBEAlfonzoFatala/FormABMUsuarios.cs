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
        string tarjeta;
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
            dataGridUsuarios.CellDoubleClick += DataGridView_CellDoubleClick;
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
            MessageBox.Show("Cambios guardados", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool bandera = true;
            if (e.RowIndex >= 0 && e.RowIndex < dataGridUsuarios.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridUsuarios.Rows[e.RowIndex];

                object usuario = dataGridUsuarios.Rows[e.RowIndex].DataBoundItem;
                if (usuario is UsuarioArgentino)
                {
                    UsuarioArgentino tarjetaBaja = (UsuarioArgentino)usuario;
                    tarjeta = tarjetaBaja.TarjetaNacional.ToString();
                }
                else if (usuario is UsuarioExtranjero)
                {
                    UsuarioExtranjero tarjetaBaja = (UsuarioExtranjero)usuario;
                    tarjeta = tarjetaBaja.TarjetaInternacional.ToString();
                }
                else
                {
                    MessageBox.Show("Este usuario no tiene tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bandera = false;
                }

                if (bandera)
                {
                    DialogResult result = MessageBox.Show("Quiere dar de baja la Tarjeta: " + tarjeta, "Baja de tarjeta",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        if (usuario is UsuarioArgentino)
                        {
                            UsuarioArgentino tarjetaBaja = (UsuarioArgentino)usuario;
                            int index = Listados.listaUsuarios.FindIndex(u => u == tarjetaBaja);

                            if (index != -1)
                            {
                                UsuarioSinTarjeta usuarioSinTarjeta = new UsuarioSinTarjeta(tarjetaBaja);

                                Listados.listaUsuarios.RemoveAt(index);

                                Listados.listaUsuarios.Add(usuarioSinTarjeta);
                            }

                        }
                        else if (usuario is UsuarioExtranjero)
                        {
                            UsuarioExtranjero tarjetaBaja = (UsuarioExtranjero)usuario;
                            int index = Listados.listaUsuarios.FindIndex(u => u == tarjetaBaja);

                            if (index != -1)
                            {
                                UsuarioSinTarjeta usuarioSinTarjeta = new UsuarioSinTarjeta(tarjetaBaja);

                                Listados.listaUsuarios.RemoveAt(index);

                                Listados.listaUsuarios.Add(usuarioSinTarjeta);
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        
                    }
                }
            }
        }
    }
}
