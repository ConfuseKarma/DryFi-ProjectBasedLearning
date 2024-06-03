USE [master]
GO
/****** Object:  Database [PBL]    Script Date: 31/05/2024 21:48:53 ******/
CREATE DATABASE [PBL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PBL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLSERVER2022\MSSQL\DATA\PBL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PBL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLSERVER2022\MSSQL\DATA\PBL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PBL] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PBL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PBL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PBL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PBL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PBL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PBL] SET ARITHABORT OFF 
GO
ALTER DATABASE [PBL] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PBL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PBL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PBL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PBL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PBL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PBL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PBL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PBL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PBL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PBL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PBL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PBL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PBL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PBL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PBL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PBL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PBL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PBL] SET  MULTI_USER 
GO
ALTER DATABASE [PBL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PBL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PBL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PBL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PBL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PBL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PBL] SET QUERY_STORE = ON
GO
ALTER DATABASE [PBL] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PBL]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[Id] [int] NOT NULL,
	[Cargo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] NOT NULL,
	[NomeCliente] [nvarchar](100) NOT NULL,
	[Cnpj] [varchar](14) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Telefone] [varchar](20) NULL,
	[TipoClienteId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[Id] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Imagem] [varbinary](max) NULL,
	[CargoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquina]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquina](
	[Id] [int] NOT NULL,
	[maqStatus] [int] NULL,
	[endereco] [varchar](200) NULL,
	[idCliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaquinaStatus]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaStatus](
	[Id] [int] NOT NULL,
	[StatusNome] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monitoramento]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitoramento](
	[Id] [int] NOT NULL,
	[idMaquina] [int] NULL,
	[Temperatura] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCliente]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCliente](
	[Id] [int] NOT NULL,
	[Tipo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Monitoramento]  WITH CHECK ADD FOREIGN KEY([idMaquina])
REFERENCES [dbo].[Maquina] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[GetMaquinaIds]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaquinaIds]
AS
BEGIN
    SELECT Id FROM Maquina
END
GO
/****** Object:  StoredProcedure [dbo].[GetClienteIds]    Script Date: 31/05/2024 21:48:53 ******/
CREATE PROCEDURE [dbo].[GetClienteIds]
AS
BEGIN
    SELECT Id FROM Cliente
