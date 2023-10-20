using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase el menejo de la lista mensajes
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

        }

        /// <summary>
        /// Creacion de la lista diccionario
        /// </summary>
        public static List<Dictionary<int, string>> listaBajas = new List<Dictionary<int, string>>();

        /// <summary>
        /// Metodo para obtener el ultimo indice de la lista
        /// </summary>
        /// <param name="listaBajas"></param>
        /// <returns>Retorna el ultimo indice + uno</returns>
        public static int obtenerUltimoIndiceListaMensajes(List<Dictionary<int, string>> listaBajas)
        {
            //operador ternario
            int ultimoIndice = listaBajas.Count > 0
                         ? listaBajas.Max(diccionario => diccionario.Keys.Max()) + 1
                         : 1;

            return ultimoIndice;
        }

        /// <summary>
        /// Serealizacion XML de la lista diccionario
        /// </summary>
        /// <param name="listaBajas"></param>
        public static void GuardarMensajesBajaEnArchivo(List<Dictionary<int, string>> listaBajas)
        {
            string rutaArchivo = @"..\..\..\Archivos\mensajes.xml";

            
            List<BajaData> bajaDataList = listaBajas.Select(dic =>
                new BajaData { Indice = dic.Keys.First(), Mensaje = dic.Values.First() }).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<BajaData>));
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                serializer.Serialize(writer, bajaDataList);
            }
        }

        /// <summary>
        /// Deserealizacion de la lista mensajes
        /// </summary>
        /// <returns>Retorna la lista</returns>
        public static List<Dictionary<int, string>> DeserializarMensajesBajaDesdeArchivo()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BajaData>));

            string rutaCarpetaArchivos = @"..\..\..\Archivos";
            string rutaArchivo = Path.Combine(rutaCarpetaArchivos, "mensajes.xml");

            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("El archivo de mensajes no existe.");
                return new List<Dictionary<int, string>>();
            }

            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                List<BajaData> bajaDataList = (List<BajaData>)serializer.Deserialize(reader);

                List<Dictionary<int, string>> listaBajas = new List<Dictionary<int, string>>();
                foreach (var bajaData in bajaDataList)
                {
                    Dictionary<int, string> diccionario = new Dictionary<int, string>
                {
                    { bajaData.Indice, bajaData.Mensaje }
                };
                    listaBajas.Add(diccionario);
                }

                return listaBajas;
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

        /// <summary>
        /// Metodo para validar que el mismo usuario no repita el mensaje de baja
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static bool VerificarNumeroEnListaBajas(int numero)
        {
            bool retorno = false;
            foreach (var diccionario in listaBajas)
            {
                foreach (var kvp in diccionario)
                {
                    int indice = kvp.Key;
                    string mensaje = kvp.Value;

                    if(EsDNIParteDeString(mensaje, numero))
                    {
                        retorno = true;
                    }

                }
            }
            return retorno;
        }
    }
}
