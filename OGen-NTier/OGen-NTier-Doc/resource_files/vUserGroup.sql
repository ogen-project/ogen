CREATE OR REPLACE VIEW "vUserGroup" 
AS 
	SELECT
		t2."IDUser", 
		t2."Login", 
		t3."IDGroup", 
		t3."Name", 
		t1."Relationdate"
	FROM "UserGroup" t1
		INNER JOIN "User" t2 ON t2."IDUser" = t1."IDUser"
		INNER JOIN "Group" t3 ON t3."IDGroup" = t1."IDGroup"
;