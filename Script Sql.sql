USE [master]
GO

/****** Object:  Database [Creditos]    Script Date: 05/12/2022 15:51:07 ******/
CREATE DATABASE [Creditos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Creditos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLPRUEBAS\MSSQL\DATA\Creditos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Creditos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLPRUEBAS\MSSQL\DATA\Creditos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO


USE [Creditos]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 05/12/2022 15:52:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[IdClient] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Apel1] [nvarchar](50) NULL,
	[Apel2] [nvarchar](50) NULL,
	[DocumentType] [char](3) NULL,
	[DocumentNumber] [nvarchar](10) NULL,
	[Sex] [char](1) NULL,
	[BirthDate] [date] NULL,
	[Address] [nvarchar](200) NULL,
	[CP] [nvarchar](5) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Prestamos](
	[IdLoan] [int] IDENTITY(1,1) NOT NULL,
	[LoanType] [int] NULL,
	[ClientId] [int] NULL,
	[Date] [datetime] NULL,
	[Mount] [decimal](18, 2) NULL,
	[PaymentDay] [datetime] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Commission] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Prestamos] PRIMARY KEY CLUSTERED 
(
	[IdLoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Listar_Clientes] as
begin
SELECT [IdClient]
      ,[Name]
      ,[Apel1]
      ,[Apel2]
      ,[DocumentType]
      ,[Sex]
      ,[BirthDate]
      ,[Address]
      ,[CP]
      ,[Status]
  FROM [Creditos].[dbo].[Clientes]
  end


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Obtener_Cliente]
(
@pDocumento nvarchar(10)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [IdClient]
      ,[Name]
      ,[Apel1]
      ,[Apel2]
      ,[DocumentType]
	  ,[DocumentNumber]
      ,[Sex]
      ,[BirthDate]
      ,[Address]
      ,[CP]
      ,[Status]
  FROM [Creditos].[dbo].[Clientes]
  where DocumentNumber = @pDocumento

END



CREATE PROCEDURE [dbo].[sp_Listar_Prestamos]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT TOP (1000) [IdLoan]
      ,[LoanType]
      ,[ClientId]
      ,[Date]
      ,[Mount]
      ,[PaymentDay]
      ,[Rate]
      ,[Commission]
  FROM [Creditos].[dbo].[Prestamos]

END
GO

CREATE PROCEDURE [dbo].[sp_Eliminar_Prestamo]
	(
	@IdLoan int	
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[Prestamos] WHERE IdLoan = @IdLoan           	
END
GO

CREATE PROCEDURE [dbo].[sp_Crear_Prestamo]	
(
	@LoanType int,
    @ClientId int,
    @Date DateTime,
    @Mount decimal(18,2),
    @PaymentDay date,
    @Rate decimal(18,2),
    @Commission decimal(18,2),
	@IdCredito int OUTPUT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Prestamos]
           ([LoanType]
           ,[ClientId]
           ,[Date]
           ,[Mount]
           ,[PaymentDay]
           ,[Rate]
           ,[Commission])
     VALUES
           (@LoanType
           ,@ClientId
           ,@Date
           ,@Mount
           ,@PaymentDay
           ,@Rate
           ,@Commission)

	set @IdCredito = SCOPE_IDENTITY()
	return @IdCredito
END
GO

CREATE PROCEDURE [dbo].[sp_Actualizar_Prestamo]	
(
	@IdLoan int,
	@LoanType int,
    @ClientId int,
    @Date DateTime,
    @Mount decimal(18,2),
    @PaymentDay date,
    @Rate decimal(18,2),
    @Commission decimal(18,2)	
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Prestamos]
           Set [LoanType] = @LoanType
           ,[ClientId] = @ClientId
           ,[Date] = @Date
           ,[Mount] = @Mount
           ,[PaymentDay] = @PaymentDay
           ,[Rate] = @Rate
           ,[Commission] = @Commission
     WHERE IdLoan = @IdLoan           	
END
GO