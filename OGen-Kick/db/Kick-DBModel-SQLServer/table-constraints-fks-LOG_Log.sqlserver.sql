ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFUser_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFUser__read_fkey" FOREIGN KEY (
		"IFUser__read"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFUser__read_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFPermition_fkey" FOREIGN KEY (
		"IFPermition"
	) REFERENCES "CRD_Permition" (
		"IDPermition"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFPermition_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFApplication_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFLogtype_fkey" FOREIGN KEY (
		"IFLogtype"
	) REFERENCES "LOG_Logtype" (
		"IDLogtype"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFLogtype_fkey"
GO

ALTER TABLE "LOG_Log" WITH CHECK 
	ADD CONSTRAINT "LOG_Log_IFErrortype_fkey" FOREIGN KEY (
		"IFErrortype"
	) REFERENCES "LOG_Errortype" (
		"IDErrortype"
	)
GO
ALTER TABLE "LOG_Log" CHECK CONSTRAINT "LOG_Log_IFErrortype_fkey"
GO

