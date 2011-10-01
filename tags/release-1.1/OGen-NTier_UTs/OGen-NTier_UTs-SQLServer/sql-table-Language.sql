USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[Language] (
	[IDLanguage] [bigint] IDENTITY (1, 1) NOT NULL,
	[IDWord_name] [bigint] NOT NULL,
	CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED (
		[IDLanguage]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_Language_Word] FOREIGN KEY (
		[IDWord_name]
	) REFERENCES [dbo].[Word] (
		[IDWord]
	)
) ON [PRIMARY]
GO
