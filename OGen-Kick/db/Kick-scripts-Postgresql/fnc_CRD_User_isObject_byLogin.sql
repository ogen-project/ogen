CREATE OR REPLACE FUNCTION "fnc_CRD_User_isObject_byLogin"("Login_search_" character varying, "IFApplication_search_" integer)
	RETURNS SETOF "v0_CRD_User__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_CRD_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDUser"
			FROM "CRD_User"
			WHERE
				("Login" = "Login_search_")
				AND
				(
					("IFApplication_search_" is null)
					or
					("IFApplication_search_" <= 0)
					or
					("IFApplication" = "IFApplication_search_")
				)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100
	ROWS 1000;
