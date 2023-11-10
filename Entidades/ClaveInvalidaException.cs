using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase para personalizar la excepcion de una clave invalidad
    /// </summary>
    public class ClaveInvalidaException : Exception
    {
        public ClaveInvalidaException() : base("La clave proporcionada es inválida.")
        {
        }

        public ClaveInvalidaException(string message) : base(message)
        {
        }

        public ClaveInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
