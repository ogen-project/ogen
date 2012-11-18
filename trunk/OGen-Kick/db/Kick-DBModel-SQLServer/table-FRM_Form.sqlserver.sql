CREATE TABLE "FRM_Form" (
	"IDForm" "bigint" IDENTITY(1, 1) NOT NULL, 
	"TX_Name" "bigint" NULL, 
	"TX_Description" "bigint" NULL, 
	"IFApplication" "int" NULL, 
	"IFUser__audit" "bigint" NOT NULL, 
	"Date__audit" "datetime" NOT NULL, 

	CONSTRAINT "PK_FRM_Form" PRIMARY KEY CLUSTERED (
		"IDForm" ASC
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
	@level1name = 'FRM_Form';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Form', 

		@level2type = N'COLUMN', 
		@level2name = 'IDForm';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Form', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Name';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Form', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Description';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Form', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Form', 

		@level2type = N'COLUMN', 
		@level2name = 'IFUser__audit';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Form', 

		@level2type = N'COLUMN', 
		@level2name = 'Date__audit';
	GO

