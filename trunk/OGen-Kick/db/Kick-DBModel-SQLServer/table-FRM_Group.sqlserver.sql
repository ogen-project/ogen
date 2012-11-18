CREATE TABLE "FRM_Group" (
	"IDGroup" "bigint" IDENTITY(1, 1) NOT NULL, 
	"IFGroup__parent" "bigint" NULL, 
	"TX_Title" "bigint" NULL, 
	"TX_Description" "bigint" NULL, 
	"IsTemplate" "bit" NULL, 
	"GroupAnswers" "bit" NULL, 
	"IFApplication" "int" NULL, 
	"IFUser__audit" "bigint" NOT NULL, 
	"Date__audit" "datetime" NOT NULL, 

	CONSTRAINT "PK_FRM_Group" PRIMARY KEY CLUSTERED (
		"IDGroup" ASC
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
	@level1name = 'FRM_Group';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'IDGroup';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'IFGroup__parent';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Title';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Description';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:boolean;sqlserver:bit;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'IsTemplate';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:boolean;sqlserver:bit;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'GroupAnswers';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'IFUser__audit';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Group', 

		@level2type = N'COLUMN', 
		@level2name = 'Date__audit';
	GO

