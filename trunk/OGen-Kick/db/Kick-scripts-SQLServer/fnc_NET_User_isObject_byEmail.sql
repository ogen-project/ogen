ALTER FUNCTION [dbo].[fnc_NET_User_isObject_byEmail](
	@Email_search_ varchar (255), 
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
	FROM "NET_User"
	WHERE
		("Email" = @Email_search_) 
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
from [dbo].[fnc_NET_User_isObject_byEmail](
	'francisco.monteiro@addsolutions.pt', 
	1
)