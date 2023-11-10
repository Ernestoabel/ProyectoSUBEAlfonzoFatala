using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    /// <summary>
    /// Esta interfas fue suplantada por una clase Padre para las tarjetas
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IConexionesSQL<T>
    {
        static void InsertarElementosSQL(List<T> elementos)
        {

        }

        List<T> ObtenerElementosSQL();

    }
}
