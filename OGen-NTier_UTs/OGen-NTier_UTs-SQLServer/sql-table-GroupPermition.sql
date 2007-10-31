USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[GroupPermition] (
	[IDGroup] bigint NOT NULL,
	[IDPermition] bigint NOT NULL,
	CONSTRAINT [PK_GroupPermition] PRIMARY KEY CLUSTERED (
		[IDGroup],
		[IDPermition]
	) ON [PRIMARY],
	CONSTRAINT [FK_GroupPermition_Group] FOREIGN KEY (
		[IDGroup]
	) REFERENCES [dbo].[Group] (
		[IDGroup]
	),
	CONSTRAINT [FK_GroupPermition_Permition] FOREIGN KEY (
		[IDPermition]
	) REFERENCES [dbo].[Permition] (
		[IDPermition]
	)
) ON [PRIMARY]
GO
