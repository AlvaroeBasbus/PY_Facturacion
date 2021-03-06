USE [db_facturacion]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 17/11/2021 18:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[documento] [int] NULL,
	[telefono] [int] NULL,
	[correo] [nvarchar](100) NULL,
	[id_provincia] [int] NULL,
	[id_localidad] [int] NULL,
	[id_condiciones_iva] [int] NULL,
	[Domicilio] [nvarchar](200) NULL,
 CONSTRAINT [pk_clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[condiciones_iva]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[condiciones_iva](
	[id_condiciones_iva] [int] IDENTITY(1,1) NOT NULL,
	[tipo_condicion] [varchar](100) NOT NULL,
 CONSTRAINT [pk_condiciones_iva] PRIMARY KEY CLUSTERED 
(
	[id_condiciones_iva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_facturas]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_facturas](
	[id_detalle_factura] [int] IDENTITY(1,1) NOT NULL,
	[precio] [decimal](8, 2) NULL,
	[cantidad] [int] NOT NULL,
	[id_producto] [int] NULL,
	[nro_factura] [int] NULL,
 CONSTRAINT [pk_detalle_facturas] PRIMARY KEY CLUSTERED 
(
	[id_detalle_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[nro_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_metodo_pago] [int] NULL,
	[total] [decimal](10, 2) NULL,
	[fecha] [date] NULL,
	[fecha_baja] [date] NULL,
 CONSTRAINT [pk_facturas] PRIMARY KEY CLUSTERED 
(
	[nro_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localidades]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localidades](
	[id_localidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[id_provincia] [int] NULL,
 CONSTRAINT [pk_localidades] PRIMARY KEY CLUSTERED 
(
	[id_localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[metodo_pagos]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[metodo_pagos](
	[id_metodo_pago] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [pk_metodo_pagos] PRIMARY KEY CLUSTERED 
(
	[id_metodo_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[precio] [decimal](8, 2) NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [pk_productos] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincias]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincias](
	[id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
 CONSTRAINT [pk_provincias] PRIMARY KEY CLUSTERED 
(
	[id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[loginname] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[correo] [nvarchar](100) NULL,
	[privilegio] [varchar](100) NULL,
 CONSTRAINT [pk_users] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD  CONSTRAINT [fk_condicion_clientes] FOREIGN KEY([id_condiciones_iva])
REFERENCES [dbo].[condiciones_iva] ([id_condiciones_iva])
GO
ALTER TABLE [dbo].[clientes] CHECK CONSTRAINT [fk_condicion_clientes]
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD  CONSTRAINT [fk_localidades_clientes] FOREIGN KEY([id_localidad])
REFERENCES [dbo].[localidades] ([id_localidad])
GO
ALTER TABLE [dbo].[clientes] CHECK CONSTRAINT [fk_localidades_clientes]
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD  CONSTRAINT [fk_provincias_clientes] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[provincias] ([id_provincia])
GO
ALTER TABLE [dbo].[clientes] CHECK CONSTRAINT [fk_provincias_clientes]
GO
ALTER TABLE [dbo].[detalle_facturas]  WITH CHECK ADD  CONSTRAINT [fk_facturas_detalle] FOREIGN KEY([nro_factura])
REFERENCES [dbo].[facturas] ([nro_factura])
GO
ALTER TABLE [dbo].[detalle_facturas] CHECK CONSTRAINT [fk_facturas_detalle]
GO
ALTER TABLE [dbo].[detalle_facturas]  WITH CHECK ADD  CONSTRAINT [fk_productos_detalle] FOREIGN KEY([id_producto])
REFERENCES [dbo].[productos] ([id_producto])
GO
ALTER TABLE [dbo].[detalle_facturas] CHECK CONSTRAINT [fk_productos_detalle]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [fk_clientes_facturas] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [fk_clientes_facturas]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [fk_metodo_facturas] FOREIGN KEY([id_metodo_pago])
REFERENCES [dbo].[metodo_pagos] ([id_metodo_pago])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [fk_metodo_facturas]
GO
ALTER TABLE [dbo].[localidades]  WITH CHECK ADD  CONSTRAINT [fk_provincias_localidades] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[provincias] ([id_provincia])
GO
ALTER TABLE [dbo].[localidades] CHECK CONSTRAINT [fk_provincias_localidades]
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_CLIENTE]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_CLIENTE]

	@nombre varchar(30),
	@apellido varchar(30),
	@documento int,
	@telefono int,
	@domicilio varchar(200),
	@correo varchar (100),
	@condicion int

	AS 
	BEGIN
	     DECLARE @ID_CONDICION INT
	     set @ID_CONDICION = (Select id_condiciones_iva from condiciones_iva where tipo_condicion=@condicion)
	UPDATE  clientes
		set nombre = @Nombre,
			apellido= @apellido,
			documento = @documento,
			telefono= @telefono,
			Domicilio = @domicilio,
			correo = @correo,
			id_condiciones_iva = @ID_CONDICION
			
	END
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_CLIENTE]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_CLIENTE]
	@id int,
	@nombre varchar(30),
	@apellido varchar(30),
	@documento int,
	@telefono int,
	@domicilio varchar(200),
	@correo nvarchar (100),
	@condicion varchar(30)

	AS 
	BEGIN
	     DECLARE @ID_CONDICION INT
	     set @ID_CONDICION = (Select id_condiciones_iva from condiciones_iva where tipo_condicion=@condicion)
	UPDATE  clientes
		set nombre = @Nombre,
			apellido= @apellido,
			documento = @documento,
			telefono= @telefono,
			Domicilio = @domicilio,
			correo = @correo,
			id_condiciones_iva = @ID_CONDICION
			WHERE id_cliente=@id
			
	END
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_PRODUCTO]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_PRODUCTO]
	@id int,
	@descripcion varchar(30),
	@precio decimal(10,2), 
	@stock int
AS
BEGIN
	update productos set
	descripcion=@descripcion,
	precio=@precio,
	stock=@stock
	where id_producto=@id;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_STOCK]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_ACTUALIZAR_STOCK] 
	@id_producto int,
	@cantidad int
AS
BEGIN

	update productos 
		set stock=(stock-@cantidad)
		where id_producto=@id_producto
ENd
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CLIENTES]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_CLIENTES]
AS
BEGIN
	
	SELECT c.*, cv.tipo_condicion as 'condicion'  from clientes c
			join condiciones_iva cv on c.id_condiciones_iva=cv.id_condiciones_iva

END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CONDICION_IVA]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_CONDICION_IVA]
AS
BEGIN
	
	SELECT * from condiciones_iva;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FACTURAS]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_FACTURAS] 
	@fecha_desde Date,
	@fecha_hasta Date,
	@cliente int=null,
	@baja varchar(1)
