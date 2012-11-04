ALTER TABLE "NET_Profile__default" WITH CHECK 
	ADD CONSTRAINT "NET_Profile__default_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "CRD_Profile" (
		"IDProfile"
	)
GO
ALTER TABLE "NET_Profile__default" CHECK CONSTRAINT "NET_Profile__default_IFProfile_fkey"
GO

