CREATE TABLE [dbo].[Campo]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [Descricao] VARCHAR(50) NULL, 
    [TipoId] INT NOT NULL, 
    [SubCategoriaId] INT NOT NULL
)
