using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class UsuarioAdministrador : Usuario
    {
        private bool _esAdministrador;
        public UsuarioAdministrador(string nombre, string apellido, string dni, string clave) : base(nombre, apellido, dni, clave)
        {
            EsAdministrador = true;
        }

        public bool EsAdministrador { get => _esAdministrador; set => _esAdministrador = value; }

        public static List<Usuario> ObtenerElementosSQL()
        {
            List<Usuario> elementos = new List<Usuario>();
            //libreria que no permite datos duplicados
            HashSet<string> dniDuplicado = new HashSet<string>();
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "SELECT nombre, apellido, clave, dni FROM usuarioadministrador";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader.GetString("nombre");
                            string apellido = reader.GetString("apellido");
                            string clave = reader.GetString("clave");
                            string dni = reader.GetString("dni");

                            //UsuarioAdministrador usuario = new UsuarioAdministrador(nombre, apellido, dni, clave);
                            //elementos.Add(usuario);
                            if (!dniDuplicado.Contains(dni))
                            {
                                UsuarioAdministrador usuario = new UsuarioAdministrador(nombre, apellido, dni, clave);
                                elementos.Add(usuario);
                                dniDuplicado.Add(dni); // Add the DNI to the HashSet
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(UsuarioAdministrador), nameof(ObtenerElementosSQL), "Error al obtener elementos de la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();

            }
            return elementos;
        }
    }
}
