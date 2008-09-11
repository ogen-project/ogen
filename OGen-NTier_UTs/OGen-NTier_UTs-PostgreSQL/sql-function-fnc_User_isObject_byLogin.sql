
-- View: ""v0_User__onlyKeys""

-- DROP VIEW "v0_User__onlyKeys";

CREATE OR REPLACE VIEW "v0_User__onlyKeys" AS 
	SELECT
		"User"."IDUser"
	FROM "User";

ALTER TABLE "v0_User__onlyKeys" OWNER TO postgres;


-- Function: "fnc_User_isObject_byLogin"("Login_search_" "varchar")

-- DROP FUNCTION "fnc_User_isObject_byLogin"("Login_search_" "varchar");

CREATE OR REPLACE FUNCTION "fnc_User_isObject_byLogin"("Login_search_" "varchar")
  RETURNS SETOF "v0_User__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDUser"
			FROM "User"
			WHERE
				--("Login" LIKE '%' || "Login_search_" || '%')
				("Login" = "Login_search_")
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
  LANGUAGE 'plpgsql' STABLE;
ALTER FUNCTION "fnc_User_isObject_byLogin"("Login_search_" "varchar") OWNER TO postgres;
