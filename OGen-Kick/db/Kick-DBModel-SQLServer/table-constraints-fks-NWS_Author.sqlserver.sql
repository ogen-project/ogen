ALTER TABLE "NWS_Author" WITH CHECK 
	ADD CONSTRAINT "NWS_Author_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Author" CHECK CONSTRAINT "NWS_Author_IFApplication_fkey"
GO

ALTER TABLE "NWS_Author" WITH CHECK 
	ADD CONSTRAINT "NWS_Author_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Author" CHECK CONSTRAINT "NWS_Author_IFUser__Approved_fkey"
GO

