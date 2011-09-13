CREATE TABLE "DIC_Text" (
	"IDText" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"SourceTableField_ref" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_Text" IS NULL;
	COMMENT ON COLUMN "DIC_Text"."IDText" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "DIC_Text"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "DIC_Text"."SourceTableField_ref" IS 'psql:integer;sqlserver:int;';

