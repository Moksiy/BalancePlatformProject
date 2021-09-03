CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ImageUrl]    NVARCHAR (MAX) NOT NULL,
    [Name]        NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (256) NOT NULL,
    [Price]       INT            NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

