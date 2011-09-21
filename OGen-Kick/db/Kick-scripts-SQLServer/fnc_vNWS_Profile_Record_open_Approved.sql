--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_vNWS_Profile_Record_open_Approved]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
--	DROP FUNCTION [dbo].[fnc_vNWS_Profile_Record_open_Approved]
--GO

alter FUNCTION [dbo].[fnc_vNWS_Profile_Record_open_Approved](
	@IDApplication_search_ int
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDProfile"
	FROM "NWS_Profile"
	inner join "CRD_Profile" on (
		"CRD_Profile"."IDProfile" = "NWS_Profile"."IFProfile"
	)
	WHERE
		(
			(@IDApplication_search_ is null)
			or
			(@IDApplication_search_ <= 0)
			OR
			(@IDApplication_search_ = "CRD_Profile"."IFApplication")
		)
		and
		(not "NWS_Profile"."IFUser__Approved" is null)
GO
