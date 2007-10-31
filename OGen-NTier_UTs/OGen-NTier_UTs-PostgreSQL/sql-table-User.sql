
-- Sequence: "User_IDUser_seq"

-- DROP SEQUENCE "User_IDUser_seq";

CREATE SEQUENCE "User_IDUser_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "User_IDUser_seq" OWNER TO postgres;


-- Table: "User"

-- DROP TABLE "User";

CREATE TABLE "User"
(
  "IDUser" bigint NOT NULL DEFAULT nextval('"User_IDUser_seq"'::regclass),
  "Login" character varying(50) NOT NULL,
  "Password" character varying(50) NOT NULL,
  "SomeNullValue" integer,
  CONSTRAINT "User_pkey" PRIMARY KEY ("IDUser"),
  CONSTRAINT "User_Login_key" UNIQUE ("Login")
) 
WITHOUT OIDS;
ALTER TABLE "User" OWNER TO postgres;
