CREATE TABLE "FOR_Message" (
	"IDMessage" bigserial NOT NULL,
	"IFMessage__parent" bigint NULL,
	"IsSticky" boolean NOT NULL,
	"Subject" character varying(255) NULL,
	"Message__small" character varying(8000) NULL,
	"Message__large" text NULL,
	"IFUser__Publisher" bigint NULL,
	"Publish_date" timestamp with time zone NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FOR_Message" IS NULL;
	COMMENT ON COLUMN "FOR_Message"."IDMessage" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FOR_Message"."IFMessage__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FOR_Message"."IsSticky" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FOR_Message"."Subject" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FOR_Message"."Message__small" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FOR_Message"."Message__large" IS 'psql:text;sqlserver:text;';
	COMMENT ON COLUMN "FOR_Message"."IFUser__Publisher" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FOR_Message"."Publish_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "FOR_Message"."IFApplication" IS 'psql:integer;sqlserver:int;';

