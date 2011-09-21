--IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vCRD_ProfilePermition]'))
--	DROP VIEW [dbo].[vCRD_ProfilePermition]
--GO

create view "dbo"."vCRD_ProfilePermition" 
as
	select
		p1."IDPermition", 
		p1."Name" as "PermitionName", 
		p2."IDProfile", 
		case 
			when exists(
				select 
					cast(1 as bit) -- pp1."IFProfile"
				from "CRD_ProfilePermition" as pp1
				where
					(pp1."IFProfile" = p2."IDProfile")
					and
					(p1."IDPermition" = pp1."IFPermition")
			) then cast(1 as bit) 
			else cast(0 as bit) 
		end as "hasPermition"
	from "CRD_Permition" as p1, "CRD_Profile" as p2
go

select 
	*
from "vCRD_ProfilePermition"
where
	"IDProfile" = 1
order by "IDPermition"
