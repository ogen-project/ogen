CREATE TABLE "NET_Defaultprofile" (
	"IDDefaultprofile" bigserial NOT NULL,
	"IFProfile" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_Defaultprofile" IS NULL;
	COMMENT ON COLUMN "NET_Defaultprofile"."IDDefaultprofile" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NET_Defaultprofile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';

