CREATE TABLE [dbo].[UserToGroupRequests] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [UserId]     INT      NOT NULL,
    [GroupId]    INT      NOT NULL,
    [DateCreate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserToGroupRequests_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [FK_UserToGroupRequests_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

