CREATE TABLE "LOG_Logtype" (
	"IDLogtype" integer NOT NULL,
	"IFLogtype_parent" integer NULL,
	"Name" character varying(20) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Logtype" IS NULL;
	COMMENT ON COLUMN "LOG_Logtype"."IDLogtype" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Logtype"."IFLogtype_parent" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Logtype"."Name" IS 'length:20;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Logtype"."IFApplication" IS 'psql:integer;sqlserver:int;';

