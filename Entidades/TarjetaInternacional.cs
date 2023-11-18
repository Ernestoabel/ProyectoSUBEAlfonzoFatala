using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Entidades
{
    /// <summary>
    /// Clase de Tarjeta Internacional
    /// </summary>
    public class TarjetaInternacional : Tarjeta, IOperacionesSistema<TarjetaInternacional>, IGenerarFacturaPDF<TarjetaInternacional>
    {
        
        IdManager idManager = new IdManager(false);
        public static List<TarjetaInternacional> listaTarjetasIntenacionales = new List<TarjetaInternacional>();
        public static int ultimoNumeroFactura = ObtenerUltimoNumeroFactura();

        public TarjetaInternacional(int id, decimal saldo) : base(id, saldo)
        {
           
        }
        public TarjetaInternacional()
        {
            
        }



        public override void DesignarId(int UltimoNumeroEnLista)
        {
            this.Id = UltimoNumeroEnLista;
        }

        protected override int GenerarNuevoId()
        {
            return idManager.GetNextId();
        }
        
        /// <summary>
        /// Metodo interface para serializar la tarjeta
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        public void GuardarEnArchivo(List<TarjetaInternacional> lista, string nombreArchivo)
        {
            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = @"..\..\..\Archivos";

            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(rutaCarpetaArchivos, nombreArchivo)))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }
        }

        /// <summary>
        /// Sobrecarga de la serialiacion para indicarle no solo el archivo sino tambien la carpeta a guardar
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        /// <param name="rutaCarpetaArchivos"></param>
        public void GuardarEnArchivo(List<TarjetaInternacional> lista, string nombreArchivo, string rutaCarpetaArchivos)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                if (!Directory.Exists(rutaCarpetaArchivos))
                {
                    Directory.CreateDirectory(rutaCarpetaArchivos);
                }

                string rutaCompleta = Path.Combine(rutaCarpetaArchivos, nombreArchivo);

                using (StreamWriter sw = new StreamWriter(rutaCompleta))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, lista);
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(GuardarEnArchivo), "Error al serealizar tarjeta internacional", ex);
            }
        }

        /// <summary>
        /// Deserealizacion de la lista de tarjetasInternacional
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public List<TarjetaInternacional> CargarDesdeArchivo(string nombreArchivo)
        {
            
            List<TarjetaInternacional> usuarios = new List<TarjetaInternacional>();
            string rutaArchivo = Path.Combine(@"..\..\..\Archivos", nombreArchivo);

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    usuarios = JsonConvert.DeserializeObject<List<TarjetaInternacional>>(jsonData);
                }
                catch (Exception ex)
                {
                    CatchError.LogError(nameof(TarjetaInternacional), nameof(CargarDesdeArchivo), "Error al deserealizar tarjeta internacional", ex);
                }
            }

            return usuarios;
        }

        /// <summary>
        /// Metodo para insertar datos en mySql
        /// </summary>
        /// <param name="tarjetasInternacionales"></param>
        public static void InsertarEnBaseDeDatos(List<TarjetaInternacional> tarjetasInternacionales)
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                accesoBD.InsertarElementosSQL(tarjetasInternacionales, "tarjetainternacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(InsertarEnBaseDeDatos), "Error al insertar mySQL tarjeta internacional", ex);
            }
        }
        /// <summary>
        /// Metodo para obtener la tabla mySQL
        /// </summary>
        /// <returns></returns>
        public static List<TarjetaInternacional> ObtenerDeBaseDeDatos()
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                return accesoBD.ObtenerElementosSQL("tarjetainternacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(ObtenerDeBaseDeDatos), "Error al obtener mySQL tarjeta internacional", ex);
                return null;
            }
        }
        /// <summary>
        /// Metodo para modificar la tabla mySQL
        /// </summary>
        /// <param name="condicion"></param>
        public void ActualizarEnBaseDeDatos(string condicion)
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                accesoBD.ActualizarElementoSQL(this, "tarjetainternacional", condicion);
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(ActualizarEnBaseDeDatos), "Error al actualizar mySQL tarjeta internacional", ex);
            }
        }
        /// <summary>
        /// Metodo para agregar una fila a la tabla mySql
        /// </summary>
        public void AgregarElementoSQL()
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                accesoBD.AgregarElementoSQL(this, "tarjetainternacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(AgregarElementoSQL), "Error al agregar fila mySQL tarjeta internacional", ex);
            }
        }
        /// <summary>
        /// Metodo para generar un pdf con la factura cuando se carga la tarjeta
        /// Se utiliza el nuget iTextSharp
        /// </summary>
        /// <param name="tarjeta"></param>
        /// <param name="txtMonto"></param>
        public static void GenerarFacturaPDF(Tarjeta tarjeta, string txtMonto)
        {
            try
            {
                ultimoNumeroFactura++;

                // Crear un documento PDF
                string nombreArchivo = @$"..\..\..\Archivos\Facturas\Factura_{ultimoNumeroFactura}.pdf";

                using (FileStream fs = new FileStream(nombreArchivo, FileMode.Create))
                {
                    using (Document pdfDoc = new Document())
                    {
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, fs);

                        // Agregar contenido al documento
                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph("Factura de Saldo Acreditado"));
                        pdfDoc.Add(new Paragraph($"Número de Factura: {ultimoNumeroFactura}"));
                        pdfDoc.Add(new Paragraph($"ID de Tarjeta: {tarjeta.Id}"));
                        pdfDoc.Add(new Paragraph($"Saldo Actual: {tarjeta.Saldo}"));
                        pdfDoc.Add(new Paragraph($"Saldo Acreditado: {txtMonto}"));

                        // Guardar el documento
                        pdfDoc.Close();
                    }

                    // Actualizar el archivo con el nuevo número de factura
                    ActualizarUltimoNumeroFactura();
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(GenerarFacturaPDF), "Error en el metodo", ex);
            }
        }
        /// <summary>
        /// Metodo para obtener el numero de la ultima factura en un archivo
        /// </summary>
        /// <returns></returns>
        public static int ObtenerUltimoNumeroFactura()
        {
            try
            {
                string rutaArchivo = @"..\..\..\Archivos\UltimoNumeroFactura.txt";

                if (File.Exists(rutaArchivo))
                {
                    string contenido = File.ReadAllText(rutaArchivo);

                    if (int.TryParse(contenido, out int ultimoNumero))
                    {
                        return ultimoNumero;
                    }
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(ObtenerUltimoNumeroFactura), "Error en el metodo", ex);
            }

            // Si no se puede obtener el último número, devolver un valor predeterminado
            return 1000;
        }

        /// <summary>
        /// Metodo para actualizar el archivo con el numero de la ultima factura
        /// </summary>
        public static void ActualizarUltimoNumeroFactura()
        {
            try
            {
                string rutaArchivo = @"..\..\..\Archivos\UltimoNumeroFactura.txt";

                File.WriteAllText(rutaArchivo, ultimoNumeroFactura.ToString());
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(ActualizarUltimoNumeroFactura), "Error en el metodo", ex);
            }
        }

    }
}
