/* drop view "vNWS_Source"
go

create */
alter view "dbo"."vNWS_Source"
as
	select 
		"NWS_Source"."IDSource", 
		"NWS_Source"."IFSource__parent", 
		"NWS_Source"."IFUser__Approved", 
		"NWS_Source"."Approved_date", 
		"dbo"."fnc_NWS_Source__fullname"(
			"NWS_Source"."IDSource"
		) as "Name", 
		"NWS_Source"."IFApplication", 
		"NWS_User"."Name" as "ManagerName"
	from "NWS_Source"
	left join "NWS_User" on (
		"NWS_User"."IFUser" = "NWS_Source"."IFUser__Approved"
	)
go

select *
from "vNWS_Source"
order by "Name"