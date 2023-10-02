using Newtonsoft.Json;

namespace Entidades
{
    public class UsuarioArgentino : Usuario
    {
        private string _idSubeArgentina;

        public string IdSubeArgentina { get => _idSubeArgentina; set => _idSubeArgentina = value; }

        public UsuarioArgentino(string nombre, string apellido, string dni, string email, string clave, string idSubeArgentina) : base(nombre, apellido, dni, email, clave)
        {
            IdSubeArgentina = idSubeArgentina;
        }

        
    }
}