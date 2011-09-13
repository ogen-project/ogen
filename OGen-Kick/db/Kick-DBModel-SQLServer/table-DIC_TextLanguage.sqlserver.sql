CREATE TABLE "DIC_TextLanguage" (
	"IFText" "bigint" NOT NULL, 
	"IFLanguage" "int" NOT NULL, 
	"CharVar8000" "varchar"(8000) NULL, 
	"Text" "text" NULL, 

	CONSTRAINT "PK_DIC_TextLanguage" PRIMARY KEY CLUSTERED (
		"IFText" ASC, 
		"IFLanguage" ASC
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
	@level1name = 'DIC_TextLanguage';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_TextLanguage', 

		@level2type = N'COLUMN', 
		@level2name = 'IFText';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_TextLanguage', 

		@level2type = N'COLUMN', 
		@level2name = 'IFLanguage';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:8000;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_TextLanguage', 

		@level2type = N'COLUMN', 
		@level2name = 'CharVar8000';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:text;sqlserver:text;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_TextLanguage', 

		@level2type = N'COLUMN', 
		@level2name = 'Text';
	GO

