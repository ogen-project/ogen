CREATE TABLE "LOG_Type" (
	"IDType" "int" NOT NULL, 
	"IFType_parent" "int" NULL, 
	"Name" "varchar"(20) NOT NULL, 
	"IFApplication" "int" NULL, 

	CONSTRAINT "PK_LOG_Type" PRIMARY KEY CLUSTERED (
		"IDType" ASC
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
	@level1name = 'LOG_Type';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;identity:False;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Type', 

		@level2type = N'COLUMN', 
		@level2name = 'IDType';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Type', 

		@level2type = N'COLUMN', 
		@level2name = 'IFType_parent';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:20;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Type', 

		@level2type = N'COLUMN', 
		@level2name = 'Name';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Type', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO

