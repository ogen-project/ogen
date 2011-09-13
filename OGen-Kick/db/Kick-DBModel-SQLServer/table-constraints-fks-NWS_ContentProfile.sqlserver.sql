ALTER TABLE "NWS_ContentProfile" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentProfile_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentProfile" CHECK CONSTRAINT "NWS_ContentProfile_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentProfile" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentProfile_IFProfile_fkey" FOREIGN KEY (
		"IFProfile"
	) REFERENCES "NWS_Profile" (
		"IFProfile"
	)
GO
ALTER TABLE "NWS_ContentProfile" CHECK CONSTRAINT "NWS_ContentProfile_IFProfile_fkey"
GO

