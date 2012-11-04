CREATE TABLE "CRD_Action" (
	"IDAction" "bigint" NOT NULL, 
	"Name" "varchar"(255) NOT NULL, 

	CONSTRAINT "PK_CRD_Action" PRIMARY KEY CLUSTERED (
		"IDAction" ASC
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
	@level1name = 'CRD_Action';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;identity:False;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'CRD_Action', 

		@level2type = N'COLUMN', 
		@level2name = 'IDAction';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'CRD_Action', 

		@level2type = N'COLUMN', 
		@level2name = 'Name';
	GO

