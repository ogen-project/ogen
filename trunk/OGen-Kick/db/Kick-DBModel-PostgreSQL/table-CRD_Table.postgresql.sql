CREATE TABLE "CRD_Table" (
	"IDTable" bigint NOT NULL,
	"Name" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Table" IS NULL;
	COMMENT ON COLUMN "CRD_Table"."IDTable" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Table"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';

