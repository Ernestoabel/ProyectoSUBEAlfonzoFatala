﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Viajes
    {
        private DateTime fechaHora;
        private string medioTransporte;
        private decimal valorBoleto;

        public Viajes(DateTime fechaHora, string medioTransporte, decimal valorBoleto)
        {
            FechaHora = fechaHora;
            MedioTransporte = medioTransporte;
            ValorBoleto = valorBoleto;
        }

        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public string MedioTransporte { get => medioTransporte; set => medioTransporte = value; }
        public decimal ValorBoleto { get => valorBoleto; set => valorBoleto = value; }
    }
}
