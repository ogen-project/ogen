--IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vCRD_UserProfile]'))
--	DROP VIEW [dbo].[vCRD_UserProfile]
--GO

create view "dbo"."vCRD_UserProfile" 
as
	select
		p1."IDProfile", 
		p1."Name" as "ProfileName", 
		p2."IDUser", 
		case 
			when exists(
				select 
					1 -- pp1."IFUser"
				from "CRD_UserProfile" as pp1
				where
					(pp1."IFUser" = p2."IDUser")
					and
					(p1."IDProfile" = pp1."IFProfile")
			) then cast(1 as bit)
			else cast (0 as bit)
		end as "hasProfile"
	from "CRD_Profile" as p1, "CRD_User" as p2
go

select 
	*
from "vCRD_UserProfile"
where
	"IDUser" = 1
order by "IDProfile"
