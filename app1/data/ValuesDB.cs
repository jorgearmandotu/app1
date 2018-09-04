using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1.data
{
    public class ValuesDB
    {

        public  const String DBName = "data.db";
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
        public const String tablaPersona = "persona";
        public const String tablaMovimientos = "movimientos";

        public const String ProductoCodigoDB = "id_producto";
        //public static String ProductoProveedorDB = "id_proveedor";
        public const String productoCategoriaDB = "categoria";
        public const String productoNombreDB = "nombre";
        public const String productoUnidadDB = "unidad";
        public const String productoVrUnitarioDB = "vlr_unitario";

        public const String categoriaCodigoDB = "id_categoria";
        public const String categoriNombreDB = "nombre";

        public const String clientesIdDB = "id_cliente";
       // public const String clientesNombreDB = "nombre";

        public const String mediaCodigoDB = "producto";
        public const String mediavalorDB = "url";

        public const String proveedorIdDB = "id_proveedor";
        public const String proveedorCuentaDB = "numeroCuenta";
        public const String proveedorBancoDB = "banco";

        public const String salidasCodigoDB = "id_salida";
        public const String salidasClienteDB = "cliente";
        public const String salidasMovimientoDB = "movimiento";

        public const String stockProductoDB = "producto";
        public const String stockCantidadDB = "cantidad";

        public const String userIdDB = "id_usuario";
        public const String userCargoB = "cargo";
        public const String userPerfilDB = "perfil";
        public const String userUsuarioDB = "usuario";
        public const String userPasswordDB = "pasword";

        public const String ingresosId = "id_ingreso";
        public const String ingresoProveedor = "proveedor";
        public const String ingresoMovimientoDB = "movimiento";
        
        public const String personaIdDB = "id_persona";
        public const String personaNombreDB = "nombre";
        public const String personaApellidoDB = "apellido";
        public const String personaTelefonoDB = "telefono";
        
        public const String movimientoIdDB = "id_movimiento";
        public const String movimientoProductoDB = "producto";
        public const String movimientoUsuarioDB = "usuario";
        public const String movimientoCantidad = "cantidad";
        public const String movimientoFecha = "fecha";
    }
}
