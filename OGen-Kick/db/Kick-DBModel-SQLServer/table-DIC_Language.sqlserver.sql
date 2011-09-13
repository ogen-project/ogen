CREATE TABLE "DIC_Language" (
	"IDLanguage" "int" IDENTITY(1, 1) NOT NULL, 
	"TX_Name" "bigint" NOT NULL, 

	CONSTRAINT "PK_DIC_Language" PRIMARY KEY CLUSTERED (
		"IDLanguage" ASC
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
	@level1name = 'DIC_Language';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:serial;sqlserver:int;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_Language', 

		@level2type = N'COLUMN', 
		@level2name = 'IDLanguage';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'DIC_Language', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Name';
	GO

