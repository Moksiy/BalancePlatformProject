CREATE TABLE [dbo].[BattleRequests] (
    [Id]              INT      IDENTITY (1, 1) NOT NULL,
    [AttackGroupId]   INT      NOT NULL,
    [DefenseGroupId]  INT      NOT NULL,
    [DateCreate]      DATETIME NOT NULL,
    [RequestStatusId] INT      NOT NULL,
    [IsActive]        BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ButtleRequests_Users_AttackGroupId] FOREIGN KEY ([AttackGroupId]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [FK_ButtleRequests_Users_DefenseGroupId] FOREIGN KEY ([DefenseGroupId]) REFERENCES [dbo].[Groups] ([Id])
);

