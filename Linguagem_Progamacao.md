## Aplicação de Controle de Acesso e Visualização de Dados ##

Criamos aplicações CRUD's (Create, Read, Update, Delete) com controles de acesso para a visualização de dados além dos cadastros e alterações em usuários.


## Tabelas no Banco de Dados ##

```sql
CREATE TABLE Funcionarios(
    Id INT PRIMARY KEY NOT NULL, 
    Nome NVARCHAR(100) NOT NULL,
    Cargo NVARCHAR(100) NOT NULL,
    Foto NVARCHAR(255) NOT NULL, -- Caminho da foto
    DepartamentoId INT NOT NULL,
    NomeDepartamento NVARCHAR(100) NOT NULL,
    FOREIGN KEY(DepartamentoId) REFERENCES Departamentos(Id)
);
```
### Utilizar Stored Procedures ###