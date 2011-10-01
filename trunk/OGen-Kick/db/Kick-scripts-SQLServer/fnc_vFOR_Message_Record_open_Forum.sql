ALTER FUNCTION [dbo].[fnc_vFOR_Message_Record_open_Forum](
	@IDApplication_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDMessage"
	FROM "FOR_Message"
	WHERE
		(
			(@IDApplication_search_ is null)
			or
			(@IDApplication_search_ = "IFApplication")
		)
		and
		("FOR_Message"."IFMessage__parent" is null)
GO


select *
from [dbo].[fnc_vFOR_Message_Record_open_Forum](
	1
)