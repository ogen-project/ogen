
-- Sequence: "Language_IDLanguage_seq"

-- DROP SEQUENCE "Language_IDLanguage_seq";

CREATE SEQUENCE "Language_IDLanguage_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Language_IDLanguage_seq" OWNER TO postgres;


-- Table: "Language"

-- DROP TABLE "Language";

CREATE TABLE "Language"
(
  "IDLanguage" bigint NOT NULL DEFAULT nextval('"Language_IDLanguage_seq"'::regclass),
  "IDWord_name" bigint NOT NULL,
  CONSTRAINT "Language_pkey" PRIMARY KEY ("IDLanguage"), 
  CONSTRAINT "Language_IDWord_name_fkey" FOREIGN KEY ("IDWord_name")
      REFERENCES "Word" ("IDWord") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
) 
WITHOUT OIDS;
ALTER TABLE "Language" OWNER TO postgres;
