CREATE TABLE "NWS_ContentTag" (
	"IFContent" bigint NOT NULL,
	"IFTag" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentTag" IS NULL;
	COMMENT ON COLUMN "NWS_ContentTag"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentTag"."IFTag" IS 'psql:bigint;sqlserver:bigint;';

