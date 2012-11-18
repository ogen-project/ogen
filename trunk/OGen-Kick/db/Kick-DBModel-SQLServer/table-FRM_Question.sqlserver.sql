CREATE TABLE "FRM_Question" (
	"IDQuestion" "bigint" IDENTITY(1, 1) NOT NULL, 
	"IFQuestion__parent" "bigint" NULL, 
	"IFQuestiontype" "int" NULL, 
	"TX_Question" "bigint" NULL, 
	"TX_Details" "bigint" NULL, 
	"IsRequired" "bit" NULL, 
	"IsTemplate" "bit" NULL, 
	"IFApplication" "int" NULL, 
	"IFUser__audit" "bigint" NOT NULL, 
	"Date__audit" "datetime" NOT NULL, 

	CONSTRAINT "PK_FRM_Question" PRIMARY KEY CLUSTERED (
		"IDQuestion" ASC
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
	@level1name = 'FRM_Question';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'IDQuestion';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'IFQuestion__parent';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'IFQuestiontype';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Question';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Details';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:boolean;sqlserver:bit;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'IsRequired';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:boolean;sqlserver:bit;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'IsTemplate';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'IFUser__audit';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Question', 

		@level2type = N'COLUMN', 
		@level2name = 'Date__audit';
	GO

