USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[Group] (
	[IDGroup] [bigint] IDENTITY (1, 1) NOT NULL,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	CONSTRAINT [PK_Group] PRIMARY KEY  CLUSTERED (
		[IDGroup]
	) ON [PRIMARY] 
) ON [PRIMARY]
GO
