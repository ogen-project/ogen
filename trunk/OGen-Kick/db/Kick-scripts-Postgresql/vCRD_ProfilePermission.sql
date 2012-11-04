--drop view "vCRD_ProfilePermission";

create or replace view "vCRD_ProfilePermission" 
as
	select
		p1."IDPermission", 
		p1."Name" as "PermissionName", 
		p2."IDProfile", 
		exists(
			select 
				true -- pp1."IFProfile"
			from "CRD_ProfilePermission" as pp1
			where
				(pp1."IFProfile" = p2."IDProfile")
				and
				(p1."IDPermission" = pp1."IFPermission")
		) as "hasPermission"
	from "CRD_Permission" as p1, "CRD_Profile" as p2
;

select 
	*
from "vCRD_ProfilePermission"
where
	"IDProfile" = 1
order by "IDPermission"
;


/*
select
	p1."IDPermission", 
	p1."Name", 
	exists(
		select 
			true -- pp1."IFProfile"
		from "CRD_ProfilePermission" as pp1
		where
			(pp1."IFProfile" = 1)
			and
			(p1."IDPermission" = pp1."IFPermission")
	) as "IDProfile"
from "CRD_Permission" as p1
*/

