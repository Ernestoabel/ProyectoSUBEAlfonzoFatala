using Newtonsoft.Json;

namespace Entidades
{
    public class UsuarioArgentino : Usuario
    {
        //private static int _ultimoID = 1002;

        private string _idSubeArgentina;
        private TarjetaNacional _tarjetaNacional;

        public string IdSubeArgentina { get => _idSubeArgentina; set => _idSubeArgentina = value; }
        public TarjetaNacional TarjetaNacional { get => _tarjetaNacional; set => _tarjetaNacional = value; }

        public UsuarioArgentino(string nombre, string apellido, string dni, string clave, string idSubeArgentina, TarjetaNacional tarjetaNacional) : base(nombre, apellido, dni, clave)
        {
            IdSubeArgentina = idSubeArgentina;
            TarjetaNacional = tarjetaNacional;
            TieneTarjeta = true;
        }
        public UsuarioArgentino()
        {
            
        }

        /// <summary>
        /// Metodo heredado para el DNI sea argentino
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public override bool ValidarDni(string dni)
        {
            return base.ValidarDni(dni) && int.Parse(dni[0].ToString()) < 9;
        }

        public override string ToString()
        {
            return IdSubeArgentina;
        }
    }
}