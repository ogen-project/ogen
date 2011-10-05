alter view "dbo"."vDIC_Language" 
as
	select
		"DIC_Language"."IDLanguage", 
		"DIC_TextLanguage"."IFLanguage" as "IDLanguage_translation", 
		case 
			when not "DIC_TextLanguage"."CharVar8000" is null 
				then "DIC_TextLanguage"."CharVar8000"
			when not "DIC_TextLanguage"."Text" is null 
				then "DIC_TextLanguage"."Text"
			else ''
		end as "Language"
	from "DIC_Language"
	inner join "DIC_TextLanguage" on (
		"DIC_TextLanguage"."IFText" = "DIC_Language"."TX_Name"
	)
go

select 
	*
from "vDIC_Language"
where 
	("IDLanguage_translation" = 1)
