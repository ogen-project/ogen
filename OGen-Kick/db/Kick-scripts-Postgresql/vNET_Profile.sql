create or replace view "vNET_Profile"
as
	select 
		"CRD_Profile".*, 
		not "NET_Defaultprofile"."IFProfile" is null as "isDefaultprofile"
	from "CRD_Profile"
	left join "NET_Defaultprofile" on (
		"NET_Defaultprofile"."IFProfile" = "CRD_Profile"."IDProfile"
	)
;

select * 
from "vNET_Profile"
;