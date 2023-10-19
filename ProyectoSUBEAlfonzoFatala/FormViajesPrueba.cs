using Entidades;
using System;
using System.Collections;
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
            
            this.dtgViajes.DataSource = this.listaViajes;
            SetDataGridViewStyle();
            this.dtgViajes.Columns[nameof(Viajes.FechaHora)].HeaderText = "Fecha y hora";
            this.dtgViajes.Columns[nameof(Viajes.MedioTransporte)].HeaderText = "Medio de Transporte";
            this.dtgViajes.Columns[nameof(Viajes.ValorBoleto)].HeaderText = "Costo del viaje";
        }

        private void btnViajar_Click(object sender, EventArgs e)
        {
            if (usuarioLogueado is UsuarioArgentino usuarioArgentino)
            {
                Viajes nuevoViaje = Viajes.GenerarViajeAleatorio();
                listaViajes = listaViajes + nuevoViaje;
                int indice = Listados.listaUsuarios.FindIndex(u => u.Dni == usuarioArgentino.Dni);
                if (indice >= 0)
                {
                    usuarioArgentino.TarjetaNacional.Viajes = listaViajes;
                    Listados.listaUsuarios.RemoveAt(indice);
                    Listados.listaUsuarios.Add(usuarioArgentino);
                    Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
                    //Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
                }

            }
            else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
            {
                Viajes nuevoViaje = Viajes.GenerarViajeAleatorio(usuarioExtranjero);
                listaViajes = listaViajes + nuevoViaje;
                int indice = Listados.listaUsuarios.FindIndex(u => u.Dni == usuarioExtranjero.Dni);
                if (indice >= 0)
                {
                    usuarioExtranjero.TarjetaInternacional.Viajes = listaViajes;
                    Listados.listaUsuarios.RemoveAt(indice);
                    Listados.listaUsuarios.Add(usuarioExtranjero);
                    Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
                    //Listados.GuardarUsuariosEnArchivo(Listados.listaUsuarios);
                }
            }
            dtgViajes.DataSource = null;
            dtgViajes.DataSource = listaViajes;
        }
    }
}
