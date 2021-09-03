CREATE TABLE [dbo].[GroupToUserRequests] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [GroupId]    INT      NOT NULL,
    [UserId]     INT      NOT NULL,
    [DateCreate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GroupToUserRequests_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [FK_GroupToUserRequests_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

