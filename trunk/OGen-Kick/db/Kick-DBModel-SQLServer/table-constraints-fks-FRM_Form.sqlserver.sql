ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_IFApplication_fkey"
GO

ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_TX_Description_fkey" FOREIGN KEY (
		"TX_Description"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_TX_Description_fkey"
GO

ALTER TABLE "FRM_Form" WITH CHECK 
	ADD CONSTRAINT "FRM_Form_TX_Name_fkey" FOREIGN KEY (
		"TX_Name"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Form" CHECK CONSTRAINT "FRM_Form_TX_Name_fkey"
GO

