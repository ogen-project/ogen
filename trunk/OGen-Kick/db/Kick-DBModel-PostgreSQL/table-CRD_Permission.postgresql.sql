CREATE TABLE "CRD_Permission" (
	"IDPermission" bigint NOT NULL,
	"Name" character varying(255) NOT NULL,
	"IFApplication" integer NULL,
	"IFTable" bigint NULL,
	"IFAction" bigint NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Permission" IS NULL;
	COMMENT ON COLUMN "CRD_Permission"."IDPermission" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Permission"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_Permission"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "CRD_Permission"."IFTable" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_Permission"."IFAction" IS 'psql:bigint;sqlserver:bigint;';

