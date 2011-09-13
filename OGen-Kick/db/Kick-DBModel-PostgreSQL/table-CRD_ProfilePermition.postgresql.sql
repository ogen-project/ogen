CREATE TABLE "CRD_ProfilePermition" (
	"IFProfile" bigint NOT NULL,
	"IFPermition" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_ProfilePermition" IS NULL;
	COMMENT ON COLUMN "CRD_ProfilePermition"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_ProfilePermition"."IFPermition" IS 'psql:bigint;sqlserver:bigint;';

