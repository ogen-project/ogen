CREATE TABLE "NWS_Profile" (
	"IFProfile" bigint NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Profile" IS NULL;
	COMMENT ON COLUMN "NWS_Profile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Profile"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Profile"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

