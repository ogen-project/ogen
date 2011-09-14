--drop view "vCRD_ProfilePermition";

create or replace view "vCRD_ProfilePermition" 
as
	select
		p1."IDPermition", 
		p1."Name" as "PermitionName", 
		p2."IDProfile", 
		exists(
			select 
				true -- pp1."IFProfile"
			from "CRD_ProfilePermition" as pp1
			where
				(pp1."IFProfile" = p2."IDProfile")
				and
				(p1."IDPermition" = pp1."IFPermition")
		) as "hasPermition"
	from "CRD_Permition" as p1, "CRD_Profile" as p2
;

select 
	*
from "vCRD_ProfilePermition"
where
	"IDProfile" = 1
order by "IDPermition"
;


/*
select
	p1."IDPermition", 
	p1."Name", 
	exists(
		select 
			true -- pp1."IFProfile"
		from "CRD_ProfilePermition" as pp1
		where
			(pp1."IFProfile" = 1)
			and
			(p1."IDPermition" = pp1."IFPermition")
	) as "IDProfile"
from "CRD_Permition" as p1
*/

