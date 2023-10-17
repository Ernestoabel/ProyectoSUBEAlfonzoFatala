using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Metodo para buscar un usuario por dni
    /// Castearlo segun su clase heredada de Usuario
    /// y retornalo para manejarlo en el formInicio
    /// </summary>
    public class ManejoDeListados
    {
        public static List<string> listaBajas = new List<string>();
        public static Usuario ObtenerUsuarioPorDniYTarjeta(string dni)
        {
            Usuario usuario = Listados.listaUsuarios.FirstOrDefault(u => u.Dni == dni);

            if (usuario != null)
            {
                if (!usuario.TieneTarjeta && usuario.Dni[0] > '0')
                {
                    return (UsuarioSinTarjeta)usuario;
                }
                else if (usuario.Dni[0] > '0' && usuario.Dni[0] < '9')
                {
                    return (UsuarioArgentino)usuario;
                }
                else if (usuario.Dni.Length == 3)
                {
                    return (UsuarioAdministrador)usuario;
                }
                else if (usuario.Dni[0] >= '9')
                {
                    return (UsuarioExtranjero)usuario;
                }

            }

            return null;
        }

        /// <summary>
        /// Metodo para deserializar el json de usuarios
        /// recorre el json y guarda en la lista segun clase heredada
        /// </summary>
        /// <returns>Retorna la lista</returns>
        public static List<Usuario> DeserializeUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string rutaArchivo = @"..\..\..\Archivos\usuarios.json";

            string jsonData = File.ReadAllText(rutaArchivo);

            var usuariosData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonData);

            if (usuariosData != null)
            {
                foreach (var usuarioData in usuariosData)
                {
                    if (usuarioData.ContainsKey("IdSubeArgentina"))
                    {
                        var usuarioArgentino = JsonConvert.DeserializeObject<UsuarioArgentino>(JsonConvert.SerializeObject(usuarioData));
                        usuarios.Add(usuarioArgentino);
                    }
                    else if (usuarioData.ContainsKey("IdSubeExtranjero"))
                    {
                        var usuarioExtranjero = JsonConvert.DeserializeObject<UsuarioExtranjero>(JsonConvert.SerializeObject(usuarioData));
                        usuarios.Add(usuarioExtranjero);
                    }
                    else if (usuarioData.ContainsKey("EsAdministrador"))
                    {
                        var usuarioAdmin = JsonConvert.DeserializeObject<UsuarioAdministrador>(JsonConvert.SerializeObject(usuarioData));
                        usuarios.Add(usuarioAdmin);
                    }
                    else
                    {
                        var usuarioSinTarjeta = JsonConvert.DeserializeObject<UsuarioSinTarjeta>(JsonConvert.SerializeObject(usuarioData));
                        usuarios.Add(usuarioSinTarjeta);
                    }
                }
            }

            return usuarios;
        }
    }

}
