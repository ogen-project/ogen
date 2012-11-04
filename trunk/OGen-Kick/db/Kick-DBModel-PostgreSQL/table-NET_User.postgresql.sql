CREATE TABLE "NET_User" (
	"IFUser" bigint NOT NULL,
	"Name" character varying(255) NULL,
	"Email" character varying(255) NOT NULL,
	"Email_verify" character varying(255) NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_User" IS NULL;
	COMMENT ON COLUMN "NET_User"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_User"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_User"."Email" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_User"."Email_verify" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_User"."IFApplication" IS 'psql:integer;sqlserver:int;';

