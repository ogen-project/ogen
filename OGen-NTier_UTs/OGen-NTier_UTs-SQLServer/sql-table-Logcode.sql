USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[Logcode] (
	[IDLogcode] [bigint] IDENTITY (1, 1) NOT NULL,
	[Warning] [bit] NOT NULL,
	[Error] [bit] NOT NULL,
	[Code] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT [PK_Logcode] PRIMARY KEY CLUSTERED (
		[IDLogcode]
	) ON [PRIMARY] 
) ON [PRIMARY]
GO
