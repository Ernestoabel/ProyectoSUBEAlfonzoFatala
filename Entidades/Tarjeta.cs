using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Tarjeta
    {

        private int _id;
        private decimal _saldo;

        public Tarjeta( int id, decimal saldo, List<Viajes> viajes)
        {
            Id = id;
            Saldo = saldo;
            Viajes = viajes;
        }

        public abstract List<Viajes> Viajes { get; set; }

        public int Id { get => _id; set => _id = value; }
        public decimal Saldo { get => _saldo; set => _saldo = value; }

        public abstract void DesignarId(int UltimoNumeroEnLista);

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
