﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    class CreacionDataBase
    {

        /*
        CREATE TABLE `persona` (
  `id_persona` varchar(60) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `apellido` varchar(60) ,
  `telefono` varchar(20), 
  PRIMARY KEY(`id_persona`)
);
CREATE TABLE `proveedor` (
  `id_proveedor` varchar(60) NOT NULL,
  `numeroCuenta` varchar(60) NOT NULL,
  `banco` varchar(60) ,
  PRIMARY KEY(`id_proveedor`) ,
  FOREIGN KEY(`id_proveedor`) REFERENCES `persona`(`id_persona`)
);
CREATE TABLE `clientes` (
  `id_cliente` varchar(60) NOT NULL,
  `numeroCuenta` varchar(60) NOT NULL,
  `banco` varchar(60) ,
  PRIMARY KEY(`id_cliente`) ,
  FOREIGN KEY(`id_cliente`) REFERENCES `persona`(`id_persona`)
);
CREATE TABLE `usuarios` (
  `id_usuario` varchar(60) NOT NULL,
  `cargo` varchar(60) NOT NULL,
  `perfil` varchar(60) ,
  `usuario` varchar(60) ,
  `pasword` varchar(255) ,
  PRIMARY KEY(`id_usuario`),
  FOREIGN KEY(`id_usuario`) REFERENCES `persona`(`id_persona`)
)
CREATE TABLE `categoria` (
`id_categoria`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
`nombre`	varchar(60) NOT NULL
);
        CREATE TABLE `producto` (
`id_producto`	int (11) NOT NULL,
 `categoria`	int (11) NOT NULL,
  `nombre`	varchar(60) NOT NULL,
  `unidad`	varchar(60) NOT NULL,
  `vlr_unitario`	float NOT NULL,
PRIMARY KEY(id_producto),
FOREIGN KEY(`categoria`) REFERENCES `categoria`(`id_categoria`)
);
CREATE TABLE `media` (
  `producto` int (11) NOT NULL,
   `url` varchar(60) ,
  FOREIGN KEY(`producto`) REFERENCES `producto`(`id_producto`)
);
CREATE TABLE `stock` (
  `producto` int (11) NOT NULL,
   `cantidad` int (11) NOT NULL,
    FOREIGN KEY(producto) REFERENCES producto(id_producto)
  --KEY `cod_producto` (`cod_producto`) 
);
CREATE TABLE `movimientos` (
`id_movimiento`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
`producto`	INTEGER NOT NULL,
`usuario`	TEXT NOT NULL,
`cantidad`	REAL NOT NULL,
`fecha`	TEXT NOT NULL,
FOREIGN KEY(`producto`) REFERENCES `producto`(`id_producto`),
FOREIGN KEY(`usuario`) REFERENCES `usuarios`(`id_usuario`)
);
CREATE TABLE `salidas` (
  `id_salida` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `movimiento` int (11) NOT NULL,
   `cliente` varchar(60) NOT NULL,
   FOREIGN KEY(cliente) REFERENCES persona(id_persona)
  FOREIGN KEY(movimiento) REFERENCES movimientos(id_movimiento)
);
CREATE TABLE `ingresos` (
  `id_ingreso` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `movimiento` int (11) NOT NULL,
   `proveedor` varchar(60) NOT NULL,
   FOREIGN KEY(movimiento) REFERENCES movimientos(id_movimiento)
  FOREIGN KEY(proveedor) REFERENCES persona(id_persona)
)

    */
    }
}
