CREATE TABLE "CRD_User" (
	"IDUser" bigserial NOT NULL,
	"Login" character varying(255) NOT NULL,
	"Password" character varying(255) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_User" IS NULL;
	COMMENT ON COLUMN "CRD_User"."IDUser" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "CRD_User"."Login" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_User"."Password" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_User"."IFApplication" IS 'psql:integer;sqlserver:int;';

