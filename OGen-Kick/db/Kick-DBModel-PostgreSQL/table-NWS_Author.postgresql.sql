CREATE TABLE "NWS_Author" (
	"IDAuthor" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"Name" character varying(255) NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Author" IS NULL;
	COMMENT ON COLUMN "NWS_Author"."IDAuthor" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Author"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Author"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Author"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Author"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

