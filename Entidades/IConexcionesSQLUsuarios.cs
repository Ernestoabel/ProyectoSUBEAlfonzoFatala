using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz para la aplicacion de metodos en las clases de los usuarios
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IConexcionesSQLUsuarios<T>
    {
        static List<Usuario> ObtenerElementosSQL()
        {
            return new List<Usuario>();
        }
        static void InsertarElementoSQL(T usuarios)
        {

        }
        static void EliminarUnElemento(string dni)
        {

        }
    }
}
