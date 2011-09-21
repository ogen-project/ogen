--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_NWS_User_Record_open_Publisher]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
--	DROP FUNCTION [dbo].[fnc_NWS_User_Record_open_Publisher]
--GO

alter FUNCTION [dbo].[fnc_NWS_User_Record_open_Publisher](
	@IDApplication_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		distinct "IFUser__Publisher" as "IFUser"
	FROM "NWS_Content"
	where 
		(@IDApplication_search_ is null)
		or
		(@IDApplication_search_ <= 0)
		OR
		(@IDApplication_search_ = "NWS_Content"."IFApplication")
GO

select *
from 
[dbo].[fnc_NWS_User_Record_open_Publisher](
	1--@IDApplication_search_ int
)