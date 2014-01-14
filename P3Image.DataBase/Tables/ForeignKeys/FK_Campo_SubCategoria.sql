ALTER TABLE [dbo].[Campo]
	ADD CONSTRAINT [FK_Campo_SubCategoria]
	FOREIGN KEY (SubCategoriaId)
	REFERENCES [SubCategoria] (Id)
