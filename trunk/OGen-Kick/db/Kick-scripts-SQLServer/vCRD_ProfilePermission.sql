--IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vCRD_ProfilePermission]'))
--	DROP VIEW [dbo].[vCRD_ProfilePermission]
--GO

alter view "dbo"."vCRD_ProfilePermission" 
as
	select
		p1."IDPermission", 
		p1."Name" as "PermissionName", 
		p2."IDProfile", 
		case 
			when exists(
				select 
					cast(1 as bit) -- pp1."IFProfile"
				from "CRD_ProfilePermission" as pp1
				where
					(pp1."IFProfile" = p2."IDProfile")
					and
					(p1."IDPermission" = pp1."IFPermission")
			) then cast(1 as bit) 
			else cast(0 as bit) 
		end as "hasPermission"
	from "CRD_Permission" as p1, "CRD_Profile" as p2
go

select 
	*
from "vCRD_ProfilePermission"
where
	"IDProfile" = 1
order by "IDPermission"
