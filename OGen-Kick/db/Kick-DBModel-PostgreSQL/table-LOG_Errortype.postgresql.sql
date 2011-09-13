CREATE TABLE "LOG_Errortype" (
	"IDErrortype" integer NOT NULL,
	"Name" character varying(255) NOT NULL,
	"Description" character varying(2048) NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Errortype" IS NULL;
	COMMENT ON COLUMN "LOG_Errortype"."IDErrortype" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Errortype"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Errortype"."Description" IS 'length:2048;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Errortype"."IFApplication" IS 'psql:integer;sqlserver:int;';

