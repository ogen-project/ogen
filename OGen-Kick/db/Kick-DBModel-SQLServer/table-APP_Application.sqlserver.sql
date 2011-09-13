CREATE TABLE "APP_Application" (
	"IDApplication" "int" IDENTITY(1, 1) NOT NULL, 
	"Name" "varchar"(20) NOT NULL, 

	CONSTRAINT "PK_APP_Application" PRIMARY KEY CLUSTERED (
		"IDApplication" ASC
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
	@level1name = 'APP_Application';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:serial;sqlserver:int;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'APP_Application', 

		@level2type = N'COLUMN', 
		@level2name = 'IDApplication';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:20;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'APP_Application', 

		@level2type = N'COLUMN', 
		@level2name = 'Name';
	GO

