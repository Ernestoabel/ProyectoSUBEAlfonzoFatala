using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Entidades
{
    public class AccesoMySql<T>
    {
        /// <summary>
        /// Metodo generico para subir datos de una lista a mySQL
        /// </summary>
        /// <param name="elementos"></param>
        /// <param name="nombreTabla"></param>
        public void InsertarElementosSQL(List<T> elementos, string nombreTabla)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = $"INSERT INTO {nombreTabla} (Id, Saldo, Viajes) VALUES (@Id, @Saldo, @Viajes)";

                    foreach (T elemento in elementos)
                    {
                        cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente

                        PropertyInfo[] propiedades = typeof(T).GetProperties();

                        Descomponer(cmd, elemento, propiedades);
                    }
                }
            }catch (Exception ex)
            {
                CatchError.LogError(nameof(AccesoMySql<T>), nameof(InsertarElementosSQL), "Error al insertar elementos en la base de datos", ex);
                
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close(); 
            }

            
        }

        private static void Descomponer(MySqlCommand cmd, T elemento, PropertyInfo[] propiedades)
        {
            foreach (var propiedad in propiedades)
            {
                object valor = propiedad.GetValue(elemento);

                // Si la propiedad es 'Viajes', convierte a JSON antes de insertar en la base de datos
                if (propiedad.Name == "Viajes" && valor != null)
                {
                    valor = JsonConvert.SerializeObject(valor);
                }

                cmd.Parameters.AddWithValue($"@{propiedad.Name}", valor);
            }

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Metodo generico para traer datos de una tabla mySQL y volcarlos a una lista
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <returns></returns>
        public List<T> ObtenerElementosSQL(string nombreTabla)
        {
            List<T> elementos = new List<T>();
            try
            {
                
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = $"SELECT * FROM {nombreTabla}";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Lógica para obtener y deserializar elementos
                            int id = reader.GetInt32("Id");
                            decimal saldo = reader.GetDecimal("Saldo");
                            string viajesJson = reader.GetString("Viajes");
                            List<Viajes> viajes = JsonConvert.DeserializeObject<List<Viajes>>(viajesJson);

                            // Crear una instancia del tipo genérico
                            T elemento = Activator.CreateInstance<T>();
                            PropertyInfo[] propiedades = typeof(T).GetProperties();

                            foreach (var propiedad in propiedades)
                            {
                                if (propiedad.Name == "Id")
                                {
                                    propiedad.SetValue(elemento, id);
                                }
                                else if (propiedad.Name == "Saldo")
                                {
                                    propiedad.SetValue(elemento, saldo);
                                }
                                else if (propiedad.Name == "Viajes")
                                {
                                    propiedad.SetValue(elemento, viajes);
                                }
                            }

                            elementos.Add(elemento);
                        }
                    }

                }
            }catch (Exception ex)
            {
                CatchError.LogError(nameof(AccesoMySql<T>), nameof(ObtenerElementosSQL), "Error al obtener elementos de la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();
                
            }

            return elementos; 
            
        }

        /// <summary>
        /// Metodo generico para actualizar una fila en una tabla de mySQL
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="nombreTabla"></param>
        /// <param name="condicion"></param>
        public void ActualizarElementoSQL(T elemento, string nombreTabla, string condicion)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = $"UPDATE {nombreTabla} SET ";

                    PropertyInfo[] propiedades = typeof(T).GetProperties();

                    // Lista para almacenar los parámetros
                    List<MySqlParameter> parametros = new List<MySqlParameter>();

                    // Construye la parte SET de la consulta SQL
                    foreach (var propiedad in propiedades)
                    {
                        // Evita actualizar la propiedad 'Id'
                        if (propiedad.Name != "Id")
                        {
                            if (propiedad.Name == "Viajes")
                            {
                                // Para la columna JSON 'Viajes', serializa el objeto como JSON
                                cmd.CommandText += $"{propiedad.Name} = @json, ";
                                string jsonValue = JsonConvert.SerializeObject(propiedad.GetValue(elemento));
                                parametros.Add(new MySqlParameter("@json", jsonValue));
                            }
                            else
                            {
                                cmd.CommandText += $"{propiedad.Name} = @{propiedad.Name}, ";
                                parametros.Add(new MySqlParameter($"@{propiedad.Name}", propiedad.GetValue(elemento)));
                            }
                        }
                    }

                    cmd.CommandText = cmd.CommandText.TrimEnd(',', ' '); // Elimina la última coma y espacio
                    cmd.CommandText += $" WHERE {condicion}";

                    // Agrega los parámetros al comando
                    cmd.Parameters.AddRange(parametros.ToArray());

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción, por ejemplo, registrándola en el log
                CatchError.LogError(nameof(AccesoMySql<T>), nameof(ActualizarElementoSQL), "Error al actualizar elemento en la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();
            }
        }

        /// <summary>
        /// Metodo generico para agregar una fila a una tabla en mySQL
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="nombreTabla"></param>
        public void AgregarElementoSQL(T elemento, string nombreTabla)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = $"INSERT INTO {nombreTabla} (";

                    PropertyInfo[] propiedades = typeof(T).GetProperties();

                    // Construye la parte de nombres de columna de la consulta SQL
                    string columnNames = string.Join(", ", propiedades.Select(propiedad => propiedad.Name));
                    cmd.CommandText += columnNames;

                    cmd.CommandText += ") VALUES (";

                    // Construye la parte de valores de la consulta SQL
                    string valuePlaceholders = string.Join(", ", propiedades.Select(propiedad => $"@{propiedad.Name}"));
                    cmd.CommandText += valuePlaceholders;

                    cmd.CommandText += ")";

                    foreach (var propiedad in propiedades)
                    {
                        if (propiedad.Name == "Viajes")
                        {
                            // Para la columna JSON 'Viajes', serializa el objeto como JSON
                            string jsonValue = JsonConvert.SerializeObject(propiedad.GetValue(elemento));
                            cmd.Parameters.AddWithValue($"@{propiedad.Name}", jsonValue);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue($"@{propiedad.Name}", propiedad.GetValue(elemento));
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción, por ejemplo, registrándola en el log
                CatchError.LogError(nameof(AccesoMySql<T>), nameof(AgregarElementoSQL), "Error al agregar elemento en la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();
            }
        }
    }
}
