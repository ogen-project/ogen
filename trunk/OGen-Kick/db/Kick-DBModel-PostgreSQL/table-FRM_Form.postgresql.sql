CREATE TABLE "FRM_Form" (
	"IDForm" bigserial NOT NULL,
	"TX_Name" bigint NULL,
	"TX_Description" bigint NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Form" IS NULL;
	COMMENT ON COLUMN "FRM_Form"."IDForm" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Form"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Form"."TX_Description" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Form"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Form"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Form"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

