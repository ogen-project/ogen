ALTER TABLE "NWS_Attachment" WITH CHECK 
	ADD CONSTRAINT "NWS_Attachment_IFContent_fkey" FOREIGN KEY (
		"IFContent"
	) REFERENCES "NWS_Content" (
		"IDContent"
	)
GO
ALTER TABLE "NWS_Attachment" CHECK CONSTRAINT "NWS_Attachment_IFContent_fkey"
GO

ALTER TABLE "NWS_Attachment" WITH CHECK 
	ADD CONSTRAINT "NWS_Attachment_TX_Description_fkey" FOREIGN KEY (
		"TX_Description"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Attachment" CHECK CONSTRAINT "NWS_Attachment_TX_Description_fkey"
GO

ALTER TABLE "NWS_Attachment" WITH CHECK 
	ADD CONSTRAINT "NWS_Attachment_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "NWS_Attachment" CHECK CONSTRAINT "NWS_Attachment_TX_Name_fkey"
GO

