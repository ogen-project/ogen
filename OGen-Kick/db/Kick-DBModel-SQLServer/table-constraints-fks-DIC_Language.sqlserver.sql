ALTER TABLE "DIC_Language" WITH CHECK 
	ADD CONSTRAINT "DIC_Language_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "DIC_Language" CHECK CONSTRAINT "DIC_Language_TX_Name_fkey"
GO

