ALTER TABLE "DIC_TextLanguage" WITH CHECK 
	ADD CONSTRAINT "DIC_TextLanguage_IFLanguage_fkey" FOREIGN KEY (
		"IFLanguage"
	) REFERENCES "DIC_Language" (
		"IDLanguage"
	)
GO
ALTER TABLE "DIC_TextLanguage" CHECK CONSTRAINT "DIC_TextLanguage_IFLanguage_fkey"
GO

ALTER TABLE "DIC_TextLanguage" WITH CHECK 
	ADD CONSTRAINT "DIC_TextLanguage_IFText_fkey" FOREIGN KEY (
		"IFText"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "DIC_TextLanguage" CHECK CONSTRAINT "DIC_TextLanguage_IFText_fkey"
GO

