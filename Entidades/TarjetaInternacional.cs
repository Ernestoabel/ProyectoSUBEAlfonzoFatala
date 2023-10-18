using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TarjetaInternacional : Tarjeta
    {
        private static int proximoId = 5003;
        public TarjetaInternacional(int id, decimal saldo, List<Viajes> viajes) : base(id, saldo, viajes)
        {
            id = GenerarNuevoId();
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
            return proximoId++;
        }
    }
}
