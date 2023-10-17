
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Entidades
{
    public static class Listados
    {
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public static List<UsuarioArgentino> listaUsuariosArgentinos = new List<UsuarioArgentino>();
        public static List<UsuarioExtranjero> listaUsuariosExtranjeros = new List<UsuarioExtranjero>();
        public static List<TarjetaNacional> listaTarjetasNacionales = new List<TarjetaNacional>();
        public static List<TarjetaInternacional> listaTarjetasIntenacionales = new List<TarjetaInternacional>();
        public static List<Viajes> ViajeTarjeta1001 = new List<Viajes>();
        public static List<Viajes> ViajeTarjeta5001 = new List<Viajes>();
        public static List<Viajes> listaDeViajes = new List<Viajes>();
        


        #region Metodos

        public static void AgregarUsuario(Usuario objeto)
        {
            listaUsuarios.Add(objeto);
        }
        public static void AgregarTarjetaNacional(TarjetaNacional objeto)
        {
            listaTarjetasNacionales.Add(objeto);
        }
        public static void AgregarTarjetaInternacional(TarjetaInternacional objeto)
        {
            listaTarjetasIntenacionales.Add(objeto);
        }

        static Listados()
        {
            AgregarViajes1001();
            AgregarViajes5001();
        }
        public static void AgregarViajes1001()
        {
            /*DateTime fechaHardcodeada = new DateTime(2023, 10, 4, 15, 30, 0);
            ViajeTarjeta1001.Add(new Viajes(fechaHardcodeada, "Mirage", 28));*/
            
            Viajes manager = new Viajes();
            manager.AgregarViaje(DateTime.Parse("2023-09-30 10:00:00"), "Autobus", 36);
            manager.AgregarViaje(DateTime.Parse("2023-09-30 10:00:00"), "Tren", 24);
            manager.AgregarViaje(DateTime.Parse("2023-09-30 10:00:00"), "Autobus", 63);
            manager.AgregarViaje(DateTime.Parse("2023-09-30 10:00:00"), "Subte", 38);

            ViajeTarjeta1001 = manager.ObtenerListaDeViajes();

            //metodo guardar viajes en json

        }

        

        // Metodo para traerme los datos de la lista listo
        // Metodo que sume los datos del valor boleto 
        // Metodo que Reste al saldo de la tarjeta


        public static void AgregarViajes5001()
        {
            Viajes extranjeroUno = new Viajes();
            extranjeroUno.AgregarViaje(DateTime.Parse("2023-10-04 20:09:10"), "Autobus",29);
            extranjeroUno.AgregarViaje(DateTime.Parse("2023-10-01 18:01:50"), "Tren", 21);
            extranjeroUno.AgregarViaje(DateTime.Parse("2023-10-04 06:02:30"), "Subte", 31);
            extranjeroUno.AgregarViaje(DateTime.Parse("2023-10-04 21:23:05"), "Tren", 42);

            ViajeTarjeta5001 = extranjeroUno.ObtenerListaDeViajes();    
        }



        /// <summary>
        /// Serializacion de las tres clases de Usuario en un JSON
        /// </summary>
        /// <param name="lista"></param>
        public static void GuardarUsuariosEnArchivo(List<Usuario> lista)
        {

            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = @"..\..\..\Archivos";


            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\..\Archivos\usuarios.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }

        }

        /// <summary>
        /// Serealizacion de las tarjetas SUBE nacionales en JSON
        /// </summary>
        /// <param name="lista"></param>
        public static void GuardarTarjetaNacionalEnArchivo(List<TarjetaNacional> lista)
        {

            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = @"..\..\..\Archivos";


            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\..\Archivos\tarjetaNacional.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }

        }

        /// <summary>
        /// Deserealizacion de la lista SUBE de tarjetas nacionales en JSON
        /// </summary>
        /// <returns>retorna la lista</returns>
        public static List<TarjetaNacional> CargarTarjetaNacionalsDesdeArchivo()
        {
            List<TarjetaNacional> tarjetas = new List<TarjetaNacional>();
            string rutaArchivo = @"..\..\..\Archivos\tarjetaNacional.json";

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    tarjetas = JsonConvert.DeserializeObject<List<TarjetaNacional>>(jsonData);
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

            return tarjetas;
        }

        /// <summary>
        /// Serealizacion de la lista SUBE tarjetas internacionales en JSON
        /// </summary>
        /// <param name="lista"></param>
        public static void GuardarTarjetaInternacionalEnArchivo(List<TarjetaInternacional> lista)
        {

            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = @"..\..\..\Archivos";


            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\..\Archivos\tarjetaInternacional.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }

        }

        /// <summary>
        /// Deserealizacion de la lista de tarjetas SUBE internacionales en JSON
        /// </summary>
        /// <returns></returns>
        public static List<TarjetaInternacional> CargarTarjetaInternacionalDesdeArchivo()
        {
            List<TarjetaInternacional> tarjetas = new List<TarjetaInternacional>();
            string rutaArchivo = @"..\..\..\Archivos\tarjetaInternacional.json";

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    tarjetas = JsonConvert.DeserializeObject<List<TarjetaInternacional>>(jsonData);
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

            return tarjetas;
        }

        
        #endregion


    }
}
