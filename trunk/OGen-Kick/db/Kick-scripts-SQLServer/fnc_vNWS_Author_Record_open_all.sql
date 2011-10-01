--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_vNWS_Author_Record_open_all]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
--	DROP FUNCTION [dbo].[fnc_vNWS_Author_Record_open_all]
--GO

alter FUNCTION [dbo].[fnc_vNWS_Author_Record_open_all](
	@IDApplication_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDAuthor"
	FROM "fnc_NWS_Author_Record_open_all"(
		@IDApplication_search_
	)
GO


select *
from [dbo].[fnc_vNWS_Author_Record_open_all](
	1
)