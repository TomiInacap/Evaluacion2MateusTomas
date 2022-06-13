
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2022 09:18:01
-- Generated from EDMX file: C:\Users\laboratorio\Desktop\eva22mdtt\eva22mdtt\Models\ModeloEvaluacion2MDTT.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bddMDTT];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Producto_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK_Producto_Categoria];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria];
GO
IF OBJECT_ID(N'[dbo].[Producto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [idCategoria] int  NOT NULL,
    [nombre] nchar(20)  NOT NULL
);
GO

-- Creating table 'Producto'
CREATE TABLE [dbo].[Producto] (
    [idProducto] int  NOT NULL,
    [nombre] nchar(40)  NOT NULL,
    [descripcion] nchar(200)  NOT NULL,
    [precio] int  NOT NULL,
    [stock] int  NOT NULL,
    [IdCategoria] int  NOT NULL,
    [estado] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idCategoria] in table 'Categoria'
ALTER TABLE [dbo].[Categoria]
ADD CONSTRAINT [PK_Categoria]
    PRIMARY KEY CLUSTERED ([idCategoria] ASC);
GO

-- Creating primary key on [idProducto] in table 'Producto'
ALTER TABLE [dbo].[Producto]
ADD CONSTRAINT [PK_Producto]
    PRIMARY KEY CLUSTERED ([idProducto] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCategoria] in table 'Producto'
ALTER TABLE [dbo].[Producto]
ADD CONSTRAINT [FK_Producto_Categoria]
    FOREIGN KEY ([IdCategoria])
    REFERENCES [dbo].[Categoria]
        ([idCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Producto_Categoria'
CREATE INDEX [IX_FK_Producto_Categoria]
ON [dbo].[Producto]
    ([IdCategoria]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------