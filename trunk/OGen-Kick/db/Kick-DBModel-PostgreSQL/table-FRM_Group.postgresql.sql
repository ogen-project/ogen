CREATE TABLE "FRM_Group" (
	"IDGroup" bigserial NOT NULL,
	"IFGroup__parent" bigint NULL,
	"TX_Title" bigint NULL,
	"TX_Description" bigint NULL,
	"IsTemplate" boolean NULL,
	"GroupAnswers" boolean NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Group" IS NULL;
	COMMENT ON COLUMN "FRM_Group"."IDGroup" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Group"."IFGroup__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."TX_Title" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."TX_Description" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."IsTemplate" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Group"."GroupAnswers" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Group"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Group"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

