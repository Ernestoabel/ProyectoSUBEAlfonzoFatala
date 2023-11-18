using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase de Viajes para que se incorpore la clase de Tarjeta en forma de lista
    /// </summary>
    public class Viajes
    {
        private List<Viajes> listaDeViajes = new List<Viajes>();

        private DateTime fechaHora;
        private decimal valorBoleto;
        private EMedioTransporte medioTransporte;
        private int tarjetaNacionalId;
        private int tarjetaInternacionalId;

        public Viajes()
        {
            
        }
        public Viajes(DateTime fechaHora, EMedioTransporte medioTransporte, decimal valorBoleto)
        {
            this.fechaHora = fechaHora;
            this.medioTransporte = medioTransporte;
            this.valorBoleto = valorBoleto;
        }

        public EMedioTransporte MedioTransporte 
        {
            get => medioTransporte;
            set => medioTransporte = value;
        }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public decimal ValorBoleto { get => valorBoleto; set => valorBoleto = value; }

        public int TarjetaNacionalId
        {
            get => tarjetaNacionalId;
            set => tarjetaNacionalId = value;
        }

        public int TarjetaInternacionalId
        {
            get => tarjetaInternacionalId;
            set => tarjetaInternacionalId = value;
        }

        /// <summary>
        /// Metodo para generar viajes aleatorios
        /// </summary>
        /// <returns>El objeto viajes</returns>
        public static Viajes GenerarViajeAleatorio()
        {
            Random random = new Random();

            // Generar valores aleatorios
            DateTime fechaHora = DateTime.Now.AddDays(random.Next(-30, 31));
            EMedioTransporte[] mediosTransporte = (EMedioTransporte[])Enum.GetValues(typeof(EMedioTransporte));
            EMedioTransporte medioTransporte = mediosTransporte[random.Next(mediosTransporte.Length)];
            decimal valorBoleto;
            switch (medioTransporte)
            {
                case EMedioTransporte.Autobus:
                    valorBoleto = 50;
                    break;
                case EMedioTransporte.Tren:
                    valorBoleto = 35;
                    break;
                case EMedioTransporte.Subte:
                    valorBoleto = 80;
                    break;
                case EMedioTransporte.Bicicleta:
                    valorBoleto = 120;
                    break;
                default:
                    valorBoleto = 0;
                    break;
            }
            //decimal valorBoleto = (decimal)(random.NextDouble() * 100);

            return new Viajes(fechaHora, medioTransporte, valorBoleto);
        }

        /// <summary>
        /// Sobrecarga del metodo aleatorio que indica otros precios de viaje
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>El objeto viajes</returns>
        public static Viajes GenerarViajeAleatorio(UsuarioExtranjero usuario)
        {
            Random random = new Random();

            // Generar valores aleatorios
            DateTime fechaHora = DateTime.Now.AddDays(random.Next(-30, 31));
            EMedioTransporte[] mediosTransporte = (EMedioTransporte[])Enum.GetValues(typeof(EMedioTransporte));
            EMedioTransporte medioTransporte = mediosTransporte[random.Next(mediosTransporte.Length)];
            decimal valorBoleto;
            switch (medioTransporte)
            {
                case EMedioTransporte.Autobus:
                    valorBoleto = 700;
                    break;
                case EMedioTransporte.Tren:
                    valorBoleto = 1100;
                    break;
                case EMedioTransporte.Subte:
                    valorBoleto = 1500;
                    break;
                case EMedioTransporte.Bicicleta:
                    valorBoleto = 2000;
                    break;
                default:
                    valorBoleto = 0;
                    break;
            }
            return new Viajes(fechaHora, medioTransporte, valorBoleto);
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un objeto viaje a la lista viajes
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nuevoViaje"></param>
        /// <returns></returns>
        public static List<Viajes> operator +(List<Viajes> lista, Viajes nuevoViaje)
        {
            lista.Add(nuevoViaje);
            return lista;
        }

        public static void InsertarViajeSQL(Viajes viaje, int idTarjeta)
        {
            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "INSERT INTO viajes (fechahora, medio, valorboleto, tarjetaNacionalId, tarjetaInternacionalId) VALUES (@fechahora, @medio, @valorboleto, @tarjetaNacionalId, @tarjetaInternacionalId)";

                    cmd.Parameters.Clear(); // Limpia los parámetros antes de usarlos nuevamente.
                    cmd.Parameters.AddWithValue("@fechahora", viaje.FechaHora);
                    cmd.Parameters.AddWithValue("@medio", viaje.MedioTransporte.ToString());
                    cmd.Parameters.AddWithValue("@valorboleto", viaje.ValorBoleto);
                    if(idTarjeta > 5000)
                    {
                        cmd.Parameters.AddWithValue("@tarjetaInternacionalId", idTarjeta);
                        cmd.Parameters.AddWithValue("@tarjetaNacionalId", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tarjetaNacionalId", idTarjeta);
                        cmd.Parameters.AddWithValue("@tarjetaInternacionalId", null);
                    }
                    
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(Viajes), nameof(InsertarViajeSQL), "Error al insertar viaje a la base de datos", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();
            }
        }

        public static List<Viajes> ObtenerViajesPorTarjetaSQL(int numeroTarjeta)
        {
            List<Viajes> viajesEncontrados = new List<Viajes>();

            try
            {
                ConexionSQL.Conectar(); // Abre la conexión

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = ConexionSQL.mysqlConexion;
                    cmd.CommandText = "SELECT fechahora, medio, valorboleto, tarjetaNacionalId, tarjetaInternacionalId FROM viajes WHERE tarjetaNacionalId = @numeroTarjeta OR tarjetaInternacionalId = @numeroTarjeta";

                    cmd.Parameters.AddWithValue("@numeroTarjeta", numeroTarjeta);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime fechaHora = reader.GetDateTime("fechahora");
                            EMedioTransporte medioTransporte = (EMedioTransporte)Enum.Parse(typeof(EMedioTransporte), reader.GetString("medio"));
                            decimal valorBoleto = reader.GetDecimal("valorboleto");
                            int tarjetaNacionalId = reader.IsDBNull("tarjetaNacionalId") ? 0 : reader.GetInt32("tarjetaNacionalId");
                            int tarjetaInternacionalId = reader.IsDBNull("tarjetaInternacionalId") ? 0 : reader.GetInt32("tarjetaInternacionalId");

                            if (tarjetaNacionalId == numeroTarjeta || tarjetaInternacionalId == numeroTarjeta)
                            {
                                Viajes viaje = new Viajes(fechaHora, medioTransporte, valorBoleto);
                                viaje.TarjetaNacionalId = tarjetaNacionalId;
                                viaje.TarjetaInternacionalId = tarjetaInternacionalId;

                                viajesEncontrados.Add(viaje);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(Viajes), nameof(ObtenerViajesPorTarjetaSQL), "Error al obtener viajes de la base de datos por tarjeta", ex);
            }
            finally
            {
                ConexionSQL.mysqlConexion.Close();
            }

            return viajesEncontrados;
        }


    }
}
