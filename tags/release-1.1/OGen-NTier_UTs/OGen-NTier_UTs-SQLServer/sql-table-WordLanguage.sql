USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[WordLanguage] (
	[IDWord] [bigint] NOT NULL,
	[IDLanguage] [bigint] NOT NULL,
	[Translation] [varchar] (2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT [PK_WordLanguage] PRIMARY KEY CLUSTERED (
		[IDWord],
		[IDLanguage]
	)  ON [PRIMARY],
	CONSTRAINT [FK_WordLanguage_Language] FOREIGN KEY (
		[IDLanguage]
	) REFERENCES [dbo].[Language] (
		[IDLanguage]
	),
	CONSTRAINT [FK_WordLanguage_Word] FOREIGN KEY (
		[IDWord]
	) REFERENCES [dbo].[Word] (
		[IDWord]
	)
) ON [PRIMARY]
GO
