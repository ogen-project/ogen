CREATE TABLE "LOG_Log" (
	"IDLog" bigserial NOT NULL,
	"IFLogtype" integer NOT NULL,
	"IFUser" bigint NULL,
	"IFUser__read" bigint NULL,
	"IFErrortype" integer NULL,
	"Stamp" timestamp with time zone NOT NULL,
	"Stamp__read" timestamp with time zone NULL,
	"Message" character varying(4000) NOT NULL,
	"IFPermition" bigint NULL,
	"IFApplication" integer NULL,
	"IFBrowser__OPT" bigint NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Log" IS NULL;
	COMMENT ON COLUMN "LOG_Log"."IDLog" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "LOG_Log"."IFLogtype" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFUser__read" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFErrortype" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."Stamp" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "LOG_Log"."Stamp__read" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "LOG_Log"."Message" IS 'length:4000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Log"."IFPermition" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."IFBrowser__OPT" IS 'psql:bigint;sqlserver:bigint;';

