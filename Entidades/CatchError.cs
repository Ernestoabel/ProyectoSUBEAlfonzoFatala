using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase para el log de errores
    /// </summary>
    public class CatchError
    {
        private static string logFilePath = @"..\..\..\Archivos\error_log.txt"; // Ruta del archivo de registro

        public static void LogError(string className, string methodName, string description, Exception exception)
        {
            string logMessage = $"{DateTime.Now} - Error en {className}.{methodName}: {description}\n{exception}\n\n";

            if (!File.Exists(logFilePath))
            {
                using (File.Create(logFilePath)) { }
            }

            File.AppendAllText(logFilePath, logMessage);
        }
    }
}
