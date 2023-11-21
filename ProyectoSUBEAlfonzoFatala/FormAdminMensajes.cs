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

            this.dataGridMensajes.RowHeadersVisible = false;
            this.dataGridMensajes.AllowUserToResizeRows = false;

            this.dataGridMensajes.Columns["Indice"].ReadOnly = true;
            this.dataGridMensajes.Columns["Mensaje"].ReadOnly = true;
            this.dataGridMensajes.Columns["Confirmar"].ReadOnly = false;
            this.dataGridMensajes.Columns["Confirmar"].Width = 80;

            this.dataGridMensajes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;



        }

        private void FormAdminMensajes_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            listaMostrarMensajes = ArchivoMensaje.listaBajas;
            dataTable.Columns.Add("Indice", typeof(int));
            dataTable.Columns.Add("Mensaje", typeof(string));
            dataTable.Columns.Add("Confirmar", typeof(bool)); // Agregar columna para el booleano

            foreach (var dict in listaMostrarMensajes)
            {
                foreach (var kvp in dict)
                {
                    if (!string.IsNullOrEmpty(kvp.Value.Mensaje)) // Agrega esta condición para evitar filas vacías
                    {
                        dataTable.Rows.Add(kvp.Key, kvp.Value.Mensaje, kvp.Value.confirmacion);
                    }
                }
            }

            this.dataGridMensajes.DataSource = dataTable;
            SetDataGridViewStyle();

            this.dataGridMensajes.CellValueChanged += (sender, e) =>
            {
                try
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == dataTable.Columns["Confirmar"].Ordinal)
                    {
                        int indice = (int)dataTable.Rows[e.RowIndex]["Indice"];
                        bool leido = (bool)dataTable.Rows[e.RowIndex]["Confirmar"];

                        // Actualiza el valor "Confirmar" en la lista
                        foreach (var dict in listaMostrarMensajes)
                        {
                            foreach (var kvp in dict)
                            {
                                if (kvp.Key == indice)
                                {
                                    kvp.Value.confirmacion = leido;
                                    break;
                                }
                            }
                        }

                        // Guarda los cambios en el archivo XML
                        ArchivoMensaje.GuardarMensajesBajaEnArchivo(listaMostrarMensajes);
                    }
                }
                catch (Exception ex)
                {
                    CatchError.LogError(nameof(FormAdminMensajes), nameof(FormAdminMensajes_Load), "Error en el evento", ex);
                }
            };
        }
    }
    
}
