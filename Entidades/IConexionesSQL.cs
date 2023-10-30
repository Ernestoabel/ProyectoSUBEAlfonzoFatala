using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public interface IConexionesSQL<T>
    {
        static void InsertarElementosSQL(List<T> elementos)
        {

        }

        List<T> ObtenerElementosSQL();
    }
}
