using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Nuget para utilizar test unitario

namespace Entidades
{
    /// <summary>
    /// Clase test unitario para la clase tarteja internacional
    /// </summary>
    public class TarjetaInternacionalTestsUnitario : ITarjetasTestUnitarios
    {
        /// <summary>
        /// Test unitario para probar el metodo guardar en archivo
        /// </summary>
        public void GuardarEnArchivo_SerializaListaCorrectamente()
        {
            // Arrange
            var tarjeta = new TarjetaInternacional();
            var lista = new List<TarjetaInternacional>(); // Crea una lista de tarjetas para probar
            var nombreArchivo = @"testTarjetaInternacional.json";

            // Act
            tarjeta.GuardarEnArchivo(lista, nombreArchivo);

            // Assert
            // Aquí puedes verificar si el archivo se creó y si los datos se serializaron correctamente
            Assert.IsTrue(File.Exists(@"..\\..\\..\\Archivos\testTarjetaInternacional.json"));
        }

        /// <summary>
        /// Test unitario para probar el metodo cargar desde archivo
        /// </summary>
        public void CargarDesdeArchivo_DeserializaListaCorrectamente()
        {
            // Arrange
            var tarjeta = new TarjetaInternacional();
            var nombreArchivo = @"testTarjetaInternacional.json";

            // Act
            var lista = tarjeta.CargarDesdeArchivo(nombreArchivo);

            // Assert
            // Verifica que la lista se haya deserializado correctamente
            Assert.IsNotNull(lista);
        }
    }
}
