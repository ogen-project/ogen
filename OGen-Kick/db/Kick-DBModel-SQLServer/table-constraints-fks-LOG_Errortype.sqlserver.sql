ALTER TABLE "LOG_Errortype" WITH CHECK 
	ADD CONSTRAINT "LOG_Errortype_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Errortype" CHECK CONSTRAINT "LOG_Errortype_IFApplication_fkey"
GO

