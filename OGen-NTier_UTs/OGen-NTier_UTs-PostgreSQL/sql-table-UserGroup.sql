
-- Table: "UserGroup"

-- DROP TABLE "UserGroup";

CREATE TABLE "UserGroup"
(
  "IDUser" bigint NOT NULL,
  "IDGroup" bigint NOT NULL,
  "Relationdate" timestamp without time zone,
  "Defaultrelation" boolean,
  CONSTRAINT "UserGroup_pkey" PRIMARY KEY ("IDUser", "IDGroup"), 
  CONSTRAINT "UserGroup_IDGroup_fkey" FOREIGN KEY ("IDGroup")
      REFERENCES "Group" ("IDGroup") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT "UserGroup_IDUser_fkey" FOREIGN KEY ("IDUser")
      REFERENCES "User" ("IDUser") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
) 
WITHOUT OIDS;
ALTER TABLE "UserGroup" OWNER TO postgres;
