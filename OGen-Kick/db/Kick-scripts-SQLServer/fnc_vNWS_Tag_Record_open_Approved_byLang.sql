--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_vNWS_Tag_Record_open_Approved_byLang]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
--	DROP FUNCTION [dbo].[fnc_vNWS_Tag_Record_open_Approved_byLang]
--GO

alter FUNCTION [dbo].[fnc_vNWS_Tag_Record_open_Approved_byLang](
	@IDApplication_search_ int, 
	@IDLanguage_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDTag", 
		"IDLanguage"
	FROM "vNWS_Tag"
	WHERE
		(
			(@IDApplication_search_ IS NULL)
			OR
			(@IDApplication_search_ <= 0)
			OR
			([IFApplication] = @IDApplication_search_)
		)
		and
		(
			(@IDLanguage_search_ <= 0)
			OR
			@IDLanguage_search_ = [IDLanguage]
		)
		and
		(not "IFUser__Approved" is null)
GO
