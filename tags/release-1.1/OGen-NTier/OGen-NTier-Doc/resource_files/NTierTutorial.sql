CREATE SEQUENCE "User_IDUser_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;

CREATE TABLE "User" (
  "IDUser" int8 NOT NULL DEFAULT nextval('public."User_IDUser_seq"'::text),
  "Login" varchar(50) NOT NULL,
  "Password" varchar(50) NOT NULL,
  CONSTRAINT "User_pkey" PRIMARY KEY ("IDUser")
) WITHOUT OIDS;

CREATE SEQUENCE "Group_IDGroup_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;

CREATE TABLE "Group" (
  "IDGroup" int8 NOT NULL DEFAULT nextval('public."Group_IDGroup_seq"'::text),
  "Name" varchar(50) NOT NULL,
  CONSTRAINT "Group_pkey" PRIMARY KEY ("IDGroup")
) WITHOUT OIDS;

CREATE TABLE "UserGroup" (
  "IDUser" int8 NOT NULL,
  "IDGroup" int8 NOT NULL,
  "Relationdate" timestamp NOT NULL,
  "Defaultrelation" bool NOT NULL,
  CONSTRAINT "UserGroup_pkey" PRIMARY KEY ("IDUser", "IDGroup")
) WITHOUT OIDS;

CREATE TABLE "Config" (
  "Name" varchar(50) NOT NULL,
  "Config" varchar(50) NOT NULL,
  "Type" int4 NOT NULL,
  CONSTRAINT "Config_pkey" PRIMARY KEY ("Name")
) WITHOUT OIDS;
