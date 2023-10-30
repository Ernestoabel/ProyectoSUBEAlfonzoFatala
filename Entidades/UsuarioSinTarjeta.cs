using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class UsuarioSinTarjeta : Usuario, IConexionesSQL<UsuarioSinTarjeta>
    {
        public UsuarioSinTarjeta(string nombre, string apellido, string dni, string clave) : base(nombre, apellido, dni, clave)
        {
            
        }
        public UsuarioSinTarjeta()
        {
        
        }

        public UsuarioSinTarjeta(UsuarioArgentino usuarioArgentino) : base(usuarioArgentino.Nombre, usuarioArgentino.Apellido, usuarioArgentino.Dni, usuarioArgentino.Clave)
        {
            
        }
        public UsuarioSinTarjeta(UsuarioExtranjero usuarioExtranjero) : base(usuarioExtranjero.Nombre, usuarioExtranjero.Apellido, usuarioExtranjero.Dni, usuarioExtranjero.Clave)
        {

        }

        public static void InsertarElementosSQL(List<Usuario> usuariosSinTarjeta)
        {
            ConexionSQL.Conectar(); // Abre la conexión

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = ConexionSQL.mysqlConexion;
                cmd.CommandText = "INSERT INTO tarjetanacional (Nombre, Apellido, Clave, DNI) VALUES (@Nombre, @Apellido, @Clave, @DNI)";

                foreach (Usuario usuario in usuariosSinTarjeta)
                {
                    if (usuario is UsuarioSinTarjeta)
                    {
                        UsuarioSinTarjeta usuarioSQL = (UsuarioSinTarjeta)usuario;
                        cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                        cmd.Parameters.AddWithValue("@Nombre", usuarioSQL.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", usuarioSQL.Apellido);
                        cmd.Parameters.AddWithValue("@Clave", usuarioSQL.Clave);
                        cmd.Parameters.AddWithValue("@DNI", usuarioSQL.Dni);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            ConexionSQL.mysqlConexion.Close(); // Cierra la conexión
        }

    }
}
