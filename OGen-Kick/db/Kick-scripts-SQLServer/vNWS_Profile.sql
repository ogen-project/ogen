alter view "dbo"."vNWS_Profile"
as
	select
		"IFProfile" as "IDProfile", 
		"CRD_Profile"."Name", 
		"CRD_Profile"."IFApplication" as "IDApplication", 
		"IFUser__Approved", 
		"Approved_date", 
		"NWS_User"."Name" as "ManagerName"
	from "NWS_Profile"
	inner join "CRD_Profile" on (
		"CRD_Profile"."IDProfile" = "NWS_Profile"."IFProfile"
	)
	left join "NWS_User" on (
		"NWS_User"."IFUser" = "NWS_Profile"."IFUser__Approved"
	)
go

select *
from "vNWS_Profile"