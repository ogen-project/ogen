ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_IFApplication_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_IFUser__Publisher_fkey" FOREIGN KEY (
		"IFUser__Publisher"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_IFUser__Publisher_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Summary_fkey" FOREIGN KEY (
		"TX_Summary"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Summary_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Subtitle_fkey" FOREIGN KEY (
		"TX_Subtitle"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Subtitle_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Content_fkey" FOREIGN KEY (
		"TX_Content"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Content_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_TX_Title_fkey" FOREIGN KEY (
		"TX_Title"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_TX_Title_fkey"
GO

ALTER TABLE "NWS_Content" WITH CHECK 
	ADD CONSTRAINT "NWS_Content_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Content" CHECK CONSTRAINT "NWS_Content_IFUser__Approved_fkey"
GO

