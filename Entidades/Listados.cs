
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


        public static void AgregarUsuario(Usuario objeto)
        {
            listaUsuarios.Add(objeto);
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


    }
}
