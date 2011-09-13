CREATE TABLE "DIC_LanguageApplication" (
	"IFLanguage" integer NOT NULL,
	"IFApplication" integer NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_LanguageApplication" IS NULL;
	COMMENT ON COLUMN "DIC_LanguageApplication"."IFLanguage" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "DIC_LanguageApplication"."IFApplication" IS 'psql:integer;sqlserver:int;';

