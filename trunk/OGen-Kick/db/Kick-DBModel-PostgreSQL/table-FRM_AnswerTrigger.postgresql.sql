CREATE TABLE "FRM_AnswerTrigger" (
	"IFAnswer" bigint NOT NULL,
	"IFTrigger" integer NOT NULL,
	"IFQuestion" bigint NOT NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_AnswerTrigger" IS NULL;
	COMMENT ON COLUMN "FRM_AnswerTrigger"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_AnswerTrigger"."IFTrigger" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_AnswerTrigger"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_AnswerTrigger"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_AnswerTrigger"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

