ALTER TABLE "NWS_ContentHighlight" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentHighlight_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentHighlight" CHECK CONSTRAINT "NWS_ContentHighlight_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentHighlight" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentHighlight_IFHighlight_fkey" FOREIGN KEY (
		"IFHighlight"
	) REFERENCES "NWS_Highlight" (
		"IDHighlight"
	)
GO
ALTER TABLE "NWS_ContentHighlight" CHECK CONSTRAINT "NWS_ContentHighlight_IFHighlight_fkey"
GO

