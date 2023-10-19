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

        public Viajes()
        {
            
        }
        public Viajes(DateTime fechaHora, string medioTransporte, decimal valorBoleto)
        {
            this.fechaHora = fechaHora;
            this.medioTransporte = medioTransporte;
            this.valorBoleto = valorBoleto;
        }
        

        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public string MedioTransporte { get => medioTransporte; set => medioTransporte = value; }
        public decimal ValorBoleto { get => valorBoleto; set => valorBoleto = value; }

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
        /*
        /// <summary>
        /// Sobrecarga del operador + para sumar dos listas
        /// </summary>
        /// <param name="lista1"></param>
        /// <param name="lista2"></param>
        /// <returns></returns>
        public static List<Viajes> operator +(List<Viajes> lista1, List<Viajes> lista2)
        {
            List<Viajes> result = new List<Viajes>(lista1);
            result.AddRange(lista2);
            return result;
        }*/

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
