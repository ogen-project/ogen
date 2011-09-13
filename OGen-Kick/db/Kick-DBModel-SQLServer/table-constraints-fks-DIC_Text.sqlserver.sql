ALTER TABLE "DIC_Text" WITH CHECK 
	ADD CONSTRAINT "DIC_Text_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "DIC_Text" CHECK CONSTRAINT "DIC_Text_IFApplication_fkey"
GO

