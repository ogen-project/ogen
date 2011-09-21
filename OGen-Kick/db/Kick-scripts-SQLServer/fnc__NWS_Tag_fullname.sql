alter function "dbo"."fnc_NWS_Tag__fullname"(
	@idTag_in bigint, 
	@idLanguage_in bigint
) 
returns varchar (8000)
as
begin
	DECLARE @output varchar (8000)
	SET @output = ''
	
	select 
		@output 
			= @output 
			+ case 
				when "NWS_Tag"."IFTag__parent" is null then '' 
				else "dbo"."fnc_NWS_Tag__fullname"(
					"NWS_Tag"."IFTag__parent", 
					@idLanguage_in
				) + ' / '
			end
			+ case 
				when not "DIC_TextLanguage"."CharVar8000" is null 
					then "DIC_TextLanguage"."CharVar8000"
				when not "DIC_TextLanguage"."Text" is null 
					then 'ERROR!'
				else ''
			end
	from "NWS_Tag"
	inner join "DIC_TextLanguage" on (
		("DIC_TextLanguage"."IFLanguage" = @idLanguage_in)
		and
		("DIC_TextLanguage"."IFText" = "NWS_Tag"."TX_Name")
	)
	where "NWS_Tag"."IDTag" = @idTag_in

	return @output
end
go
