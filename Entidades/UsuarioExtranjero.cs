using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class UsuarioExtranjero : Usuario
    {
        private string _idSubeExtranjero;
        private TarjetaInternacional _tarjetaInternacional;

        public string IdSubeExtranjero { get => _idSubeExtranjero; set => _idSubeExtranjero = value; }

        public UsuarioExtranjero(string nombre, string apellido, string dni, string clave, string idSubeExtranjero) : base(nombre, apellido, dni, clave)
        {
            IdSubeExtranjero = idSubeExtranjero;
            TieneTarjeta = true;
        }
        public UsuarioExtranjero()
        {
        }



        /// <summary>
        /// Metodo heredado para validadr que el DNI sea de personas con residencia
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public override bool ValidarDni(string dni)
        {
            return base.ValidarDni(dni) && int.Parse(dni[0].ToString()) > 9;
        }

        public static void ObtenerElementosSQL()
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "SELECT nombre, apellido, clave, dni, idSube FROM usuarioextranjero";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader.GetString("Nombre");
                            string apellido = reader.GetString("Apellido");
                            string clave = reader.GetString("Clave");
                            string dni = reader.GetString("DNI");
                            string idSube = reader.GetString("idSube");

                            UsuarioExtranjero usuario = new UsuarioExtranjero(nombre, apellido, dni, clave, idSube);
                            Listados.AgregarUsuario(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioExtranjero), nameof(ObtenerElementosSQL), "Error al obtener elementos de la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();

            }
        }

        public static void InsertarElementoSQL(UsuarioExtranjero usuariosExtrangero)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "INSERT INTO usuarioextrangero (nombre, apellido, clave, dni, idSube) VALUES (@nombre, @apellido, @clave, @dni, @idSube)";

                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@nombre", usuariosExtrangero.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuariosExtrangero.Apellido);
                    cmd.Parameters.AddWithValue("@clave", usuariosExtrangero.Clave);
                    cmd.Parameters.AddWithValue("@dni", usuariosExtrangero.Dni);
                    cmd.Parameters.AddWithValue("@idSube", usuariosExtrangero.IdSubeExtranjero);
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
