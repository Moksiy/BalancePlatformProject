CREATE TABLE [dbo].[Badges] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [ImageUrl]    NVARCHAR (MAX) NOT NULL,
    [Cost]        INT            NOT NULL,
    CONSTRAINT [PK_Badges] PRIMARY KEY CLUSTERED ([Id] ASC)
);

