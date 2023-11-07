using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz para los metodos a utilizar en un test unitario 
    /// </summary>
    internal interface ITarjetasTestUnitarios
    {
        public void GuardarEnArchivo_SerializaListaCorrectamente();

        public void CargarDesdeArchivo_DeserializaListaCorrectamente();
    }
}
