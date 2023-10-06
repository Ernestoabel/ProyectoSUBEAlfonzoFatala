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
    }
}
