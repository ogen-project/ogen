create or replace view "vCRD_UserProfile" 
as
	select
		p1."IDProfile", 
		p1."Name" as "ProfileName", 
		p2."IDUser", 
		exists(
			select 
				true -- pp1."IFUser"
			from "CRD_UserProfile" as pp1
			where
				(pp1."IFUser" = p2."IDUser")
				and
				(p1."IDProfile" = pp1."IFProfile")
		) as "hasProfile"
	from "CRD_Profile" as p1, "CRD_User" as p2
;

select 
	*
from "vCRD_UserProfile"
where
	"IDUser" = 1
order by "IDProfile"
;
