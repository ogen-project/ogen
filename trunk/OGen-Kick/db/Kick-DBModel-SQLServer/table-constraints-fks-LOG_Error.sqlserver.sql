ALTER TABLE "LOG_Error" WITH CHECK 
	ADD CONSTRAINT "LOG_Error_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Error" CHECK CONSTRAINT "LOG_Error_IFApplication_fkey"
GO

