ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_IFApplication_fkey"
GO

ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_IFTag__parent_fkey" FOREIGN KEY (
		"IFTag__parent"
	) REFERENCES "NWS_Tag" (
		"IDTag"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_IFTag__parent_fkey"
GO

ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_TX_Name_fkey"
GO

ALTER TABLE "NWS_Tag" WITH CHECK 
	ADD CONSTRAINT "NWS_Tag_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Tag" CHECK CONSTRAINT "NWS_Tag_IFUser__Approved_fkey"
GO

