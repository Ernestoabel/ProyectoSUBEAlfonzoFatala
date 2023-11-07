using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta de tarjeta
    /// </summary>
    public abstract class Tarjeta
    {

        private int _id;
        private decimal _saldo;

        /// <summary>
        /// Constructor del objeto tarjeta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saldo"></param>
        /// <param name="viajes"></param>
        public Tarjeta( int id, decimal saldo, List<Viajes> viajes)
        {
            Id = GenerarNuevoId();
            Saldo = saldo;
            Viajes = new List<Viajes>();
        }
        public Tarjeta()
        {
            
        }

        public abstract List<Viajes> Viajes { get; set; }

        public int Id { get => _id; set => _id = value; }
        public decimal Saldo { get => _saldo; set => _saldo = value; }

        public abstract void DesignarId(int UltimoNumeroEnLista);

        protected abstract int GenerarNuevoId();

        public void CargarSaldo(decimal monto)
        {
            Saldo += monto;
        }

        public bool RestarSaldo(decimal valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                return true; // La operación fue exitosa
            }
            else
            {
                return false; // No hay suficiente saldo
            }
            
        }

    }
}
