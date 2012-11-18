CREATE TABLE "FRM_GroupAnswer" (
	"IFGroup" bigint NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NULL,
	"Date__audit" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_GroupAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_GroupAnswer"."IFGroup" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

