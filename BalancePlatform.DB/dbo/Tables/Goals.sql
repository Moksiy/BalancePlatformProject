CREATE TABLE [dbo].[Goals] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [Score]        INT      NOT NULL,
    [IsActive]     BIT      NOT NULL,
    [DateDeadline] DATETIME NOT NULL,
    [UserId]       INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Goals_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

