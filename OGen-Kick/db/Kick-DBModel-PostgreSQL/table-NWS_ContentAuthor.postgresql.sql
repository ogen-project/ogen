CREATE TABLE "NWS_ContentAuthor" (
	"IFContent" bigint NOT NULL,
	"IFAuthor" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentAuthor" IS NULL;
	COMMENT ON COLUMN "NWS_ContentAuthor"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentAuthor"."IFAuthor" IS 'psql:bigint;sqlserver:bigint;';

