using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz generica para la serealizacion y deserealizacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOperacionesSistema<T>
    {
        void GuardarEnArchivo(List<T> lista, string nombreArchivo);
        
        List<T> CargarDesdeArchivo(string nombreArchivo);
        

    }
}
