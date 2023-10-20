using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Viajes
    {
        private List<Viajes> listaDeViajes = new List<Viajes>();

        private DateTime fechaHora;
        private decimal valorBoleto;
        private EMedioTransporte medioTransporte;

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


        /// <summary>
        ///     Método para obtener la lista de viajes
        /// </summary>
        /// <returns>lista de viajes</returns>
        public List<Viajes> ObtenerListaDeViajes()
        {
            return listaDeViajes;
        }

      

    }
}
