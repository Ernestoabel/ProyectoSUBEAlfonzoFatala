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
using static Entidades.Listados;
using System.Xml.Serialization;
using static Entidades.ArchivoMensaje;
using System.Net.Mail;

namespace ProyectoSUBEAlfonzoFatala
{

    public partial class FormBajaUsuario : Form
    {
        string mensaje;
        int indice = 1;
        int dni;
        int tarjeta;
        const string Usuario = "proyectosube.ps@gmail.com";
        const string Password = "rasz wqyj tmhn oguf";
        public FormBajaUsuario()
        {
            InitializeComponent();
        }

        public void TraerUsuario(object usuario)
        {
            try
            {
                if (usuario is UsuarioSinTarjeta)
                {
                    throw new UsuarioSinTarjetaException();
                }
                else if (usuario is UsuarioArgentino usuarioArgentino)
                {
                    mensaje = $"El usuario {usuarioArgentino.Dni} con la tarjeta {usuarioArgentino.IdSubeArgentina} quiere la baja";
                    indice = ArchivoMensaje.obtenerUltimoIndiceListaMensajes(ArchivoMensaje.listaBajas);
                    dni = int.Parse(usuarioArgentino.Dni);
                    tarjeta = int.Parse(usuarioArgentino.IdSubeArgentina);
                }
                else if (usuario is UsuarioExtranjero usuarioExtranjero)
                {
                    mensaje = $"El usuario {usuarioExtranjero.Dni} con la tarjeta {usuarioExtranjero.IdSubeExtranjero} quiere la baja";
                    indice = ArchivoMensaje.obtenerUltimoIndiceListaMensajes(ArchivoMensaje.listaBajas);
                    dni = int.Parse(usuarioExtranjero.Dni);
                    tarjeta = int.Parse(usuarioExtranjero.IdSubeExtranjero);
                }
            }
            catch (UsuarioSinTarjetaException)
            {
                btnBajaTarjetaUsuario.Enabled = false;
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(FormBajaUsuario), nameof(TraerUsuario), "Error en el metodo", ex);
            }
        }
        private void btnBajaTarjetaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ArchivoMensaje.VerificarNumeroEnListaBajas(dni, tarjeta))
                {
                    ArchivoMensaje.listaBajas.Add(new Dictionary<int, BajaData> { { indice, new BajaData { Indice = indice, Mensaje = mensaje } } });
                    ArchivoMensaje.GuardarMensajesBajaEnArchivo(ArchivoMensaje.listaBajas);
                    lblMensaje.Text = "El mensaje fue enviado";
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                lblMensaje.Text = "Esta tarjeta ya pidio la baja";
            }
        }

        /// <summary>
        /// Metodo que toma desde los text box la informacion para enviar al 
        /// administrador con el mail "proyectosube.ps@gmail.com" los 
        /// mensajes especificos
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="FechaEnvio"></param>
        /// <param name="de"></param>
        /// <param name="para"></param>
        /// <param name="asunto"></param>
        /// <param name="error"></param>
        public static async Task<bool> EnviarCorreoAsync(StringBuilder mensaje, DateTime FechaEnvio, string de, string para, string asunto)
        {
            try
            {
                mensaje.Append(Environment.NewLine);
                mensaje.Append(string.Format("Este correo ha sido enviado el día {0:dd:/MM/yyyy} a las {0:HH:mm:ss} hs : \n\n", FechaEnvio));
                mensaje.Append(Environment.NewLine);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(de);
                mail.To.Add(para);
                mail.Subject = asunto;
                mail.Body = mensaje.ToString();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(Usuario, Password);
                smtp.EnableSsl = true;

                VentanaEmergenteCorreoEnviado enviandoCorreo = new VentanaEmergenteCorreoEnviado();
                enviandoCorreo.Show();

                await Task.Delay(5000); // Retraso de 5 segundos
                await Task.Run(() =>
                {
                    smtp.Send(mail);
                });
                enviandoCorreo.Close();
                return true; // El correo se envió exitosamente
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false; // Indica que hubo un error al enviar el correo
            }
        }

        private void btnCorreo_Click(object sender, EventArgs e)
        {
            //EnviarCorreo()
            bool visible = true;
            HacerControlersVisibles(visible);

        }

        /// <summary>
        /// Hace los controlers visibles
        /// </summary>
        private void HacerControlersVisibles(bool visible)
        {
            if(visible)
            {
                txtAsunto.Visible = true;
                txtDe.Visible = true;
                txtPara.Visible = true;
                lblAsunto.Visible = true;
                lblDe.Visible = true;
                lblPara.Visible = true;
                lblMsj.Visible = true;
                txtMensaje.Visible = true;
                btnEnviarEmail.Visible = true;
            }
            else
            {
                txtAsunto.Text = "";
                txtDe.Text = "";
                txtPara.Text = "";
                lblAsunto.Text = "";
                lblDe.Text = "";
                lblPara.Text = "";
                lblMsj.Text = "";
                txtMensaje.Text = "";
                btnEnviarEmail.Text = "";


                txtAsunto.Visible = false;
                txtDe.Visible = false;
                txtPara.Visible = false;
                lblAsunto.Visible = false;
                lblDe.Visible = false;
                lblPara.Visible = false;
                lblMsj.Visible = false;
                txtMensaje.Visible = false;
                btnEnviarEmail.Visible = false;
            }
           
        }

        /// <summary>
        /// Envia el correo hacia el propio admin 
        /// (no se puede simular un envio desde todas las cuentas de mail por
        ///  el token y la verificacion en dos pasos, por la exposicion a los
        ///  datos.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            
            bool visible = false;

            StringBuilder mensajeBuilder = new StringBuilder();

            mensajeBuilder.Append(txtMensaje.Text.Trim());

            bool correoEnviado = await EnviarCorreoAsync(mensajeBuilder, DateTime.Now, txtDe.Text.Trim(), "proyectosube.ps@gmail.com", txtAsunto.Text.Trim());

            if (correoEnviado ) 
            {
                ///logica para cargar el mensaje en el admin
            }

            HacerControlersVisibles(visible);
        }
    }
}


