CREATE TABLE [dbo].[Transactions] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]         INT            NOT NULL,
    [Value]          INT            NOT NULL,
    [IsIncome]       BIT            NOT NULL,
    [Description]    NVARCHAR (256) NOT NULL,
    [CurrencyTypeId] TINYINT        NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

