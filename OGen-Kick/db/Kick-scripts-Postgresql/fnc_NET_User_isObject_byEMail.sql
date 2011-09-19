CREATE OR REPLACE FUNCTION "fnc_NET_User_isObject_byEMail"("EMail_search_" character varying, "IDApplication_search_" integer)
	RETURNS SETOF "v0_NET_User__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_NET_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IFUser"
			FROM "NET_User"
			WHERE
				("NET_User"."EMail" = "EMail_search_") 
				AND
				(
					("IDApplication_search_" is null)
					or
					("IDApplication_search_" = "NET_User"."IFApplication")
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
