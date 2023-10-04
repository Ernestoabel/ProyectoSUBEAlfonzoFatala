using Newtonsoft.Json;

namespace Entidades
{
    public class UsuarioArgentino : Usuario
    {
        private string _idSubeArgentina;
        private TarjetaNacional _tarjetaNacional;

        public string IdSubeArgentina { get => _idSubeArgentina; set => _idSubeArgentina = value; }
        public TarjetaNacional TarjetaNacional { get => _tarjetaNacional; set => _tarjetaNacional = value; }

        public UsuarioArgentino(string nombre, string apellido, string dni, string clave, string idSubeArgentina, TarjetaNacional tarjetaNacional) : base(nombre, apellido, dni, clave)
        {
            IdSubeArgentina = idSubeArgentina;
            TarjetaNacional = tarjetaNacional;
        }

    }
}