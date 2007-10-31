USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[Permition] (
	[IDPermition] [bigint] IDENTITY (1, 1) NOT NULL,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT [PK_Permition] PRIMARY KEY CLUSTERED (
		[IDPermition]
	) ON [PRIMARY] 
) ON [PRIMARY]
GO
