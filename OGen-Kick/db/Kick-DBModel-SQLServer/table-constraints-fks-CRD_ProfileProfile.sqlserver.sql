ALTER TABLE "CRD_ProfileProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfileProfile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfileProfile" CHECK CONSTRAINT "CRD_ProfileProfile_IFProfile_fkey"
GO

ALTER TABLE "CRD_ProfileProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfileProfile_IFProfile_parent_fkey" FOREIGN KEY (
		"IFProfile_parent"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfileProfile" CHECK CONSTRAINT "CRD_ProfileProfile_IFProfile_parent_fkey"
GO

