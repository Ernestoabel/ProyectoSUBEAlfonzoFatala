using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class UsuarioArgentino : Usuario
    {
        //private static int _ultimoID = 1002;

        private string _idSubeArgentina;
        private TarjetaNacional _tarjetaNacional;

        public string IdSubeArgentina { get => _idSubeArgentina; set => _idSubeArgentina = value; }

        public UsuarioArgentino(string nombre, string apellido, string dni, string clave, string idSubeArgentina) : base(nombre, apellido, dni, clave)
        {
            IdSubeArgentina = idSubeArgentina;
            TieneTarjeta = true;
        }
        public UsuarioArgentino()
        {

        }

        /// <summary>
        /// Metodo heredado para el DNI sea argentino
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public override bool ValidarDni(string dni)
        {
            return base.ValidarDni(dni) && int.Parse(dni[0].ToString()) < 9;
        }

        public override string ToString()
        {
            return IdSubeArgentina;
        }

        public static void InsertarElementoSQL(UsuarioArgentino usuariosArgentino)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "INSERT INTO usuarioargentino (nombre, apellido, clave, dni, idSube, tienetarjeta) VALUES (@nombre, @apellido, @clave, @dni, @idSube, @tienetarjeta)";

                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@nombre", usuariosArgentino.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuariosArgentino.Apellido);
                    cmd.Parameters.AddWithValue("@clave", usuariosArgentino.Clave);
                    cmd.Parameters.AddWithValue("@dni", usuariosArgentino.Dni);
                    cmd.Parameters.AddWithValue("@idSube", usuariosArgentino.IdSubeArgentina);
                    cmd.Parameters.AddWithValue("@tienetarjeta", usuariosArgentino.IdSubeArgentina);
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

        public static void ObtenerElementosSQL()
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "SELECT nombre, apellido, clave, dni, idSube FROM usuarioargentino";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader.GetString("Nombre");
                            string apellido = reader.GetString("Apellido");
                            string clave = reader.GetString("Clave");
                            string dni = reader.GetString("DNI");
                            string idSube = reader.GetString("idSube");
  

                            UsuarioArgentino usuario = new UsuarioArgentino(nombre, apellido, dni, clave, idSube);
                            Listados.AgregarUsuario(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioArgentino), nameof(ObtenerElementosSQL), "Error al obtener elementos de la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();

            }
        }

    }
}