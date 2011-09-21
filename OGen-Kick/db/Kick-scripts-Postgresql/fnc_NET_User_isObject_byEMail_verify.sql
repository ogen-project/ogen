--drop function "fnc_NET_User_isObject_byEMail_verify"(
--	"EMail_verify_search_" character varying, 
--	"IDApplication_search_" int
--)

CREATE OR REPLACE FUNCTION "fnc_NET_User_isObject_byEMail_verify"(
	"EMail_verify_search_" character varying, 
	"IDApplication_search_" int
)
	RETURNS SETOF "v0_NET_User__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_NET_User__onlyKeys";
	BEGIN
		FOR _Output IN
			select
				"IFUser"
			from "NET_User"
			where
				("EMail_verify" = "EMail_verify_search_") 
				and
				(
					("IDApplication_search_" is null)
					or
					("IDApplication_search_" = "IFApplication")
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

select 
	*
from "fnc_NET_User_isObject_byEMail_verify"(
	'frm@fct.unl.pt', 
	1
);