using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz para la generacion de la factura cuando se carga la tarjeta
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenerarFacturaPDF<T>
    {
        public static int ultimoNumeroFactura = ObtenerUltimoNumeroFactura();
        static void GenerarFacturaPDF(T tarjeta, string acreditacion)
        {

        }
        static int ObtenerUltimoNumeroFactura()
        {
            return ultimoNumeroFactura;
        }
        static void ActualizarUltimoNumeroFactura()
        {

        }
    }
}
