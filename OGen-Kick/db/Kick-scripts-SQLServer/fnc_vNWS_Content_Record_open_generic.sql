--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_vNWS_Content_Record_open_generic]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
--	DROP FUNCTION [dbo].[fnc_vNWS_Content_Record_open_generic]
--GO

alter FUNCTION [dbo].[fnc_vNWS_Content_Record_open_generic](
	@IFApplication_search_ int, 
	@IFUser__Publisher_search_ bigint, 
	@IFUser__Aproved_search_ bigint, 
	@Begin_date_search_ datetime, 
	@End_date_search_ datetime, 
	@IDTag_search_ varchar (8000), 
	@IDAuthor_search_ varchar (8000), 
	@IDSource_search_ varchar (8000), 
	@IDHighlight_search_ varchar (8000), 
	@IDProfile_search_ varchar (8000), 
	@Keywords_search_ varchar (8000), 
	@IDLanguage_search_ int, 
	@isAND_notOR_search_ bit
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDContent", 
		@IDLanguage_search_ as "IDLanguage"
	FROM "fnc_NWS_Content_Record_open_generic"(
		@IFApplication_search_, 
		@IFUser__Publisher_search_, 
		@IFUser__Aproved_search_, 
		@Begin_date_search_, 
		@End_date_search_, 
		@IDTag_search_, 
		@IDAuthor_search_, 
		@IDSource_search_, 
		@IDHighlight_search_, 
		@IDProfile_search_, 
		@Keywords_search_, 
		@IDLanguage_search_, 
		@isAND_notOR_search_
	)
GO
