ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_IFApplication_fkey"
GO

ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_TX_Answer_fkey" FOREIGN KEY (
		"TX_Answer"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_TX_Answer_fkey"
GO

ALTER TABLE "FRM_Answer" WITH CHECK 
	ADD CONSTRAINT "FRM_Answer_TX_Details_fkey" FOREIGN KEY (
		"TX_Details"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Answer" CHECK CONSTRAINT "FRM_Answer_TX_Details_fkey"
GO

