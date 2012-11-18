ALTER TABLE "FRM_UserAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_UserAnswer_IFAnswer_fkey" FOREIGN KEY (
		"IFAnswer"
	) REFERENCES "FRM_Answer" (
		"IDAnswer"
	)
GO
ALTER TABLE "FRM_UserAnswer" CHECK CONSTRAINT "FRM_UserAnswer_IFAnswer_fkey"
GO

ALTER TABLE "FRM_UserAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_UserAnswer_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserAnswer" CHECK CONSTRAINT "FRM_UserAnswer_IFUser_fkey"
GO

ALTER TABLE "FRM_UserAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_UserAnswer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserAnswer" CHECK CONSTRAINT "FRM_UserAnswer_IFUser__audit_fkey"
GO

