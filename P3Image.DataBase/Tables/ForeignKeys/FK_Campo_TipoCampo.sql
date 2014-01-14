ALTER TABLE [dbo].[Campo]
	ADD CONSTRAINT [FK_Campo_TipoCampo]
	FOREIGN KEY (TipoId)
	REFERENCES [TipoCampo] (Id)
