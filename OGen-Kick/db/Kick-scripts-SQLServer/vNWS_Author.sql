alter view "dbo"."vNWS_Author"
as
	select
		"IDAuthor", 
		"NWS_Author"."IFApplication" as "IDApplication", 
		"NWS_Author"."Name", 
		"NWS_Author"."IFUser__Approved", 
		"NWS_User"."Name" as "ManagerName", 
		"NWS_Author"."Approved_date"
	from "NWS_Author"
	left join "NWS_User" on (
		"NWS_Author"."IFUser__Approved" = "NWS_User"."IFUser"
	)
go

select *
from "vNWS_Author"
