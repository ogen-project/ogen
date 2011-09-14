CREATE OR REPLACE FUNCTION "fnc_vNWS_Profile_Record_open_all"("IDApplication_search_" integer)
	RETURNS SETOF "v0_vNWS_Profile__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNWS_Profile__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDProfile"
			FROM "vNWS_Profile"
			WHERE
				("IDApplication_search_" is null)
				or
				("IDApplication_search_" <= 0)
				or
				("IDApplication_search_" = "IDApplication")
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100
	ROWS 1000;
