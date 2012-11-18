CREATE TABLE "CRD_User" (
	"IDUser" bigserial NOT NULL,
	"Login" character varying(255) NOT NULL,
	"Password" character varying(255) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_User" IS NULL;
	COMMENT ON COLUMN "CRD_User"."IDUser" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "CRD_User"."Login" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_User"."Password" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_User"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "CRD_ProfilePermission" (
	"IFProfile" bigint NOT NULL,
	"IFPermission" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_ProfilePermission" IS NULL;
	COMMENT ON COLUMN "CRD_ProfilePermission"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_ProfilePermission"."IFPermission" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "DIC_Language" (
	"IDLanguage" serial NOT NULL,
	"TX_Name" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_Language" IS NULL;
	COMMENT ON COLUMN "DIC_Language"."IDLanguage" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "DIC_Language"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "DIC_Text" (
	"IDText" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"SourceTableField_ref" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_Text" IS NULL;
	COMMENT ON COLUMN "DIC_Text"."IDText" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "DIC_Text"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "DIC_Text"."SourceTableField_ref" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "DIC_TextLanguage" (
	"IFText" bigint NOT NULL,
	"IFLanguage" integer NOT NULL,
	"Text__small" character varying(8000) NULL,
	"Text__large" text NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_TextLanguage" IS NULL;
	COMMENT ON COLUMN "DIC_TextLanguage"."IFText" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "DIC_TextLanguage"."IFLanguage" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "DIC_TextLanguage"."Text__small" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "DIC_TextLanguage"."Text__large" IS 'psql:text;sqlserver:text;';

CREATE TABLE "DIC_LanguageApplication" (
	"IFLanguage" integer NOT NULL,
	"IFApplication" integer NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_LanguageApplication" IS NULL;
	COMMENT ON COLUMN "DIC_LanguageApplication"."IFLanguage" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "DIC_LanguageApplication"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "NWS_Attachment" (
	"IDAttachment" bigserial NOT NULL,
	"IFContent" bigint NOT NULL,
	"GUID" character varying(50) NOT NULL,
	"Order" bigint NULL,
	"IsImage" boolean NOT NULL,
	"TX_Name" bigint NULL,
	"TX_Description" bigint NULL,
	"FileName" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Attachment" IS NULL;
	COMMENT ON COLUMN "NWS_Attachment"."IDAttachment" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Attachment"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."GUID" IS 'length:50;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Attachment"."Order" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."IsImage" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "NWS_Attachment"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."TX_Description" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Attachment"."FileName" IS 'length:255;psql:character varying;sqlserver:varchar;';

CREATE TABLE "NWS_ContentTag" (
	"IFContent" bigint NOT NULL,
	"IFTag" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentTag" IS NULL;
	COMMENT ON COLUMN "NWS_ContentTag"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentTag"."IFTag" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "NWS_ContentSource" (
	"IFContent" bigint NOT NULL,
	"IFSource" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentSource" IS NULL;
	COMMENT ON COLUMN "NWS_ContentSource"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentSource"."IFSource" IS 'psql:bigint;sqlserver:bigint;';

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

CREATE TABLE "NWS_ContentAuthor" (
	"IFContent" bigint NOT NULL,
	"IFAuthor" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentAuthor" IS NULL;
	COMMENT ON COLUMN "NWS_ContentAuthor"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentAuthor"."IFAuthor" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "NWS_Content" (
	"IDContent" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFUser__Publisher" bigint NOT NULL,
	"Publish_date" timestamp with time zone NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL,
	"Begin_date" timestamp with time zone NULL,
	"End_date" timestamp with time zone NULL,
	"TX_Title" bigint NULL,
	"TX_Content" bigint NULL,
	"TX_Subtitle" bigint NULL,
	"TX_Summary" bigint NULL,
	"Newslettersent_date" timestamp with time zone NULL,
	"IsNews_notForum" boolean NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Content" IS NULL;
	COMMENT ON COLUMN "NWS_Content"."IDContent" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Content"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Publisher" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Publish_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."Begin_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."End_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."TX_Title" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Content" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Subtitle" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Summary" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Newslettersent_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."IsNews_notForum" IS 'psql:boolean;sqlserver:bit;';

CREATE TABLE "FOR_Message" (
	"IDMessage" bigserial NOT NULL,
	"IFMessage__parent" bigint NULL,
	"IsSticky" boolean NOT NULL,
	"Subject" character varying(255) NULL,
	"Message__small" character varying(8000) NULL,
	"Message__large" text NULL,
	"IFUser__Publisher" bigint NULL,
	"Publish_date" timestamp with time zone NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FOR_Message" IS NULL;
	COMMENT ON COLUMN "FOR_Message"."IDMessage" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FOR_Message"."IFMessage__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FOR_Message"."IsSticky" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FOR_Message"."Subject" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FOR_Message"."Message__small" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FOR_Message"."Message__large" IS 'psql:text;sqlserver:text;';
	COMMENT ON COLUMN "FOR_Message"."IFUser__Publisher" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FOR_Message"."Publish_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "FOR_Message"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "NWS_Source" (
	"IDSource" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFSource__parent" bigint NULL,
	"Name" character varying(255) NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Source" IS NULL;
	COMMENT ON COLUMN "NWS_Source"."IDSource" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Source"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Source"."IFSource__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Source"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Source"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Source"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "NWS_Highlight" (
	"IDHighlight" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFHighlight__parent" bigint NULL,
	"Name" character varying(100) NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Highlight" IS NULL;
	COMMENT ON COLUMN "NWS_Highlight"."IDHighlight" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Highlight"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Highlight"."IFHighlight__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Highlight"."Name" IS 'length:100;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Highlight"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Highlight"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "NWS_Author" (
	"IDAuthor" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"Name" character varying(255) NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Author" IS NULL;
	COMMENT ON COLUMN "NWS_Author"."IDAuthor" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Author"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Author"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NWS_Author"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Author"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "NWS_Tag" (
	"IDTag" bigserial NOT NULL,
	"IFApplication" integer NULL,
	"IFTag__parent" bigint NULL,
	"TX_Name" bigint NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Tag" IS NULL;
	COMMENT ON COLUMN "NWS_Tag"."IDTag" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Tag"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Tag"."IFTag__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Tag"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Tag"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Tag"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "NWS_ContentProfile" (
	"IFContent" bigint NOT NULL,
	"IFProfile" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_ContentProfile" IS NULL;
	COMMENT ON COLUMN "NWS_ContentProfile"."IFContent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_ContentProfile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "NWS_Profile" (
	"IFProfile" bigint NOT NULL,
	"IFUser__Approved" bigint NULL,
	"Approved_date" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Profile" IS NULL;
	COMMENT ON COLUMN "NWS_Profile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Profile"."IFUser__Approved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Profile"."Approved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "NWS_UserTag" (
	"IFUser" bigint NOT NULL,
	"IFTag" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_UserTag" IS NULL;
	COMMENT ON COLUMN "NWS_UserTag"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_UserTag"."IFTag" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "LOG_Type" (
	"IDType" integer NOT NULL,
	"IFType_parent" integer NULL,
	"Name" character varying(20) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Type" IS NULL;
	COMMENT ON COLUMN "LOG_Type"."IDType" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Type"."IFType_parent" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Type"."Name" IS 'length:20;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Type"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "LOG_Error" (
	"IDError" integer NOT NULL,
	"Name" character varying(255) NOT NULL,
	"Description" character varying(2048) NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Error" IS NULL;
	COMMENT ON COLUMN "LOG_Error"."IDError" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Error"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Error"."Description" IS 'length:2048;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Error"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "LOG_Log" (
	"IDLog" bigserial NOT NULL,
	"IFType" integer NOT NULL,
	"IFUser" bigint NULL,
	"IFUser__read" bigint NULL,
	"IFError" integer NULL,
	"Stamp" timestamp with time zone NOT NULL,
	"Stamp__read" timestamp with time zone NULL,
	"Message" character varying(4000) NOT NULL,
	"IFPermission" bigint NULL,
	"IFApplication" integer NULL,
	"IFBrowser__OPT" bigint NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Log" IS NULL;
	COMMENT ON COLUMN "LOG_Log"."IDLog" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "LOG_Log"."IFType" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFUser__read" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFError" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."Stamp" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "LOG_Log"."Stamp__read" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "LOG_Log"."Message" IS 'length:4000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Log"."IFPermission" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."IFBrowser__OPT" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "CRD_Permission" (
	"IDPermission" bigint NOT NULL,
	"Name" character varying(255) NOT NULL,
	"IFApplication" integer NULL,
	"IFTable" bigint NULL,
	"IFAction" bigint NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Permission" IS NULL;
	COMMENT ON COLUMN "CRD_Permission"."IDPermission" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Permission"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_Permission"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "CRD_Permission"."IFTable" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_Permission"."IFAction" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "NET_Profile__default" (
	"IFProfile" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_Profile__default" IS NULL;
	COMMENT ON COLUMN "NET_Profile__default"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';

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

CREATE TABLE "NET_BrowserUser" (
	"IFBrowser" bigint NOT NULL,
	"IFUser" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_BrowserUser" IS NULL;
	COMMENT ON COLUMN "NET_BrowserUser"."IFBrowser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_BrowserUser"."IFUser" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "CRD_ProfileProfile" (
	"IFProfile" bigint NOT NULL,
	"IFProfile_parent" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_ProfileProfile" IS NULL;
	COMMENT ON COLUMN "CRD_ProfileProfile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_ProfileProfile"."IFProfile_parent" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "CRD_Profile" (
	"IDProfile" bigserial NOT NULL,
	"Name" character varying(255) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Profile" IS NULL;
	COMMENT ON COLUMN "CRD_Profile"."IDProfile" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "CRD_Profile"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_Profile"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "CRD_UserProfile" (
	"IFUser" bigint NOT NULL,
	"IFProfile" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_UserProfile" IS NULL;
	COMMENT ON COLUMN "CRD_UserProfile"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_UserProfile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "DIC_User" (
	"IFUser" bigint NOT NULL,
	"IFLanguage" integer NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_User" IS NULL;
	COMMENT ON COLUMN "DIC_User"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "DIC_User"."IFLanguage" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "APP_Application" (
	"IDApplication" serial NOT NULL,
	"Name" character varying(20) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "APP_Application" IS NULL;
	COMMENT ON COLUMN "APP_Application"."IDApplication" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "APP_Application"."Name" IS 'length:20;psql:character varying;sqlserver:varchar;';

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

CREATE TABLE "CRD_Table" (
	"IDTable" bigint NOT NULL,
	"Name" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Table" IS NULL;
	COMMENT ON COLUMN "CRD_Table"."IDTable" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Table"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';

CREATE TABLE "CRD_Action" (
	"IDAction" bigint NOT NULL,
	"Name" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Action" IS NULL;
	COMMENT ON COLUMN "CRD_Action"."IDAction" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Action"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';

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

CREATE TABLE "FRM_QuestionTriggerAnswer" (
	"IFQuestion" bigint NOT NULL,
	"IFTrigger" integer NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_QuestionTriggerAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFTrigger" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionTriggerAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_Form" (
	"IDForm" bigserial NOT NULL,
	"TX_Name" bigint NULL,
	"TX_Description" bigint NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Form" IS NULL;
	COMMENT ON COLUMN "FRM_Form"."IDForm" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Form"."TX_Name" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Form"."TX_Description" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Form"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Form"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Form"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_FormGroup" (
	"IFForm" bigint NOT NULL,
	"IFGroup" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_FormGroup" IS NULL;
	COMMENT ON COLUMN "FRM_FormGroup"."IFForm" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_FormGroup"."IFGroup" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_FormGroup"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_FormGroup"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_FormGroup"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_QuestionAnswer" (
	"IFQuestion" bigint NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_QuestionAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_QuestionAnswer"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_QuestionAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_GroupQuestion" (
	"IFGroup" bigint NOT NULL,
	"IFQuestion" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_GroupQuestion" IS NULL;
	COMMENT ON COLUMN "FRM_GroupQuestion"."IFGroup" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupQuestion"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_Trigger" (
	"IDTrigger" serial NOT NULL,
	"Name" character varying(255) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Trigger" IS NULL;
	COMMENT ON COLUMN "FRM_Trigger"."IDTrigger" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "FRM_Trigger"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';

CREATE TABLE "FRM_Group" (
	"IDGroup" bigserial NOT NULL,
	"IFGroup__parent" bigint NULL,
	"TX_Title" bigint NULL,
	"TX_Description" bigint NULL,
	"IsTemplate" boolean NULL,
	"GroupAnswers" boolean NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Group" IS NULL;
	COMMENT ON COLUMN "FRM_Group"."IDGroup" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Group"."IFGroup__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."TX_Title" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."TX_Description" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."IsTemplate" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Group"."GroupAnswers" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Group"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Group"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Group"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_Question" (
	"IDQuestion" bigserial NOT NULL,
	"IFQuestion__parent" bigint NULL,
	"IFQuestiontype" integer NULL,
	"TX_Question" bigint NULL,
	"TX_Details" bigint NULL,
	"IsRequired" boolean NULL,
	"IsTemplate" boolean NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Question" IS NULL;
	COMMENT ON COLUMN "FRM_Question"."IDQuestion" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Question"."IFQuestion__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."IFQuestiontype" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Question"."TX_Question" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."TX_Details" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."IsRequired" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Question"."IsTemplate" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Question"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Question"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Question"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_Answer" (
	"IDAnswer" bigserial NOT NULL,
	"TX_Answer" bigint NULL,
	"TX_Details" bigint NULL,
	"IsRequired" boolean NULL,
	"IFApplication" integer NULL,
	"IFUser__audit" bigint NOT NULL,
	"Date__audit" timestamp with time zone NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_Answer" IS NULL;
	COMMENT ON COLUMN "FRM_Answer"."IDAnswer" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FRM_Answer"."TX_Answer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Answer"."TX_Details" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Answer"."IsRequired" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FRM_Answer"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_Answer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_Answer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_UserQuestion" (
	"IFUser" bigint NOT NULL,
	"IFQuestion" bigint NOT NULL,
	"Answer" character varying(8000) NULL,
	"IFUser__audit" bigint NULL,
	"Date__audit" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_UserQuestion" IS NULL;
	COMMENT ON COLUMN "FRM_UserQuestion"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserQuestion"."IFQuestion" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserQuestion"."Answer" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FRM_UserQuestion"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserQuestion"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

CREATE TABLE "FRM_GroupAnswer" (
	"IFGroup" bigint NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"Order" integer NULL,
	"IFUser__audit" bigint NULL,
	"Date__audit" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_GroupAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_GroupAnswer"."IFGroup" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."Order" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_GroupAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

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

CREATE TABLE "FRM_UserAnswer" (
	"IFUser" bigint NOT NULL,
	"IFAnswer" bigint NOT NULL,
	"IFUser__audit" bigint NULL,
	"Date__audit" timestamp with time zone NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FRM_UserAnswer" IS NULL;
	COMMENT ON COLUMN "FRM_UserAnswer"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserAnswer"."IFAnswer" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserAnswer"."IFUser__audit" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FRM_UserAnswer"."Date__audit" IS 'psql:timestamp with time zone;sqlserver:datetime;';

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

