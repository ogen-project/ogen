CREATE TABLE "FRM_Questiontype" (
	"IDQuestiontype" serial NOT NULL,
	"Name" character varying(255) NOT NULL,
	"RegularExpression" character varying(1024) NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Questiontype" IS NULL;
	COMMENT ON COLUMN "FRM_Questiontype"."IDQuestiontype" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "FRM_Questiontype"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FRM_Questiontype"."RegularExpression" IS 'length:1024;psql:character varying;sqlserver:varchar;';

