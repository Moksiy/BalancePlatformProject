CREATE TABLE [dbo].[GroupsUsers]
(
	[GroupId] INT NOT NULL
	,[UserId] INT NOT NULL
	--
	,constraint PK_GroupsUsers primary key(GroupId, UserId)
)
