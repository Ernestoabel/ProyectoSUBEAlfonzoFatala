using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Entidades
{
    public class ConexionSQL
    {
        
        public static MySqlConnection mysqlConexion;
        //private static MySqlCommand query;
        static ConexionSQL()
        {
            mysqlConexion = new MySqlConnection("Server=localhost;Port=3306;Database=proyectosube;Uid=root;Pwd='';");
        }
        /// <summary>
        /// Metodo para abrir la conexion mySQL
        /// </summary>
        public static void Conectar()
        {
            try
            {
                mysqlConexion.Open();
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(ConexionSQL), nameof(Conectar), "Error al conectar la base de datos", ex);
            }
        }

    }
}
