--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_vNWS_Profile_Record_open_all]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
--	DROP FUNCTION [dbo].[fnc_vNWS_Profile_Record_open_all]
--GO

alter FUNCTION [dbo].[fnc_vNWS_Profile_Record_open_all](
	@IDApplication_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDProfile"
	FROM "vNWS_Profile"
	WHERE
		(@IDApplication_search_ is null)
		or
		(@IDApplication_search_ <= 0)
		or
		(@IDApplication_search_ = [IDApplication])
GO
