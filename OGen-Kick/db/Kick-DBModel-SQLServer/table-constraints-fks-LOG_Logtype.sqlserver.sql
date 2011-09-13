ALTER TABLE "LOG_Logtype" WITH CHECK 
	ADD CONSTRAINT "LOG_Logtype_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Logtype" CHECK CONSTRAINT "LOG_Logtype_IFApplication_fkey"
GO

ALTER TABLE "LOG_Logtype" WITH CHECK 
	ADD CONSTRAINT "LOG_Logtype_IFLogtype_parent_fkey" FOREIGN KEY (
		"IFLogtype_parent"
	) REFERENCES "LOG_Logtype" (
		"IDLogtype"
	)
GO
ALTER TABLE "LOG_Logtype" CHECK CONSTRAINT "LOG_Logtype_IFLogtype_parent_fkey"
GO

