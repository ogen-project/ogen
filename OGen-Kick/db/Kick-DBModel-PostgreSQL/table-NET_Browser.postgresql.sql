CREATE TABLE "NET_Browser" (
	"IDBrowser" bigserial NOT NULL,
	"HTTP_FULL_SIGNATURE" character varying(1024) NOT NULL,
	"HTTP_FULL_SIGNATURE__CRC" bigint NOT NULL,
	"HTTP_ACCEPT" character varying(255) NOT NULL,
	"HTTP_ACCEPT__CRC" bigint NOT NULL,
	"HTTP_ACCEPT_CHARSET" character varying(255) NOT NULL,
	"HTTP_ACCEPT_CHARSET__CRC" bigint NOT NULL,
	"HTTP_ACCEPT_ENCODING" character varying(255) NOT NULL,
	"HTTP_ACCEPT_ENCODING__CRC" bigint NOT NULL,
	"HTTP_ACCEPT_LANGUAGE" character varying(255) NOT NULL,
	"HTTP_ACCEPT_LANGUAGE__CRC" bigint NOT NULL,
	"HTTP_USER_AGENT" character varying(255) NOT NULL,
	"HTTP_USER_AGENT__CRC" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_Browser" IS NULL;
	COMMENT ON COLUMN "NET_Browser"."IDBrowser" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_FULL_SIGNATURE" IS 'length:1024;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_FULL_SIGNATURE__CRC" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT__CRC" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT_CHARSET" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT_CHARSET__CRC" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT_ENCODING" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT_ENCODING__CRC" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT_LANGUAGE" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_ACCEPT_LANGUAGE__CRC" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_USER_AGENT" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_Browser"."HTTP_USER_AGENT__CRC" IS 'psql:bigint;sqlserver:bigint;';

