
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2016 09:25:49
-- Generated from EDMX file: C:\Users\PROGRAMADOR\Downloads\PruebaCascada-master\PruebaCascada\DAL\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PruebaCascada];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Productos_Categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productos] DROP CONSTRAINT [FK_Productos_Categorias];
GO
IF OBJECT_ID(N'[dbo].[FK_Productos_Subcategorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productos] DROP CONSTRAINT [FK_Productos_Subcategorias];
GO
IF OBJECT_ID(N'[dbo].[FK_Subcategorias_Categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subcategorias] DROP CONSTRAINT [FK_Subcategorias_Categorias];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[Subcategorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subcategorias];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(50)  NOT NULL
);
GO

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [descripcion] varchar(50)  NOT NULL,
    [idcat] int  NOT NULL,
    [idsubcat] int  NOT NULL
);
GO

-- Creating table 'Subcategorias'
CREATE TABLE [dbo].[Subcategorias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [idcat] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Subcategorias'
ALTER TABLE [dbo].[Subcategorias]
ADD CONSTRAINT [PK_Subcategorias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idcat] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [FK_Productos_Categorias]
    FOREIGN KEY ([idcat])
    REFERENCES [dbo].[Categorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Productos_Categorias'
CREATE INDEX [IX_FK_Productos_Categorias]
ON [dbo].[Productos]
    ([idcat]);
GO

-- Creating foreign key on [idcat] in table 'Subcategorias'
ALTER TABLE [dbo].[Subcategorias]
ADD CONSTRAINT [FK_Subcategorias_Categorias]
    FOREIGN KEY ([idcat])
    REFERENCES [dbo].[Categorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subcategorias_Categorias'
CREATE INDEX [IX_FK_Subcategorias_Categorias]
ON [dbo].[Subcategorias]
    ([idcat]);
GO

-- Creating foreign key on [idsubcat] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [FK_Productos_Subcategorias]
    FOREIGN KEY ([idsubcat])
    REFERENCES [dbo].[Subcategorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Productos_Subcategorias'
CREATE INDEX [IX_FK_Productos_Subcategorias]
ON [dbo].[Productos]
    ([idsubcat]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------