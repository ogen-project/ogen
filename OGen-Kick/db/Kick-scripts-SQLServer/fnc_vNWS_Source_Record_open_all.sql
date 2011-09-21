--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_vNWS_Source_Record_open_all]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
--	DROP FUNCTION [dbo].[fnc_vNWS_Source_Record_open_all]
--GO

alter FUNCTION [dbo].[fnc_vNWS_Source_Record_open_all](
	@IDApplication_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDSource"
	FROM "vNWS_Source"
	WHERE
		(@IDApplication_search_ IS NULL)
		OR
		(@IDApplication_search_ <= 0)
		OR
		([IFApplication] = @IDApplication_search_)
GO
