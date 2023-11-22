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
using Tulpep.NotificationWindow;

namespace ProyectoSUBEAlfonzoFatala
{
    /// <summary>
    /// Formulario de administrador para ver y modificar la lista de usuarios
    /// </summary>
    public partial class FormABMUsuarios : Form, IDataGridViewStyler
    {
        private TextBox txtBusqueda;
        private Label lblBusqueda;
        private CheckBox chkActivarBusqueda;
        public FormABMUsuarios()
        {
            InitializeComponent();
            InitializeCheckBox();
            InitializeBusquedaControls();


        }
        string tarjeta;

        /// <summary>
        /// Metodo de interfaz para darle estilo al datagrid
        /// </summary>
        public void SetDataGridViewStyle()
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
            dataGridUsuarios.RowHeadersVisible = false;

            // Ajusta el modo de redimensionamiento de las columnas
            dataGridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridUsuarios.RowHeadersVisible = false;
            dataGridUsuarios.AllowUserToResizeRows = false;

            // Habilita la edición para la columna de la clave
            dataGridUsuarios.Columns["Nombre"].ReadOnly = true;
            dataGridUsuarios.Columns["Apellido"].ReadOnly = true;
            dataGridUsuarios.Columns["Dni"].ReadOnly = true;
            dataGridUsuarios.Columns["Clave"].ReadOnly = false;
            dataGridUsuarios.Columns["TieneTarjeta"].ReadOnly = true;

            dataGridUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        /// <summary>
        /// evento para cargar metodos al cargarce el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormABMUsuarios_Load(object sender, EventArgs e)
        {
            Listados.listaUsuarios = Listados.listaUsuarios.OrderBy(u => u.Dni).ToList();
            this.dataGridUsuarios.DataSource = Listados.listaUsuarios;
            SetDataGridViewStyle();
            dataGridUsuarios.CellValueChanged += dataGridUsuarios_CellValueChanged;
            dataGridUsuarios.CellDoubleClick += DataGridView_CellDoubleClick;

            // Refresca la vista para que se aplique el estilo y se muestre la columna IdSubeArgentina
            dataGridUsuarios.Refresh();
        }

