## Aplicação de Controle de Acesso e Visualização de Dados ##

Criamos aplicações CRUD's (Create, Read, Update, Delete) com controles de acesso para a visualização de dados além dos cadastros e alterações em usuários.


## Tabelas no Banco de Dados ##

```sql
CREATE TABLE Funcionarios (
    Id INT NOT NULL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Foto VARCHAR(MAX) NULL,
    Imagem VARBINARY(MAX) NULL,
    CargoId INT NULL
);

CREATE TABLE TipoCliente (
    Id INT PRIMARY KEY,
    Tipo VARCHAR(50)
);
INSERT INTO TipoCliente (Id, Tipo)
VALUES
    (1, 'Nacional'),
    (2, 'Internacional');

CREATE TABLE Cargo (
    Id INT PRIMARY KEY,
    Cargo VARCHAR(50)
);
INSERT INTO TipoCliente (Id, Tipo)
VALUES
    (1, 'Administrador'),
    (2, 'Recrutador'),
	(3, 'Vendedor'),

CREATE TABLE Cliente (
    Id INT PRIMARY KEY,
    NomeCliente NVARCHAR(100) NOT NULL,
    Cnpj VARCHAR(14) NOT NULL,
    Email NVARCHAR(100),
    Telefone VARCHAR(20),
    TipoClienteId INT
);

CREATE TABLE Maquina (
    Id INT PRIMARY KEY,
    maqStatus VARCHAR(50) NOT NULL,
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
 @cargoId int,
 @imagem varbinary(max)
)
as
begin
 update funcionario set
 nome = @nome,
 cargoId = @cargoId,
 imagem = @imagem
 where id = @id
end
GO
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
