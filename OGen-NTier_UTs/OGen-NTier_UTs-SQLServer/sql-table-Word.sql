USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[Word] (
	[IDWord] [bigint] IDENTITY (1, 1) NOT NULL,
	[DeleteThisTestField] [bit] NULL,
	CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED (
		[IDWord]
	) ON [PRIMARY] 
) ON [PRIMARY]
GO
