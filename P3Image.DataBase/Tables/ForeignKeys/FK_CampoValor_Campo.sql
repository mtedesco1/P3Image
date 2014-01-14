ALTER TABLE [dbo].[CampoValor]
	ADD CONSTRAINT [FK_CampoValor_Campo]
	FOREIGN KEY (CampoId)
	REFERENCES [Campo] (Id)
