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
        private string _clave;

        public Usuario(string nombre, string apellido, string dni, string clave)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni; 
            Clave = clave; // 4 digitos
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Clave { get => _clave; set => _clave = value; }

        /// <summary>
        /// Metodo Virtual para validar que el dni sea real
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public virtual bool ValidarDni(string dni)
        {
            return dni.Length == 8 && dni[0] != '0';
        }

    }
}
