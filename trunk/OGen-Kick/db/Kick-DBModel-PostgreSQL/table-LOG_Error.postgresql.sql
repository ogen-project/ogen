CREATE TABLE "LOG_Error" (
	"IDError" integer NOT NULL,
	"Name" character varying(255) NOT NULL,
	"Description" character varying(2048) NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Error" IS NULL;
	COMMENT ON COLUMN "LOG_Error"."IDError" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Error"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Error"."Description" IS 'length:2048;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Error"."IFApplication" IS 'psql:integer;sqlserver:int;';

