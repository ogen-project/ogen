
-- Sequence: "Log_IDLog_seq"

-- DROP SEQUENCE "Log_IDLog_seq";

CREATE SEQUENCE "Log_IDLog_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Log_IDLog_seq" OWNER TO postgres;


-- Table: "Log"

-- DROP TABLE "Log";

CREATE TABLE "Log"
(
  "IDLog" bigint NOT NULL DEFAULT nextval('"Log_IDLog_seq"'::regclass),
  "IDLogcode" bigint NOT NULL,
  "IDUser_posted" bigint NOT NULL,
  "Date_posted" timestamp without time zone NOT NULL,
  "Logdata" character varying(1024) NOT NULL,
  CONSTRAINT "Log_pkey" PRIMARY KEY ("IDLog"),
  CONSTRAINT "Log_IDLogcode_fkey" FOREIGN KEY ("IDLogcode")
      REFERENCES "Logcode" ("IDLogcode") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT "Log_IDUser_posted_fkey" FOREIGN KEY ("IDUser_posted")
      REFERENCES "User" ("IDUser") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
) 
WITHOUT OIDS;
ALTER TABLE "Log" OWNER TO postgres;
