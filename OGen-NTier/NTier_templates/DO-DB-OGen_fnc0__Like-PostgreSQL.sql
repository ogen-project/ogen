CREATE OR REPLACE FUNCTION "OGen_fnc0__Like"(
	"string_" character varying, 
	"patern_" character varying
)
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
RETURNS boolean AS
$BODY$
	DECLARE
		_Output boolean = false;
	BEGIN
		if (
			("patern_" is null) 
			or 
			("patern_" = '')
		) then
			select into _Output true;
		else 
			if (
				("string_" is null)
				or
				("string_" = '')
			) then
				select into _Output false;
			else
				select
					into _Output
					(
						sum(
							case 
								----CASE SENSITIVE
								--when ("string_" like '%' || "OGen_fnc0__Split" || '%') then 1 
								----CASE INSENSITIVE
								when ("string_" ~* ('.*' || "OGen_fnc0__Split" || '.*')) then 1 
								else 0 
							end
						) 
						= 
						count("OGen_fnc0__Split")
					)
				from "OGen_fnc0__Split"(string_to_array(
					"patern_", 
					' '
				));
			end if;
		end if;

		RETURN _Output;
	END;
$BODY$
LANGUAGE 'plpgsql' STABLE;