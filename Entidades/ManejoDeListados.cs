using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class ManejoDeListados
    {
        public static Usuario ObtenerUsuarioPorDNI(string dni)
        {
            
            Usuario usuarioEncontrado = Listados.listaUsuarios.FirstOrDefault(u => u.Dni == dni);

            return usuarioEncontrado;
        }
        public static UsuarioArgentino ObtenerUsuarioArgentinoPorDNI(string dni)
        {

            UsuarioArgentino usuarioEncontrado = (UsuarioArgentino)Listados.listaUsuarios.FirstOrDefault(u => u.Dni == dni);

            return usuarioEncontrado;
        }
        public static UsuarioExtranjero ObtenerUsuarioExtranjeroPorDNI(string dni)
        {

            UsuarioExtranjero usuarioEncontrado = (UsuarioExtranjero)Listados.listaUsuarios.FirstOrDefault(u => u.Dni == dni);

            return usuarioEncontrado;
        }
    }
}
