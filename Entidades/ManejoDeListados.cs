using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ManejoDeListados
    {
        public static Usuario ObtenerUsuarioPorDniYTarjeta(string dni)
        {
            Usuario usuario = Listados.listaUsuarios.FirstOrDefault(u => u.Dni == dni);

            if (usuario != null)
            {
                if (!usuario.TieneTarjeta)
                {
                    return (UsuarioSinTarjeta)usuario;
                }
                else if (usuario.Dni[0] < '9')
                {
                    return (UsuarioArgentino)usuario;
                }
                else
                {
                    return (UsuarioExtranjero)usuario;
                }
                    
            }

            return null;
        }


    }
}
