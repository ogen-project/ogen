create or replace view "vNWS_Author"
as
	select
		"IDAuthor", 
		"NWS_Author"."IFApplication" as "IDApplication", 
		"NWS_Author"."Name", 
		"NWS_Author"."IFUser__Approved", 
		"NET_User"."Name" as "ManagerName", 
		"NWS_Author"."Approved_date"
	from "NWS_Author"
	left join "NET_User" on (
		"NWS_Author"."IFUser__Approved" = "NET_User"."IFUser"
	)
;

select *
from "vNWS_Author"
;