create view "dbo"."vDIC_ApplicationLanguage" 
as
	select 
		"DIC_LanguageApplication"."IFApplication", 
		"DIC_Language"."IDLanguage", 
		case 
			when (not "DIC_TextLanguage"."CharVar8000" is null) 
				then "DIC_TextLanguage"."CharVar8000"
			when (not "DIC_TextLanguage"."Text" is null) 
				then "DIC_TextLanguage"."Text"
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
go

select 
	*
from "vDIC_ApplicationLanguage"
where 
	("IFApplication" = 1)
