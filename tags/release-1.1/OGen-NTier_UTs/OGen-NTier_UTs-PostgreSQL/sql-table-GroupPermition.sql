
-- Table: "GroupPermition"

-- DROP TABLE "GroupPermition";

CREATE TABLE "GroupPermition"
(
  "IDGroup" bigint NOT NULL,
  "IDPermition" bigint NOT NULL,
  CONSTRAINT "GroupPermition_pkey" PRIMARY KEY ("IDGroup", "IDPermition"),
  CONSTRAINT "GroupPermition_IDGroup_fkey" FOREIGN KEY ("IDGroup")
      REFERENCES "Group" ("IDGroup") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT "GroupPermition_IDPermition_fkey" FOREIGN KEY ("IDPermition")
      REFERENCES "Permition" ("IDPermition") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
) 
WITHOUT OIDS;
ALTER TABLE "GroupPermition" OWNER TO postgres;
