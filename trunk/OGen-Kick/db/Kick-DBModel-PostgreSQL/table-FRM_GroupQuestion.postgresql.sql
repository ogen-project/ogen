CREATE TABLE "FRM_GroupQuestion" (
	"IFGroup" bigint NOT NULL,
	"IFQuestion" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_GroupQuestion" IS NULL;
	COMMENT ON COLUMN "FRM_GroupQuestion"."IFGroup" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