        /// <summary>
        /// metodo para capturar el evento click de la celda Clave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    UsuarioSinTarjeta.ModificarClaveSQL(usuarioACambiar.Dni,usuarioACambiar.Clave);
                }
                else if (usuario is UsuarioArgentino)
                {
                    UsuarioArgentino usuarioACambiar = (UsuarioArgentino)usuario;
                    usuarioACambiar.Clave = nuevaClave;
                    UsuarioArgentino.ModificarClaveSQL(usuarioACambiar.Dni, usuarioACambiar.Clave);
                }
                else if (usuario is UsuarioExtranjero)
                {
                    UsuarioExtranjero usuarioACambiar = (UsuarioExtranjero)usuario;
                    usuarioACambiar.Clave = nuevaClave;
                    UsuarioExtranjero.ModificarClaveSQL(usuarioACambiar.Dni, usuarioACambiar.Clave);
                }
                else if (usuario is UsuarioAdministrador)
                {
                    // MessageBox.Show("No puede cambiar su clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopUpUsuarioError("Error", "Usted es administrador no puede cambiar su clave");
                }

            }

        }

        /// <summary>
        /// Boton para guardar los datos que se cambiaron en la clave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Listados.GuardarEnArchivo(Listados.listaUsuarios, "usuarios.json");
            PopUpGuardado();
            //MessageBox.Show("Cambios guardados", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exito en el guardado popup nugget 
        /// </summary>
        private static void PopUpGuardado()
        {
            string rutaImagen = @"..\..\..\Assets\cambiosGuardados.png";

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Image.FromFile(rutaImagen);
            popup.BodyColor = Color.FromArgb(40, 167, 69);
            popup.TitleText = "Cambios Guardados";
            popup.TitleColor = Color.White;
            popup.TitleFont = new Font("Century Gothic", 15, FontStyle.Bold);

            popup.ContentText = "Cambios actualizados en la base de datos.";
            popup.ContentColor = Color.White;
            popup.ContentFont = new Font("Century Gothic", 12);
            popup.Popup();
        }

        /// <summary>
        /// setea el error con mensajes
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="subtitulo"></param>
        private static void PopUpUsuarioError(string titulo, string subtitulo)
        {

            string rutaImagen = @"..\..\..\Assets\errorLogueo.png";

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Image.FromFile(rutaImagen);
            popup.BodyColor = Color.FromArgb(220, 53, 69);
            popup.TitleText = titulo;
            popup.TitleColor = Color.White;
            popup.TitleFont = new Font("Century Gothic", 15, FontStyle.Bold);

            popup.ContentText = subtitulo;
            popup.ContentColor = Color.White;
            popup.ContentFont = new Font("Century Gothic", 12);
            popup.Popup();
        }

        /// <summary>
        /// Evento para tomar un objeto cuando se hace doble click en una fila del datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    tarjeta = tarjetaBaja.IdSubeArgentina.ToString();
                }
                else if (usuario is UsuarioExtranjero)
                {
                    UsuarioExtranjero tarjetaBaja = (UsuarioExtranjero)usuario;
                    tarjeta = tarjetaBaja.IdSubeExtranjero.ToString();
                }
                else
                {
                    //MessageBox.Show("Este usuario no tiene tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopUpUsuarioError("Usuario sin tarjeta", "Seleccione un usuario con tarjeta para dar de baja");
                    bandera = false;
                }

                if (bandera)
                {
                    //DialogResult result = MessageBox.Show("Quiere dar de baja la Tarjeta: " + tarjeta, "Baja de tarjeta",
                    //                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    
                    VentanaEmergenteAdmin ventanaEmergenteAdmin = new VentanaEmergenteAdmin($"id: {tarjeta}", "  Desea dar de baja la \n\r    tarjeta: "+tarjeta+" ?");
                    ventanaEmergenteAdmin.ShowDialog();

                    if (ventanaEmergenteAdmin.DialogResult == DialogResult.Yes)
                    {
                        if (usuario is UsuarioArgentino)
                        {
                            UsuarioArgentino usuarioTarjetaBaja = (UsuarioArgentino)usuario;
                            TarjetaNacional tarjetaNacional = new TarjetaNacional();
                            int index = Listados.listaUsuarios.FindIndex(u => u == usuarioTarjetaBaja);

                            UsuarioSinTarjeta usuarioSinTarjeta = new UsuarioSinTarjeta(usuarioTarjetaBaja);


                            Listados.listaUsuarios.RemoveAt(index);
                            Listados.listaUsuarios.Add(usuarioSinTarjeta);
                            UsuarioSinTarjeta.InsertarElementoSQL(usuarioSinTarjeta);
                            UsuarioArgentino.EliminarUnElemento(usuarioSinTarjeta.Dni);
                            RefreshDataGridView();


                        }
                        else if (usuario is UsuarioExtranjero)
                        {
                            UsuarioExtranjero usuarioTarjetaBaja = (UsuarioExtranjero)usuario;
                            TarjetaInternacional tarjetaInternacional = new TarjetaInternacional();
                            int index = Listados.listaUsuarios.FindIndex(u => u == usuarioTarjetaBaja);

                            ///Esto no esta andando
                            //UsuarioSinTarjeta usuarioSinTarjeta = new UsuarioSinTarjeta(usuarioTarjetaBaja);
                            UsuarioSinTarjeta usuarioSinTarjeta = new UsuarioSinTarjeta(usuarioTarjetaBaja.Nombre, usuarioTarjetaBaja.Apellido, usuarioTarjetaBaja.Dni, usuarioTarjetaBaja.Clave);
                            Listados.listaUsuarios.RemoveAt(index);
                            Listados.listaUsuarios.Add(usuarioSinTarjeta);
                            UsuarioSinTarjeta.InsertarElementoSQL(usuarioSinTarjeta);
                            UsuarioExtranjero.EliminarUnElemento(usuarioSinTarjeta.Dni);
                            RefreshDataGridView();


                        }
                    }
                    else if (ventanaEmergenteAdmin.DialogResult == DialogResult.No)
                    {

                    }
                }
            }
        }
        /// <summary>
        /// Metodo para refrescar y ordenar la lista sincronicamente cuando se hace una cambio
        /// </summary>
        private void RefreshDataGridView()
        {
            Listados.listaUsuarios = Listados.listaUsuarios.OrderBy(u => u.Dni).ToList();
            dataGridUsuarios.DataSource = null;
            dataGridUsuarios.DataSource = Listados.listaUsuarios;

            SetDataGridViewStyle();
        }

        /// <summary>
        /// Metodo para crear los elementos de busqueda en el desing
        /// </summary>
        private void InitializeBusquedaControls()
        {
            // TextBox
            txtBusqueda = new TextBox();
            txtBusqueda.Location = new Point(356, 45); // el primero es la posicion horizontal y el segundo la vertical
            txtBusqueda.Size = new Size(200, 20);
            txtBusqueda.TextChanged += TxtBusqueda_TextChanged;

            // Label
            lblBusqueda = new Label();
            lblBusqueda.Text = "Buscar:";
            lblBusqueda.Location = new Point(300, 50);

        }

        /// <summary>
        /// Metodo para manejar la busqueda segun el check boxs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el CheckBox está marcado antes de aplicar el filtro
            if (chkActivarBusqueda.Checked)
            {
                string filtro = txtBusqueda.Text;
                FiltrarUsuarios(filtro);
            }
        }

        /// <summary>
        /// Metodo para las condiciones del filtrado
        /// </summary>
        /// <param name="filtro"></param>
        private void FiltrarUsuarios(string filtro)
        {
            // Filtra la lista de usuarios según el criterio de búsqueda
            var usuariosFiltrados = Listados.listaUsuarios
                .Where(usuario => usuario.Dni.Contains(filtro))
                .ToList();

            dataGridUsuarios.DataSource = usuariosFiltrados;


            SetDataGridViewStyle();
        }

        /// <summary>
        /// metodo para inicializar el check box
        /// </summary>
        private void InitializeCheckBox()
        {
            chkActivarBusqueda = new CheckBox();
            chkActivarBusqueda.Text = "Búsqueda";
            chkActivarBusqueda.Location = new Point(182, 46); // Ajusta las coordenadas según tu diseño
            chkActivarBusqueda.CheckedChanged += ChkActivarBusqueda_CheckedChanged;

            // Agrega el control al formulario
            this.Controls.Add(chkActivarBusqueda);
        }

        /// <summary>
        /// evento para manejar no solo el check box
        /// sino para remover del semi codigo del formulario
        /// los text box y lavel de la busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkActivarBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            bool activarBusqueda = chkActivarBusqueda.Checked;

            if (!activarBusqueda)
            {
                // Desvincula el controlador de eventos
                txtBusqueda.TextChanged -= TxtBusqueda_TextChanged;

                // Remueve los controles del formulario
                this.Controls.Remove(txtBusqueda);
                this.Controls.Remove(lblBusqueda);
            }
            else
            {
                // Vuelve a vincular el controlador de eventos
                txtBusqueda.TextChanged += TxtBusqueda_TextChanged;

                // Agrega los controles al formulario
                this.Controls.Add(txtBusqueda);
                this.Controls.Add(lblBusqueda);
            }
        }

    }
}

