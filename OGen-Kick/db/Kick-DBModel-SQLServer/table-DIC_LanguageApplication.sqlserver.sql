CREATE TABLE "DIC_LanguageApplication" (
	"IFLanguage" "int" NOT NULL, 
	"IFApplication" "int" NOT NULL, 

	CONSTRAINT "PK_DIC_LanguageApplication" PRIMARY KEY CLUSTERED (
		"IFLanguage" ASC, 
		"IFApplication" ASC
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
	@level1name = 'DIC_LanguageApplication';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_LanguageApplication', 

		@level2type = N'COLUMN', 
		@level2name = 'IFLanguage';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_LanguageApplication', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO

