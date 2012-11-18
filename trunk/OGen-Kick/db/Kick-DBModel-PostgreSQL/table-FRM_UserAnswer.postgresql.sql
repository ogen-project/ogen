CREATE TABLE "FRM_UserAnswer" (
	"IFUser" bigint NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"IFUser__audit" bigint NULL,
	"Date__audit" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_UserAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_UserAnswer"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

