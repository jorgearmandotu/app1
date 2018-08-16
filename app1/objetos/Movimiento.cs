using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1.objetos
{
    public class Movimiento
    {
        private String id;
        private String producto;
        private int cantidad;
        private String usuario;
        private String fecha;
        private String tipo;
        private String userFinal;

        /*public Movimiento(String id, String idProduc, int cantidad, String idUser, String fecha)
        {
            this.id = id;
            this.producto = idProduc;
            this.cantidad = cantidad;
            this.usuario = idUser;
            this.fecha = fecha;
        }*/

        public string Id
        {
            get => id;
            set => id = value;
        }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string UserFinal { get => userFinal; set => userFinal = value; }

        public Movimiento(string id, int cantidad, string fecha, string producto, string usuario, String tipo, String userFinal)
        {
            Id = id;
            Cantidad = cantidad;
            Fecha = fecha;
            Producto = producto;
            Usuario = usuario;
            Tipo = tipo;
            UserFinal = userFinal;
        }
        public Movimiento(int cantidad, string fecha, string producto, string usuario, String tipo, String userFinal)
        {
            Id = id;
            Cantidad = cantidad;
            Fecha = fecha;
            Producto = producto;
            Usuario = usuario;
            Tipo = tipo;
            UserFinal = userFinal;
        }
    }

    public class Salidas : Movimiento
    {
        private readonly String cliente;
        public Salidas(String cliente, String id, int cantidad, String fecha, String producto, String usuario, String tipo, String userFinal)
            :base(id, cantidad, fecha, producto, usuario, tipo, userFinal)
        {
            this.cliente = cliente;
        }
        public Salidas(String cliente, int cantidad, String fecha, String producto, String usuario, String tipo, String userFinal)
           : base( cantidad, fecha, producto, usuario, tipo, userFinal)
        {
            this.cliente = cliente;
        }
    }

    public class Ingresos : Movimiento
    {
        String proveedor;

        public Ingresos(string proveedor, String id, int cantidad, String fecha, String producto, String usuario, String tipo, String userFinal)
            : base(id, cantidad, fecha, producto, usuario, tipo, userFinal)
        {
            this.proveedor = proveedor;

        }
    }
}
