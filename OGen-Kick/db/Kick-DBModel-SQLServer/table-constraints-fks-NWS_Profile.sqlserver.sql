ALTER TABLE "NWS_Profile" WITH CHECK 
	ADD CONSTRAINT "NWS_Profile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "NWS_Profile" CHECK CONSTRAINT "NWS_Profile_IFProfile_fkey"
GO

ALTER TABLE "NWS_Profile" WITH CHECK 
	ADD CONSTRAINT "NWS_Profile_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Profile" CHECK CONSTRAINT "NWS_Profile_IFUser__Approved_fkey"
GO

