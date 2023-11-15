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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSUBEAlfonzoFatala
{
    /// <summary>
    /// Formulario para la visualizacion y creacion de Viajes
    /// </summary>
    public partial class FormViajesPrueba : Form, IDataGridViewStyler
    {
        List<Viajes> listaViajes;
        object usuarioLogueado;
        TarjetaNacional tarjetaNacional = new TarjetaNacional();
        TarjetaInternacional tarjetaInternacional = new TarjetaInternacional();

        public FormViajesPrueba()
        {
            InitializeComponent();
            this.listaViajes = new List<Viajes>();
        }

        /// <summary>
        /// Metodo para recivir el usuario
        /// Se ejecuta por delegado en el FormInicio
        /// </summary>
        /// <param name="usuario"></param>
        public void TraerUsuario(object usuario)
        {
            try
            {
                if (usuario is UsuarioSinTarjeta)
                {
                    throw new UsuarioSinTarjetaException();
                }
                else if (usuario is UsuarioArgentino)
                {
                    usuarioLogueado = usuario;
                    btnViajar.Enabled = true;
                    btnViajarx5.Enabled = true;
                    if (usuario is UsuarioArgentino usuarioArgentino)
                    {
                        int idTarjeta = int.Parse(usuarioArgentino.IdSubeArgentina);
                        tarjetaNacional = TarjetaNacional.listaTarjetasNacionales.FirstOrDefault(tarjeta => tarjeta.Id == idTarjeta);
                        List<Viajes> viajes = tarjetaNacional.Viajes;
                        listaViajes.AddRange(viajes);
                    }

                }
                else if (usuario is UsuarioExtranjero)
                {
                    usuarioLogueado = usuario;
                    btnViajar.Enabled = true;
                    btnViajarx5.Enabled = true;
                    if (usuario is UsuarioExtranjero usuarioExtranjero)
                    {
                        int idTarjeta = int.Parse(usuarioExtranjero.IdSubeExtranjero);
                        tarjetaInternacional = TarjetaInternacional.listaTarjetasIntenacionales.FirstOrDefault(tarjeta => tarjeta.Id == idTarjeta);
                        List<Viajes> viajes = tarjetaInternacional.Viajes;
                        listaViajes.AddRange(viajes);
                    }
                }
            }
            catch (UsuarioSinTarjetaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnViajar.Enabled = false;
                btnViajarx5.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Metodo obligatorio por interfase para darle estilo al dataGrid
        /// </summary>
        public void SetDataGridViewStyle()
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

            //Les da Nombre a las columnas
            this.dtgViajes.Columns[nameof(Viajes.FechaHora)].HeaderText = "Fecha y hora";
            this.dtgViajes.Columns[nameof(Viajes.MedioTransporte)].HeaderText = "Medio de Transporte";
            this.dtgViajes.Columns[nameof(Viajes.ValorBoleto)].HeaderText = "Costo del viaje";

            //Opcion para cuando se maximiza la ventana y tome toda la ventana
            this.dtgViajes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FormViajesPrueba_Load(object sender, EventArgs e)
        {

            this.dtgViajes.DataSource = this.listaViajes;
            SetDataGridViewStyle();
            
        }

        /// <summary>
        /// Comportamiento asincronico del boton Viajar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnViajar_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Viajar()).ConfigureAwait(false);
        }

        /// <summary>
        /// Comportamiento asincronico del boton Viajar x5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnViajarx5_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ViajarCincoVeces()).ConfigureAwait(false);
        }

        /// <summary>
        /// Metodo Task para generar el viaje en el boton viajar
        /// </summary>
        private void Viajar()
        {
            this.Invoke(new Action(() =>
            {
                if (usuarioLogueado is UsuarioArgentino usuarioArgentino)
                {
                    Viajes nuevoViaje = Viajes.GenerarViajeAleatorio();
                    decimal costoViaje = nuevoViaje.ValorBoleto;
                    bool haySaldo = tarjetaNacional.RestarSaldo(costoViaje);

                    if(haySaldo)
                    {
                        listaViajes = listaViajes + nuevoViaje;
                        tarjetaNacional.Viajes = listaViajes;
                        string condicion = $"Id = {tarjetaNacional.Id}";
                        tarjetaNacional.ActualizarEnBaseDeDatos(condicion);

                    }
                    else
                    {
                        MessageBox.Show($"{usuarioArgentino.Nombre} no tiene saldo suficiente, cargue la tarjeta {tarjetaNacional.Id}");
                    }

                }
                else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
                {
                    Viajes nuevoViaje = Viajes.GenerarViajeAleatorio(usuarioExtranjero);
                    decimal costoViaje = nuevoViaje.ValorBoleto;
                    bool haySaldo = tarjetaInternacional.RestarSaldo(costoViaje);

                    if(haySaldo) 
                    {
                        listaViajes = listaViajes + nuevoViaje;
                        tarjetaInternacional.Viajes = listaViajes;
                        string condicion = $"Id = {tarjetaInternacional.Id}";
                        tarjetaInternacional.ActualizarEnBaseDeDatos(condicion);
                    
                    }
                    else
                    {
                        MessageBox.Show($"{usuarioExtranjero.Nombre} no tiene saldo suficiente, cargue la tarjeta {tarjetaInternacional.Id}");
                    }

                }

                listaViajes = listaViajes.OrderBy(viaje => viaje.FechaHora).ToList();
                dtgViajes.DataSource = null;
                dtgViajes.DataSource = listaViajes;

            }));
        }

        /// <summary>
        /// Metodo Task para el boton viajar x5
        /// Se utiliza el delegado Func que retorna un objeto Viajes
        /// </summary>
        private async Task ViajarCincoVeces()
        {
            this.Invoke(new Action(async() =>
            {
                //Thread.Sleep(5000);
                await Task.Delay(4000);
                if (usuarioLogueado is UsuarioArgentino usuarioArgentino)
                {
                    Func<Viajes> acumuluarFunciones = () => Viajes.GenerarViajeAleatorio(); ;
                    for (var i = 0; i < 5; i++)
                    {
                        var nuevoViaje = acumuluarFunciones.Invoke();
                        decimal costoViaje = nuevoViaje.ValorBoleto;
                        bool haySaldo = tarjetaNacional.RestarSaldo(costoViaje);
                        if (haySaldo)
                        {
                            listaViajes = listaViajes + nuevoViaje;

                        }
                        else
                        {
                            MessageBox.Show($"{usuarioArgentino.Nombre} no tiene saldo suficiente, cargue la tarjeta {tarjetaNacional.Id}");
                            break;
                        }
                    }
                    tarjetaNacional.Viajes = listaViajes;
                    string condicion = $"Id = {tarjetaNacional.Id}";

                    tarjetaNacional.ActualizarEnBaseDeDatos(condicion);
                }
                else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
                {
                    Func<Viajes> acumuluarFunciones = () => Viajes.GenerarViajeAleatorio(usuarioExtranjero);
                    for (var i = 0; i < 5; i++)
                    {
                        var nuevoViaje = acumuluarFunciones.Invoke();
                        decimal costoViaje = nuevoViaje.ValorBoleto;
                        bool haySaldo = tarjetaInternacional.RestarSaldo(costoViaje);
                        if (haySaldo)
                        {
                            listaViajes = listaViajes + nuevoViaje;

                        }
                        else
                        {
                            MessageBox.Show($"{usuarioExtranjero.Nombre} no tiene saldo suficiente, cargue la tarjeta {tarjetaInternacional.Id}");
                            break;
                        }
                    }
                    tarjetaInternacional.Viajes = listaViajes;
                    string condicion = $"Id = {tarjetaInternacional.Id}";

                    tarjetaInternacional.ActualizarEnBaseDeDatos(condicion);
                }

                listaViajes = listaViajes.OrderBy(viaje => viaje.FechaHora).ToList();
                dtgViajes.DataSource = null;
                dtgViajes.DataSource = listaViajes;

            }));
        }
    }
}
