using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion personalisada
    /// </summary>
    public class UsuarioSinTarjetaException : Exception
    {
        public UsuarioSinTarjetaException() : base("El usuario no tiene tarjeta") { }
    }
}
