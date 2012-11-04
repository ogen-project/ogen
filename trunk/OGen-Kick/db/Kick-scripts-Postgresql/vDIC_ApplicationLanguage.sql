create or replace view "vDIC_ApplicationLanguage" 
as
	select 
		"DIC_LanguageApplication"."IFApplication", 
		"DIC_Language"."IDLanguage", 
		case 
			when (not "DIC_TextLanguage"."Text__small" is null) 
				then "DIC_TextLanguage"."Text__small"
			when (not "DIC_TextLanguage"."Text__large" is null) 
				then "DIC_TextLanguage"."Text__large"
			else
				''
		end as "Language"
	from "DIC_Language"
	inner join "DIC_LanguageApplication" on (
		"DIC_LanguageApplication"."IFLanguage" = "DIC_Language"."IDLanguage"
	)
	inner join "DIC_TextLanguage" on (
		"DIC_TextLanguage"."IFText" = "DIC_Language"."TX_Name"
		and
		"DIC_TextLanguage"."IFLanguage" = "DIC_Language"."IDLanguage"
	)
	--where
	--	"DIC_Language"."IDLanguage" = "DIC_TextLanguage"."IFLanguage"
	--order by "DIC_LanguageApplication"."IFApplication"
;

select 
	*
from "vDIC_ApplicationLanguage"
where 
	("IFApplication" = 1)
;
