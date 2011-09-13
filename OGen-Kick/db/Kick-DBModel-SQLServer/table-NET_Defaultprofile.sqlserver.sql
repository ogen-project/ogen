CREATE TABLE "NET_Defaultprofile" (
	"IDDefaultprofile" "bigint" IDENTITY(1, 1) NOT NULL, 
	"IFProfile" "bigint" NOT NULL, 

	CONSTRAINT "PK_NET_Defaultprofile" PRIMARY KEY CLUSTERED (
		"IDDefaultprofile" ASC
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
	@level1name = 'NET_Defaultprofile';
GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigserial;sqlserver:bigint;identity:True;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Defaultprofile', 

		@level2type = N'COLUMN', 
		@level2name = 'IDDefaultprofile';
	GO
	EXEC sys.sp_addextendedproperty 
		@name = N'MS_Description', 
		@value = N'psql:bigint;sqlserver:bigint;', 

		@level0type = N'SCHEMA', 
		@level0name = 'dbo', 

		@level1type = N'TABLE',  
		@level1name = 'NET_Defaultprofile', 

		@level2type = N'COLUMN', 
		@level2name = 'IFProfile';
	GO

