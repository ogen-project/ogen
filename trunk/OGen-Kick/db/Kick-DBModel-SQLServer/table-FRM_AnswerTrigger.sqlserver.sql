CREATE TABLE "FRM_AnswerTrigger" (
	"IFAnswer" "bigint" NOT NULL, 
	"IFTrigger" "int" NOT NULL, 
	"IFQuestion" "bigint" NOT NULL, 
	"IFUser__audit" "bigint" NOT NULL, 
	"Date__audit" "datetime" NOT NULL, 

	CONSTRAINT "PK_FRM_AnswerTrigger" PRIMARY KEY CLUSTERED (
		"IFAnswer" ASC, 
		"IFTrigger" ASC, 
		"IFQuestion" ASC
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
	@level1name = 'FRM_AnswerTrigger';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_AnswerTrigger', 

		@level2type = N'COLUMN', 
		@level2name = 'IFAnswer';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_AnswerTrigger', 

		@level2type = N'COLUMN', 
		@level2name = 'IFTrigger';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_AnswerTrigger', 

		@level2type = N'COLUMN', 
		@level2name = 'IFQuestion';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_AnswerTrigger', 

		@level2type = N'COLUMN', 
		@level2name = 'IFUser__audit';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_AnswerTrigger', 

		@level2type = N'COLUMN', 
		@level2name = 'Date__audit';
	GO

