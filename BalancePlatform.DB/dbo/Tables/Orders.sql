CREATE TABLE [dbo].[Orders] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [UserId]    INT      NOT NULL,
    [ProductId] INT      NOT NULL,
    [Datetime]  DATETIME NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

