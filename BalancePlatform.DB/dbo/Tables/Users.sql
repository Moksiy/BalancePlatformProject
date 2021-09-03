﻿CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [ImageUrl]     NVARCHAR (MAX) NULL,
    [Login]        NVARCHAR (256) NOT NULL,
    [UserName]     NVARCHAR (256) NULL,
    [Email]        NVARCHAR (64)  NULL,
    [PasswordHash] NVARCHAR (256) NOT NULL,
    [Salt]         NVARCHAR (128) NOT NULL,
    [RoleId]       INT            NOT NULL,
    [IsActive]     BIT            NOT NULL,
    [City]         NVARCHAR (500) NULL,
    [BirthDate]    DATETIME       NOT NULL,
    [PhoneNum]     NVARCHAR (12)  NULL,
    [GroupId]      INT            NULL,
    CONSTRAINT [PK__Users__3214EC071697D63A] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [FK_Users_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id])
);