AS
BEGIN
	
	SELECT c.apellido + ' ' + C.nombre as 'cliente', F.fecha as 'fecha', F.nro_factura as 'factura_nro', F.total as 'total', mp.descripcion as 'metodo_pago', F.fecha_baja as 'fecha_baja'  FROM facturas F
	JOIN clientes C ON C.id_cliente = F.id_cliente
	join metodo_pagos mp on F.id_metodo_pago=mp.id_metodo_pago
	WHERE 
	 ((@fecha_desde is null and @fecha_hasta is  null) OR (fecha between @fecha_desde and @fecha_hasta))
	 AND(@cliente is null OR c.id_cliente= @cliente)
	 AND (@baja = 'S' OR (@baja = 'N' and F.fecha_baja IS  NULL))
	
	 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FACTURASR]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_CONSULTAR_FACTURASR] 

AS
BEGIN
	
	SELECT c.apellido + ' ' + C.nombre as 'cliente', F.fecha as 'fecha', F.nro_factura as 'factura_nro', F.total as 'total', mp.descripcion as 'metodo_pago', F.fecha_baja as 'fecha_baja'  FROM facturas F
	JOIN clientes C ON C.id_cliente = F.id_cliente
	join metodo_pagos mp on F.id_metodo_pago=mp.id_metodo_pago

		 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRODUCTOS]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_PRODUCTOS]
AS
BEGIN
	
	SELECT * from productos;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_CLIENTE]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_CLIENTE] 
	@id int
AS
BEGIN
	delete clientes
	WHERE id_cliente = @id;
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PRODUCTO]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_ELIMINAR_PRODUCTO] 
	@id_producto int
AS
BEGIN
	delete productos 
	WHERE id_producto = @id_producto;
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_CLIENTE]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[SP_INSERTAR_CLIENTE]
	@nombre varchar(30),
	@apellido varchar(30),
	@documento int,
	@telefono int,
	@domicilio varchar(200),
	@correo nvarchar (100),
	@condicion varchar(30)
AS
BEGIN		
	DECLARE @ID_CONDICION INT
	set @ID_CONDICION = (Select id_condiciones_iva from condiciones_iva where tipo_condicion=@condicion)

	INSERT INTO clientes (nombre,apellido,documento,telefono,Domicilio,correo,id_condiciones_iva)
	       VALUES(@nombre,@apellido,@documento,@telefono,@domicilio,@correo,@ID_CONDICION)
	      
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
	@NRO_FACTURA int,
	@id_producto int, 
	@cantidad int,
	@precio decimal(10,2)
