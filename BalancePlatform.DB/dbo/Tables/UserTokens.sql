CREATE TABLE [dbo].[UserTokens] (
    [Token]          NVARCHAR (256) NOT NULL,
    [UserId]         INT            NOT NULL,
    [ExpirationDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED ([Token] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_UserTokens_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Токены авторизации пользователей', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserTokens';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Токен', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserTokens', @level2type = N'COLUMN', @level2name = N'Token';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Идентификатор пользователя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserTokens', @level2type = N'COLUMN', @level2name = N'UserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Дата окончания действия токена', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserTokens', @level2type = N'COLUMN', @level2name = N'ExpirationDate';

