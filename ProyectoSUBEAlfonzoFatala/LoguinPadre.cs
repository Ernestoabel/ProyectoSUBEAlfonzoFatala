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
    //Formulario padre para que herede su diseño
    //Aca tuve un problema, trate de que los hijos hereden botones y su comportamiento para luego con poliformismo
    //sobrescriban un accionar, el problema es que si bien podia sobrescribir, el comportamiento heredado no podia anularlo
    //por lo tanto tenia dos comportamientos
    //por ahora no heredan botones devido a este problema
    public partial class LoguinPadre : Form
    {
        public LoguinPadre()
        {
            InitializeComponent();
        }

    
    }
}
