CREATE TABLE "FRM_Trigger" (
	"IDTrigger" "int" IDENTITY(1, 1) NOT NULL, 
	"Name" "varchar"(255) NOT NULL, 

	CONSTRAINT "PK_FRM_Trigger" PRIMARY KEY CLUSTERED (
		"IDTrigger" ASC
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
	@level1name = 'FRM_Trigger';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:serial;sqlserver:int;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Trigger', 

		@level2type = N'COLUMN', 
		@level2name = 'IDTrigger';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Trigger', 

		@level2type = N'COLUMN', 
		@level2name = 'Name';
	GO

