using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{
    public class TarjetaNacional : Tarjeta, IOperacionesSistema<TarjetaNacional>
    {
        
        IdManager idManagerNacional = new IdManager(true);
        public static List<TarjetaNacional> listaTarjetasNacionales = new List<TarjetaNacional>();

        public TarjetaNacional(int id, decimal saldo, List<Viajes> viajes) : base(id, saldo, viajes)
        {
            
        }
        public TarjetaNacional()
        {

        }

        public override List<Viajes> Viajes { get; set; }

        public override void DesignarId(int UltimoNumeroEnLista)
        {
            this.Id = UltimoNumeroEnLista;
        }

        protected override int GenerarNuevoId()
        {
            return idManagerNacional.GetNextId();
        }

        /// <summary>
        /// Metodo para serealizar la lista
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreArchivo"></param>
        public void GuardarEnArchivo(List<TarjetaNacional> lista, string nombreArchivo)
        {
            try
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
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(GuardarEnArchivo), "Error al serializar la lista de tarjeta nacional", ex);
            }
        }

        /// <summary>
        /// Metodo para deserealizar la lista
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public List<TarjetaNacional> CargarDesdeArchivo(string nombreArchivo)
        {
            List<TarjetaNacional> usuarios = new List<TarjetaNacional>();
            string rutaArchivo = Path.Combine(@"..\..\..\Archivos", nombreArchivo);

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    usuarios = JsonConvert.DeserializeObject<List<TarjetaNacional>>(jsonData);
                }
                catch (Exception ex)
                {
                    CatchError.LogError(nameof(TarjetaNacional), nameof(CargarDesdeArchivo), "Error al deserializar la lista de tarjeta nacional", ex);
                }
            }

            return usuarios;
        }

        /// <summary>
        /// Metodo para insertar datos en mySql
        /// </summary>
        /// <param name="tarjetasNacionales"></param>
        public static void InsertarEnBaseDeDatos(List<TarjetaNacional> tarjetasNacionales)
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                accesoBD.InsertarElementosSQL(tarjetasNacionales, "tarjetanacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(InsertarEnBaseDeDatos), "Error al insertar tabla mySQL de tarjeta nacional", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener datos de la tabla mySql
        /// </summary>
        /// <returns></returns>
        public static List<TarjetaNacional> ObtenerDeBaseDeDatos()
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                return accesoBD.ObtenerElementosSQL("tarjetanacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(ObtenerDeBaseDeDatos), "Error al obtener tabla mySQL de tarjeta nacional", ex);
                return null;
            }
        }
        /// <summary>
        /// Metodo para actualizar la tabla en mySql
        /// </summary>
        /// <param name="condicion"></param>
        public void ActualizarEnBaseDeDatos(string condicion)
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                accesoBD.ActualizarElementoSQL(this, "tarjetanacional", condicion);
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(ActualizarEnBaseDeDatos), "Error al actualizar tabla mySQL de tarjeta nacional", ex);
            }
        }
        /// <summary>
        /// Metodo para agregar una fila a la tabla mySql
        /// </summary>
        public void AgregarElementoSQL()
        {
            try
            {
                AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
                accesoBD.AgregarElementoSQL(this, "tarjetanacional");
            }
            catch (Exception ex)
            {
                CatchError.LogError(nameof(TarjetaNacional), nameof(AgregarElementoSQL), "Error al insertar fila a la tabla mySQL de tarjeta nacional", ex);
            }
        }

    }
}
