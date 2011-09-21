alter function "dbo"."fnc_NWS_Source__fullname"(
	@idSource_in bigint
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
				when "NWS_Source"."IFSource__parent" is null then '' 
				else "dbo"."fnc_NWS_Source__fullname"(
					"NWS_Source"."IFSource__parent"
				) + ' / '
			end
			+ "NWS_Source"."Name"
	from "NWS_Source"
	where "NWS_Source"."IDSource" = @idSource_in

	return @output
end
go
