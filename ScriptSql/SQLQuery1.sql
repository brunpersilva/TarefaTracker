CREATE DATABASE Tarefas_Banco;

USE Tarefas_Banco;

CREATE TABLE Tarefas(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Titulo nvarchar(100) NOT NULL,
    Descricao nvarchar(300),
);

GO

Create PROCEDURE spGetAllTarefas
	-- Parameters List	
	@ItensPorPagina int,	
	@PaginaAtual int
	
AS

BEGIN
	
	if (@PaginaAtual = 0)
		set @PaginaAtual = 1;


	declare @TotalITens int;
	declare @TotalPages int;
	set @TotalITens = (select COUNT(Id) From Tarefas);

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	set @TotalPages = Ceiling((SELECT Cast(COUNT(Id) as decimal(15,2))/@ItensPorPagina From Tarefas));

	if  (@PaginaAtual > @TotalPages)
		set @PaginaAtual = @TotalPages

	SELECT Id, Titulo, Descricao from Tarefas
	Order By Id

	OFFSET  @ItensPorPagina * (@PaginaAtual - 1) ROWS

	FETCH NEXT @ItensPorPagina Rows Only;

	select @TotalITens as TotalItens, @TotalPages as TotalPages
	
END
