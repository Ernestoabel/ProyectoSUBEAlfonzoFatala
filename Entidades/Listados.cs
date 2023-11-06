
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
    public class Listados
    {
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        
        #region Metodos

        public static void AgregarUsuario(Usuario objeto)
        {
            listaUsuarios.Add(objeto);
        }

        /// <summary>
        /// Metodo para serealizar la lista de usuarios
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        public static void GuardarEnArchivo(List<Usuario> lista, string nombreArchivo) 
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
                CatchError.LogError(nameof(Listados), nameof(GuardarEnArchivo), "Error al serializar la lista de usuarios", ex);
            }
        }
       

        
        #endregion


    }
}
