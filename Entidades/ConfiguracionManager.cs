using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
    public static class ConfiguracionManager
    {
        public static Configuraciones CargarConfiguraciones(string archivoPath)
        {
            if (File.Exists(archivoPath))
            {
                string json = File.ReadAllText(archivoPath);
                return JsonConvert.DeserializeObject<Configuraciones>(json);
            }
            return new Configuraciones(); // Configuraciones predeterminadas si el archivo no existe
        }

        public static void GuardarConfiguraciones(string archivoPath, Configuraciones configuraciones)
        {
            string json = JsonConvert.SerializeObject(configuraciones, Formatting.Indented);
            File.WriteAllText(archivoPath, json);
        }
    }
}
