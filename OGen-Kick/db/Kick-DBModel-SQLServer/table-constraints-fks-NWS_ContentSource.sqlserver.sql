ALTER TABLE "NWS_ContentSource" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentSource_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentSource" CHECK CONSTRAINT "NWS_ContentSource_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentSource" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentSource_IFSource_fkey" FOREIGN KEY (
		"IFSource"
	) REFERENCES "NWS_Source" (
		"IDSource"
	)
GO
ALTER TABLE "NWS_ContentSource" CHECK CONSTRAINT "NWS_ContentSource_IFSource_fkey"
GO

