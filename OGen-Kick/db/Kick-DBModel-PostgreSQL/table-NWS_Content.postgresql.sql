CREATE TABLE "NWS_Content" (
	"IDContent" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFUser__Publisher" bigint NOT NULL,
	"Publish_date" timestamp with time zone NOT NULL,
	"IFUser__Aproved" bigint NULL,
	"Aproved_date" timestamp with time zone NULL,
	"Begin_date" timestamp with time zone NULL,
	"End_date" timestamp with time zone NULL,
	"TX_Title" bigint NULL,
	"TX_Content" bigint NULL,
	"tx_subtitle" bigint NULL,
	"tx_summary" bigint NULL,
	"Newslettersent_date" timestamp with time zone NULL,
	"isNews_notForum" boolean NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Content" IS NULL;
	COMMENT ON COLUMN "NWS_Content"."IDContent" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Content"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Publisher" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Publish_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Aproved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Aproved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."Begin_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."End_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."TX_Title" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Content" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."tx_subtitle" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."tx_summary" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Newslettersent_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."isNews_notForum" IS 'psql:boolean;sqlserver:bit;';

