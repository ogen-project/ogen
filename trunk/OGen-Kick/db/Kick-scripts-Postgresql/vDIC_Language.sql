create or replace view "vDIC_Language" 
as
	select
		"DIC_Language"."IDLanguage", 
		"DIC_TextLanguage"."IFLanguage" as "IDLanguage_translation", 
		case 
			when not "DIC_TextLanguage"."Text__small" is null 
				then "DIC_TextLanguage"."Text__small"
			when not "DIC_TextLanguage"."Text__large" is null 
				then "DIC_TextLanguage"."Text__large"
			else ''
		end as "Language"
	from "DIC_Language"
	inner join "DIC_TextLanguage" on (
		"DIC_TextLanguage"."IFText" = "DIC_Language"."TX_Name"
	)
;

select 
	*
from "vDIC_Language"
where 
	("IDLanguage_translation" = 1)
;
