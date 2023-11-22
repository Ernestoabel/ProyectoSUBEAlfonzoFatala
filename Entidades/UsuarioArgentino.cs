using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase que hereda de Usuario para generar el usuario Argentino
    /// Utiliza una interfaz para la utilizacion de metodos para manejo de mySQL
    /// </summary>
    public class UsuarioArgentino : Usuario, IConexcionesSQLUsuarios<UsuarioArgentino>
    {
        private string _idSubeArgentina;

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
        /// Sobreescritura del metodo heredado
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public override bool ValidarDni(string dni)
        {
            return base.ValidarDni(dni) && int.Parse(dni[0].ToString()) < 9;
        }

        /// <summary>
        /// Sobreescritura del metodo heredado
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IdSubeArgentina;
        }

        /// <summary>
        /// Metodo para insertar una fila en la base de datos
        /// </summary>
        /// <param name="usuariosArgentino"></param>
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

        /// <summary>
        /// Metodo para obtener los datos de la base de datos
        /// </summary>
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

        /// <summary>
        /// Metodo para eliminar una fila de la base de datos
        /// </summary>
        /// <param name="dni"></param>
        public static void EliminarUnElemento(string dni)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = $"DELETE FROM usuarioargentino WHERE dni = {dni} ";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioArgentino), nameof(EliminarUnElemento), "Error al eliminar elemento a la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();

            }
        }

        public static void ModificarClaveSQL(string dni, string nuevaClave)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = $"UPDATE usuarioargentino SET clave = @nuevaClave WHERE dni = {dni}";

                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@nuevaClave", nuevaClave);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioArgentino), nameof(ModificarClaveSQL), "Error al modificar la clave en la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();
            }
        }

    }
}