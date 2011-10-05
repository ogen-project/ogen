--create view "vNET_Profile"
alter view "dbo"."vNET_Profile"
as
	select 
		"CRD_Profile".*, 
		case 
			when ("NET_Defaultprofile"."IFProfile" is null) then cast(0 as bit)
			else cast(1 as bit)
		end as "isDefaultprofile"
	from "CRD_Profile"
	left join "NET_Defaultprofile" on (
		"NET_Defaultprofile"."IFProfile" = "CRD_Profile"."IDProfile"
	)
go

select *
from "vNET_Profile"
where 
	("IFApplication" in (1))