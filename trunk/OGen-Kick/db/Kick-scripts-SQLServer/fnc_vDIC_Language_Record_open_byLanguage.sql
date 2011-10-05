alter FUNCTION [dbo].[fnc_vDIC_Language_Record_open_byLanguage](
	@IDLanguage_translation_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDLanguage", 
		"IDLanguage_translation"
	FROM "vDIC_Language"
	WHERE
		(@IDLanguage_translation_search_ is null)
		or
		(@IDLanguage_translation_search_ <= 0)
		or
		("IDLanguage_translation" = @IDLanguage_translation_search_)
GO

select * 
from "sp0_vDIC_Language_Record_open_byLanguage_fullmode"(
	-1
);