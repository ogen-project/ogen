create or replace view "vNWS_Source"
as
	select 
		"NWS_Source"."IDSource", 
		"NWS_Source"."IFSource__parent", 
		"NWS_Source"."IFUser__Approved", 
		"NWS_Source"."Approved_date", 
		"fnc_NWS_Source__fullname"(
			"NWS_Source"."IDSource"
		) as "Name", 
		"NWS_Source"."IFApplication", 
		"NET_User"."Name" as "ManagerName"
	from "NWS_Source"
	left join "NET_User" on (
		"NET_User"."IFUser" = "NWS_Source"."IFUser__Approved"
	)
;

select *
from "vNWS_Source"
order by "Name";