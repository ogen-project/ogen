CREATE TABLE "CRD_Permition" (
	"IDPermition" bigint NOT NULL,
	"Name" character varying(255) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Permition" IS NULL;
	COMMENT ON COLUMN "CRD_Permition"."IDPermition" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Permition"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_Permition"."IFApplication" IS 'psql:integer;sqlserver:int;';

