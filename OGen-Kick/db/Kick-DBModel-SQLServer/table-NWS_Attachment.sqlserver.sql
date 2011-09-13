CREATE TABLE "NWS_Attachment" (
	"IDAttachment" "bigint" IDENTITY(1, 1) NOT NULL, 
	"IFContent" "bigint" NOT NULL, 
	"GUID" "varchar"(50) NOT NULL, 
	"OrderNum" "bigint" NULL, 
	"isImage" "bit" NOT NULL, 
	"TX_Name" "bigint" NULL, 
	"TX_Description" "bigint" NULL, 
	"FileName" "varchar"(255) NOT NULL, 

	CONSTRAINT "PK_NWS_Attachment" PRIMARY KEY CLUSTERED (
		"IDAttachment" ASC
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
	@level1name = 'NWS_Attachment';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'IDAttachment';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'IFContent';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:50;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'GUID';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'OrderNum';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:boolean;sqlserver:bit;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'isImage';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Name';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'TX_Description';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NWS_Attachment', 

		@level2type = N'COLUMN', 
		@level2name = 'FileName';
	GO

