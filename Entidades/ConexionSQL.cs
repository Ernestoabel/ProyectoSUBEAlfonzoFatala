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
        private static MySqlCommand query;
        static ConexionSQL()
        {
            mysqlConexion = new MySqlConnection("Server=localhost;Port=3306;Database=proyectosube;Uid=root;Pwd='';");
        }
        public static void Conectar()
        {
            try
            {
                mysqlConexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }

    }
}
