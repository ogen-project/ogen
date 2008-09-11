USE [OGen-NTier_UTs]
GO

CREATE FUNCTION [dbo].[fnc_User_isObject_byLogin](
	@Login_search_ varchar (50)
)
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
RETURNS @finalresult TABLE (
	[IDUser] bigint
)
AS
BEGIN
	INSERT INTO @finalresult
	SELECT
		[IDUser]
	FROM [User]
	WHERE
		--([Login] LIKE '%' + @Login_search_ + '%' COLLATE SQL_Latin1_General_CP1_CI_AI)
		([Login] = @Login_search_)

	RETURN
END


