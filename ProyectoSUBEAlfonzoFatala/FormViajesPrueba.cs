using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSUBEAlfonzoFatala
{
    public partial class FormViajesPrueba : Form
    {
        List<Viajes> listaViajes;

        public FormViajesPrueba()
        {
            InitializeComponent();
            this.listaViajes = new List<Viajes>();
        }

        private void FormViajesPrueba_Load(object sender, EventArgs e)
        {
            
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-09-30 10:30:12"), "Autobus", 36));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-07-30 10:40:31"), "Subte", 56));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-05-30 09:47:00"), "Tren", 23));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-05-22 12:00:00"), "Autobus", 12));
            this.listaViajes.Add(new Viajes(DateTime.Parse("2023-05-18 13:00:00"), "Autobus", 31));

            this.dtgViajes.DataSource = this.listaViajes;
  
        }
    }
}
