USE [master]
GO
/****** Object:  Database [Practica2]    Script Date: 2/28/2024 8:14:03 PM ******/
CREATE DATABASE [Practica2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Practica2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Practica2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Practica2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Practica2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Practica2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Practica2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Practica2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Practica2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Practica2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Practica2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Practica2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Practica2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Practica2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Practica2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Practica2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Practica2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Practica2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Practica2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Practica2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Practica2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Practica2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Practica2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Practica2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Practica2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Practica2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Practica2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Practica2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Practica2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Practica2] SET RECOVERY FULL 
GO
ALTER DATABASE [Practica2] SET  MULTI_USER 
GO
ALTER DATABASE [Practica2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Practica2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Practica2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Practica2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Practica2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Practica2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Practica2', N'ON'
GO
ALTER DATABASE [Practica2] SET QUERY_STORE = OFF
GO
USE [Practica2]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 2/28/2024 8:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[IdVehiculo] [bigint] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](100) NOT NULL,
	[Modelo] [varchar](100) NOT NULL,
	[Color] [varchar](100) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[IdVendedor] [bigint] NOT NULL,
 CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendedores]    Script Date: 2/28/2024 8:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendedores](
	[IdVendedor] [bigint] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](50) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Vendedores] PRIMARY KEY CLUSTERED 
(
	[IdVendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Vendedores] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Vendedores] ([IdVendedor])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Vendedores]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerVehiculos]    Script Date: 2/28/2024 8:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerVehiculos]
AS
BEGIN
	
	SELECT P.Cedula,
		   Marca,
		   Modelo,
		   Color,
		   Precio
	  FROM dbo.Vehiculos				U
	  INNER JOIN dbo.Vendedores		P ON U.IdVendedor = P.IdVendedor

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerVhiculos]    Script Date: 2/28/2024 8:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerVhiculos]
AS
BEGIN
	
	SELECT P.Cedula,
		   Marca,
		   Modelo,
		   Color,
		   Precio
	  FROM dbo.Vehiculos				U
	  INNER JOIN dbo.Vendedores		P ON U.IdVendedor = P.IdVendedor

END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarVehiculo]    Script Date: 2/28/2024 8:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarVehiculo]

    @Marca		varchar(100),
    @Modelo		varchar(100),
    @Color		varchar(100),
    @Precio		decimal(18,2),
    @IdVendedor	bigint

AS
BEGIN
	DECLARE @NumVehiculos INT

	SELECT @NumVehiculos = COUNT(*) From Vehiculos WHERE Marca = @Marca


	IF @NumVehiculos < 2
	BEGIN
	    INSERT INTO Vehiculos (Marca,Modelo,Color,Precio,IdVendedor)
        VALUES (@Marca,@Modelo,@Color,@Precio,@IdVendedor)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarVendedor]    Script Date: 2/28/2024 8:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarVendedor]
	@Cedula			varchar(200),
	@NombreVendedor	varchar(200),
	@Correo		varchar(200)
AS
BEGIN

	IF NOT EXISTS(SELECT 1 FROM Vendedores WHERE Cedula = @Cedula)
	BEGIN

		INSERT INTO dbo.Vendedores(Cedula,Nombre,Correo,Estado)
	    VALUES(@Cedula,@NombreVendedor,@Correo,1)

	END

END
GO
USE [master]
GO
ALTER DATABASE [Practica2] SET  READ_WRITE 
GO
