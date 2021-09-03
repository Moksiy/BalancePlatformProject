CREATE TABLE [dbo].[GroupBattleScores] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [BattleId] INT NOT NULL,
    [GroupId]  INT NOT NULL,
    [Score]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GroupBattleScore_Battles] FOREIGN KEY ([BattleId]) REFERENCES [dbo].[Battles] ([Id]),
    CONSTRAINT [FK_GroupBattleScore_Group] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id])
);

