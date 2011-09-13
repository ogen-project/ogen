CREATE TABLE "NWS_Highlight" (
	"IDHighlight" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFHighlight__parent" bigint NULL,
	"Name" character varying(100) NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Highlight" IS NULL;
	COMMENT ON COLUMN "NWS_Highlight"."IDHighlight" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Highlight"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Highlight"."IFHighlight__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Highlight"."Name" IS 'length:100;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Highlight"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Highlight"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

