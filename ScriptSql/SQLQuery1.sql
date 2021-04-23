CREATE DATABASE Tarefas_Banco;
USE Tarefas_Banco;
CREATE TABLE Tarefas(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Titulo nvarchar(100) NOT NULL,
    Descricao nvarchar(300),
);
