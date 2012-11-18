CREATE TABLE "FRM_QuestionTriggerAnswer" (
	"IFQuestion" bigint NOT NULL,
	"IFTrigger" integer NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_QuestionTriggerAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFTrigger" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

