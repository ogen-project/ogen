CREATE TABLE "CRD_Action" (
	"IDAction" bigint NOT NULL,
	"Name" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Action" IS NULL;
	COMMENT ON COLUMN "CRD_Action"."IDAction" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Action"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';

