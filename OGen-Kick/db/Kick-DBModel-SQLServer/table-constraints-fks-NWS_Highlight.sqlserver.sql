ALTER TABLE "NWS_Highlight" WITH CHECK 
	ADD CONSTRAINT "NWS_Highlight_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "NWS_Highlight" CHECK CONSTRAINT "NWS_Highlight_IFApplication_fkey"
GO

ALTER TABLE "NWS_Highlight" WITH CHECK 
	ADD CONSTRAINT "NWS_Highlight_IFHighlight__parent_fkey" FOREIGN KEY (
		"IFHighlight__parent"
	) REFERENCES "NWS_Highlight" (
		"IDHighlight"
	)
GO
ALTER TABLE "NWS_Highlight" CHECK CONSTRAINT "NWS_Highlight_IFHighlight__parent_fkey"
GO

ALTER TABLE "NWS_Highlight" WITH CHECK 
	ADD CONSTRAINT "NWS_Highlight_IFUser__Approved_fkey" FOREIGN KEY (
		"IFUser__Approved"
	) REFERENCES "NET_User" (
		"IFUser"
	)
GO
ALTER TABLE "NWS_Highlight" CHECK CONSTRAINT "NWS_Highlight_IFUser__Approved_fkey"
GO

