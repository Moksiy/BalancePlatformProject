CREATE TABLE [dbo].[BattleParticipants] (
    [BattleId]       INT NOT NULL,
    [AttackGroupId]  INT NOT NULL,
    [DefenseGroupId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([BattleId] ASC),
    CONSTRAINT [FK_BattleParticipants_Battles] FOREIGN KEY ([BattleId]) REFERENCES [dbo].[Battles] ([Id]),
    CONSTRAINT [FK_BattleParticipants_Groups_AttackGroupId] FOREIGN KEY ([AttackGroupId]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [FK_BattleParticipants_Groups_DefenseGroupId] FOREIGN KEY ([DefenseGroupId]) REFERENCES [dbo].[Groups] ([Id])
);

