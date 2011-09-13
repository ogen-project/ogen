CREATE TABLE "NWS_ContentSource" (
	"IFContent" bigint NOT NULL,
	"IFSource" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentSource" IS NULL;
	COMMENT ON COLUMN "NWS_ContentSource"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentSource"."IFSource" IS 'psql:bigint;sqlserver:bigint;';

