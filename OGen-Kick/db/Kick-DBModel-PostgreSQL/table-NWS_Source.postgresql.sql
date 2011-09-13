CREATE TABLE "NWS_Source" (
	"IDSource" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFSource__parent" bigint NULL,
	"Name" character varying(255) NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Source" IS NULL;
	COMMENT ON COLUMN "NWS_Source"."IDSource" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Source"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Source"."IFSource__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Source"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Source"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Source"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

