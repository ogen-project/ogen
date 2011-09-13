CREATE TABLE "NWS_Tag" (
	"IDTag" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFTag__parent" bigint NULL,
	"TX_Name" bigint NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Tag" IS NULL;
	COMMENT ON COLUMN "NWS_Tag"."IDTag" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Tag"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Tag"."IFTag__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Tag"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Tag"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Tag"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

