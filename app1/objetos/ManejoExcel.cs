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
        private Boolean ingresos;
        private Boolean salidas;
        private String sql;

        public ManejoExcel()
        {
            this.criterioReporte = "";
            this.fechaInicio = "";
            this.fechaFinal = "";
            this.ingresos = true;
            this.salidas = true;
            this.sql = "select * from producto left join categoria on producto.cod_categoria = " +
                "categoria.cod_cat left join ingresos on producto.cod_pro = ingresos.cod_producto";
        }

        public ManejoExcel(string criterioReporte)
        {
            this.criterioReporte = criterioReporte;
        }

        public void GenerarReporte()
        {
            
            
        }
    }
}
