ALTER FUNCTION [dbo].[fnc_NWS_User_isObject_byEMail](
	@EMail_search_ varchar (255), 
	@IDApplication_search_ int
)
RETURNS @finalresult TABLE (
	"IFUser" bigint
)
AS
BEGIN
	INSERT INTO @finalresult
	SELECT
		"IFUser"
	FROM "NWS_User"
	WHERE
		("EMail" = @EMail_search_) 
		AND
		(
			(@IDApplication_search_ is null)
			or
			(@IDApplication_search_ = "IFApplication")
		)

	RETURN
END
GO


select *
from [dbo].[fnc_NWS_User_isObject_byEMail](
	'francisco.monteiro@addsolutions.pt', 
	1
)