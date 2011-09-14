-- drop view "vNWS_Content";
create or replace view "vNWS_Content"
as
	select
		"NWS_Content"."IDContent", 
		"DIC_Language"."IDLanguage", 

--		"NWS_Content"."IFContenttype", 

		"NWS_Content"."IFUser__Publisher", 
		"NET_User"."Name" as "PublisherName", 
		"NWS_Content"."Publish_date", 
		"NWS_Content"."IFUser__Aproved", 
		"NWS_Content"."Aproved_date", 


		case 
			when not _tx_title."CharVar8000" is null 
				then _tx_title."CharVar8000"
			when not _tx_title."Text" is null 
				then _tx_title."Text"
			else ''
		end as "Title", 
		case 
			when not _tx_content."CharVar8000" is null 
				then _tx_content."CharVar8000"
			when not _tx_content."Text" is null 
				then _tx_content."Text"
			else ''
		end as "Content", 
		case 
			when not _tx_subtitle."CharVar8000" is null 
				then _tx_subtitle."CharVar8000"
			when not _tx_subtitle."Text" is null 
				then _tx_subtitle."Text"
			else ''
		end as "subtitle", 
		case 
			when not _tx_summary."CharVar8000" is null 
				then _tx_summary."CharVar8000"
			when not _tx_summary."Text" is null 
				then _tx_summary."Text"
			else ''
		end as "summary"

	from "NWS_Content"



	left join "DIC_LanguageApplication" on (
		(not "NWS_Content"."IFApplication" is null)
		and
		("DIC_LanguageApplication"."IFApplication" = "NWS_Content"."IFApplication")
	)
	left join "DIC_Language" on (
		("NWS_Content"."IFApplication" is null)
		or
		("DIC_LanguageApplication"."IFLanguage" = "DIC_Language"."IDLanguage")
	)




	inner join "NET_User" on (
		"NET_User"."IFUser" = "NWS_Content"."IFUser__Publisher"
	)

	left join "DIC_TextLanguage" as _tx_title on (
		("DIC_Language"."IDLanguage" = _tx_title."IFLanguage")
		and
		("NWS_Content"."TX_Title" = _tx_title."IFText")
	)
	left join "DIC_TextLanguage" as _tx_content on (
		("DIC_Language"."IDLanguage" = _tx_content."IFLanguage")
		and
		("NWS_Content"."TX_Content" = _tx_content."IFText")
	)
	left join "DIC_TextLanguage" as _tx_subtitle on (
		("DIC_Language"."IDLanguage" = _tx_subtitle."IFLanguage")
		and
		("NWS_Content"."tx_subtitle" = _tx_subtitle."IFText")
	)
	left join "DIC_TextLanguage" as _tx_summary on (
		("DIC_Language"."IDLanguage" = _tx_summary."IFLanguage")
		and
		("NWS_Content"."tx_summary" = _tx_summary."IFText")
	)
;

select *
from "vNWS_Content"
/*
where "IDLanguage" in (
	1,
	2
)
*/
;
