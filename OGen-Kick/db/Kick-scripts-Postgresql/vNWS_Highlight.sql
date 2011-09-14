create or replace view "vNWS_Highlight"
as
	select 
		"NWS_Highlight"."IDHighlight", 
		"NWS_Highlight"."IFHighlight__parent", 
		"NWS_Highlight"."IFUser__Approved", 
		"NWS_Highlight"."Approved_date", 
		"fnc_NWS_Highlight__fullname"(
			"NWS_Highlight"."IDHighlight"
		) as "Name", 
		"NWS_Highlight"."IFApplication", 
		"NET_User"."Name" as "ManagerName"
	from "NWS_Highlight"
	left join "NET_User" on (
		"NWS_Highlight"."IFUser__Approved" = "NET_User"."IFUser"
	)
;

select *
from "vNWS_Highlight"
order by "Name";