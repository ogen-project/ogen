USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[User] (
	[IDUser] [bigint] IDENTITY (1, 1) NOT NULL,
	[Login] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SomeNullValue] [int] NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED (
		[IDUser]
	) ON [PRIMARY] 
) ON [PRIMARY]
GO
