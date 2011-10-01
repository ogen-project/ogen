
-- Sequence: "Group_IDGroup_seq"

-- DROP SEQUENCE "Group_IDGroup_seq";

CREATE SEQUENCE "Group_IDGroup_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Group_IDGroup_seq" OWNER TO postgres;


-- Table: "Group"

-- DROP TABLE "Group";

CREATE TABLE "Group"
(
  "IDGroup" bigint NOT NULL DEFAULT nextval('"Group_IDGroup_seq"'::regclass),
  "Name" character varying(50) NOT NULL,
  CONSTRAINT "Group_pkey" PRIMARY KEY ("IDGroup"),
  CONSTRAINT "Group_Name_key" UNIQUE ("Name")
) 
WITHOUT OIDS;
ALTER TABLE "Group" OWNER TO postgres;
