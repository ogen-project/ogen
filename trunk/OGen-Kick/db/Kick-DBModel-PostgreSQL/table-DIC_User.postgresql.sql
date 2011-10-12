CREATE TABLE "DIC_User" (
	"IFUser" bigint NOT NULL,
	"IFLanguage" integer NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_User" IS NULL;
	COMMENT ON COLUMN "DIC_User"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "DIC_User"."IFLanguage" IS 'psql:integer;sqlserver:int;';

