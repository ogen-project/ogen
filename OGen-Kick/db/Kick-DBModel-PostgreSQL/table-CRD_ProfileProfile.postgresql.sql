CREATE TABLE "CRD_ProfileProfile" (
	"IFProfile" bigint NOT NULL,
	"IFProfile_parent" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_ProfileProfile" IS NULL;
	COMMENT ON COLUMN "CRD_ProfileProfile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_ProfileProfile"."IFProfile_parent" IS 'psql:bigint;sqlserver:bigint;';

