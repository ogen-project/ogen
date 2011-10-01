USE [OGen-NTier_UTs]
GO

CREATE TABLE [dbo].[Config] (
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Config] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	CONSTRAINT [PK_Config] PRIMARY KEY  CLUSTERED (
		[Name]
	) ON [PRIMARY] 
) ON [PRIMARY]
GO


insert into [Config] ([Name], [Config], [Type], [Description]) values ('SomeBoolConfig', 'False', 1, 'some bool config');
insert into [Config] ([Name], [Config], [Type], [Description]) values ('SomeIntConfig', '1245', 4, 'some int config');
insert into [Config] ([Name], [Config], [Type], [Description]) values ('SomeMultiLineStringConfig', 'line 1\nline 2', 3, 'some multi-line string config');
insert into [Config] ([Name], [Config], [Type], [Description]) values ('SomeStringConfig', 'whatever', 2, 'some string config');

