CREATE TABLE "LOG_Errortype" (
	"IDErrortype" "int" NOT NULL, 
	"Name" "varchar"(255) NOT NULL, 
	"Description" "varchar"(2048) NULL, 
	"IFApplication" "int" NULL, 

	CONSTRAINT "PK_LOG_Errortype" PRIMARY KEY CLUSTERED (
		"IDErrortype" ASC
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
	@level1name = 'LOG_Errortype';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;identity:False;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Errortype', 

		@level2type = N'COLUMN', 
		@level2name = 'IDErrortype';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Errortype', 

		@level2type = N'COLUMN', 
		@level2name = 'Name';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:2048;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Errortype', 

		@level2type = N'COLUMN', 
		@level2name = 'Description';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'LOG_Errortype', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO

