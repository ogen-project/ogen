--create view "vNWS_User"
create view "dbo"."vNWS_User"
as
	select 
		c1."IDUser", 
		c1."IFApplication", 
		c1."Login", 
		n1."Name", 
		n1."EMail"
	from "CRD_User" c1
	left join "NWS_User" n1 on (
		n1."IFUser" = c1."IDUser"
	)
go

select *
from "vNWS_User"
where 
	("IFApplication" in (1))