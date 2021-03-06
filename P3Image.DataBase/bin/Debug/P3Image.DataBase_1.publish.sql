﻿/*
Deployment script for P3ImageDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "P3ImageDB"
:setvar DefaultFilePrefix "P3ImageDB"
:setvar DefaultDataPath "c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Dropping FK_Categoria_SubCategoria...';


GO
ALTER TABLE [dbo].[SubCategoria] DROP CONSTRAINT [FK_Categoria_SubCategoria];


GO
PRINT N'Altering [dbo].[SubCategoria]...';


GO
ALTER TABLE [dbo].[SubCategoria] ALTER COLUMN [CategoriaId] INT NULL;

ALTER TABLE [dbo].[SubCategoria] ALTER COLUMN [Descricao] VARCHAR (50) NULL;


GO
PRINT N'Creating FK_Categoria_SubCategoria...';


GO
ALTER TABLE [dbo].[SubCategoria] WITH NOCHECK
    ADD CONSTRAINT [FK_Categoria_SubCategoria] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categoria] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[SubCategoria] WITH CHECK CHECK CONSTRAINT [FK_Categoria_SubCategoria];


GO
PRINT N'Update complete.'
GO
