CREATE TABLE "LOG_Type" (
	"IDType" integer NOT NULL,
	"IFType_parent" integer NULL,
	"Name" character varying(20) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Type" IS NULL;
	COMMENT ON COLUMN "LOG_Type"."IDType" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Type"."IFType_parent" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Type"."Name" IS 'length:20;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Type"."IFApplication" IS 'psql:integer;sqlserver:int;';

