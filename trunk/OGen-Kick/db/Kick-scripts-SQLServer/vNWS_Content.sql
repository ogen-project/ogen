/*
drop view "vNWS_Content"
create view "vNWS_Content"
alter view "vNWS_Content"
*/
alter view "dbo"."vNWS_Content"
as
	select
		"NWS_Content"."IDContent", 
		"DIC_Language"."IDLanguage", 

--		"NWS_Content"."IFContenttype", 

		"NWS_Content"."IFUser__Publisher", 
		"NET_User"."Name" as "PublisherName", 
		"NWS_Content"."Publish_date", 
		"NWS_Content"."IFUser__Approved", 
		"NWS_Content"."Approved_date", 


		case 
			when not _tx_title."Text__small" is null 
				then _tx_title."Text__small"
			when not _tx_title."Text__large" is null 
				then _tx_title."Text__large"
			else ''
		end as "Title", 
		case 
			when not _tx_content."Text__small" is null 
				then _tx_content."Text__small"
			when not _tx_content."Text__large" is null 
				then _tx_content."Text__large"
			else ''
		end as "Content", 
		case 
			when not _tx_subtitle."Text__small" is null 
				then _tx_subtitle."Text__small"
			when not _tx_subtitle."Text__large" is null 
				then _tx_subtitle."Text__large"
			else ''
		end as "subtitle", 
		case 
			when not _tx_summary."Text__small" is null 
				then _tx_summary."Text__small"
			when not _tx_summary."Text__large" is null 
				then _tx_summary."Text__large"
			else ''
		end as "summary"


/*
		select "NWS_ContentTag"."IFTag"
		from "NWS_ContentTag" 
		where 
			("NWS_ContentTag"."IFContent" = "NWS_Content"."IDContent")
*/
/*
		select "NWS_ContentSource"."IFSource", "NWS_Source"."Name"
		from "NWS_ContentSource" 
		inner join "NWS_Source" on (
			"NWS_Source"."IDSource" = "NWS_ContentSource"."IFSource"
		)
		where 
			("NWS_ContentSource"."IFContent" = "NWS_Content"."IDContent")
*/
/*
		(
			select 
				replace(
					replace(
						replace(
							replace(
								(
									select 
										"NWS_ContentSource"."IFSource" as "X", 
										--"NWS_Source"."Name" as "Y"
										"dbo"."fnc_NWS_Source__fullname"(
											"NWS_ContentSource"."IFSource"
										) as "Y"
									from "NWS_ContentSource" 
									where 
										("NWS_ContentSource"."IFContent" = "NWS_Content"."IDContent")
									FOR XML PATH('')
								), 
								'<X>', 
								''
							), 
							'</X>', 
							'<'
						), 
						'<Y>', 
						''
					), 
					'</Y>', 
					'>'
				)
		) as "Sources"
*/
	from "NWS_Content"



	left join "DIC_LanguageApplication" on (
		(not "NWS_Content"."IFApplication" is null)
		and
		("DIC_LanguageApplication"."IFApplication" = "NWS_Content"."IFApplication")
	)
	left join "DIC_Language" on (
		("NWS_Content"."IFApplication" is null)
		or
		("DIC_LanguageApplication"."IFLanguage" = "DIC_Language"."IDLanguage")
	)




	inner join "NET_User" on (
		"NET_User"."IFUser" = "NWS_Content"."IFUser__Publisher"
	)

	left join "DIC_TextLanguage" as _tx_title on (
		("DIC_Language"."IDLanguage" = _tx_title."IFLanguage")
		and
		("NWS_Content"."TX_Title" = _tx_title."IFText")
	)
	left join "DIC_TextLanguage" as _tx_content on (
		("DIC_Language"."IDLanguage" = _tx_content."IFLanguage")
		and
		("NWS_Content"."TX_Content" = _tx_content."IFText")
	)
	left join "DIC_TextLanguage" as _tx_subtitle on (
		("DIC_Language"."IDLanguage" = _tx_subtitle."IFLanguage")
		and
		("NWS_Content"."TX_Subtitle" = _tx_subtitle."IFText")
	)
	left join "DIC_TextLanguage" as _tx_summary on (
		("DIC_Language"."IDLanguage" = _tx_summary."IFLanguage")
		and
		("NWS_Content"."TX_Summary" = _tx_summary."IFText")
	)
go

select *
from "vNWS_Content"
/*
where "IDLanguage" in (
	1,
	2
)
*/

/*
SELECT 
	STUFF(
		(
			SELECT NWS_Source.Name
			from NWS_Source FOR XML PATH('')
		),
		1,
		1,
		''
	) as Numbers 
*/
/*
select 
	replace(
		replace(
			replace(
				replace(
					(
						select 
							"NWS_Source"."IDSource" as "X", 
							--"NWS_Source"."Name" as "Y"
							"dbo"."fnc_NWS_Source__fullname"(
								"NWS_Source"."IDSource"
							) as "Y"
						from "NWS_Source" FOR XML PATH('')
					), 
					'<X>', 
					''
				), 
				'</X>', 
				'<'
			), 
			'<Y>', 
			''
		), 
		'</Y>', 
		'>'
	)

select (
	select "NWS_Source"."Name" as "n"
	from "NWS_Source" FOR XML PATH('')
) as "SourceName"
*/