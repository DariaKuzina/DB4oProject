
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2018 23:14:15
-- Generated from EDMX file: D:\ProgrammsC#\Db4oExample\SqlDatabase\NetworkModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Network];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Nodes'
CREATE TABLE [dbo].[Nodes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [NodeType_Id] int  NOT NULL,
    [NodeType_Type] nvarchar(max)  NOT NULL,
    [NodeStatus_Id] int  NOT NULL,
    [NodeStatus_Status] nvarchar(max)  NOT NULL,
    [NodeColor_Id] int  NOT NULL,
    [NodeColor_Color] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NodeTypes'
CREATE TABLE [dbo].[NodeTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NodeStatus'
CREATE TABLE [dbo].[NodeStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NodeColors'
CREATE TABLE [dbo].[NodeColors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Color] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Edges'
CREATE TABLE [dbo].[Edges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Node1_Id] int  NOT NULL,
    [Node1_Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id], [Name] in table 'Nodes'
ALTER TABLE [dbo].[Nodes]
ADD CONSTRAINT [PK_Nodes]
    PRIMARY KEY CLUSTERED ([Id], [Name] ASC);
GO

-- Creating primary key on [Id], [Type] in table 'NodeTypes'
ALTER TABLE [dbo].[NodeTypes]
ADD CONSTRAINT [PK_NodeTypes]
    PRIMARY KEY CLUSTERED ([Id], [Type] ASC);
GO

-- Creating primary key on [Id], [Status] in table 'NodeStatus'
ALTER TABLE [dbo].[NodeStatus]
ADD CONSTRAINT [PK_NodeStatus]
    PRIMARY KEY CLUSTERED ([Id], [Status] ASC);
GO

-- Creating primary key on [Id], [Color] in table 'NodeColors'
ALTER TABLE [dbo].[NodeColors]
ADD CONSTRAINT [PK_NodeColors]
    PRIMARY KEY CLUSTERED ([Id], [Color] ASC);
GO

-- Creating primary key on [Id] in table 'Edges'
ALTER TABLE [dbo].[Edges]
ADD CONSTRAINT [PK_Edges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [NodeType_Id], [NodeType_Type] in table 'Nodes'
ALTER TABLE [dbo].[Nodes]
ADD CONSTRAINT [FK_NodeTypeNode]
    FOREIGN KEY ([NodeType_Id], [NodeType_Type])
    REFERENCES [dbo].[NodeTypes]
        ([Id], [Type])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NodeTypeNode'
CREATE INDEX [IX_FK_NodeTypeNode]
ON [dbo].[Nodes]
    ([NodeType_Id], [NodeType_Type]);
GO

-- Creating foreign key on [NodeStatus_Id], [NodeStatus_Status] in table 'Nodes'
ALTER TABLE [dbo].[Nodes]
ADD CONSTRAINT [FK_NodeStatusNode]
    FOREIGN KEY ([NodeStatus_Id], [NodeStatus_Status])
    REFERENCES [dbo].[NodeStatus]
        ([Id], [Status])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NodeStatusNode'
CREATE INDEX [IX_FK_NodeStatusNode]
ON [dbo].[Nodes]
    ([NodeStatus_Id], [NodeStatus_Status]);
GO

-- Creating foreign key on [NodeColor_Id], [NodeColor_Color] in table 'Nodes'
ALTER TABLE [dbo].[Nodes]
ADD CONSTRAINT [FK_NodeColorNode]
    FOREIGN KEY ([NodeColor_Id], [NodeColor_Color])
    REFERENCES [dbo].[NodeColors]
        ([Id], [Color])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NodeColorNode'
CREATE INDEX [IX_FK_NodeColorNode]
ON [dbo].[Nodes]
    ([NodeColor_Id], [NodeColor_Color]);
GO

-- Creating foreign key on [Node1_Id], [Node1_Name] in table 'Edges'
ALTER TABLE [dbo].[Edges]
ADD CONSTRAINT [FK_NodeEdge]
    FOREIGN KEY ([Node1_Id], [Node1_Name])
    REFERENCES [dbo].[Nodes]
        ([Id], [Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NodeEdge'
CREATE INDEX [IX_FK_NodeEdge]
ON [dbo].[Edges]
    ([Node1_Id], [Node1_Name]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------