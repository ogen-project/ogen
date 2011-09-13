ALTER TABLE "CRD_ProfilePermition" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermition_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_ProfilePermition" CHECK CONSTRAINT "CRD_ProfilePermition_IFProfile_fkey"
GO

ALTER TABLE "CRD_ProfilePermition" WITH CHECK 
	ADD CONSTRAINT "CRD_ProfilePermition_IFPermition_fkey" FOREIGN KEY (
		"IFPermition"
	) REFERENCES "CRD_Permition" (
		"IDPermition"
	)
GO
ALTER TABLE "CRD_ProfilePermition" CHECK CONSTRAINT "CRD_ProfilePermition_IFPermition_fkey"
GO

