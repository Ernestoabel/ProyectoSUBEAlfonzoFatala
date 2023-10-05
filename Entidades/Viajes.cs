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
        private string medioTransporte;
        private decimal valorBoleto;
        private Tarjeta tarjetaAsociada;

        public Viajes()
        {
            
        }
        public Viajes(DateTime fechaHora, string medioTransporte, decimal valorBoleto)
        {
            this.fechaHora = fechaHora;
            this.medioTransporte = medioTransporte;
            this.valorBoleto = valorBoleto;
        }
        public Viajes(DateTime fechaHora, string medioTransporte, decimal valorBoleto, Tarjeta tarjeta)
        {
            this.fechaHora = fechaHora;
            this.medioTransporte = medioTransporte;
            this.valorBoleto = valorBoleto;
            this.tarjetaAsociada = tarjeta;
        }

        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public string MedioTransporte { get => medioTransporte; set => medioTransporte = value; }
        public decimal ValorBoleto { get => valorBoleto; set => valorBoleto = value; }



        /// <summary>
        ///     Método para crear y agregar un viaje
        /// </summary>
        /// <param name="fechaHora"></param>
        /// <param name="medioTransporte"></param>
        /// <param name="valorBoleto"></param>
        public void AgregarViaje(DateTime fechaHora, string medioTransporte, decimal valorBoleto)
        {
            Viajes viaje  = new Viajes(fechaHora, medioTransporte, valorBoleto);
            listaDeViajes.Add(viaje);
        }

        /// <summary>
        ///     Método para obtener la lista de viajes
        /// </summary>
        /// <returns>lista de viajes</returns>
        public List<Viajes> ObtenerListaDeViajes()
        {
            return listaDeViajes;
        }

        public decimal CalcularTotalBoletos(List<Viajes> listaDeViajes)
        {
            decimal total = 0;

            foreach (Viajes viaje in listaDeViajes)
            {
                total += viaje.ValorBoleto;
            }

            return total;
        }

        public bool RealizarViaje(Tarjeta tarjeta)
        {
            if (tarjeta.RestarSaldo(ValorBoleto))
            {
                // El viaje se realizó con éxito (suficiente saldo)
                return true;
            }
            else
            {
                // No hay suficiente saldo en la tarjeta
                return false;
            }
        }

    }
}
