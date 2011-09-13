CREATE TABLE "CRD_Profile" (
	"IDProfile" bigserial NOT NULL,
	"Name" character varying(255) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Profile" IS NULL;
	COMMENT ON COLUMN "CRD_Profile"."IDProfile" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "CRD_Profile"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_Profile"."IFApplication" IS 'psql:integer;sqlserver:int;';

