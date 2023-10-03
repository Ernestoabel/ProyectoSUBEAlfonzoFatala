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

        public string IdSubeExtranjero { get => _idSubeExtranjero; set => _idSubeExtranjero = value; }

        public UsuarioExtranjero(string nombre, string apellido, string dni, string clave, string idSubeExtranjero) : base(nombre, apellido, dni, clave)
        {
            IdSubeExtranjero = idSubeExtranjero;
        }

        
    }
}
