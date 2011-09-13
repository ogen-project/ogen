ALTER TABLE "DIC_LanguageApplication" WITH CHECK 
	ADD CONSTRAINT "DIC_LanguageApplication_IFLanguage_fkey" FOREIGN KEY (
		"IFLanguage"
	) REFERENCES "DIC_Language" (
		"IDLanguage"
	)
GO
ALTER TABLE "DIC_LanguageApplication" CHECK CONSTRAINT "DIC_LanguageApplication_IFLanguage_fkey"
GO

ALTER TABLE "DIC_LanguageApplication" WITH CHECK 
	ADD CONSTRAINT "DIC_LanguageApplication_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "DIC_LanguageApplication" CHECK CONSTRAINT "DIC_LanguageApplication_IFApplication_fkey"
GO

