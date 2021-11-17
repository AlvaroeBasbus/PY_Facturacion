create database db_facturacion
go	
use db_facturacion
go
CREATE TABLE condiciones_iva(
id_condiciones_iva int identity(1,1),
tipo_condicion varchar(100) not null
CONSTRAINT pk_condiciones_iva PRIMARY KEY(id_condiciones_iva)
);

CREATE TABLE provincias(
id_provincia int identity(1,1),
nombre varchar(100)not null
CONSTRAINT pk_provincias PRIMARY KEY(id_provincia)
);

CREATE TABLE localidades(
id_localidad int identity(1,1),
nombre varchar(100)not null,
id_provincia int
CONSTRAINT pk_localidades PRIMARY KEY(id_localidad)
CONSTRAINT fk_provincias_localidades FOREIGN KEY (id_provincia) references provincias(id_provincia)
);

CREATE TABLE clientes(
id_cliente int identity(1,1),
nombre varchar(100)not null,
apellido varchar(100)not null,
documento int,
telefono int,
correo nvarchar(100),
id_provincia int,
id_localidad int,
id_condiciones_iva int
CONSTRAINT pk_clientes PRIMARY KEY(id_cliente)
CONSTRAINT fk_provincias_clientes FOREIGN KEY (id_provincia) references provincias(id_provincia),
CONSTRAINT fk_localidades_clientes FOREIGN KEY (id_localidad) references localidades(id_localidad),
CONSTRAINT fk_condicion_clientes FOREIGN KEY (id_condiciones_iva) references condiciones_iva(id_condiciones_iva)
);
CREATE TABLE metodo_pagos(
id_metodo_pago int identity(1,1),
descripcion varchar(100)not null
CONSTRAINT pk_metodo_pagos PRIMARY KEY(id_metodo_pago),

);
CREATE TABLE facturas(
nro_factura int identity(1,1),
fecha datetime not null,
id_cliente int,
id_metodo_pago int
CONSTRAINT pk_facturas PRIMARY KEY(nro_factura),
CONSTRAINT fk_clientes_facturas FOREIGN KEY (id_cliente) references clientes(id_cliente),
CONSTRAINT fk_metodo_facturas FOREIGN KEY (id_metodo_pago) references metodo_pagos(id_metodo_pago)
);

CREATE TABLE productos(
id_producto int identity(1,1),
descripcion varchar(200)not null,
precio decimal(8,2)not null ,
stock int not null,
CONSTRAINT pk_productos PRIMARY KEY(id_producto)
);
CREATE TABLE detalle_facturas(
id_detalle_factura int identity(1,1),
precio decimal(8,2),
cantidad int not null,
id_producto int,
nro_factura int
CONSTRAINT pk_detalle_facturas PRIMARY KEY(id_detalle_factura),
CONSTRAINT fk_facturas_detalle FOREIGN KEY (nro_factura) references facturas(nro_factura),
CONSTRAINT fk_productos_detalle FOREIGN KEY (id_producto) references productos(id_producto)
);

-----------------
CREATE TABLE [dbo].[detalle_facturas](
	[id_detalle_factura] [int] NOT NULL,
	[detalle_nro] [int] NOT NULL,
	[nro_factura] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](10,2) NOT NULL
	CONSTRAINT fk_productos_detalle FOREIGN KEY (id_producto) references productos(id_producto)
PRIMARY KEY CLUSTERED 
(
	[id_detalle_factura] ASC,
	[detalle_nro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-----------------------

CREATE TABLE users(
id_usuario int identity(1,1),
loginname nvarchar(100)not null , 
password nvarchar(100) not null,
nombre varchar(100),
apellido varchar(100),
correo nvarchar(100),
privilegio varchar(100),
CONSTRAINT pk_users PRIMARY KEY(id_usuario),
);