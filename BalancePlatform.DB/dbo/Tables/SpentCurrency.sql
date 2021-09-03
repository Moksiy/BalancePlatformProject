CREATE TABLE [dbo].[SpentCurrency] (
    [UserId] INT NOT NULL,
    [Value]  INT NOT NULL,
    CONSTRAINT [FK_SpentCurrency_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

