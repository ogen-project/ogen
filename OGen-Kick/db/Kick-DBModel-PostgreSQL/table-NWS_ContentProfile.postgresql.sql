CREATE TABLE "NWS_ContentProfile" (
	"IFContent" bigint NOT NULL,
	"IFProfile" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentProfile" IS NULL;
	COMMENT ON COLUMN "NWS_ContentProfile"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentProfile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';

