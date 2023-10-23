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
        bool esNacional = false;    
       
        

        public IdManager(bool esNacionalEste)
        {
            // Intenta cargar el último ID desde el archivo al crear una instancia de la clase.

            if (esNacionalEste)
            {
                esNacional = true;
            }

            LoadLastId();
        }

        /// <summary>
        ///     Obtiene el id ya cargado en el load
        ///     y lo guarda en el archivo
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            lastId++;
            SaveLastId();
            return lastId;
        }

        /// <summary>
        /// Carga el ultimo id del archivo ingresado
        /// </summary>
        private void LoadLastId()
        {

            if(esNacional)
            {
                string nombreArchivo = "ultimoIdNacional.txt";
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
            else
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
                lastId = 5404;

            }
        }

        /// <summary>
        ///  Intenta sobreescribir el archivo con el ultimo id que se ingrese
        /// </summary>
        private void SaveLastId()
        {
            if (esNacional)
            {
                string nombreArchivo = "ultimoIdNacional.txt";
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
            else
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


}
