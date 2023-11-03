using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class TarjetaInternacional : Tarjeta, IOperacionesSistema<TarjetaInternacional>
    {
        
        IdManager idManager = new IdManager(false);
        public static List<TarjetaInternacional> listaTarjetasIntenacionales = new List<TarjetaInternacional>();

        public TarjetaInternacional(int id, decimal saldo, List<Viajes> viajes) : base(id, saldo, viajes)
        {
           
        }
        public TarjetaInternacional()
        {
            
        }


        public override List<Viajes> Viajes { get; set; }

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
                    Console.WriteLine("Error al deserializar el archivo: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("El archivo de usuarios no existe.");
            }

            return usuarios;
        }

        public static void InsertarEnBaseDeDatos(List<TarjetaInternacional> tarjetasInternacionales)
        {
            AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
            accesoBD.InsertarElementosSQL(tarjetasInternacionales, "tarjetainternacional");
        }

        public static List<TarjetaInternacional> ObtenerDeBaseDeDatos()
        {
            AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
            return accesoBD.ObtenerElementosSQL("tarjetainternacional");
        }

        public void ActualizarEnBaseDeDatos(string condicion)
        {
            AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
            accesoBD.ActualizarElementoSQL(this, "tarjetainternacional", condicion);
        }
        public void AgregarElementoSQL()
        {
            AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
            accesoBD.AgregarElementoSQL(this, "tarjetainternacional");
        }

    }
}
