ALTER TABLE "NET_Defaultprofile" WITH CHECK 
	ADD CONSTRAINT "NET_Defaultprofile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "NET_Defaultprofile" CHECK CONSTRAINT "NET_Defaultprofile_IFProfile_fkey"
GO

