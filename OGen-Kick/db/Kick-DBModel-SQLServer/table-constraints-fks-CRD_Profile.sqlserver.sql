ALTER TABLE "CRD_Profile" WITH CHECK 
	ADD CONSTRAINT "CRD_Profile_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_Profile" CHECK CONSTRAINT "CRD_Profile_IFApplication_fkey"
GO

