CREATE TABLE [dbo].[Battles] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [DateStart]     DATETIME NOT NULL,
    [EndDate]       DATETIME NOT NULL,
    [WinnerGroupId] INT      NULL,
    [IsActive]      BIT      NOT NULL,
    CONSTRAINT [PK__Battles__3214EC079B674EA3] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Buttles_Groups] FOREIGN KEY ([WinnerGroupId]) REFERENCES [dbo].[Groups] ([Id])
);

