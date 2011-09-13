CREATE TABLE "NWS_ContentHighlight" (
	"IFContent" "bigint" NOT NULL, 
	"IFHighlight" "bigint" NOT NULL, 
	"Begin_date" "datetime" NULL, 
	"End_date" "datetime" NULL, 

	CONSTRAINT "PK_NWS_ContentHighlight" PRIMARY KEY CLUSTERED (
		"IFContent" ASC, 
		"IFHighlight" ASC
	) WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty 
	@name = N'MS_Description', 
	@value = N'', 

	@level0type = N'SCHEMA', 
	@level0name = 'dbo', 

	@level1type = N'TABLE',  
	@level1name = 'NWS_ContentHighlight';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_ContentHighlight', 

		@level2type = N'COLUMN', 
		@level2name = 'IFContent';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_ContentHighlight', 

		@level2type = N'COLUMN', 
		@level2name = 'IFHighlight';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_ContentHighlight', 

		@level2type = N'COLUMN', 
		@level2name = 'Begin_date';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_ContentHighlight', 

		@level2type = N'COLUMN', 
		@level2name = 'End_date';
	GO

