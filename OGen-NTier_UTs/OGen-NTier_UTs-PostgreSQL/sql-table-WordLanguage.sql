
-- Table: "WordLanguage"

-- DROP TABLE "WordLanguage";

CREATE TABLE "WordLanguage"
(
  "IDWord" bigint NOT NULL,
  "IDLanguage" bigint NOT NULL,
  "Translation" character varying(2048),
  CONSTRAINT "WordLanguage_pkey" PRIMARY KEY ("IDWord", "IDLanguage"),
  CONSTRAINT "WordLanguage_IDLanguage_fkey" FOREIGN KEY ("IDLanguage")
      REFERENCES "Language" ("IDLanguage") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT "WordLanguage_IDWord_fkey" FOREIGN KEY ("IDWord")
      REFERENCES "Word" ("IDWord") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
) 
WITHOUT OIDS;
ALTER TABLE "WordLanguage" OWNER TO postgres;
