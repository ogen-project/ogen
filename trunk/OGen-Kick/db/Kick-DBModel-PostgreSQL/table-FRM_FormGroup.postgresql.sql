CREATE TABLE "FRM_FormGroup" (
	"IFForm" bigint NOT NULL,
	"IFGroup" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_FormGroup" IS NULL;
	COMMENT ON COLUMN "FRM_FormGroup"."IFForm" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_FormGroup"."IFGroup" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_FormGroup"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_FormGroup"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_FormGroup"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

