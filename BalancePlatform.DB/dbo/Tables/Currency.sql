CREATE TABLE [dbo].[Currency] (
    [UserId] INT NOT NULL,
    [Value]  INT NOT NULL,
    CONSTRAINT [PK__Currency__1788CC4CFA092BF4] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Currency_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

