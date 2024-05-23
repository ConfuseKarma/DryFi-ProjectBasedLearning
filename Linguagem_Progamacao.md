## Aplicação de Controle de Acesso e Visualização de Dados ##

Criamos aplicações CRUD's (Create, Read, Update, Delete) com controles de acesso para a visualização de dados além dos cadastros e alterações em usuários.


## Tabelas no Banco de Dados ##

```sql
CREATE TABLE Funcionario (
    Id INT NOT NULL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Imagem VARBINARY(MAX) NULL,
    CargoId INT NULL
);

CREATE TABLE Cargo (
    Id INT PRIMARY KEY,
    Cargo VARCHAR(50)
);
INSERT INTO Cargo (Id, Cargo)
VALUES
    (1, 'Administrator'),
    (2, 'Recruiter'),
    (3, 'Salesperson');

CREATE TABLE Cliente (
    Id INT PRIMARY KEY,
    NomeCliente NVARCHAR(100) NOT NULL,
    Cnpj VARCHAR(14) NOT NULL,
    Email NVARCHAR(100),
    Telefone VARCHAR(20),
    TipoClienteId INT
);

CREATE TABLE TipoCliente (
    Id INT PRIMARY KEY,
    Tipo VARCHAR(50)
);
INSERT INTO TipoCliente (Id, Tipo)
VALUES
    (1, 'National'),
    (2, 'International');

CREATE TABLE Maquina (
    Id INT PRIMARY KEY,
    maqStatus INT,
	endereço VARCHAR(200),
    idCliente INT,
    FOREIGN KEY (idCliente) REFERENCES Cliente(Id)
);

CREATE TABLE Monitoramento (
    Id INT PRIMARY KEY,
    idMaquina INT,
    Temperatura DECIMAL(5,2),
    FOREIGN KEY (idMaquina) REFERENCES Maquina(Id)
);

```
### Utilizar Stored Procedures ###
```sql
create procedure spDelete
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

create procedure spConsulta
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

create procedure spListagem
(
 @tabela varchar(max),
 @ordem varchar(max))
as
begin
 exec('select * from ' + @tabela +
 ' order by ' + @ordem)
end
GO
create procedure spProximoId
(@tabela varchar(max))
as
begin
 exec('select isnull(max(id) +1, 1) as MAIOR from '
 +@tabela)
end
GO

```
### SP Funcionarios ###
```sql
create procedure spInsert_Funcionario
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

```
### SP Cliente ###
```sql
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

CREATE PROCEDURE spUpdate_Cliente
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

```
### SP Maquina ###
```sql
CREATE PROCEDURE spInsert_Maquina
(
    @Id INT,
    @maqStatus VARCHAR(50),
    @endereço VARCHAR(200),
    @idCliente INT
)
AS
BEGIN
    INSERT INTO Maquina
    (Id, maqStatus, endereço, idCliente)
    VALUES 
    (@Id, @maqStatus, @endereço, @idCliente);
END
GO

CREATE PROCEDURE spUpdate_Maquina
(
    @Id INT,
    @maqStatus VARCHAR(50),
    @endereço VARCHAR(200),
    @idCliente INT
)
AS
BEGIN
    UPDATE Maquina SET
    maqStatus = @maqStatus,
    endereço = @endereço,
    idCliente = @idCliente
    WHERE Id = @Id;
END
GO
```
### SP Monitoramento ###
```sql
