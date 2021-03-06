ALTER FUNCTION "dbo"."fnc_vNET_User_Record_open_generic"(
	@Login_search_ varchar (255), 
	@Name_search_ varchar (255), 
	@Email_search_ varchar (255), 
	@IFApplication_search_ int, 
	@IDProfile__in_search_ bigint, 
	@IDProfile__out_search_ bigint
)
RETURNS TABLE
AS
RETURN
	SELECT
		"IDUser"
	FROM "vNET_User"
	WHERE
		(
			(@Name_search_ is null)
			or
			(@Name_search_ = '')

			--("Name" LIKE '%' + @Name_search_ + '%' COLLATE SQL_Latin1_General_CP1_CI_AS)
			or
			(
				select "dbo"."OGen_fnc0__Like"(
					"Name", 			
					@Name_search_
				)
			) = 1
		)
		AND
		(
			(@Login_search_ is null)
			or
			(@Login_search_ = '')
			or
			("Login" LIKE '%' + @Login_search_ + '%')
		)
		AND
		(
			(@Email_search_ is null)
			or
			(@Email_search_ = '')
			or
			("Email" LIKE '%' + @Email_search_ + '%')
		)
		AND
		(
			(@IFApplication_search_ is null)
			or
			(@IFApplication_search_ <= 0)
			or
			(@IFApplication_search_ = "IFApplication")
		) 
		AND
		(
			(@IDProfile__in_search_ is null)
			or
			(@IDProfile__in_search_ <= 0)
			or
			exists (
				select top 1 cast(1 as bit)
				from "CRD_UserProfile"
				where 
					("CRD_UserProfile"."IFUser" = "vNET_User"."IDUser")
					and
					("CRD_UserProfile"."IFProfile" = @IDProfile__in_search_)
			)
		)
		AND
		(
			(@IDProfile__out_search_ is null)
			or
			(@IDProfile__out_search_ <= 0)
			or
			not exists (
				select top 1 cast(1 as bit)
				from "CRD_UserProfile"
				where 
					("CRD_UserProfile"."IFUser" = "vNET_User"."IDUser")
					and
					("CRD_UserProfile"."IFProfile" = @IDProfile__out_search_)
			)
		)
GO



select *
from "dbo"."fnc_vNET_User_Record_open_generic"(
	'f', -- @Login_search_ varchar (255), 
	'onteiro rancisco', -- @Name_search_ varchar (255), 
	'rancisco', --@Email_search_ varchar (255), 
	1, -- @IFApplication_search_ int, 
	1, -- @IDProfile__in_search_ bigint, 
	2 -- @IDProfile__out_search_ bigint
)