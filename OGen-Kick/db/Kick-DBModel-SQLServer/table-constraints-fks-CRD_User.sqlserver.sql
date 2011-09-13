ALTER TABLE "CRD_User" WITH CHECK 
	ADD CONSTRAINT "CRD_User_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "CRD_User" CHECK CONSTRAINT "CRD_User_IFApplication_fkey"
GO

