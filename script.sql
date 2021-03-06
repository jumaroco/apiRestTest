USE [testapi]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/07/2021 05:24:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[primer_nombre] [nvarchar](max) NOT NULL,
	[segundo_nombre] [nvarchar](max) NULL,
	[primer_apellido] [nvarchar](max) NOT NULL,
	[segundo_apellido] [nvarchar](max) NULL,
	[direccion] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[telefono] [int] NOT NULL,
	[activo] [smallint] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraDetalles]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraDetalles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CompraEncabezadoid] [int] NOT NULL,
	[Productoid] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CompraDetalles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraEncabezados]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraEncabezados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sucursalid] [int] NOT NULL,
	[Proveedorid] [int] NOT NULL,
	[fecha] [datetime2](7) NOT NULL,
	[observaciones] [nvarchar](max) NULL,
	[activo] [smallint] NOT NULL,
 CONSTRAINT [PK_CompraEncabezados] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [nvarchar](max) NULL,
	[direccion] [nvarchar](max) NULL,
	[activo] [smallint] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[Sucursalid] [int] NOT NULL,
	[Productoid] [int] NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_Inventarios] PRIMARY KEY CLUSTERED 
(
	[Productoid] ASC,
	[Sucursalid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](max) NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[costo] [decimal](18, 2) NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[activo] [smallint] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [nvarchar](max) NULL,
	[direccion] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[activo] [smallint] NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Empresaid] [int] NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[telefono] [int] NULL,
	[activo] [smallint] NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaDetalles]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[VentaEncabezadoid] [int] NULL,
	[Productoid] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_VentaDetalles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaEncabezados]    Script Date: 26/07/2021 05:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaEncabezados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sucursalid] [int] NOT NULL,
	[Clienteid] [int] NOT NULL,
	[fecha] [datetime2](7) NOT NULL,
	[observaciones] [nvarchar](max) NULL,
	[activo] [smallint] NOT NULL,
 CONSTRAINT [PK_VentaEncabezados] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CompraDetalles]  WITH CHECK ADD  CONSTRAINT [FK_CompraDetalles_CompraEncabezados_CompraEncabezadoid] FOREIGN KEY([CompraEncabezadoid])
REFERENCES [dbo].[CompraEncabezados] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompraDetalles] CHECK CONSTRAINT [FK_CompraDetalles_CompraEncabezados_CompraEncabezadoid]
GO
ALTER TABLE [dbo].[CompraDetalles]  WITH CHECK ADD  CONSTRAINT [FK_CompraDetalles_Productos_Productoid] FOREIGN KEY([Productoid])
REFERENCES [dbo].[Productos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompraDetalles] CHECK CONSTRAINT [FK_CompraDetalles_Productos_Productoid]
GO
ALTER TABLE [dbo].[CompraEncabezados]  WITH CHECK ADD  CONSTRAINT [FK_CompraEncabezados_Proveedores_Proveedorid] FOREIGN KEY([Proveedorid])
REFERENCES [dbo].[Proveedores] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompraEncabezados] CHECK CONSTRAINT [FK_CompraEncabezados_Proveedores_Proveedorid]
GO
ALTER TABLE [dbo].[CompraEncabezados]  WITH CHECK ADD  CONSTRAINT [FK_CompraEncabezados_Sucursales_Sucursalid] FOREIGN KEY([Sucursalid])
REFERENCES [dbo].[Sucursales] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompraEncabezados] CHECK CONSTRAINT [FK_CompraEncabezados_Sucursales_Sucursalid]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_Inventarios_Productos_Productoid] FOREIGN KEY([Productoid])
REFERENCES [dbo].[Productos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_Inventarios_Productos_Productoid]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_Inventarios_Sucursales_Sucursalid] FOREIGN KEY([Sucursalid])
REFERENCES [dbo].[Sucursales] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_Inventarios_Sucursales_Sucursalid]
GO
ALTER TABLE [dbo].[Sucursales]  WITH CHECK ADD  CONSTRAINT [FK_Sucursales_Empresas_Empresaid] FOREIGN KEY([Empresaid])
REFERENCES [dbo].[Empresas] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sucursales] CHECK CONSTRAINT [FK_Sucursales_Empresas_Empresaid]
GO
ALTER TABLE [dbo].[VentaDetalles]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalles_Productos_Productoid] FOREIGN KEY([Productoid])
REFERENCES [dbo].[Productos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentaDetalles] CHECK CONSTRAINT [FK_VentaDetalles_Productos_Productoid]
GO
ALTER TABLE [dbo].[VentaDetalles]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalles_VentaEncabezados_VentaEncabezadoid] FOREIGN KEY([VentaEncabezadoid])
REFERENCES [dbo].[VentaEncabezados] ([id])
GO
ALTER TABLE [dbo].[VentaDetalles] CHECK CONSTRAINT [FK_VentaDetalles_VentaEncabezados_VentaEncabezadoid]
GO
ALTER TABLE [dbo].[VentaEncabezados]  WITH CHECK ADD  CONSTRAINT [FK_VentaEncabezados_Clientes_Clienteid] FOREIGN KEY([Clienteid])
REFERENCES [dbo].[Clientes] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentaEncabezados] CHECK CONSTRAINT [FK_VentaEncabezados_Clientes_Clienteid]
GO
ALTER TABLE [dbo].[VentaEncabezados]  WITH CHECK ADD  CONSTRAINT [FK_VentaEncabezados_Sucursales_Sucursalid] FOREIGN KEY([Sucursalid])
REFERENCES [dbo].[Sucursales] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentaEncabezados] CHECK CONSTRAINT [FK_VentaEncabezados_Sucursales_Sucursalid]
GO
