CREATE FUNCTION [dbo].[OGen_fnc0__Split](
	@text_ NVarChar(4000), 
	@separator_ Char(1) = '|'
)
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

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