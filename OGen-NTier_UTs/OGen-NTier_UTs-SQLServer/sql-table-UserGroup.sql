USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[UserGroup] (
	[IDUser] [bigint] NOT NULL,
	[IDGroup] [bigint] NOT NULL,
	[Relationdate] [datetime] NULL,
	[Defaultrelation] [bit] NULL,
	CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED (
		[IDUser],
		[IDGroup]
	) ON [PRIMARY],
	CONSTRAINT [FK_UserGroup_Group] FOREIGN KEY (
		[IDGroup]
	) REFERENCES [dbo].[Group] (
		[IDGroup]
	),
	CONSTRAINT [FK_UserGroup_User] FOREIGN KEY (
		[IDUser]
	) REFERENCES [dbo].[User] (
		[IDUser]
	)
) ON [PRIMARY]
GO
