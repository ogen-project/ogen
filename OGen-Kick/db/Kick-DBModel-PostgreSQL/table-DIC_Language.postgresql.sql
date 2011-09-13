CREATE TABLE "DIC_Language" (
	"IDLanguage" serial NOT NULL,
	"TX_Name" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_Language" IS NULL;
	COMMENT ON COLUMN "DIC_Language"."IDLanguage" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "DIC_Language"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';

