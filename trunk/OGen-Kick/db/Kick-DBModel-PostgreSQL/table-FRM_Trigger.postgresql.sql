CREATE TABLE "FRM_Trigger" (
	"IDTrigger" serial NOT NULL,
	"Name" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Trigger" IS NULL;
	COMMENT ON COLUMN "FRM_Trigger"."IDTrigger" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "FRM_Trigger"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';

