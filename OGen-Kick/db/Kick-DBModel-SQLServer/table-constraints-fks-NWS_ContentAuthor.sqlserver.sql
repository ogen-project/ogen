ALTER TABLE "NWS_ContentAuthor" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentAuthor_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_ContentAuthor" CHECK CONSTRAINT "NWS_ContentAuthor_IFContent_fkey"
GO

ALTER TABLE "NWS_ContentAuthor" WITH CHECK 
	ADD CONSTRAINT "NWS_ContentAuthor_IFAuthor_fkey" FOREIGN KEY (
		"IFAuthor"
	) REFERENCES "NWS_Author" (
		"IDAuthor"
	)
GO
ALTER TABLE "NWS_ContentAuthor" CHECK CONSTRAINT "NWS_ContentAuthor_IFAuthor_fkey"
GO

