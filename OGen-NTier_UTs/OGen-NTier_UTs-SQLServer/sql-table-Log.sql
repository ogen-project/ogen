USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[Log] (
	[IDLog] [bigint] IDENTITY (1, 1) NOT NULL,
	[IDLogcode] [bigint] NOT NULL,
	[IDUser_posted] [bigint] NOT NULL,
	[Date_posted] [datetime] NOT NULL,
	[Logdata] [varchar] (1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED (
		[IDLog]
	)  ON [PRIMARY],
	CONSTRAINT [FK_Log_Logcode] FOREIGN KEY (
		[IDLogcode]
	) REFERENCES [dbo].[Logcode] (
		[IDLogcode]
	),
	CONSTRAINT [FK_Log_User] FOREIGN KEY (
		[IDUser_posted]
	) REFERENCES [dbo].[User] (
		[IDUser]
	)
) ON [PRIMARY]
GO
