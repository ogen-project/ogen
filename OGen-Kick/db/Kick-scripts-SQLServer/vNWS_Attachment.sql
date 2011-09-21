/* 
drop view "vNWS_Attachment"
go
*/

--create
alter view "dbo"."vNWS_Attachment"
as
	select 
		"NWS_Attachment"."IDAttachment", 
		"DIC_Language"."IDLanguage", 
		"NWS_Attachment"."IFContent", 
		"NWS_Attachment"."GUID", 
		"NWS_Attachment"."OrderNum", 
		"NWS_Attachment"."isImage", 

		case 
			when not _tx_name."CharVar8000" is null 
				then _tx_name."CharVar8000"
			when not _tx_name."Text" is null 
				then _tx_name."Text"
			else ''
		end as "Name", 
		case 
			when not _tx_description."CharVar8000" is null 
				then _tx_description."CharVar8000"
			when not _tx_description."Text" is null 
				then _tx_description."Text"
			else ''
		end as "Description", 
		
		"NWS_Attachment"."FileName"

	from "NWS_Attachment"
	left join "DIC_Language" on (1 = 1)
	left join "DIC_TextLanguage" as _tx_name on (
		("DIC_Language"."IDLanguage" = _tx_name."IFLanguage")
		and
		("NWS_Attachment"."TX_Name" = _tx_name."IFText")
	)
	left join "DIC_TextLanguage" as _tx_description on (
		("DIC_Language"."IDLanguage" = _tx_description."IFLanguage")
		and
		("NWS_Attachment"."TX_Description" = _tx_description."IFText")
	)
go

select *
from "vNWS_Attachment"
order by "IDAttachment", "IDLanguage"
