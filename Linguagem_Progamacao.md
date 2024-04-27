## Aplicação de Controle de Acesso e Visualização de Dados ##

Criamos aplicações CRUD's (Create, Read, Update, Delete) com controles de acesso para a visualização de dados além dos cadastros e alterações em usuários.


## Tabelas no Banco de Dados ##

```sql
CREATE TABLE Funcionarios(
    IdFuncionario INT PRIMARY KEY NOT NULL, 
    Nome NVARCHAR(100) NOT NULL,
    Cargo NVARCHAR(100) NOT NULL,
    Foto NVARCHAR(255) NOT NULL, -- Caminho da foto
    IdDepartamento INT NOT NULL,
    FOREIGN KEY(IdDepartamento) REFERENCES Departamento(IdDepartamento)
);

CREATE TABLE Departamento(
    IdDepartamento INT PRIMARY KEY NOT NULL, 
    NomeDepartamento NVARCHAR(100) NOT NULL
);


CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY,
    Nome NVARCHAR(100),
    CNPJ VARCHAR(14) UNIQUE, -- Definindo CNPJ como campo único
    Endereco NVARCHAR(255),
    Telefone NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE Monitoramento (
    IdMonitoramento INT PRIMARY KEY,
    IdCliente INT,
    IdFuncionario INT,
    Temperatura INT,
    FOREIGN KEY(IdCliente) REFERENCES Clientes(IdCliente),
    FOREIGN KEY(IdFuncionario) REFERENCES Funcionarios(IdFuncionario)
);

CREATE TABLE Venda (
    IdVenda INT PRIMARY KEY,
    IdCliente INT,
    IdFuncionario INT,
    IdMaquina INT,
    DataVenda DATE,
    Quantidade INT,
    ValorMaquina DECIMAL(10,2),
    ValorTotal DECIMAL(10,2),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(IdFuncionario),
    FOREIGN KEY (IdMaquina) REFERENCES Maquina(IdMaquina)
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
