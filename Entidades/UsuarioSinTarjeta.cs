using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class UsuarioSinTarjeta : Usuario
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

        public static List<Usuario> ObtenerElementosSQL()
        {
            List<Usuario> elementos = new List<Usuario>();
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "SELECT nombre, apellido, clave, dni FROM usuariosintarjeta";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader.GetString("nombre");
                            string apellido = reader.GetString("apellido");
                            string clave = reader.GetString("clave");
                            string dni = reader.GetString("dni");

                            UsuarioSinTarjeta usuario = new UsuarioSinTarjeta(nombre, apellido, dni, clave);
                            elementos.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioSinTarjeta), nameof(ObtenerElementosSQL), "Error al obtener elementos de la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();

            }
            return elementos;
        }

        public static void InsertarElementoSQL(UsuarioSinTarjeta usuariosSinTarjeta)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "INSERT INTO usuariosintarjeta (nombre, apellido, clave, dni) VALUES (@nombre, @apellido, @clave, @dni)";

                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@nombre", usuariosSinTarjeta.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuariosSinTarjeta.Apellido);
                    cmd.Parameters.AddWithValue("@clave", usuariosSinTarjeta.Clave);
                    cmd.Parameters.AddWithValue("@dni", usuariosSinTarjeta.Dni);
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioArgentino), nameof(InsertarElementoSQL), "Error al insertar elemento a la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();

            }
        }

    }
}
