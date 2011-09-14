create or replace view "vFOR_Message"
as
	select
		m3."IDMessage", 
		m3."IFMessage__parent" as "IDMessage__parent", 
		--case when (m3."IFMessage__parent" is null) then cast(1 as bit) else cast(0 as bit) end as "isForum", 
		case 
			when --(
				(m3."IFMessage__parent" is null) 
				or
				(not (m2."IFMessage__parent" is null))
			--) 
				then false
			else 
				true
		end as "isThread", 
		--case when (m1."IFMessage__parent" is null) then cast(1 as bit) else cast(0 as bit) end as "isReply", 
		
		m3."isSticky", 
		m3."Subject", 

		/*
		case 
			when (not m3."Message__charvar8000" is null) then m3."Message__charvar8000"
			when (not m3."Message__text" is null) then m3."Message__text" 
			else ''
		end as "Message", 
		*/
		m3."Message__charvar8000", 
		m3."Message__text", 

		m3."IFUser__Publisher" as "IDUser", 
		u1."Name", 
		m3."Publish_date", 
		m3."IFApplication", 
		u2."Login"
		--m2."Subject" as "ParentSubject", 
	from "FOR_Message" as m3
	left join "FOR_Message" as m2 on (
		--(not m3."IFMessage__parent" is null)
		--and
		(m3."IFMessage__parent" = m2."IDMessage")
	)
	left join "FOR_Message" as m1 on (
		--(not m2."IFMessage__parent" is null)
		--and
		(m2."IFMessage__parent" = m1."IDMessage")
	)
	inner join "NET_User" as u1 on (
		--(not m3."IFUser__Publisher" is null)
		--and
		m3."IFUser__Publisher" = u1."IFUser"
	)
	inner join "CRD_User" as u2 on (
		--(not m3."IFUser__Publisher" is null)
		--and
		m3."IFUser__Publisher" = u2."IDUser"
	)
;

select * 
from "vFOR_Message"
;