ALTER TABLE "FRM_UserQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_UserQuestion_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_UserQuestion" CHECK CONSTRAINT "FRM_UserQuestion_IFQuestion_fkey"
GO

ALTER TABLE "FRM_UserQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_UserQuestion_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserQuestion" CHECK CONSTRAINT "FRM_UserQuestion_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_UserQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_UserQuestion_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_UserQuestion" CHECK CONSTRAINT "FRM_UserQuestion_IFUser_fkey"
GO

