CREATE TABLE "NWS_Content" (
	"IDContent" "bigint" IDENTITY(1, 1) NOT NULL, 
	"IFApplication" "int" NULL, 
	"IFUser__Publisher" "bigint" NOT NULL, 
	"Publish_date" "datetime" NOT NULL, 
	"IFUser__Aproved" "bigint" NULL, 
	"Aproved_date" "datetime" NULL, 
	"Begin_date" "datetime" NULL, 
	"End_date" "datetime" NULL, 
	"TX_Title" "bigint" NULL, 
	"TX_Content" "bigint" NULL, 
	"tx_subtitle" "bigint" NULL, 
	"tx_summary" "bigint" NULL, 
	"Newslettersent_date" "datetime" NULL, 
	"isNews_notForum" "bit" NULL, 

	CONSTRAINT "PK_NWS_Content" PRIMARY KEY CLUSTERED (
		"IDContent" ASC
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
	@level1name = 'NWS_Content';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'IDContent';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:integer;sqlserver:int;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'IFApplication';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'IFUser__Publisher';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'Publish_date';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'IFUser__Aproved';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'Aproved_date';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'Begin_date';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'End_date';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Title';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Content';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'tx_subtitle';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'tx_summary';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:timestamp with time zone;sqlserver:datetime;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'Newslettersent_date';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:boolean;sqlserver:bit;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Content', 

		@level2type = N'COLUMN', 
		@level2name = 'isNews_notForum';
	GO

