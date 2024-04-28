## Aplicação de Controle de Acesso e Visualização de Dados ##

Criamos aplicações CRUD's (Create, Read, Update, Delete) com controles de acesso para a visualização de dados além dos cadastros e alterações em usuários.


## Tabelas no Banco de Dados ##

```sql
CREATE TABLE Funcionarios(
    Id INT PRIMARY KEY NOT NULL, 
    Nome VARCHAR(100) NOT NULL,
    Cargo VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
    Foto VARCHAR(MAX),
    Departamento VARCHAR(100) NOT NULL,
);

CREATE TABLE Cliente (
    Id INT PRIMARY KEY,
    nomeCliente NVARCHAR(100) NOT NULL,
    CNPJ VARCHAR(14) NOT NULL,
    email NVARCHAR(100),
    telefone VARCHAR(20)
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
create procedure spInsert_Funcionarios
(
 @id int,
 @nome varchar(200),
 @cargo varchar(100),
 @foto varchar(max),
 @Departamento varchar(100),
 @Email varchar(100)
)
as
begin
 insert into Funcionarios
 (id, nome, cargo, foto, departamento, email)
 values 
 (@id, @nome, @cargo, @foto, @departamento, @Email)
end
GO
create procedure spUpdate_Funcionarios
(
 @id int,
 @nome varchar(200),
 @cargo varchar(100),
 @foto varchar(max),
 @Departamento varchar(100)
)
as
begin
 update funcionarios set
 nome = @nome,
 cargo = @cargo,
 departamento = @departamento,
 foto = @foto
 where id = @id
end
GO
```
