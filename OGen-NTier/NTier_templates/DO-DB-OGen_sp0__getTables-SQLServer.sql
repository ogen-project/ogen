CREATE PROCEDURE [dbo].[OGen_sp0__getTables]
	@subApp_ NVarChar (4000)
AS
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
IF (@subApp_ = '') SET @subApp_ = '%'
SELECT
	t1.TABLE_NAME AS [Name],
	CASE
		WHEN (t1.TABLE_TYPE = 'VIEW') THEN
			CAST(1 AS Int)
		ELSE
			CAST(0 AS Int)
	END AS [isVT]
FROM INFORMATION_SCHEMA.TABLES t1
INNER JOIN [dbo].[OGen_fnc0__Split](
	@subApp_, 
	'|'
) t2 ON (
	(t1.[TABLE_NAME] LIKE t2.[OutputValue])
)
WHERE
	(
		(t1.TABLE_TYPE = 'BASE TABLE')
		OR
		(t1.TABLE_TYPE = 'VIEW')
	)
	AND
	(
		(t1.TABLE_TYPE != 'VIEW')
		OR
		(
			(t1.TABLE_TYPE = 'VIEW')
			AND
			(t1.TABLE_NAME NOT LIKE 'v0_%')
		)
	)
	AND
	(t1.TABLE_NAME != 'dtproperties')
	AND
	(t1.TABLE_NAME NOT LIKE 'sql_%')
	AND
	(t1.TABLE_NAME NOT LIKE 'pg_%')
	AND
	(t1.TABLE_NAME NOT LIKE 'sys%')
	AND
	(t1.TABLE_NAME NOT LIKE '%__base')
	AND
	(t1.TABLE_SCHEMA NOT LIKE 'information_schema')