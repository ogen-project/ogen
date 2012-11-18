CREATE TABLE "FRM_Question" (
	"IDQuestion" bigserial NOT NULL,
	"IFQuestion__parent" bigint NULL,
	"IFQuestiontype" integer NULL,
	"TX_Question" bigint NULL,
	"TX_Details" bigint NULL,
	"IsRequired" boolean NULL,
	"IsTemplate" boolean NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Question" IS NULL;
	COMMENT ON COLUMN "FRM_Question"."IDQuestion" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Question"."IFQuestion__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."IFQuestiontype" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Question"."TX_Question" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."TX_Details" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."IsRequired" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Question"."IsTemplate" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Question"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Question"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