AS
BEGIN
	INSERT INTO detalle_facturas(nro_factura, id_producto, cantidad, precio)
    VALUES (@NRO_FACTURA, @id_producto, @cantidad, @precio);
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_FACTURA]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_FACTURA] 
	@cliente int,
	@total numeric(10,2),
	@metodo int,
	@nro_factura int OUTPUT
AS
BEGIN
		declare @fecha date
		set @fecha=CONVERT(date,GETDATE(),3)
	INSERT INTO facturas(fecha, id_cliente,total, id_metodo_pago)
    VALUES (@fecha, @cliente,@total, @metodo);
	
    SET @nro_factura = SCOPE_IDENTITY();

ENd
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_PRODUCTO]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_PRODUCTO]

	@descripcion varchar(30),
	@precio decimal(10,2), 
	@stock int
AS
BEGIN
	INSERT INTO productos(descripcion,precio,stock)
    VALUES (@descripcion,@precio,@stock);
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LOGIN]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LOGIN]
	@USUARIO VARCHAR(50) = null,
    @CONTRASENA VARCHAR(50) = null,
    @USUARIOS int OUTPUT
AS
BEGIN
	SELECT * FROM users
	WHERE loginname = @USUARIO AND password = @CONTRASENA;

    SELECT @USUARIOS = @@ROWCOUNT;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_PRECIO]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_PRECIO]
	@id int
AS
BEGIN
	
	SELECT precio from productos
	where id_producto=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_BAJA_FACTURA]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_REGISTRAR_BAJA_FACTURA] 
	@factura_nro int
AS
BEGIN
	UPDATE facturas SET fecha_baja = GETDATE()
	WHERE nro_factura = @factura_nro;
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_CLIENTES]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_REPORTE_CLIENTES] 
	
AS
BEGIN
	
	select c.apellido + ' ' + c.nombre as 'Cliente', c.documento as 'DNI', c.correo as 'correo', c.telefono as 'telefono', cv.tipo_condicion as 'CondicionIVA', count(distinct f.nro_factura) as 'CantidadCompras', sum(f.total) as 'TotalCompra'  from clientes c
		join condiciones_iva cv on c.id_condiciones_iva=cv.id_condiciones_iva
		join facturas f on f.id_cliente=c.id_cliente
		group by c.apellido, c.nombre, c.documento,c.correo,c.telefono,cv.tipo_condicion
		order by Cliente 
	 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_FACTURAS]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_REPORTE_FACTURAS] 
	@nro_Factura int
AS
BEGIN
	
	select  c.nombre + ' ' + c.apellido as 'Cliente', c.documento as 'DNI', c.correo as 'correo', p.descripcion as 'Producto', dt.cantidad as 'cantidad', p.precio as 'Precio', dt.precio 'Subtotal', f.fecha as 'Fecha', f.fecha_baja as 'FechaBaja', cv.tipo_condicion as 'condicion', f.total as 'Total', mp.descripcion as 'Metodo', dt.nro_factura as 'NumeroF'  from facturas f 
	join detalle_facturas dt on f.nro_factura=dt.nro_factura
	join clientes c on f.id_cliente=c.id_cliente
	join productos p on dt.id_producto=p.id_producto
	join condiciones_iva cv on c.id_condiciones_iva=cv.id_condiciones_iva
	join metodo_pagos mp on f.id_metodo_pago=mp.id_metodo_pago
	where f.nro_factura=@nro_Factura
	
	 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_PRODUCTOS]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------
CREATE PROCEDURE [dbo].[SP_REPORTE_PRODUCTOS] 
	
AS
BEGIN
	
	select p.descripcion as 'Producto', p.precio as 'precio', p.stock as 'Stock' from productos p
	order by Producto
	 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_PRODUCTOS0]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_REPORTE_PRODUCTOS0] 
	
AS
BEGIN
	
	select p.descripcion as 'Producto', p.precio as 'precio', p.stock as 'Stock' from productos p
	where p.stock=0
	order by Producto
	
	 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_PRODUCTOS5]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_REPORTE_PRODUCTOS5] 
	
AS
BEGIN
	
	select p.descripcion as 'Producto', p.precio as 'precio', p.stock as 'Stock' from productos p
	where p.stock<=5
	order by Producto
	
	 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TRAER_CLIENTES]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TRAER_CLIENTES]
AS
BEGIN
	
	SELECT id_cliente,nombre+' '+apellido as 'Cliente' from clientes;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TRAER_METODOS]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_TRAER_METODOS]
AS
BEGIN
	
	SELECT * from metodo_pagos;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TRAER_PRODUCTOS]    Script Date: 17/11/2021 18:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TRAER_PRODUCTOS]
AS
BEGIN
	
	SELECT id_producto,descripcion FROM productos;
END
GO
