ALTER TABLE "NWS_ContentTag" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentTag_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentTag" CHECK CONSTRAINT "NWS_ContentTag_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentTag" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentTag_IFTag_fkey" FOREIGN KEY (
		"IFTag"
	) REFERENCES "NWS_Tag" (
		"IDTag"
	)
GO
ALTER TABLE "NWS_ContentTag" CHECK CONSTRAINT "NWS_ContentTag_IFTag_fkey"
GO

