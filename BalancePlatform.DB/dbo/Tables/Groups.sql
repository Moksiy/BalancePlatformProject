CREATE TABLE [dbo].[Groups] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ImageUrl]    NVARCHAR (MAX) NOT NULL,
    [Name]        NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [GroupScore]  INT            NOT NULL,
    [AdminId]     INT            NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Groups_Users] FOREIGN KEY ([AdminId]) REFERENCES [dbo].[Users] ([Id])
);

