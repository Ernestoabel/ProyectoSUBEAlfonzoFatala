using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TarjetaNacional : Tarjeta
    {
        public TarjetaNacional(int id, decimal saldo, List<Viajes> viajes) : base(id, saldo, viajes)
        {

        }

        public override List<Viajes> Viajes { get; set; }

        public override void DesignarId(int UltimoNumeroEnLista)
        {
            this.Id = UltimoNumeroEnLista;
        }
    }
}
