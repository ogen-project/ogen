
-- Sequence: "Logcode_IDLogcode_seq"

-- DROP SEQUENCE "Logcode_IDLogcode_seq";

CREATE SEQUENCE "Logcode_IDLogcode_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Logcode_IDLogcode_seq" OWNER TO postgres;


-- Table: "Logcode"

-- DROP TABLE "Logcode";

CREATE TABLE "Logcode"
(
  "IDLogcode" bigint NOT NULL DEFAULT nextval('"Logcode_IDLogcode_seq"'::regclass),
  "Warning" boolean NOT NULL,
  "Error" boolean NOT NULL,
  "Code" character varying(50) NOT NULL,
  "Description" character varying(255),
  CONSTRAINT "Logcode_pkey" PRIMARY KEY ("IDLogcode")
) 
WITHOUT OIDS;
ALTER TABLE "Logcode" OWNER TO postgres;
