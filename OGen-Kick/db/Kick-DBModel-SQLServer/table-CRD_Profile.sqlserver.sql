CREATE TABLE "CRD_Profile" (
	"IDProfile" "bigint" IDENTITY(1, 1) NOT NULL, 
	"Name" "varchar"(255) NOT NULL, 
	"IFApplication" "int" NULL, 

	CONSTRAINT "PK_CRD_Profile" PRIMARY KEY CLUSTERED (
		"IDProfile" ASC
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
	@level1name = 'CRD_Profile';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'CRD_Profile', 

		@level2type = N'COLUMN', 
		@level2name = 'IDProfile';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'CRD_Profile', 

		@level2type = N'COLUMN', 
		@level2name = 'Name';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'CRD_Profile', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO

