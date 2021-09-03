CREATE TABLE [dbo].[UserScores] (
    [UserId] INT NOT NULL,
    [Score]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Score_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

