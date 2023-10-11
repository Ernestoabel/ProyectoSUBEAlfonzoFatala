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
        private bool _tieneTarjeta;

        public Usuario(string nombre, string apellido, string dni, string clave)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni; 
            Clave = clave; // 4 digitos
            TieneTarjeta = false;
        }
        public Usuario()
        {

        
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public bool TieneTarjeta { get => _tieneTarjeta; set => _tieneTarjeta = value; }

        /// <summary>
        /// Metodo Virtual para validar que el dni sea real
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public virtual bool ValidarDni(string dni)
        {
            if (dni.Length != 8 || !dni.All(char.IsDigit))
            {
                return false;
            }
            char primerCaracter = dni[0];
            return primerCaracter >= '1' && primerCaracter <= '9';
        }

        public bool ValidarClave(string clave)
        {
            return Clave == clave;
        }


        public string ObtenerInformacionUsuario(Usuario nuevoUsuario)
        {

            string informacion = $"Nombre: {nuevoUsuario.Nombre}, Apellido: {nuevoUsuario.Apellido}, DNI: {nuevoUsuario.Dni}, Clave: {nuevoUsuario.Clave}, TieneTarjeta: {(nuevoUsuario.TieneTarjeta ? "Sí" : "No")}";
            return informacion;
        }

        /// <summary>
        /// Muestra los datos del usurio actual
        /// </summary>
        /// <returns>string personalizado</returns>
        public override string ToString()
        {
            return $"Usuario: {this.Nombre} {this.Apellido}, Dni: {this.Dni}, Clave{this.Clave}";
        }

    }
}
