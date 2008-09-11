
-- View: ""v0_vUserGroup__onlyKeys""

-- DROP VIEW "v0_vUserGroup__onlyKeys";

CREATE OR REPLACE VIEW "v0_vUserGroup__onlyKeys" AS 
	SELECT
		"vUserGroup"."IDUser",
		"vUserGroup"."IDGroup"
	FROM "vUserGroup";

ALTER TABLE "v0_vUserGroup__onlyKeys" OWNER TO postgres;


-- Function: "fnc_UserGroup_Record_open_byUser_Defaultrelation"("IDUser_search_" bigint, "Relationdate_search_" timestamp without time zone)

-- DROP FUNCTION "fnc_UserGroup_Record_open_byUser_Defaultrelation"("IDUser_search_" bigint, "Relationdate_search_" timestamp without time zone);

CREATE OR REPLACE FUNCTION "fnc_UserGroup_Record_open_byUser_Defaultrelation"("IDUser_search_" bigint, "Relationdate_search_" timestamp without time zone)
  RETURNS SETOF "v0_UserGroup__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_UserGroup__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDUser",
				"IDGroup"
			FROM "UserGroup"
			WHERE
				((
					("IDUser_search_" IS NULL)
					AND
					("IDUser" IS NULL)
				) OR (
					NOT ("IDUser_search_" IS NULL)
					AND
					("IDUser" = "IDUser_search_")
				)) AND
				((
					("Relationdate_search_" IS NULL)
					AND
					("Relationdate" IS NULL)
				) OR (
					NOT ("Relationdate_search_" IS NULL)
					AND
					("Relationdate" = "Relationdate_search_")
				))
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
  LANGUAGE 'plpgsql' STABLE;
ALTER FUNCTION "fnc_UserGroup_Record_open_byUser_Defaultrelation"("IDUser_search_" bigint, "Relationdate_search_" timestamp without time zone) OWNER TO postgres;
