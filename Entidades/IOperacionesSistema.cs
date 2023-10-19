using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IOperacionesSistema<T>
    {
        void GuardarEnArchivo(List<T> lista, string nombreArchivo);
        List<T> CargarDesdeArchivo(string nombreArchivo);
    }
}
