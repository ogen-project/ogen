ALTER TABLE "LOG_Type" WITH CHECK 
	ADD CONSTRAINT "LOG_Type_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "LOG_Type" CHECK CONSTRAINT "LOG_Type_IFApplication_fkey"
GO

ALTER TABLE "LOG_Type" WITH CHECK 
	ADD CONSTRAINT "LOG_Type_IFType_parent_fkey" FOREIGN KEY (
		"IFType_parent"
	) REFERENCES "LOG_Type" (
		"IDType"
	)
GO
ALTER TABLE "LOG_Type" CHECK CONSTRAINT "LOG_Type_IFType_parent_fkey"
GO

