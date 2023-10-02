using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entidades
{
    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _dni;
        private string _email;
        private string _clave;

        public Usuario(string nombre, string apellido, string dni, string email, string clave)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            Clave = clave;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Email { get => _email; set => _email = value; }
        public string Clave { get => _clave; set => _clave = value; }

        
    }
}
