ALTER TABLE "FRM_GroupQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupQuestion_IFGroup_fkey" FOREIGN KEY (
		"IFGroup"
	) REFERENCES "FRM_Group" (
		"IDGroup"
	)
GO
ALTER TABLE "FRM_GroupQuestion" CHECK CONSTRAINT "FRM_GroupQuestion_IFGroup_fkey"
GO

ALTER TABLE "FRM_GroupQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupQuestion_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_GroupQuestion" CHECK CONSTRAINT "FRM_GroupQuestion_IFQuestion_fkey"
GO

ALTER TABLE "FRM_GroupQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_GroupQuestion_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_GroupQuestion" CHECK CONSTRAINT "FRM_GroupQuestion_IFUser__audit_fkey"
GO

