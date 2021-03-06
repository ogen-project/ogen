ALTER FUNCTION [dbo].[fnc_NET_Profile__default_Record_open_all](
	@IDApplication_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		d1."IFProfile"
	FROM "NET_Profile__default" as d1
	inner join "CRD_Profile" as p1 on (
		(
			(@IDApplication_search_ is null)
			or
			(@IDApplication_search_ <= 0)
			or
			(@IDApplication_search_ = p1."IFApplication")
		)
		and
		p1."IDProfile" = d1."IFProfile"
	)
GO

--select 
--	"IFProfile"
--from "NET_Profile__default"
--where
--	"IFProfile" in (
		select "IFProfile"
		from [dbo].[fnc_NET_Profile__default_Record_open_all](
			1
		)
--	)