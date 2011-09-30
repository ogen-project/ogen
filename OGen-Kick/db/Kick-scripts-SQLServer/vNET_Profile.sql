--create view "vNET_Profile"
create view "dbo"."vNET_Profile"
as
	select 
		"CRD_Profile".*, 
		not "NET_Defaultprofile"."IFProfile" is null as "isDefaultprofile"
	from "CRD_Profile"
	left join "NET_Defaultprofile" on (
		"NET_Defaultprofile"."IFProfile" = "CRD_Profile"."IDProfile"
	)
go

select *
from "vNET_Profile"
where 
	("IFApplication" in (1))