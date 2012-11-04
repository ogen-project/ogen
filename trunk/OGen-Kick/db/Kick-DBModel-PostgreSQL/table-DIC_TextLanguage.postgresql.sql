CREATE TABLE "DIC_TextLanguage" (
	"IFText" bigint NOT NULL,
	"IFLanguage" integer NOT NULL,
	"Text__small" character varying(8000) NULL,
	"Text__large" text NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_TextLanguage" IS NULL;
	COMMENT ON COLUMN "DIC_TextLanguage"."IFText" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "DIC_TextLanguage"."IFLanguage" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "DIC_TextLanguage"."Text__small" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "DIC_TextLanguage"."Text__large" IS 'psql:text;sqlserver:text;';

