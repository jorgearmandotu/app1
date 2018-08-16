using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1.data
{
    class ValuesDB
    {

        public  const String DBName = "inventario.db";
        public  const int DataVersion = 3;
        public  const String tablaProducto = "producto";
        public  const String tablaCategoria = "categoria";
        public  const String tablaClientes = "clientes";
        public  const String tablaMedia = "media";
        public  const String tablaProveedor = "proveedor";
        public  const String tablaSalidas = "salidas";
        public  const String tablaStock = "stock";
        public  const String tablaUsuarios = "usuarios";
        public  const String tablaingresos = "ingresos";

        public const String ProductoCodigoDB = "cod_pro";
        //public static String ProductoProveedorDB = "id_proveedor";
        public const String productoCategoriaDB = "cod_categoria";
        public const String productoNombreDB = "nombre";
        public const String productoUnidadDB = "unidad";
        public const String productoVrUnitarioDB = "vlr_unitario";

        public const String categoriaCodigoDB = "cod_cat";
        public const String categoriNombreDB = "nombre";

        public const String clientesIdDB = "id_cli";
        public const String clientesNombreDB = "nombre";

        public const String mediaCodigoDB = "cod_producto";
        public const String mediavalorDB = "valor";

        public const String proveedorIdDB = "id_provee";
        public const String proveedorNombreDB = "nombre";

        public const String salidasCodigoDB = "cod_sale";
        public const String salidasClienteDB = "id_cliente";
        public const String salidasProductoDB = "cod_producto";
        public const String salidasUsuarioDB = "id_user";
        public const String salidasCantidadDB = "cantidad";
        public const String salidasFechaDB = "fecha";

        public const String stockProductoDB = "cod_producto";
        public const String stockCantidadDB = "cantidad";

        public const String userIdDB = "id_user";
        public const String userNombreDB = "nombre";
        public const String userCargoB = "cargo";
        public const String userPerfilDB = "perfil";
        public const String userUsuarioDB = "usuario";
        public const String userPasswordDB = "pwd";

        public const String ingresosId = "id_ingreso";
        public const String ingresosProducto = "cod_producto";
        public const String ingresosUser = "id_user";
        public const String ingresosCantidad = "cantidad";
        public const String ingresosFecha = "fecha";
        public const String ingresoProveedor = "id_proveedor";
    }
}
