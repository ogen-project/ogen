CREATE TABLE "NET_Browser" (
	"IDBrowser" "bigint" IDENTITY(1, 1) NOT NULL, 
	"HTTP_FULL_SIGNATURE" "varchar"(1024) NOT NULL, 
	"HTTP_FULL_SIGNATURE__CRC" "bigint" NOT NULL, 
	"HTTP_ACCEPT" "varchar"(255) NOT NULL, 
	"HTTP_ACCEPT__CRC" "bigint" NOT NULL, 
	"HTTP_ACCEPT_CHARSET" "varchar"(255) NOT NULL, 
	"HTTP_ACCEPT_CHARSET__CRC" "bigint" NOT NULL, 
	"HTTP_ACCEPT_ENCODING" "varchar"(255) NOT NULL, 
	"HTTP_ACCEPT_ENCODING__CRC" "bigint" NOT NULL, 
	"HTTP_ACCEPT_LANGUAGE" "varchar"(255) NOT NULL, 
	"HTTP_ACCEPT_LANGUAGE__CRC" "bigint" NOT NULL, 
	"HTTP_USER_AGENT" "varchar"(255) NOT NULL, 
	"HTTP_USER_AGENT__CRC" "bigint" NOT NULL, 

	CONSTRAINT "PK_NET_Browser" PRIMARY KEY CLUSTERED (
		"IDBrowser" ASC
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
	@level1name = 'NET_Browser';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'IDBrowser';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:1024;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_FULL_SIGNATURE';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_FULL_SIGNATURE__CRC';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT__CRC';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT_CHARSET';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT_CHARSET__CRC';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT_ENCODING';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT_ENCODING__CRC';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT_LANGUAGE';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_ACCEPT_LANGUAGE__CRC';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'length:255;psql:character varying;sqlserver:varchar;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_USER_AGENT';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Browser', 

		@level2type = N'COLUMN', 
		@level2name = 'HTTP_USER_AGENT__CRC';
	GO

