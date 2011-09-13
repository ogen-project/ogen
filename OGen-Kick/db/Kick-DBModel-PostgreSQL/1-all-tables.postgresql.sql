CREATE TABLE "APP_Application" (
	"IDApplication" serial NOT NULL,
	"Name" character varying(20) NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "APP_Application" IS NULL;
	COMMENT ON COLUMN "APP_Application"."IDApplication" IS 'psql:serial;sqlserver:int;identity:True;';
	COMMENT ON COLUMN "APP_Application"."Name" IS 'length:20;psql:character varying;sqlserver:varchar;';

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

CREATE TABLE "CRD_ProfilePermition" (
	"IFProfile" bigint NOT NULL,
	"IFPermition" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_ProfilePermition" IS NULL;
	COMMENT ON COLUMN "CRD_ProfilePermition"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "CRD_ProfilePermition"."IFPermition" IS 'psql:bigint;sqlserver:bigint;';

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
	"CharVar8000" character varying(8000) NULL,
	"Text" text NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "DIC_TextLanguage" IS NULL;
	COMMENT ON COLUMN "DIC_TextLanguage"."IFText" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "DIC_TextLanguage"."IFLanguage" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "DIC_TextLanguage"."CharVar8000" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "DIC_TextLanguage"."Text" IS 'psql:text;sqlserver:text;';

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
	"IFUser__Aproved" bigint NULL,
	"Aproved_date" timestamp with time zone NULL,
	"Begin_date" timestamp with time zone NULL,
	"End_date" timestamp with time zone NULL,
	"TX_Title" bigint NULL,
	"TX_Content" bigint NULL,
	"tx_subtitle" bigint NULL,
	"tx_summary" bigint NULL,
	"Newslettersent_date" timestamp with time zone NULL,
	"isNews_notForum" boolean NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NWS_Content" IS NULL;
	COMMENT ON COLUMN "NWS_Content"."IDContent" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NWS_Content"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Publisher" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Publish_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."IFUser__Aproved" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Aproved_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."Begin_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."End_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."TX_Title" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."TX_Content" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."tx_subtitle" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."tx_summary" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NWS_Content"."Newslettersent_date" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "NWS_Content"."isNews_notForum" IS 'psql:boolean;sqlserver:bit;';

CREATE TABLE "FOR_Message" (
	"IDMessage" bigserial NOT NULL,
	"IFMessage__parent" bigint NULL,
	"isSticky" boolean NOT NULL,
	"Subject" character varying(255) NULL,
	"Message__charvar8000" character varying(8000) NULL,
	"Message__text" text NULL,
	"IFUser__Publisher" bigint NULL,
	"Publish_date" timestamp with time zone NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "FOR_Message" IS NULL;
	COMMENT ON COLUMN "FOR_Message"."IDMessage" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "FOR_Message"."IFMessage__parent" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "FOR_Message"."isSticky" IS 'psql:boolean;sqlserver:bit;';
	COMMENT ON COLUMN "FOR_Message"."Subject" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FOR_Message"."Message__charvar8000" IS 'length:8000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "FOR_Message"."Message__text" IS 'psql:text;sqlserver:text;';
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

CREATE TABLE "NET_User" (
	"IFUser" bigint NOT NULL,
	"Name" character varying(255) NULL,
	"EMail" character varying(255) NOT NULL,
	"EMail_verify" character varying(255) NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_User" IS NULL;
	COMMENT ON COLUMN "NET_User"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "NET_User"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_User"."EMail" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_User"."EMail_verify" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "NET_User"."IFApplication" IS 'psql:integer;sqlserver:int;';

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

CREATE TABLE "LOG_Logtype" (
	"IDLogtype" integer NOT NULL,
	"IFLogtype_parent" integer NULL,
	"Name" character varying(20) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Logtype" IS NULL;
	COMMENT ON COLUMN "LOG_Logtype"."IDLogtype" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Logtype"."IFLogtype_parent" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Logtype"."Name" IS 'length:20;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Logtype"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "LOG_Errortype" (
	"IDErrortype" integer NOT NULL,
	"Name" character varying(255) NOT NULL,
	"Description" character varying(2048) NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Errortype" IS NULL;
	COMMENT ON COLUMN "LOG_Errortype"."IDErrortype" IS 'psql:integer;sqlserver:int;identity:False;';
	COMMENT ON COLUMN "LOG_Errortype"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Errortype"."Description" IS 'length:2048;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Errortype"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "LOG_Log" (
	"IDLog" bigserial NOT NULL,
	"IFLogtype" integer NOT NULL,
	"IFUser" bigint NULL,
	"IFUser__read" bigint NULL,
	"IFErrortype" integer NULL,
	"Stamp" timestamp with time zone NOT NULL,
	"Stamp__read" timestamp with time zone NULL,
	"Message" character varying(4000) NOT NULL,
	"IFPermition" bigint NULL,
	"IFApplication" integer NULL,
	"IFBrowser__OPT" bigint NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "LOG_Log" IS NULL;
	COMMENT ON COLUMN "LOG_Log"."IDLog" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "LOG_Log"."IFLogtype" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."IFUser" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFUser__read" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFErrortype" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."Stamp" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "LOG_Log"."Stamp__read" IS 'psql:timestamp with time zone;sqlserver:datetime;';
	COMMENT ON COLUMN "LOG_Log"."Message" IS 'length:4000;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "LOG_Log"."IFPermition" IS 'psql:bigint;sqlserver:bigint;';
	COMMENT ON COLUMN "LOG_Log"."IFApplication" IS 'psql:integer;sqlserver:int;';
	COMMENT ON COLUMN "LOG_Log"."IFBrowser__OPT" IS 'psql:bigint;sqlserver:bigint;';

CREATE TABLE "CRD_Permition" (
	"IDPermition" bigint NOT NULL,
	"Name" character varying(255) NOT NULL,
	"IFApplication" integer NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "CRD_Permition" IS NULL;
	COMMENT ON COLUMN "CRD_Permition"."IDPermition" IS 'psql:bigint;sqlserver:bigint;identity:False;';
	COMMENT ON COLUMN "CRD_Permition"."Name" IS 'length:255;psql:character varying;sqlserver:varchar;';
	COMMENT ON COLUMN "CRD_Permition"."IFApplication" IS 'psql:integer;sqlserver:int;';

CREATE TABLE "NET_Defaultprofile" (
	"IDDefaultprofile" bigserial NOT NULL,
	"IFProfile" bigint NOT NULL
)
WITH (OIDS=FALSE);
COMMENT ON TABLE "NET_Defaultprofile" IS NULL;
	COMMENT ON COLUMN "NET_Defaultprofile"."IDDefaultprofile" IS 'psql:bigserial;sqlserver:bigint;identity:True;';
	COMMENT ON COLUMN "NET_Defaultprofile"."IFProfile" IS 'psql:bigint;sqlserver:bigint;';

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

