CREATE TABLE "NWS_ContentHighlight" (
	"IFContent" bigint NOT NULL,
	"IFHighlight" bigint NOT NULL,
	"Begin_date" timestamp with time zone NULL,
	"End_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentHighlight" IS NULL;
	COMMENT ON COLUMN "NWS_ContentHighlight"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentHighlight"."IFHighlight" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentHighlight"."Begin_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_ContentHighlight"."End_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

