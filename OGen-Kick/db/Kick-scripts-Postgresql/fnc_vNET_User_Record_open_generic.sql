CREATE OR REPLACE FUNCTION "fnc_vNET_User_Record_open_generic"(
	"Login_search_" character varying, 
	"Name_search_" character varying, 
	"EMail_search_" character varying, 
	"IFApplication_search_" integer, 
	"IDProfile__in_search_" bigint, 
	"IDProfile__out_search_" bigint
)
	RETURNS SETOF "v0_vNET_User__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNET_User__onlyKeys";
	BEGIN
		FOR _Output IN

			SELECT
				"IDUser"
			FROM "vNET_User"
			WHERE
				(
					("Name_search_" is null)
					or
					("Name_search_" = '')

					--("Name" LIKE '%' || "Name_search_" || '%')
					or
					(
						select "OGen_fnc0__Like"(
							"Name", 			
							"Name_search_"
						)
					) = true
				)
				AND
				(
					("Login_search_" is null)
					or
					("Login_search_" = '')
					or
					("Login" LIKE '%' || "Login_search_" || '%')
				)
				AND
				(
					("EMail_search_" is null)
					or
					("EMail_search_" = '')
					or
					("EMail" LIKE '%' || "EMail_search_" || '%')
				)
				AND
				(
					("IFApplication_search_" is null)
					or
					("IFApplication_search_" <= 0)
					or
					("IFApplication_search_" = "IFApplication")
				) 
				AND
				(
					("IDProfile__in_search_" is null)
					or
					("IDProfile__in_search_" <= 0)
					or
					exists (
						select null
						from "CRD_UserProfile"
						where 
							("CRD_UserProfile"."IFUser" = "vNET_User"."IDUser")
							and
							("CRD_UserProfile"."IFProfile" = "IDProfile__in_search_")
					)
				)
				AND
				(
					("IDProfile__out_search_" is null)
					or
					("IDProfile__out_search_" <= 0)
					or
					not exists (
						select null
						from "CRD_UserProfile"
						where 
							("CRD_UserProfile"."IFUser" = "vNET_User"."IDUser")
							and
							("CRD_UserProfile"."IFProfile" = "IDProfile__out_search_")
					)
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


select *
from "fnc_vNET_User_Record_open_generic"(
	'f', -- @Login_search_ varchar (255), 
	'onteiro rancisco', -- @Name_search_ varchar (255), 
	'rancisco', --@EMail_search_ varchar (255), 
	1, -- @IFApplication_search_ int, 
	1, -- @IDProfile__in_search_ bigint, 
	2 -- @IDProfile__out_search_ bigint
)