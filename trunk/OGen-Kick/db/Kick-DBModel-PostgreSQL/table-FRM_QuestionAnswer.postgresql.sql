CREATE TABLE "FRM_QuestionAnswer" (
	"IFQuestion" bigint NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_QuestionAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_QuestionAnswer"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

