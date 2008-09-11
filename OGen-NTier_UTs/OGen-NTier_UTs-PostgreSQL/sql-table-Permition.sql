
-- Sequence: "Permition_IDPermition_seq"

-- DROP SEQUENCE "Permition_IDPermition_seq";

CREATE SEQUENCE "Permition_IDPermition_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Permition_IDPermition_seq" OWNER TO postgres;


-- Table: "Permition"

-- DROP TABLE "Permition";

CREATE TABLE "Permition"
(
  "IDPermition" bigint NOT NULL DEFAULT nextval('"Permition_IDPermition_seq"'::regclass),
  "Name" character varying(50) NOT NULL,
  CONSTRAINT "Permition_pkey" PRIMARY KEY ("IDPermition")
) 
WITHOUT OIDS;
ALTER TABLE "Permition" OWNER TO postgres;
