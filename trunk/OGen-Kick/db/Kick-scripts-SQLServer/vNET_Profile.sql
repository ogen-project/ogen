--create view "vNET_Profile"
alter view "dbo"."vNET_Profile"
as
	select 
		"CRD_Profile".*, 
		case 
			when ("NET_Profile__default"."IFProfile" is null) then cast(0 as bit)
			else cast(1 as bit)
		end as "IsDefault"
	from "CRD_Profile"
	left join "NET_Profile__default" on (
		"NET_Profile__default"."IFProfile" = "CRD_Profile"."IDProfile"
	)
go

select *
from "vNET_Profile"
where 
	("IFApplication" in (1))