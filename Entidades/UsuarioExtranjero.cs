using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase que hereda de Usuario para crear el usuario extranjero
    /// Con una interfaz para aplicar en la base de datos
    /// </summary>
    public class UsuarioExtranjero : Usuario, IConexcionesSQLUsuarios<UsuarioExtranjero>
    {
        private string _idSubeExtranjero;

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
        /// Sobrescritura del metodo heredado
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public override bool ValidarDni(string dni)
        {
            return base.ValidarDni(dni) && int.Parse(dni[0].ToString()) > 9;
        }

        /// <summary>
        /// Sobrescritura del metodo heredado
        /// </summary>
        public static void ObtenerElementosSQL()
        {
            try
            {
                ConexionSQL.Conectar();

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

        /// <summary>
        /// Metodo pare insertar una fila en la base de datos
        /// </summary>
        /// <param name="usuariosExtranjero"></param>
        public static void InsertarElementoSQL(UsuarioExtranjero usuariosExtranjero)
        {
            try
            {
                ConexionSQL.Conectar();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "INSERT INTO usuarioextranjero (nombre, apellido, clave, dni, idSube, tienetarjeta) VALUES (@nombre, @apellido, @clave, @dni, @idSube, @tienetarjeta)";

                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@nombre", usuariosExtranjero.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuariosExtranjero.Apellido);
                    cmd.Parameters.AddWithValue("@clave", usuariosExtranjero.Clave);
                    cmd.Parameters.AddWithValue("@dni", usuariosExtranjero.Dni);
                    cmd.Parameters.AddWithValue("@idSube", usuariosExtranjero.IdSubeExtranjero);
                    cmd.Parameters.AddWithValue("@tienetarjeta", usuariosExtranjero.TieneTarjeta);
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioExtranjero), nameof(InsertarElementoSQL), "Error al insertar elemento a la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();

            }
        }

        /// <summary>
        /// Metodo para eliminar una fila en la base de datos
        /// </summary>
        /// <param name="dni"></param>
        public static void EliminarUnElemento(string dni)
        {
            try
            {
                ConexionSQL.Conectar();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = $"DELETE FROM usuarioextranjero WHERE dni = {dni} ";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioExtranjero), nameof(EliminarUnElemento), "Error al eliminar elemento a la base de datos", ex);
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
                    cmd.CommandText = $"UPDATE usuarioextranjero SET clave = @nuevaClave WHERE dni = {dni}";

                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@nuevaClave", nuevaClave);
                    cmd.Parameters.AddWithValue("@idUsuario", dni);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioExtranjero), nameof(ModificarClaveSQL), "Error al modificar la clave en la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();
            }
        }

    }
}
