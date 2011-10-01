
-- Table: "Config"

-- DROP TABLE "Config";

CREATE TABLE "Config"
(
  "Name" character varying(50) NOT NULL,
  "Config" character varying(50) NOT NULL,
  "Type" integer NOT NULL,
  "Description" character varying(50) NOT NULL,
  CONSTRAINT "Config_pkey" PRIMARY KEY ("Name")
) 
WITHOUT OIDS;
ALTER TABLE "Config" OWNER TO postgres;




insert into "Config" ("Name", "Config", "Type", "Description") values ('SomeBoolConfig', 'False', 1, 'some bool config');
insert into "Config" ("Name", "Config", "Type", "Description") values ('SomeIntConfig', '1245', 4, 'some int config');
insert into "Config" ("Name", "Config", "Type", "Description") values ('SomeMultiLineStringConfig', 'line 1\r\nline 2', 3, 'some multi-line string config');
insert into "Config" ("Name", "Config", "Type", "Description") values ('SomeStringConfig', 'whatever', 2, 'some string config');
