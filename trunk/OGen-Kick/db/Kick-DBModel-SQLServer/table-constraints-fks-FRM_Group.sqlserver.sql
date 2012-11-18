ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_IFGroup__parent_fkey" FOREIGN KEY (
		"IFGroup__parent"
	) REFERENCES "FRM_Group" (
		"IDGroup"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_IFGroup__parent_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_IFApplication_fkey" FOREIGN KEY (
		"IFApplication"
	) REFERENCES "APP_Application" (
		"IDApplication"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_IFApplication_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_IFUser__audit_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_TX_Title_fkey" FOREIGN KEY (
		"TX_Title"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_TX_Title_fkey"
GO

ALTER TABLE "FRM_Group" WITH CHECK 
	ADD CONSTRAINT "FRM_Group_TX_Description_fkey" FOREIGN KEY (
		"TX_Description"
	) REFERENCES "DIC_Text" (
		"IDText"
	)
GO
ALTER TABLE "FRM_Group" CHECK CONSTRAINT "FRM_Group_TX_Description_fkey"
GO

