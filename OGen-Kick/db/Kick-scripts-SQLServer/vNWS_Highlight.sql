/* drop view "vNWS_Highlight"
go

create */
alter view "dbo"."vNWS_Highlight"
as
	select 
		"NWS_Highlight"."IDHighlight", 
		"NWS_Highlight"."IFHighlight__parent", 
		"NWS_Highlight"."IFUser__Approved", 
		"NWS_Highlight"."Approved_date", 
		"dbo"."fnc_NWS_Highlight__fullname"(
			"NWS_Highlight"."IDHighlight"
		) as "Name", 
		"NWS_Highlight"."IFApplication", 
		"NWS_User"."Name" as "ManagerName"
	from "NWS_Highlight"
	left join "NWS_User" on (
		"NWS_Highlight"."IFUser__Approved" = "NWS_User"."IFUser"
	)
go

select *
from "vNWS_Highlight"
order by "Name"