CREATE TABLE "FRM_UserQuestion" (
	"IFUser" bigint NOT NULL,
	"IFQuestion" bigint NOT NULL,
	"Answer" character varying(8000) NULL,
	"IFUser__audit" bigint NULL,
	"Date__audit" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_UserQuestion" IS NULL;
	COMMENT ON COLUMN "FRM_UserQuestion"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserQuestion"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserQuestion"."Answer" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FRM_UserQuestion"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserQuestion"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

