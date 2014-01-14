/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-----------------------------------------------------TIPO CAMPO-------------------------------------------------------------


IF NOT EXISTS (SELECT * FROM [dbo].[TipoCampo] WHERE [Id] = 1)
	INSERT [dbo].[TipoCampo] ([Id], [Descricao]) VALUES (1, N'TextBox')
ELSE
	UPDATE [dbo].[TipoCampo] SET [Descricao] = N'TextBox' WHERE [Id] = 1

IF NOT EXISTS (SELECT * FROM [dbo].[TipoCampo] WHERE [Id] = 2)
	INSERT [dbo].[TipoCampo] ([Id], [Descricao]) VALUES (2, N'CheckBox')
ELSE
	UPDATE [dbo].[TipoCampo] SET [Descricao] = N'CheckBox' WHERE [Id] = 2

IF NOT EXISTS (SELECT * FROM [dbo].[TipoCampo] WHERE [Id] = 3)
	INSERT [dbo].[TipoCampo] ([Id], [Descricao]) VALUES (3, N'ComboBox')
ELSE
	UPDATE [dbo].[TipoCampo] SET [Descricao] = N'ComboBox' WHERE [Id] = 3