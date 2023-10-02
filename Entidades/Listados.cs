using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void AgregarUsuarioArgentino()
        {
            listaUsuarios.Add(new UsuarioArgentino("Carlos", "Pepe", "30555199", "Carlos@hotmail.com", "1234","1001"));
        }
        public static void AgregarUsuarioExtranjero()
        {
            listaUsuarios.Add(new UsuarioExtranjero("Carlos", "Pepe", "30555199", "Carlos@hotmail.com", "1234", "5001"));
        }

        public static void GuardarUsuariosEnArchivo(List<Usuario> lista)
        {
            
                JsonSerializer serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter(@"..\..\Archivos\usuarios.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, lista);
                }
           
        }


    }
}
