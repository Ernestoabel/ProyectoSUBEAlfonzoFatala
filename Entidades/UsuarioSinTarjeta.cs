using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioSinTarjeta : Usuario
    {
        public UsuarioSinTarjeta(string nombre, string apellido, string dni, string clave) : base(nombre, apellido, dni, clave)
        {
            
        }
        public UsuarioSinTarjeta()
        {
        
        }

        public UsuarioSinTarjeta(UsuarioArgentino usuarioArgentino) : base(usuarioArgentino.Nombre, usuarioArgentino.Apellido, usuarioArgentino.Dni, usuarioArgentino.Clave)
        {
            
        }
        public UsuarioSinTarjeta(UsuarioExtranjero usuarioExtranjero) : base(usuarioExtranjero.Nombre, usuarioExtranjero.Apellido, usuarioExtranjero.Dni, usuarioExtranjero.Clave)
        {

        }

    }
}
