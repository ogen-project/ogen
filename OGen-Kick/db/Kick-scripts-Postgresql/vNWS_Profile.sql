create or replace view "vNWS_Profile"
as
	select
		"IFProfile" as "IDProfile", 
		"CRD_Profile"."Name", 
		"CRD_Profile"."IFApplication" as "IDApplication", 
		"IFUser__Approved", 
		"Approved_date", 
		"NET_User"."Name" as "ManagerName"
	from "NWS_Profile"
	inner join "CRD_Profile" on (
		"CRD_Profile"."IDProfile" = "NWS_Profile"."IFProfile"
	)
	left join "NET_User" on (
		"NET_User"."IFUser" = "NWS_Profile"."IFUser__Approved"
	)
;

select *
from "vNWS_Profile"
;