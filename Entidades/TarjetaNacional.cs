﻿using Newtonsoft.Json;
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
        public void GuardarEnArchivo(List<TarjetaNacional> lista, string nombreArchivo)
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
                    Console.WriteLine("Error al deserializar el archivo: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("El archivo de usuarios no existe.");
            }

            return usuarios;
        }

        public static void InsertarEnBaseDeDatos(List<TarjetaNacional> tarjetasNacionales)
        {
            AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
            accesoBD.InsertarElementosSQL(tarjetasNacionales, "tarjetanacional");
        }

        public static List<TarjetaNacional> ObtenerDeBaseDeDatos()
        {
            AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
            return accesoBD.ObtenerElementosSQL("tarjetanacional");
        }

        public void ActualizarEnBaseDeDatos(string condicion)
        {
            AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
            accesoBD.ActualizarElementoSQL(this, "tarjetanacional", condicion);
        }

        public void AgregarElementoSQL()
        {
            AccesoMySql<TarjetaNacional> accesoBD = new AccesoMySql<TarjetaNacional>();
            accesoBD.AgregarElementoSQL(this, "tarjetanacional");
        }

    }
}
