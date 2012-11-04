CREATE TABLE "CRD_ProfilePermission" (
	"IFProfile" bigint NOT NULL,
	"IFPermission" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_ProfilePermission" IS NULL;
	COMMENT ON COLUMN "CRD_ProfilePermission"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_ProfilePermission"."IFPermission" IS 'psql:bigint;sqlserver:bigint;';

