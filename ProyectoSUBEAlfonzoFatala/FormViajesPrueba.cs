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
        Usuario usuarioLogueado;
        TarjetaNacional tarjetaNacional = new TarjetaNacional();
        TarjetaInternacional tarjetaInternacional = new TarjetaInternacional();
        private CancellationTokenSource cancellationTokenSource;

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
        public void TraerUsuario(Usuario usuario)
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
                        tarjetaNacional = TarjetaNacional.listaTarjetasNacionales.FirstOrDefault(tarjeta => tarjeta.Id == int.Parse(usuarioArgentino.IdSubeArgentina));
                        List<Viajes> viajes = Viajes.ObtenerViajesPorTarjetaSQL(int.Parse(usuarioArgentino.IdSubeArgentina));
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
                        tarjetaInternacional = TarjetaInternacional.listaTarjetasIntenacionales.FirstOrDefault(tarjeta => tarjeta.Id == int.Parse(usuarioExtranjero.IdSubeExtranjero));
                        List<Viajes> viajes = Viajes.ObtenerViajesPorTarjetaSQL(int.Parse(usuarioExtranjero.IdSubeExtranjero));
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
            catch (Exception ex)
            {
                CatchError.LogError(nameof(FormViajesPrueba), nameof(TraerUsuario), "Error en el metodo", ex);
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

            // Las celdas no se pueden modificar
            this.dtgViajes.ReadOnly = true;

            this.dtgViajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dtgViajes.AllowUserToResizeRows = false;

            // Les da Nombre a las columnas
            this.dtgViajes.Columns[nameof(Viajes.FechaHora)].HeaderText = "Fecha y hora";
            this.dtgViajes.Columns[nameof(Viajes.MedioTransporte)].HeaderText = "Medio de Transporte";
            this.dtgViajes.Columns[nameof(Viajes.ValorBoleto)].HeaderText = "Costo del viaje";
            this.dtgViajes.Columns[nameof(Viajes.TarjetaNacionalId)].Visible = false;
            this.dtgViajes.Columns[nameof(Viajes.TarjetaInternacionalId)].Visible = false;

            // Oculta la columna del índice
            this.dtgViajes.RowHeadersVisible = false;

            // Opción para cuando se maximiza la ventana y tome toda la ventana
            this.dtgViajes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Asigna colores diferentes según el enumerado MedioTransporte
            foreach (DataGridViewRow row in this.dtgViajes.Rows)
            {
                if (row.Cells[nameof(Viajes.MedioTransporte)].Value is EMedioTransporte transporte)
                {
                    switch (transporte)
                    {
                        case EMedioTransporte.Autobus:
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case EMedioTransporte.Subte:
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case EMedioTransporte.Tren:
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                            break;
                        case EMedioTransporte.Bicicleta:
                            row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                            break;
                    }
                }
            }

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

                    if (haySaldo)
                    {
                        listaViajes.Add(nuevoViaje);
                        Viajes.InsertarViajeSQL(nuevoViaje, int.Parse(usuarioArgentino.IdSubeArgentina));
                    }
                    else
                    {
                        lblMensaje.Text = "no tiene saldo suficiente, cargue la tarjeta";
                    }

                }
                else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
                {
                    Viajes nuevoViaje = Viajes.GenerarViajeAleatorio(usuarioExtranjero);
                    decimal costoViaje = nuevoViaje.ValorBoleto;
                    bool haySaldo = tarjetaInternacional.RestarSaldo(costoViaje);

                    if (haySaldo)
                    {
                        listaViajes.Add(nuevoViaje);
                        Viajes.InsertarViajeSQL(nuevoViaje, int.Parse(usuarioExtranjero.IdSubeExtranjero));

                    }
                    else
                    {
                        lblMensaje.Text = "no tiene saldo suficiente, cargue la tarjeta";
                    }

                }
                SetTimer(3000);
                listaViajes = listaViajes.OrderBy(viaje => viaje.FechaHora).ToList();
                dtgViajes.DataSource = null;
                dtgViajes.DataSource = listaViajes;
                SetDataGridViewStyle();
            }));
        }

        /// <summary>
        /// Metodo Task para el boton viajar x5
        /// Se utiliza el delegado Func que retorna un objeto Viajes
        /// </summary>
        private async Task ViajarCincoVeces()
        {
            this.Invoke(new Action(async () =>
            {
                // Crear un nuevo origen del token de cancelación antes de iniciar el bucle
                cancellationTokenSource = new CancellationTokenSource();

                try
                {
                    int randomDelay = new Random().Next(3, 9);

                    int factorCosto = randomDelay;

                    await Task.Delay(randomDelay * 1000, cancellationTokenSource.Token);

                    Random random = new Random();

                    if (usuarioLogueado is UsuarioArgentino usuarioArgentino)
                    {
                        Func<Viajes> acumuluarFunciones = () => Viajes.GenerarViajeAleatorio();

                        Viajes nuevoViaje = acumuluarFunciones.Invoke();
                        nuevoViaje.ValorBoleto = nuevoViaje.ValorBoleto * factorCosto;
                        lblMensaje.Text = "Usted viajo: " + randomDelay * 10 + "Km con costo por: " + nuevoViaje.ValorBoleto;
                        lblMensaje.ForeColor = Color.White;
                        bool haySaldo = tarjetaNacional.RestarSaldo(nuevoViaje.ValorBoleto);

                        if (haySaldo)
                        {
                            listaViajes.Add(nuevoViaje);
                            Viajes.InsertarViajeSQL(nuevoViaje, int.Parse(usuarioArgentino.IdSubeArgentina));
                        }
                        else
                        {
                            lblMensaje.ForeColor = Color.White;
                            lblMensaje.Text = "No tiene saldo suficiente, cargue la tarjeta";
                        }

                    }
                    else if (usuarioLogueado is UsuarioExtranjero usuarioExtranjero)
                    {
                        Func<Viajes> acumuluarFunciones = () => Viajes.GenerarViajeAleatorio(usuarioExtranjero);
                        Viajes nuevoViaje = acumuluarFunciones.Invoke();
                        nuevoViaje.ValorBoleto = nuevoViaje.ValorBoleto * factorCosto;
                        lblMensaje.Text = "Usted viajo: " + randomDelay * 10 + "Km con costo por: " + nuevoViaje.ValorBoleto;
                        lblMensaje.ForeColor = Color.White;
                        bool haySaldo = tarjetaNacional.RestarSaldo(nuevoViaje.ValorBoleto);

                        if (haySaldo)
                        {
                            listaViajes.Add(nuevoViaje);
                            Viajes.InsertarViajeSQL(nuevoViaje, int.Parse(usuarioExtranjero.IdSubeExtranjero));
                        }
                        else
                        {
                            //lblMensaje.ForeColor = Color.White;
                            lblMensaje.Text = "No tiene saldo suficiente, cargue la tarjeta";
                        }

                    }

                    SetTimer(6000);
                    listaViajes = listaViajes.OrderBy(viaje => viaje.FechaHora).ToList();
                    dtgViajes.DataSource = null;
                    dtgViajes.DataSource = listaViajes;
                    SetDataGridViewStyle();
                }
                catch (OperationCanceledException)
                {
                    // La excepción se lanza si se cancela la operación
                    lblMensaje.ForeColor = Color.White;
                    lblMensaje.Text = "Se cancelo el viaje";
                }
                finally
                {
                    // Limpiar el token de cancelación después de la ejecución
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = null;
                }
            }));
        }

        private void SetTimer(int intervalo)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = intervalo;
            timer.Tick += (sender, e) =>
            {
                lblMensaje.Text = "";  // Limpiar el mensaje después del intervalo
                timer.Stop();  // Detener el temporizador
                timer.Dispose();  // Liberar recursos
            };
            timer.Start();  // Iniciar el temporizador
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}
