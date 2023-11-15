using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Nuget para utilizar test unitario

namespace Entidades
{
    /// <summary>
    /// Clase de test unitario para la clase tarjeta internacional
    /// </summary>
    public class TarjetaNacionalTestsUnitario : ITarjetasTestUnitarios
    {
        /// <summary>
        /// Test unitario para probar el metodo guardar en archivo
        /// </summary>
        public void GuardarEnArchivo_SerializaListaCorrectamente()
        {
            // Arrange
            var viaje = Viajes.GenerarViajeAleatorio();
            var viajes = new List<Viajes>();
            viajes.Add(viaje);
            var tarjeta = new TarjetaNacional(10, 500, viajes);
            var lista = new List<TarjetaNacional>(); // Crea una lista de tarjetas para probar
            lista.Add(tarjeta); // Crea una lista de tarjetas para probar
            var nombreArchivo = @"testTarjetaNacional.json";

            // Act
            tarjeta.GuardarEnArchivo(lista, nombreArchivo);

            // Assert
            // Aquí puedes verificar si el archivo se creó y si los datos se serializaron correctamente
            Assert.IsTrue(File.Exists(@"..\\..\\..\\Archivos\testTarjetaNacional.json"));
        }

        /// <summary>
        /// Test unitario para probar el metodo cargar desde archivo
        /// </summary>
        public void CargarDesdeArchivo_DeserializaListaCorrectamente()
        {
            // Arrange
            var tarjeta = new TarjetaInternacional();
            var nombreArchivo = @"testTarjetaNacional.json";

            // Act
            var lista = tarjeta.CargarDesdeArchivo(nombreArchivo);

            // Assert
            // Verifica que la lista se haya deserializado correctamente
            Assert.IsNotNull(lista);
        }
    }
}
