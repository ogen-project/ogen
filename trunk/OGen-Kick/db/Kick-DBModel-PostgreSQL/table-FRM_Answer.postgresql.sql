CREATE TABLE "FRM_Answer" (
	"IDAnswer" bigserial NOT NULL,
	"TX_Answer" bigint NULL,
	"TX_Details" bigint NULL,
	"IsRequired" boolean NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Answer" IS NULL;
	COMMENT ON COLUMN "FRM_Answer"."IDAnswer" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Answer"."TX_Answer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Answer"."TX_Details" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Answer"."IsRequired" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Answer"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Answer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Answer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

