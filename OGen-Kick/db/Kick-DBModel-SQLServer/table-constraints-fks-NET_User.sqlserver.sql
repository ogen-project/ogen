ALTER TABLE "NET_User" WITH CHECK 
	ADD CONSTRAINT "NET_User_IFUser_fkey" FOREIGN KEY (
		"IFUser"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "NET_User" CHECK CONSTRAINT "NET_User_IFUser_fkey"
GO

ALTER TABLE "NET_User" WITH CHECK 
	ADD CONSTRAINT "NET_User_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NET_User" CHECK CONSTRAINT "NET_User_IFApplication_fkey"
GO

