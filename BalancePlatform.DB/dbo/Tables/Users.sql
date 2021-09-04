CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Login]        NVARCHAR (256) NOT NULL,
    [UserName]     NVARCHAR (256) NULL,
    [Email]        NVARCHAR (64)  NULL,
    [PasswordHash] NVARCHAR (256) NOT NULL,
    [Salt]         NVARCHAR (128) NOT NULL,
    [RoleId]       INT            NOT NULL,
    [IsActive]     BIT            NOT NULL,
    --
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);
