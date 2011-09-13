CREATE TABLE "NWS_Attachment" (
	"IDAttachment" bigserial NOT NULL,
	"IFContent" bigint NOT NULL,
	"GUID" character varying(50) NOT NULL,
	"OrderNum" bigint NULL,
	"isImage" boolean NOT NULL,
	"TX_Name" bigint NULL,
	"TX_Description" bigint NULL,
	"FileName" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Attachment" IS NULL;
	COMMENT ON COLUMN "NWS_Attachment"."IDAttachment" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Attachment"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."GUID" IS 'length:50;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Attachment"."OrderNum" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."isImage" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "NWS_Attachment"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."TX_Description" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."FileName" IS 'length:255;psql:character varying;sqlserver:varchar;';

