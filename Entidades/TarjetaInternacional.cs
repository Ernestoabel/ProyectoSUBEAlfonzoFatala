using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase de Tarjeta Internacional
    /// </summary>
    public class TarjetaInternacional : Tarjeta, IOperacionesSistema<TarjetaInternacional>
    {
        
        IdManager idManager = new IdManager(false);
        public static List<TarjetaInternacional> listaTarjetasIntenacionales = new List<TarjetaInternacional>();

        public TarjetaInternacional(int id, decimal saldo, List<Viajes> viajes) : base(id, saldo, viajes)
        {
           
        }
        public TarjetaInternacional()
        {
            
        }


        public override List<Viajes> Viajes { get; set; }

        public override void DesignarId(int UltimoNumeroEnLista)
        {
            this.Id = UltimoNumeroEnLista;
        }

        protected override int GenerarNuevoId()
        {
            return idManager.GetNextId();
        }
        
        /// <summary>
        /// Metodo interface para serializar la tarjeta
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        public void GuardarEnArchivo(List<TarjetaInternacional> lista, string nombreArchivo)
        {
            JsonSerializer serializer = new JsonSerializer();
            string rutaCarpetaArchivos = @"..\..\..\Archivos";

            if (!Directory.Exists(rutaCarpetaArchivos))
            {
                Directory.CreateDirectory(rutaCarpetaArchivos);
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(rutaCarpetaArchivos, nombreArchivo)))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, lista);
            }
        }

        /// <summary>
        /// Sobrecarga de la serialiacion para indicarle no solo el archivo sino tambien la carpeta a guardar
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        /// <param name="rutaCarpetaArchivos"></param>
        public void GuardarEnArchivo(List<TarjetaInternacional> lista, string nombreArchivo, string rutaCarpetaArchivos)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                if (!Directory.Exists(rutaCarpetaArchivos))
                {
                    Directory.CreateDirectory(rutaCarpetaArchivos);
                }

                string rutaCompleta = Path.Combine(rutaCarpetaArchivos, nombreArchivo);

                using (StreamWriter sw = new StreamWriter(rutaCompleta))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, lista);
                }
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(GuardarEnArchivo), "Error al serealizar tarjeta internacional", ex);
            }
        }

        /// <summary>
        /// Deserealizacion de la lista de tarjetasInternacional
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public List<TarjetaInternacional> CargarDesdeArchivo(string nombreArchivo)
        {
            
            List<TarjetaInternacional> usuarios = new List<TarjetaInternacional>();
            string rutaArchivo = Path.Combine(@"..\..\..\Archivos", nombreArchivo);

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    usuarios = JsonConvert.DeserializeObject<List<TarjetaInternacional>>(jsonData);
                }
                catch (Exception ex)
                {
                    CatchError.LogError(nameof(TarjetaInternacional), nameof(CargarDesdeArchivo), "Error al deserealizar tarjeta internacional", ex);
                }
            }

            return usuarios;
        }

        /// <summary>
        /// Metodo para insertar datos en mySql
        /// </summary>
        /// <param name="tarjetasInternacionales"></param>
        public static void InsertarEnBaseDeDatos(List<TarjetaInternacional> tarjetasInternacionales)
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                accesoBD.InsertarElementosSQL(tarjetasInternacionales, "tarjetainternacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(InsertarEnBaseDeDatos), "Error al insertar mySQL tarjeta internacional", ex);
            }
        }
        /// <summary>
        /// Metodo para obtener la tabla mySQL
        /// </summary>
        /// <returns></returns>
        public static List<TarjetaInternacional> ObtenerDeBaseDeDatos()
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                return accesoBD.ObtenerElementosSQL("tarjetainternacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(ObtenerDeBaseDeDatos), "Error al obtener mySQL tarjeta internacional", ex);
                return null;
            }
        }
        /// <summary>
        /// Metodo para modificar la tabla mySQL
        /// </summary>
        /// <param name="condicion"></param>
        public void ActualizarEnBaseDeDatos(string condicion)
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                accesoBD.ActualizarElementoSQL(this, "tarjetainternacional", condicion);
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(ActualizarEnBaseDeDatos), "Error al actualizar mySQL tarjeta internacional", ex);
            }
        }
        /// <summary>
        /// Metodo para agregar una fila a la tabla mySql
        /// </summary>
        public void AgregarElementoSQL()
        {
            try
            {
                AccesoMySql<TarjetaInternacional> accesoBD = new AccesoMySql<TarjetaInternacional>();
                accesoBD.AgregarElementoSQL(this, "tarjetainternacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaInternacional), nameof(AgregarElementoSQL), "Error al agregar fila mySQL tarjeta internacional", ex);
            }
        }

    }
}
