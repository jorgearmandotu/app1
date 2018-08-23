using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace app1.objetos
{
    public class ManejoExcel
    {
        private String criterioReporte;

        public ManejoExcel(string criterioReporte)
        {
            this.criterioReporte = criterioReporte;
        }

        public void GenerarReporte()
        {
            
            Thread.Sleep(10000);
            MessageBox.Show("El hilo se esta ejecutando " + criterioReporte);
        }
    }
}
