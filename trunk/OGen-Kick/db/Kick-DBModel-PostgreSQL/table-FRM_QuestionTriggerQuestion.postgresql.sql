CREATE TABLE "FRM_QuestionTriggerQuestion" (
	"IFQuestion" bigint NOT NULL,
	"IFTrigger" integer NOT NULL,
	"IFQuestion__destination" bigint NOT NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_QuestionTriggerQuestion" IS NULL;
	COMMENT ON COLUMN "FRM_QuestionTriggerQuestion"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerQuestion"."IFTrigger" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_QuestionTriggerQuestion"."IFQuestion__destination" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerQuestion"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerQuestion"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

