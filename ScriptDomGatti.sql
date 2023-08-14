
-- Script para criar o database
CREATE DATABASE DomGatti
COLLATE Latin1_General_CI_AI;



--Script para criar a tabela de cliente
CREATE TABLE Customer(
	Id INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(200) NOT NULL,
	Telefone VARCHAR(15) NOT NULL
)

--Script para criar a tabela de Agendamento
CREATE TABLE Agendamento(
	Id INT IDENTITY(1,1) NOT NULL,
	CustomerId INT NOT NULL,
	Data VARCHAR(10) NOT NULL,
	Hora VARCHAR(10) NOT NULL,
	Valor decimal(18,2) NOT NULL
)




-- Script para criar a proc de insert dos clientes
CREATE PROCEDURE InsertCustomer(
	@Nome VARCHAR(200),
	@Telefone VARCHAR(15),
	@CustomerId int output
)AS
BEGIN
	INSERT INTO [dbo].[Customer]
		(
			[Nome],
			[Telefone]
		)
	VALUES
		(
			@Nome,
			@Telefone
		)
		
	SET @CustomerId = SCOPE_IDENTITY()
	RETURN  @CustomerId
END

-- Script para criar a proc de insert dos clientes
CREATE PROCEDURE InsertAgendamento(
	@CustomerId INT,
	@Data VARCHAR(10),
	@Hora VARCHAR(10)
)AS
BEGIN
	INSERT INTO [dbo].[Agendamento]
	(
		[CustomerId],
		[Data],
		[Hora]
	)
	VALUES
	(
		@CustomerId,
		@Data,
		@Hora
	)
END