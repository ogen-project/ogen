ALTER TABLE "FRM_FormGroup" WITH CHECK 
	ADD CONSTRAINT "FRM_FormGroup_IFForm_fkey" FOREIGN KEY (
		"IFForm"
	) REFERENCES "FRM_Form" (
		"IDForm"
	)
GO
ALTER TABLE "FRM_FormGroup" CHECK CONSTRAINT "FRM_FormGroup_IFForm_fkey"
GO

ALTER TABLE "FRM_FormGroup" WITH CHECK 
	ADD CONSTRAINT "FRM_FormGroup_IFGroup_fkey" FOREIGN KEY (
		"IFGroup"
	) REFERENCES "FRM_Group" (
		"IDGroup"
	)
GO
ALTER TABLE "FRM_FormGroup" CHECK CONSTRAINT "FRM_FormGroup_IFGroup_fkey"
GO

ALTER TABLE "FRM_FormGroup" WITH CHECK 
	ADD CONSTRAINT "FRM_FormGroup_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_FormGroup" CHECK CONSTRAINT "FRM_FormGroup_IFUser__audit_fkey"
GO

