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
        private String fechaInicio;
        private String fechaFinal;
        private String ingresos;
        private String salidas;

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
