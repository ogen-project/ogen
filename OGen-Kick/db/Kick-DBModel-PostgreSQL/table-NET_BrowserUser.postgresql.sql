CREATE TABLE "NET_BrowserUser" (
	"IFBrowser" bigint NOT NULL,
	"IFUser" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_BrowserUser" IS NULL;
	COMMENT ON COLUMN "NET_BrowserUser"."IFBrowser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_BrowserUser"."IFUser" IS 'psql:bigint;sqlserver:bigint;';

