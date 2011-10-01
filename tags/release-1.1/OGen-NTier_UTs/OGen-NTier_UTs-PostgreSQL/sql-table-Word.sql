
-- Sequence: "Word_IDWord_seq"

-- DROP SEQUENCE "Word_IDWord_seq";

CREATE SEQUENCE "Word_IDWord_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Word_IDWord_seq" OWNER TO postgres;


-- Table: "Word"

-- DROP TABLE "Word";

CREATE TABLE "Word"
(
  "IDWord" bigint NOT NULL DEFAULT nextval('"Word_IDWord_seq"'::regclass),
  "DeleteThisTestField" boolean,
  CONSTRAINT "Word_pkey" PRIMARY KEY ("IDWord")
) 
WITHOUT OIDS;
ALTER TABLE "Word" OWNER TO postgres;
