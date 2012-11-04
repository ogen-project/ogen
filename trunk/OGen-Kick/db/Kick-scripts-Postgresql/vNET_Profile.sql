create or replace view "vNET_Profile"
as
	select 
		"CRD_Profile".*, 
		not "NET_Profile__default"."IFProfile" is null as "IsDefault"
	from "CRD_Profile"
	left join "NET_Profile__default" on (
		"NET_Profile__default"."IFProfile" = "CRD_Profile"."IDProfile"
	)
;

select * 
from "vNET_Profile"
;