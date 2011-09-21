alter function "dbo"."fnc_NWS_Highlight__fullname"(
	@idHighlight_in bigint
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
				when "NWS_Highlight"."IFHighlight__parent" is null then '' 
				else "dbo"."fnc_NWS_Highlight__fullname"(
					"NWS_Highlight"."IFHighlight__parent"
				) + ' / '
			end
			+ "NWS_Highlight"."Name"
	from "NWS_Highlight"
	where "NWS_Highlight"."IDHighlight" = @idHighlight_in

	return @output
end
go
