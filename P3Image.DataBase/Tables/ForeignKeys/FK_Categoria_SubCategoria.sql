ALTER TABLE [dbo].[SubCategoria]
	ADD CONSTRAINT [FK_Categoria_SubCategoria]
	FOREIGN KEY (CategoriaId)
	REFERENCES [Categoria] (Id)
