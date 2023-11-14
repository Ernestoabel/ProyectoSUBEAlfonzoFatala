using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Entidades
{
    public class TarjetaNacional : Tarjeta, IOperacionesSistema<TarjetaNacional>, IGenerarFacturaPDF<TarjetaNacional>
    {

        IdManager idManagerNacional = new IdManager(true);
        public static List<TarjetaNacional> listaTarjetasNacionales = new List<TarjetaNacional>();
        public static int ultimoNumeroFactura = ObtenerUltimoNumeroFactura();

        public TarjetaNacional(int id, decimal saldo, List<Viajes> viajes) : base(id, saldo, viajes)
        {

        }
        public TarjetaNacional()
        {

        }

        public override List<Viajes> Viajes { get; set; }

        /// <summary>
        /// trae el id
        /// </summary>
        /// <param name="UltimoNumeroEnLista"></param>
        public override void DesignarId(int UltimoNumeroEnLista)
        {
            this.Id = UltimoNumeroEnLista;
        }

        /// <summary>
        /// Mediante la clase manejadora crea el proximo id 
        /// </summary>
        /// <returns></returns>
        protected override int GenerarNuevoId()
        {
            return idManagerNacional.GetNextId();
        }

        /// <summary>
        /// Metodo para serealizar la lista
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        public void GuardarEnArchivo(List<TarjetaNacional> lista, string nombreArchivo)
        {
            try
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
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(GuardarEnArchivo), "Error al serializar la lista de tarjeta nacional", ex);
            }
        }

        /// <summary>
        /// Metodo para deserealizar la lista
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public List<TarjetaNacional> CargarDesdeArchivo(string nombreArchivo)
        {
            List<TarjetaNacional> usuarios = new List<TarjetaNacional>();
            string rutaArchivo = Path.Combine(@"..\..\..\Archivos", nombreArchivo);

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    usuarios = JsonConvert.DeserializeObject<List<TarjetaNacional>>(jsonData);
                }
                catch (Exception ex)
                {
                    CatchError.LogError(nameof(TarjetaNacional), nameof(CargarDesdeArchivo), "Error al deserializar la lista de tarjeta nacional", ex);
                }
            }

            return usuarios;
        }

        /// <summary>
        /// Metodo para insertar datos en mySql
        /// </summary>
        /// <param name="tarjetasNacionales"></param>
        public static void InsertarEnBaseDeDatos(List<TarjetaNacional> tarjetasNacionales)
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                accesoBD.InsertarElementosSQL(tarjetasNacionales, "tarjetanacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(InsertarEnBaseDeDatos), "Error al insertar tabla mySQL de tarjeta nacional", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener datos de la tabla mySql
        /// </summary>
        /// <returns></returns>
        public static List<TarjetaNacional> ObtenerDeBaseDeDatos()
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                return accesoBD.ObtenerElementosSQL("tarjetanacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(ObtenerDeBaseDeDatos), "Error al obtener tabla mySQL de tarjeta nacional", ex);
                return null;
            }
        }
        /// <summary>
        /// Metodo para actualizar la tabla en mySql
        /// </summary>
        /// <param name="condicion"></param>
        public void ActualizarEnBaseDeDatos(string condicion)
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                accesoBD.ActualizarElementoSQL(this, "tarjetanacional", condicion);
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(ActualizarEnBaseDeDatos), "Error al actualizar tabla mySQL de tarjeta nacional", ex);
            }
        }
        /// <summary>
        /// Metodo para agregar una fila a la tabla mySql
        /// </summary>
        public void AgregarElementoSQL()
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                accesoBD.AgregarElementoSQL(this, "tarjetanacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(AgregarElementoSQL), "Error al insertar fila a la tabla mySQL de tarjeta nacional", ex);
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
                CatchError.LogError(nameof(TarjetaNacional), nameof(GenerarFacturaPDF), "Error en el metodo", ex);
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
                CatchError.LogError(nameof(TarjetaNacional), nameof(ObtenerUltimoNumeroFactura), "Error en el metodo", ex);
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
                CatchError.LogError(nameof(TarjetaNacional), nameof(ActualizarUltimoNumeroFactura), "Error en el metodo", ex);
            }
        }

    }
}
