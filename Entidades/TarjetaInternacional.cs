﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class TarjetaInternacional : Tarjeta, IOperacionesSistema<TarjetaInternacional>, IConexionesSQL<TarjetaInternacional>
    {
        
        IdManager idManager = new IdManager(false);
        public static List<TarjetaInternacional> listaTarjetasIntenacionales = new List<TarjetaInternacional>();

        public TarjetaInternacional(int id, decimal saldo, List<Viajes> viajes) : base(id, saldo, viajes)
        {
            
        }
        public TarjetaInternacional()
        {
            
        }


        public override List<Viajes> Viajes { get; set; }

        public override void DesignarId(int UltimoNumeroEnLista)
        {
            this.Id = UltimoNumeroEnLista;
        }

        protected override int GenerarNuevoId()
        {
            return idManager.GetNextId();
        }
        
        /// <summary>
        /// Metodo interface para serializar la tarjeta
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        public void GuardarEnArchivo(List<TarjetaInternacional> lista, string nombreArchivo)
        {
            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = @"..\..\..\Archivos";

            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(rutaCarpetaArchivos, nombreArchivo)))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }
        }

        /// <summary>
        /// Sobrecarga de la serialiacion para indicarle no solo el archivo sino tambien la carpeta a guardar
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        /// <param name="rutaCarpetaArchivos"></param>
        public void GuardarEnArchivo(List<TarjetaInternacional> lista, string nombreArchivo, string rutaCarpetaArchivos)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            string rutaCompleta = Path.Combine(rutaCarpetaArchivos, nombreArchivo);

            using (StreamWriter sw = new StreamWriter(rutaCompleta))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }
        }

        /// <summary>
        /// Deserealizacion de la lista de tarjetasInternacional
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public List<TarjetaInternacional> CargarDesdeArchivo(string nombreArchivo)
        {
            
            List<TarjetaInternacional> usuarios = new List<TarjetaInternacional>();
            string rutaArchivo = Path.Combine(@"..\..\..\Archivos", nombreArchivo);

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    usuarios = JsonConvert.DeserializeObject<List<TarjetaInternacional>>(jsonData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al deserializar el archivo: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("El archivo de usuarios no existe.");
            }

            return usuarios;
        }

        public static void InsertarElementosSQL(List<TarjetaInternacional> tarjetasInterrnacionales)
        {
            ConexionSQL.Conectar(); // Abre la conexión

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = ConexionSQL.mysqlConexion;
                cmd.CommandText = "INSERT INTO tarjetanacional (Id, Saldo, Viajes) VALUES (@Id, @Saldo, @Viajes)";

                foreach (TarjetaInternacional tarjeta in tarjetasInterrnacionales)
                {
                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@Id", tarjeta.Id);
                    cmd.Parameters.AddWithValue("@Saldo", tarjeta.Saldo);
                    string viajesJson = JsonConvert.SerializeObject(tarjeta.Viajes);
                    cmd.Parameters.AddWithValue("@Viajes", viajesJson);

                    cmd.ExecuteNonQuery();
                }
            }

            ConexionSQL.mysqlConexion.Close(); // Cierra la conexión
        }

        public List<TarjetaInternacional> ObtenerElementosSQL()
        {
            List<TarjetaInternacional> tarjetasInternacional = new List<TarjetaInternacional>();
            ConexionSQL.Conectar(); // Abre la conexión

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = ConexionSQL.mysqlConexion;
                cmd.CommandText = "SELECT * FROM tarjetanacional";

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        decimal saldo = reader.GetDecimal("Saldo");
                        string viajesJson = reader.GetString("Viajes");
                        List<Viajes> viajes = JsonConvert.DeserializeObject<List<Viajes>>(viajesJson);

                        TarjetaInternacional tarjeta = new TarjetaInternacional(id, saldo, viajes);
                        tarjetasInternacional.Add(tarjeta);
                    }
                }
            }

            ConexionSQL.mysqlConexion.Close(); // Cierra la conexión
            return tarjetasInternacional;
        }
    }
}
