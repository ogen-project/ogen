CREATE TABLE "APP_Application" (
	"IDApplication" serial NOT NULL,
	"Name" character varying(20) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "APP_Application" IS NULL;
	COMMENT ON COLUMN "APP_Application"."IDApplication" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "APP_Application"."Name" IS 'length:20;psql:character varying;sqlserver:varchar;';

