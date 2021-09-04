CREATE TABLE [dbo].[Groups]
(
	[Id]			INT				identity(1,1) NOT NULL 
	,[Name]			nvarchar(256)	NOT NULL
	,[Descr]		nvarchar(256)	NULL
)
