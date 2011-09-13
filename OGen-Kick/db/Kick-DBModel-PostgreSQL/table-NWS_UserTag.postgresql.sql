CREATE TABLE "NWS_UserTag" (
	"IFUser" bigint NOT NULL,
	"IFTag" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_UserTag" IS NULL;
	COMMENT ON COLUMN "NWS_UserTag"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_UserTag"."IFTag" IS 'psql:bigint;sqlserver:bigint;';

