ALTER TABLE "CRD_UserProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_UserProfile_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "CRD_UserProfile" CHECK CONSTRAINT "CRD_UserProfile_IFUser_fkey"
GO

ALTER TABLE "CRD_UserProfile" WITH CHECK 
	ADD CONSTRAINT "CRD_UserProfile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "CRD_UserProfile" CHECK CONSTRAINT "CRD_UserProfile_IFProfile_fkey"
GO

