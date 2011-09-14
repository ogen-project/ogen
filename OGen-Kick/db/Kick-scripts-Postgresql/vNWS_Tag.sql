create or replace view "vNWS_Tag"
as
	select 
		"NWS_Tag"."IDTag", 
		"DIC_Language"."IDLanguage", 
		"NWS_Tag"."IFTag__parent", 
		"NWS_Tag"."IFUser__Approved", 
		"NWS_Tag"."Approved_date", 
		"fnc_NWS_Tag__fullname"(
			"NWS_Tag"."IDTag", 
			"DIC_Language"."IDLanguage"
		) as "Name", 
		"NWS_Tag"."IFApplication", 
		"NET_User"."Name" as "ManagerName", 

		case 
			when not _tx_name."CharVar8000" is null 
				then _tx_name."CharVar8000"
			when not _tx_name."Text" is null 
				then _tx_name."Text"
			else ''
		end as "ShortName"

	from "NWS_Tag"
	left join "DIC_Language" on (1 = 1)
	left join "DIC_TextLanguage" as _tx_name on (
		("DIC_Language"."IDLanguage" = _tx_name."IFLanguage")
		and
		("NWS_Tag"."TX_Name" = _tx_name."IFText")
	)
	left join "NET_User" on (
		"NET_User"."IFUser" = "NWS_Tag"."IFUser__Approved"
	)
;

select *
from "vNWS_Tag"
order by "IDLanguage", "Name";