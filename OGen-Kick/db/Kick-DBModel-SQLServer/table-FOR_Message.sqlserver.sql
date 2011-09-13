CREATE TABLE "FOR_Message" (
	"IDMessage" "bigint" IDENTITY(1, 1) NOT NULL, 
	"IFMessage__parent" "bigint" NULL, 
	"isSticky" "bit" NOT NULL, 
	"Subject" "varchar"(255) NULL, 
	"Message__charvar8000" "varchar"(8000) NULL, 
	"Message__text" "text" NULL, 
	"IFUser__Publisher" "bigint" NULL, 
	"Publish_date" "datetime" NOT NULL, 
	"IFApplication" "int" NULL, 

	CONSTRAINT "PK_FOR_Message" PRIMARY KEY CLUSTERED (
		"IDMessage" ASC
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
	@level1name = 'FOR_Message';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'IDMessage';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'IFMessage__parent';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:boolean;sqlserver:bit;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'isSticky';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'Subject';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:8000;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'Message__charvar8000';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:text;sqlserver:text;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'Message__text';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'IFUser__Publisher';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'Publish_date';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'FOR_Message', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO

