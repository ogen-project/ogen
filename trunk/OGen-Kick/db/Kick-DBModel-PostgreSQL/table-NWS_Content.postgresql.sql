CREATE TABLE "NWS_Content" (
	"IDContent" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFUser__Publisher" bigint NOT NULL,
	"Publish_date" timestamp with time zone NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL,
	"Begin_date" timestamp with time zone NULL,
	"End_date" timestamp with time zone NULL,
	"TX_Title" bigint NULL,
	"TX_Content" bigint NULL,
	"TX_Subtitle" bigint NULL,
	"TX_Summary" bigint NULL,
	"Newslettersent_date" timestamp with time zone NULL,
	"IsNews_notForum" boolean NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Content" IS NULL;
	COMMENT ON COLUMN "NWS_Content"."IDContent" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Content"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Publisher" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Publish_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."Begin_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."End_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."TX_Title" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Content" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Subtitle" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Summary" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Newslettersent_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."IsNews_notForum" IS 'psql:boolean;sqlserver:bit;';

