using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class IdManager
    {
        private int lastId;
        

        public IdManager()
        {
            // Intenta cargar el último ID desde el archivo al crear una instancia de la clase.
            LoadLastId();
        }

        public int GetNextId()
        {
            lastId++;
            SaveLastId();
            return lastId;
        }

        private void LoadLastId()
        {
            string nombreArchivo = "ultimoId.txt";
            string rutaArchivo = Path.Combine(@"..\..\..\Archivos", nombreArchivo);

            if (File.Exists(rutaArchivo))
            {
                string lastIdText = File.ReadAllText(rutaArchivo);
                if (int.TryParse(lastIdText, out lastId))
                {
                    return;
                }
            }

            // Si no se pudo cargar el último ID, inicia desde un valor predeterminado.
            lastId = 1404;
        }

        private void SaveLastId()
        {
            string nombreArchivo = "ultimoId.txt";
            string rutaArchivo = Path.Combine(@"..\..\..\Archivos", nombreArchivo);

            try
            {
                File.WriteAllText(rutaArchivo, lastId.ToString());
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre algún problema al guardar el último ID en el archivo.
                Console.WriteLine("Error al guardar el último ID de SUBE: " + ex.Message);
            }
        }
        
    }


}
