using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase con dos configuraciones para el menu inicio
    /// </summary>
    public class Configuraciones
    {
        public string ImagenFondo { get; set; }
        public string ColorFondo { get; set; }
        public string FuenteTexto { get; set; }

        public Configuraciones()
        {
            ImagenFondo = "default.png";
            ColorFondo = "White";
            FuenteTexto = "Arial";
        }
        public void ConfiguracionNacional()
        {
            ImagenFondo = @"..\..\..\Assets\login.jpeg";
            ColorFondo = "White";
            FuenteTexto = "Microsoft YaHei";
        }
        public void ConfiguracionSovietical()
        {
            ImagenFondo = @"..\..\..\Assets\tarjetaRoja.jpg";
            ColorFondo = "Red";
            FuenteTexto = "Engravers MT";
        }
    }
    /// <summary>
    /// Clase con metodos para serializar y deserealizar las configuraciones
    /// </summary>
    public static class ConfiguracionManager
    {
        /// <summary>
        /// Deserealizacion
        /// </summary>
        /// <param name="archivoPath"></param>
        /// <returns></returns>
        public static Configuraciones CargarConfiguraciones(string archivoPath)
        {
            try
            {
                if (File.Exists(archivoPath))
                {
                    string json = File.ReadAllText(archivoPath);
                    return JsonConvert.DeserializeObject<Configuraciones>(json);
                }
                return new Configuraciones();
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(Configuraciones), nameof(CargarConfiguraciones), "Error en el metodo", ex);
                return new Configuraciones(); // Configuraciones predeterminadas si el archivo no existe
            }
            
        }

        /// <summary>
        /// Seriealizacion
        /// </summary>
        /// <param name="archivoPath"></param>
        /// <param name="configuraciones"></param>
        public static void GuardarConfiguraciones(string archivoPath, Configuraciones configuraciones)
        {
            try
            {
                string json = JsonConvert.SerializeObject(configuraciones, Formatting.Indented);
                File.WriteAllText(archivoPath, json);
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(Configuraciones), nameof(GuardarConfiguraciones), "Error en el metodo", ex);
            }
        }
    }
}
