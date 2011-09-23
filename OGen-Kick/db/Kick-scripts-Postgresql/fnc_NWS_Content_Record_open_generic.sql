CREATE OR REPLACE FUNCTION "fnc_NWS_Content_Record_open_generic"(
	"IFApplication_search_" integer, 
	"IFUser__Publisher_search_" bigint, 
	"IFUser__Aproved_search_" bigint, 
	"Begin_date_search_" timestamp with time zone, 
	"End_date_search_" timestamp with time zone, 
	"IDTag_search_" character varying, 
	"IDAuthor_search_" character varying, 
	"IDSource_search_" character varying, 
	"IDHighlight_search_" character varying, 
	"IDProfile_search_" character varying, 
	"Keywords_search_" character varying, 
	"IDLanguage_" integer, 
	"isAND_notOR_" boolean
)
	RETURNS SETOF "v0_NWS_Content__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_NWS_Content__onlyKeys";

		_conditional_join_DIC_TextLanguage boolean = not (
			("Keywords_search_" is null)
			or
			("Keywords_search_" = '')
		);

		_tagCount integer = 0;
		_conditional_join_NWS_ContentTag boolean = not (
			("IDTag_search_" is null)
			or
			("IDTag_search_" = '')
		);

		_profileCount integer = 0;
		_conditional_join_NWS_ContentProfile boolean = not (
			("IDProfile_search_" is null)
			or
			("IDProfile_search_" = '')
		);
	BEGIN
		if (_conditional_join_NWS_ContentTag) then
			select into _tagCount count("OGen_fnc0__Split")
			from "OGen_fnc0__Split" (string_to_array(
				"IDTag_search_", 
				','
			));
		end if;
		if (_conditional_join_NWS_ContentProfile) then
			select into _profileCount count("OGen_fnc0__Split")
			from "OGen_fnc0__Split" (string_to_array(
				"IDProfile_search_", 
				','
			));
		end if;

		FOR _Output IN
			SELECT
				distinct "IDContent"
			FROM "NWS_Content"
			left join "DIC_TextLanguage" on (
				_conditional_join_DIC_TextLanguage
				and
				("DIC_TextLanguage"."IFLanguage" = "IDLanguage_")
				and
				("DIC_TextLanguage"."IFText" in (
					"NWS_Content"."TX_Title", 
					"NWS_Content"."TX_Content", 
					"NWS_Content"."tx_subtitle"
				))
			)
			WHERE
				("NWS_Content"."isNews_notForum")
				and
				(
					("IFApplication_search_" is null)
					or
					("IFApplication_search_" = "NWS_Content"."IFApplication")
				) 
				and
				(
					("IFUser__Publisher_search_" is null)
					or
					("IFUser__Publisher_search_" <= 0)
					or
					("IFUser__Publisher_search_" = "NWS_Content"."IFUser__Publisher")
				) 
				and
				(
					("IFUser__Aproved_search_" <= 0)
					or 
					(
						("IFUser__Aproved_search_" is null)
						and
						("NWS_Content"."IFUser__Aproved" is null)
					) 
					or
					(
						not ("IFUser__Aproved_search_" is null)
						and
						("NWS_Content"."IFUser__Aproved" = "IFUser__Aproved_search_")
					)
				) 
				and
				(
					("Begin_date_search_" is null)
					OR
					("End_date_search_" is null)
					OR
					("NWS_Content"."Begin_date" between "Begin_date_search_" and "End_date_search_")
				)
				and
				(
					(not _conditional_join_DIC_TextLanguage)
					or
					(
						select "OGen_fnc0__Like"(
							(
								case 
									when (not "DIC_TextLanguage"."CharVar8000" is null) 
										then "DIC_TextLanguage"."CharVar8000"
									when (not "DIC_TextLanguage"."Text" is null) 
										then "DIC_TextLanguage"."Text"
									else
										''
								end
							), 			
							"Keywords_search_"
						)
					) = true
				)
				and
				(
					(not _conditional_join_NWS_ContentTag)
					or
					(
						(
							select count("NWS_ContentTag"."IFTag")
							from "NWS_ContentTag"
							where 
								("NWS_ContentTag"."IFContent" = "NWS_Content"."IDContent")
								and
								("NWS_ContentTag"."IFTag" in (
									select cast("OGen_fnc0__Split" as bigint)
									from "OGen_fnc0__Split" (string_to_array(
										"IDTag_search_", 
										','
									))
								))
						) = _tagCount
					)
				) 
				and
				(
					(not _conditional_join_NWS_ContentProfile)
					or
					(
						(
							select count("NWS_ContentProfile"."IFProfile")
							from "NWS_ContentProfile"
							where 
								("NWS_ContentProfile"."IFContent" = "NWS_Content"."IDContent")
								and
								("NWS_ContentProfile"."IFProfile" in (
									select cast("OGen_fnc0__Split" as bigint)
									from "OGen_fnc0__Split" (string_to_array(
										"IDProfile_search_", 
										','
									))
								))
						) = _profileCount
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
from "NWS_Content"
where
	("IDContent" in (
		select "IDContent"
		from "fnc_NWS_Content_Record_open_generic"(
			null,		-- "IFApplication_search_" integer, 
			null,		-- "IFUser__Publisher_search_" bigint, 
			null,		-- "IFUser__Aproved_search_" bigint, 
			null,		-- "Begin_date_search_" timestamp with time zone, 
			null,		-- "End_date_search_" timestamp with time zone, 

			'12,34',	-- "IDTag_search_" text, 
			null,		-- "IDAuthor_search_" character varying, 
			null,		-- "IDSource_search_" character varying, 
			null,		-- "IDHighlight_search_" character varying, 
			'12,34',	-- "IDProfile_search_" text, 
			null,		-- "Keywords_search_" character varying, 

			null,		-- "IDLanguage_" integer, 
			true		-- "isAND_notOR_" boolean
		)
	))
;
