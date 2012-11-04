ALTER TABLE "CRD_ProfilePermission" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermission_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfilePermission" CHECK CONSTRAINT "CRD_ProfilePermission_IFProfile_fkey"
GO

ALTER TABLE "CRD_ProfilePermission" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermission_IFPermission_fkey" FOREIGN KEY (
		"IFPermission"
	) REFERENCES "CRD_Permission" (
		"IDPermission"
	)
GO
ALTER TABLE "CRD_ProfilePermission" CHECK CONSTRAINT "CRD_ProfilePermission_IFPermission_fkey"
GO

