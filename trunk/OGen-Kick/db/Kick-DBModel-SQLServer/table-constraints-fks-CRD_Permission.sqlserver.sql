ALTER TABLE "CRD_Permission" WITH CHECK 
	ADD CONSTRAINT "CRD_Permission_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_Permission" CHECK CONSTRAINT "CRD_Permission_IFApplication_fkey"
GO

ALTER TABLE "CRD_Permission" WITH CHECK 
	ADD CONSTRAINT "CRD_Permission_IFTable_fkey" FOREIGN KEY (
		"IFTable"
	) REFERENCES "CRD_Table" (
		"IDTable"
	)
GO
ALTER TABLE "CRD_Permission" CHECK CONSTRAINT "CRD_Permission_IFTable_fkey"
GO

ALTER TABLE "CRD_Permission" WITH CHECK 
	ADD CONSTRAINT "CRD_Permission_IFAction_fkey" FOREIGN KEY (
		"IFAction"
	) REFERENCES "CRD_Action" (
		"IDAction"
	)
GO
ALTER TABLE "CRD_Permission" CHECK CONSTRAINT "CRD_Permission_IFAction_fkey"
GO