END
GO
/****** Object:  StoredProcedure [dbo].[spConsulta]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spConsulta]
(
 @id int ,
 @tabela varchar(max)
)
as
begin
 declare @sql varchar(max);
 set @sql = 'select * from ' + @tabela +
 ' where id = ' + cast(@id as varchar(max))
 exec(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultaAvancadaClientes]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spConsultaAvancadaClientes]
(
    @nomeCliente NVARCHAR(100),
    @cnpj VARCHAR(14),
    @tipo INT
)
AS
BEGIN
    IF (@nomeCliente IS NULL OR @nomeCliente = '')
        AND (@cnpj IS NULL OR @cnpj = '')
        AND (@tipo IS NULL OR @tipo = 0)
    BEGIN
        -- Se todos os parâmetros forem nulos ou vazios, busca todos os registros
        SELECT cliente.*, TipoCliente.Tipo AS 'DescricaoTipoCliente'
        FROM Cliente
        INNER JOIN TipoCliente ON Cliente.TipoClienteId = TipoCliente.Id;
    END
    ELSE
    BEGIN
        -- Se algum parâmetro estiver preenchido, busca pelos registros que batem 100%
        SELECT cliente.*, TipoCliente.Tipo AS 'DescricaoTipoCliente'
        FROM Cliente
        INNER JOIN TipoCliente ON Cliente.TipoClienteId = TipoCliente.Id
        WHERE (Cliente.NomeCliente LIKE '%' + @nomeCliente + '%' OR @nomeCliente IS NULL)
        AND (Cliente.Cnpj LIKE '%' + @cnpj + '%' OR @cnpj IS NULL)
        AND (Cliente.TipoClienteId = @tipo OR @tipo = 0);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[spConsultaAvancadaFuncionarios]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spConsultaAvancadaFuncionarios]
(
    @nome VARCHAR(MAX),
    @cargo INT
)
AS
BEGIN
    IF @cargo = 0
    BEGIN
        SELECT funcionario.*, Cargo.cargo AS 'DescricaoCategoria'
        FROM Funcionario
        INNER JOIN Cargo ON Funcionario.CargoId = Cargo.id
        WHERE Funcionario.nome LIKE '%' + @nome + '%';
    END
    ELSE
    BEGIN
        SELECT funcionario.*, Cargo.cargo AS 'DescricaoCategoria'
        FROM Funcionario
        INNER JOIN Cargo ON Funcionario.CargoId = Cargo.id
        WHERE Funcionario.nome LIKE '%' + @nome + '%' AND Funcionario.CargoID = @cargo;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[spConsultaAvancadaMaquinas]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spConsultaAvancadaMaquinas]
(
    @maqStatus INT,
    @idCliente INT,
    @nomeCliente NVARCHAR(100)
)
AS
BEGIN
    IF (@maqStatus = 0 AND @idCliente = 0 AND @nomeCliente = '')
    BEGIN
        -- Se todos os parâmetros forem zero ou vazios, busca todas as máquinas
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id;
    END
    ELSE IF (@maqStatus <> 0 AND @idCliente = 0 AND @nomeCliente = '')
    BEGIN
        -- Se apenas o status da máquina for fornecido como filtro
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id
        WHERE maquina.maqStatus = @maqStatus;
    END
    ELSE IF (@maqStatus = 0 AND @idCliente <> 0 AND @nomeCliente = '')
    BEGIN
        -- Se apenas o ID do cliente for fornecido como filtro
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id
        WHERE maquina.idCliente = @idCliente;
    END
    ELSE IF (@maqStatus = 0 AND @idCliente = 0 AND @nomeCliente <> '')
    BEGIN
        -- Se apenas o nome do cliente for fornecido como filtro
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id
        WHERE cliente.NomeCliente LIKE '%' + @nomeCliente + '%';
    END
    ELSE IF (@maqStatus <> 0 AND @idCliente <> 0 AND @nomeCliente = '')
    BEGIN
        -- Se status da máquina e ID do cliente forem fornecidos como filtro
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id
        WHERE maquina.maqStatus = @maqStatus AND maquina.idCliente = @idCliente;
    END
    ELSE IF (@maqStatus <> 0 AND @idCliente = 0 AND @nomeCliente <> '')
    BEGIN
        -- Se status da máquina e nome do cliente forem fornecidos como filtro
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id
        WHERE maquina.maqStatus = @maqStatus AND cliente.NomeCliente LIKE '%' + @nomeCliente + '%';
    END
    ELSE IF (@maqStatus = 0 AND @idCliente <> 0 AND @nomeCliente <> '')
    BEGIN
        -- Se ID do cliente e nome do cliente forem fornecidos como filtro
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id
        WHERE maquina.idCliente = @idCliente AND cliente.NomeCliente LIKE '%' + @nomeCliente + '%';
    END
    ELSE
    BEGIN
        -- Se todos os parâmetros forem fornecidos como filtro
        SELECT maquina.*, MaquinaStatus.StatusNome AS 'DescricaoStatus', cliente.NomeCliente
        FROM Maquina
        INNER JOIN MaquinaStatus ON Maquina.maqStatus = MaquinaStatus.Id
        LEFT JOIN Cliente ON Maquina.idCliente = Cliente.Id
        WHERE maquina.maqStatus = @maqStatus AND maquina.idCliente = @idCliente AND cliente.NomeCliente LIKE '%' + @nomeCliente + '%';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[spDelete]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDelete]
(
 @id int ,
 @tabela varchar(max)
)
as
begin
 declare @sql varchar(max);
 set @sql = ' delete ' + @tabela +
 ' where id = ' + cast(@id as varchar(max))
 exec(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[spInsert_Cliente]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsert_Cliente]
(
    @Id INT,
    @nomeCliente NVARCHAR(100),
    @CNPJ VARCHAR(14),
    @email NVARCHAR(100),
    @telefone VARCHAR(20),
	@TipoClienteId INT
)
AS
BEGIN
    INSERT INTO Cliente
    (Id, nomeCliente, CNPJ, email, telefone, TipoClienteId)
    VALUES 
    (@Id, @nomeCliente, @CNPJ, @email, @telefone, @TipoClienteId);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsert_Funcionario]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsert_Funcionario]
(
 @id int,
 @nome varchar(200),
 @cargoId int,
 @Email varchar(100),
 @imagem varbinary(max)
)
as
begin
 insert into Funcionario
 (id, nome, CargoId, email, imagem)
 values 
 (@id, @nome, @cargoId, @Email, @imagem)
end
GO
/****** Object:  StoredProcedure [dbo].[spInsert_Maquina]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsert_Maquina]
(
    @Id INT,
    @maqStatus INT,
    @endereco VARCHAR(200),
    @idCliente INT
)
AS
BEGIN
    INSERT INTO Maquina
    (Id, maqStatus, endereco, idCliente)
    VALUES 
    (@Id, @maqStatus, @endereco, @idCliente);
END
GO
/****** Object:  StoredProcedure [dbo].[spListagem]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spListagem]
(
 @tabela varchar(max),
 @ordem varchar(max))
as
begin
 exec('select * from ' + @tabela +
 ' order by ' + @ordem)
end
GO
/****** Object:  StoredProcedure [dbo].[spProximoId]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spProximoId]
(@tabela varchar(max))
as
begin
 exec('select isnull(max(id) +1, 1) as MAIOR from '
 +@tabela)
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdate_Cliente]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdate_Cliente]
(
    @Id INT,
    @nomeCliente NVARCHAR(100),
    @CNPJ VARCHAR(14),
    @email NVARCHAR(100),
    @telefone VARCHAR(20),
	@TipoClienteId INT
)
AS
BEGIN
    UPDATE Cliente SET
    nomeCliente = @nomeCliente,
    CNPJ = @CNPJ,
    email = @email,
    telefone = @telefone,
	TipoClienteId = @TipoClienteId
    WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdate_Funcionario]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdate_Funcionario]
(
 @id int,
 @nome varchar(200),
 @email varchar(100),
 @cargoId int,
 @imagem varbinary(max)
)
as
begin
 update funcionario set
 nome = @nome,
 cargoId = @cargoId,
 Email = @email,
 imagem = @imagem
 where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdate_Maquina]    Script Date: 31/05/2024 21:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdate_Maquina]
(
    @Id INT,
    @maqStatus INT,
    @endereco VARCHAR(200),
    @idCliente INT
)
AS
BEGIN
    UPDATE Maquina SET
    maqStatus = @maqStatus,
    endereco = @endereco,
    idCliente = @idCliente
    WHERE Id = @Id;
END
GO
USE [master]
GO
ALTER DATABASE [PBL] SET  READ_WRITE 
GO
USE [PBL]
GO
INSERT INTO [dbo].[Cargo] (Id, Cargo)
VALUES
    (1, 'Administrator'),
    (2, 'Recruiter'),
    (3, 'Salesperson');

INSERT INTO [dbo].[Cliente] (Id, NomeCliente, Cnpj, Email, Telefone, TipoClienteId)
VALUES (1, 'Empresa XYZ', '12345678901234', 'contato@empresa.xyz', '(11) 98765-4321', 1);

INSERT INTO [dbo].TipoCliente (Id, Tipo)
VALUES
    (1, 'National'),
    (2, 'International');

INSERT INTO [dbo].[Maquina] (Id, maqStatus, endereco, idCliente)
VALUES (1, 1, 'Rua A, 123', 1),
       (2, 2, 'Avenida B, 456', 2),
       (3, 3, 'Rua C, 789', 1),
       (4, 2, 'Avenida D, 1011', 3);

INSERT INTO [dbo].[MaquinaStatus](Id, StatusNome) 
VALUES (1, 'On'),
       (2, 'Off'),
       (3, 'Standby');
