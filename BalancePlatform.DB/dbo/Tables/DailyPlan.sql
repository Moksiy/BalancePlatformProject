CREATE TABLE [dbo].[DailyPlan] (
    [Id]       INT      IDENTITY (1, 1) NOT NULL,
    [UserId]   INT      NOT NULL,
    [MinScore] INT      NOT NULL,
    [Date]     DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DailyPlan_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

