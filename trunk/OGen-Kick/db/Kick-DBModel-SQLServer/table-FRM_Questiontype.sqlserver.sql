CREATE TABLE "FRM_Questiontype" (
	"IDQuestiontype" "int" IDENTITY(1, 1) NOT NULL, 
	"Name" "varchar"(255) NOT NULL, 
	"RegularExpression" "varchar"(1024) NULL, 

	CONSTRAINT "PK_FRM_Questiontype" PRIMARY KEY CLUSTERED (
		"IDQuestiontype" ASC
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
	@level1name = 'FRM_Questiontype';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:serial;sqlserver:int;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Questiontype', 

		@level2type = N'COLUMN', 
		@level2name = 'IDQuestiontype';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Questiontype', 

		@level2type = N'COLUMN', 
		@level2name = 'Name';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:1024;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FRM_Questiontype', 

		@level2type = N'COLUMN', 
		@level2name = 'RegularExpression';
	GO

