CREATE FUNCTION [dbo].[OGen_fnc0__Split](
	@text_ NVarChar(4000), 
	@separator_ Char(1) = '|'
)
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
RETURNS @output_ TABLE (   
--  [OutputIndex] Int IDENTITY, 
	[OutputValue] NVarChar(4000)  
) AS BEGIN
	DECLARE @_index Int
	SET @_index = -1
	WHILE (LEN(@text_) > 0) BEGIN 
		SET @_index = CHARINDEX(@separator_ , @text_) 
		IF (@_index = 0) AND (LEN(@text_) > 0) BEGIN  
			INSERT INTO @output_ VALUES (@text_)
			BREAK 
		END 
		IF (@_index > 1) BEGIN  
			INSERT INTO @output_ ([OutputValue]) VALUES (LEFT(@text_, @_index - 1))  
		END
		SET @text_ = RIGHT(@text_, (LEN(@text_) - @_index))
	END
	RETURN
END