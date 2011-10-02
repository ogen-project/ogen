alter FUNCTION [dbo].[fnc_DIC_TextLanguage_Record_open_byLanguage_short](
	@IDLanguage_search_ int
)
RETURNS TABLE
AS
RETURN

			select
				t3."IFText", 
				t3."IFLanguage"
			from "DIC_Language" as t1
			inner join "DIC_Text" as t2 on (
				t2."IDText" = t1."TX_Name"
			)
			inner join "DIC_TextLanguage" as t3 on (
				t3."IFText" = t2."IDText"
			)
			where t3."IFLanguage" = @IDLanguage_search_

GO