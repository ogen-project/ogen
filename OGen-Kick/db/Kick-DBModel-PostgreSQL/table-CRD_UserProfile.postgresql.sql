CREATE TABLE "CRD_UserProfile" (
	"IFUser" bigint NOT NULL,
	"IFProfile" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_UserProfile" IS NULL;
	COMMENT ON COLUMN "CRD_UserProfile"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_UserProfile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';

