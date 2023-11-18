using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase de manejo de la lista mensajes del usuario al admin
    /// </summary>
    public class ArchivoMensaje
    {
        /// <summary>
        /// Atributos XML para la lista diccionario
        /// </summary>
        public class BajaData
        {
            [XmlAttribute("Indice")]
            public int Indice { get; set; }

            [XmlElement("Mensaje")]
            public string Mensaje { get; set; }

            [XmlElement("confirmacion")]
            public bool confirmacion { get; set; }

            public BajaData()
            {
                // Establecer NamespaceEntidades como false por defecto
                confirmacion = false;
            }
        }

        /// <summary>
        /// Creacion de la lista diccionario
        /// </summary>
        public static List<Dictionary<int, BajaData>> listaBajas = new List<Dictionary<int, BajaData>>();

        /// <summary>
        /// Metodo para obtener el ultimo indice de la lista
        /// </summary>
        /// <param name="listaBajas"></param>
        /// <returns>Retorna el ultimo indice + uno</returns>
        public static int obtenerUltimoIndiceListaMensajes(List<Dictionary<int, BajaData>> listaBajas)
        {
            try
            {
                //operador ternario
                int ultimoIndice = listaBajas.Count > 0
                             ? listaBajas.Max(diccionario => diccionario.Keys.Max()) + 1
                             : 1;
                return ultimoIndice;
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(ArchivoMensaje), nameof(obtenerUltimoIndiceListaMensajes), "Error al obtener el indice", ex);
                return 0;
            }

        }

        /// <summary>
        /// Serealizacion XML de la lista diccionario
        /// </summary>
        /// <param name="listaBajas"></param>

        public static void GuardarMensajesBajaEnArchivo(List<Dictionary<int, BajaData>> listaBajas)
        {
            string rutaArchivo = @"..\..\..\Archivos\mensajes.xml";
            try
            {
                List<BajaData> bajaDataList = listaBajas
                    .SelectMany(dic => dic.Values)
                    .ToList();

                XmlSerializer serializer = new XmlSerializer(typeof(List<BajaData>));
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    serializer.Serialize(writer, bajaDataList);
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(ArchivoMensaje), nameof(GuardarMensajesBajaEnArchivo), "Error al guardar el mensaje", ex);
            }
        }

        /// <summary>
        /// Deserealizacion de la lista mensajes
        /// </summary>
        /// <returns>Retorna la lista</returns>
        public static List<Dictionary<int, BajaData>> DeserializarMensajesBajaDesdeArchivo()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<BajaData>));

                string rutaCarpetaArchivos = @"..\..\..\Archivos";
                string rutaArchivo = Path.Combine(rutaCarpetaArchivos, "mensajes.xml");

                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo de mensajes no existe.");
                    return new List<Dictionary<int, BajaData>>();
                }

                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    List<BajaData> bajaDataList = (List<BajaData>)serializer.Deserialize(reader);

                    List<Dictionary<int, BajaData>> listaBajas = bajaDataList
                        .Select(bajaData => new Dictionary<int, BajaData> { { bajaData.Indice, bajaData } })
                        .ToList();

                    return listaBajas;
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(ArchivoMensaje), nameof(DeserializarMensajesBajaDesdeArchivo), "Error al cargar el archivo", ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo para validar que un entero sea parte del mensaje
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="numero"></param>
        /// <returns>retorna true o false</returns>
        public static bool EsDNIParteDeString(string cadena, int numero)
        {
            string numeroStr = numero.ToString();

            return cadena.Contains(numeroStr);
        }
        public static bool EsTarjetaParteDeString(string cadena, int numero)
        {
            string numeroStr = numero.ToString();

            return cadena.Contains(numeroStr);
        }

        /// <summary>
        /// Metodo para validar que el mismo usuario no repita el mensaje de baja
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static bool VerificarNumeroEnListaBajas(int numeroDni, int numeroTarjeta)
        {
            try
            {
                return listaBajas.Any(diccionario =>
                    diccionario.Any(kvp =>
                        EsDNIParteDeString(kvp.Value.Mensaje, numeroDni) && EsTarjetaParteDeString(kvp.Value.Mensaje, numeroTarjeta)
                    )
                );
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(ArchivoMensaje), nameof(VerificarNumeroEnListaBajas), "Error al realizar el método", ex);
                return false;
            }
        }
    }
}
