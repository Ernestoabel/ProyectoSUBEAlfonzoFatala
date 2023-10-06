using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioExtranjero : Usuario
    {
        private string _idSubeExtranjero;
        private TarjetaInternacional _tarjetaInternacional;

        public string IdSubeExtranjero { get => _idSubeExtranjero; set => _idSubeExtranjero = value; }
        public TarjetaInternacional TarjetaInternacional { get => _tarjetaInternacional; set => _tarjetaInternacional = value; }

        public UsuarioExtranjero(string nombre, string apellido, string dni, string clave, string idSubeExtranjero, TarjetaInternacional tarjetaInternacional) : base(nombre, apellido, dni, clave)
        {
            IdSubeExtranjero = idSubeExtranjero;
            TarjetaInternacional = tarjetaInternacional;
        }

        /// <summary>
        /// Metodo heredado para validadr que el DNI sea de personas con residencia
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public override bool ValidarDni(string dni)
        {
            return base.ValidarDni(dni) && int.Parse(dni[0].ToString()) > 9;
        }
    }
}
