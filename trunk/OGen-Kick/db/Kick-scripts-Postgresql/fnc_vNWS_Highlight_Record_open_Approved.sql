CREATE OR REPLACE FUNCTION "fnc_vNWS_Highlight_Record_open_Approved"("IDApplication_search_" integer)
  RETURNS SETOF "v0_vNWS_Highlight__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNWS_Highlight__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDHighlight"
			FROM "vNWS_Highlight"
			WHERE
				(
					("IDApplication_search_" IS NULL)
					OR
					("IDApplication_search_" <= 0)
					OR
					("IFApplication" = "IDApplication_search_")
				)
				and
				(not "IFUser__Approved" is null)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
  LANGUAGE 'plpgsql' STABLE
  COST 100
  ROWS 1000;
ALTER FUNCTION "fnc_vNWS_Highlight_Record_open_Approved"(integer) OWNER TO postgres;
