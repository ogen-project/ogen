ALTER TABLE "CRD_Permition" WITH CHECK 
	ADD CONSTRAINT "CRD_Permition_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_Permition" CHECK CONSTRAINT "CRD_Permition_IFApplication_fkey"
GO

