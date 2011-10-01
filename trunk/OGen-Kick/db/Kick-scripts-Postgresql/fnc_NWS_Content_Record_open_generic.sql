CREATE OR REPLACE FUNCTION "fnc_NWS_Content_Record_open_generic"(
	"IFApplication_search_" integer, 
	"IFUser__Publisher_search_" bigint, 

	"IFUser__Aproved_search_" bigint, ----------------------- = 0  - Approved
	--------------------------------------------------------- = -1 - Not Approved
	--------------------------------------------------------- < -1 - ignore

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

		_authorCount integer = 0;
		_conditional_join_NWS_ContentAuthor boolean = not (
			("IDAuthor_search_" is null)
			or
			("IDAuthor_search_" = '')
		);

		_sourceCount integer = 0;
		_conditional_join_NWS_ContentSource boolean = not (
			("IDSource_search_" is null)
			or
			("IDSource_search_" = '')
		);

		_highlightCount integer = 0;
		_conditional_join_NWS_ContentHighlight boolean = not (
			("IDHighlight_search_" is null)
			or
			("IDHighlight_search_" = '')
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
		if (_conditional_join_NWS_ContentAuthor) then
			select into _authorCount count("OGen_fnc0__Split")
			from "OGen_fnc0__Split" (string_to_array(
				"IDAuthor_search_", 
				','
			));
		end if;
		if (_conditional_join_NWS_ContentSource) then
			select into _sourceCount count("OGen_fnc0__Split")
			from "OGen_fnc0__Split" (string_to_array(
				"IDSource_search_", 
				','
			));
		end if;
		if (_conditional_join_NWS_ContentHighlight) then
			select into _highlightCount count("OGen_fnc0__Split")
			from "OGen_fnc0__Split" (string_to_array(
				"IDHighlight_search_", 
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
					("IFUser__Aproved_search_" < -1) -- < -1 !!! have in consideration argument comments
					or 
					(
						(
							("IFUser__Aproved_search_" is null)
							or
							("IFUser__Aproved_search_" = -1)
						)
						and
						("NWS_Content"."IFUser__Aproved" is null)
					) 
					or
					(
						("IFUser__Aproved_search_" = 0)
						and
						(not "NWS_Content"."IFUser__Aproved" is null)
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
					(not _conditional_join_NWS_ContentAuthor)
					or
					(
						(
							select count("NWS_ContentAuthor"."IFAuthor")
							from "NWS_ContentAuthor"
							where 
								("NWS_ContentAuthor"."IFContent" = "NWS_Content"."IDContent")
								and
								("NWS_ContentAuthor"."IFAuthor" in (
									select cast("OGen_fnc0__Split" as bigint)
									from "OGen_fnc0__Split" (string_to_array(
										"IDAuthor_search_", 
										','
									))
								))
						) = _authorCount
					)
				) 
				and
				(
					(not _conditional_join_NWS_ContentSource)
					or
					(
						(
							select count("NWS_ContentSource"."IFSource")
							from "NWS_ContentSource"
							where 
								("NWS_ContentSource"."IFContent" = "NWS_Content"."IDContent")
								and
								("NWS_ContentSource"."IFSource" in (
									select cast("OGen_fnc0__Split" as bigint)
									from "OGen_fnc0__Split" (string_to_array(
										"IDSource_search_", 
										','
									))
								))
						) = _sourceCount
					)
				) 
				and
				(
					(not _conditional_join_NWS_ContentHighlight)
					or
					(
						(
							select count("NWS_ContentHighlight"."IFHighlight")
							from "NWS_ContentHighlight"
							where 
								("NWS_ContentHighlight"."IFContent" = "NWS_Content"."IDContent")
								and
								("NWS_ContentHighlight"."IFHighlight" in (
									select cast("OGen_fnc0__Split" as bigint)
									from "OGen_fnc0__Split" (string_to_array(
										"IDHighlight_search_", 
										','
									))
								))
						) = _highlightCount
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
