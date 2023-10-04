﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entidades
{
    public class Listados
    {
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public static List<UsuarioArgentino> listaUsuariosArgentinos = new List<UsuarioArgentino>();
        public static List<UsuarioExtranjero> listaUsuariosExtranjeros = new List<UsuarioExtranjero>();
        public static List<TarjetaNacional> listaTarjetasNacionales = new List<TarjetaNacional>();
        public static List<TarjetaInternacional> listaTarjetasIntenacionales = new List<TarjetaInternacional>();
        public static List<Viajes> ViajeTarjeta1001 = new List<Viajes>();
        public static List<Viajes> ViajeTarjeta5001 = new List<Viajes>();

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
            DateTime fechaHardcodeada = new DateTime(2023, 10, 4, 15, 30, 0);
            ViajeTarjeta1001.Add(new Viajes(fechaHardcodeada, "Mirage", 28));
            
        }

        public static void AgregarViajes5001()
        {
            DateTime fechaHardcodeada = new DateTime(2023, 10, 4, 15, 30, 0);
            ViajeTarjeta5001.Add(new Viajes(fechaHardcodeada, "Mirage", 28));

        }
        public static void GuardarUsuariosEnArchivo(List<Usuario> lista)
        {

            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Archivos");


            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\Archivos\usuarios.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }

        }

        public static List<Usuario> CargarUsuariosDesdeArchivo()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Archivos\usuarios.json");

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonData);
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

        public static void GuardarTarjetaNacionalEnArchivo(List<TarjetaNacional> lista)
        {

            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Archivos");


            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\Archivos\tarjetaNacional.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }

        }

        public static List<TarjetaNacional> CargarTarjetaNacionalsDesdeArchivo()
        {
            List<TarjetaNacional> tarjetas = new List<TarjetaNacional>();
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Archivos\tarjetaNacional.json");

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

        public static void GuardarTarjetaInternacionalEnArchivo(List<TarjetaInternacional> lista)
        {

            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Archivos");


            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\Archivos\tarjetaInternacional.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }

        }

        public static List<TarjetaInternacional> CargarTarjetaInternacionalDesdeArchivo()
        {
            List<TarjetaInternacional> tarjetas = new List<TarjetaInternacional>();
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Archivos\tarjetaInternacional.json");

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

    }
}
