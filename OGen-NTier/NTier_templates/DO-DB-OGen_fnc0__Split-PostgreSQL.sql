CREATE OR REPLACE FUNCTION "OGen_fnc0__Split"(
--	someString_ CHARACTER VARYING
	_someArray ANYARRAY
)
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
RETURNS SETOF ANYELEMENT AS $BODY$
    DECLARE
--	_someArray ANYARRAY DEFAULT STRING_TO_ARRAY(someString_, '|');
        _length INT DEFAULT ARRAY_UPPER(_someArray, 1);
        _ii INT;
    BEGIN
        FOR _ii IN 1.._length LOOP
            RETURN NEXT _someArray[_ii];
        END LOOP;
        RETURN;
    END;
$BODY$
LANGUAGE plpgsql immutable;
