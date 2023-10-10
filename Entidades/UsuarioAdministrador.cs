using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioAdministrador : Usuario
    {
        private bool _esAdministrador;
        public UsuarioAdministrador(string nombre, string apellido, string dni, string clave) : base(nombre, apellido, dni, clave)
        {
            EsAdministrador = true;
        }

        public bool EsAdministrador { get => _esAdministrador; set => _esAdministrador = value; }
    }
}
